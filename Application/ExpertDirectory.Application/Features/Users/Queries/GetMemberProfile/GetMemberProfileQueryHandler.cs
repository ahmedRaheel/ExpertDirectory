using AutoMapper;
using ExpertDirectory.Application.Contracts;
using ExpertDirectory.Application.Exceptions;
using ExpertDirectory.Application.Models.User;
using ExpertDirectory.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ExpertDirectory.Application.Features.Users.Queries.GetMemberProfile
{
    public class GetMemberProfileQueryHandler : IRequestHandler<GetMemberProfileQuery, MemberProfileDTO>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetMemberProfileQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }
        public async Task<MemberProfileDTO> Handle(GetMemberProfileQuery request, CancellationToken cancellationToken)
        {
            var memberProfile = await _userRepository.GetUserById(request.UserId);
            if (memberProfile == null)
            {
                throw new NotFoundException(nameof(User), request.UserId);
            }
            var memberDto = _mapper.Map<MemberProfileDTO>(memberProfile);
            if (memberProfile.UserConnections.Count == 0 && memberProfile.FriendConnections.Count == 0) 
            {
                return memberDto;
            }
            if (memberProfile.UserHeadings.Count > 0) 
            {
                memberDto.Headings = _mapper.Map<List<WebHeadingsDTO>>(memberProfile.UserHeadings);
            }
            var userConnections = _mapper.Map<List<MemberFriendDTO>>(memberProfile.UserConnections);
            //var userFriends = _mapper.Map<List<MemberFriend>>(memberProfile.FriendConnections);
            memberDto.Friends.AddRange(userConnections);
            foreach (var item in memberProfile.FriendConnections) 
            {
                memberDto.Friends.Add(new MemberFriendDTO 
                {
                    Id = item.User.Id,
                    UserName = item.User.UserName,
                    PersonWebUrl = item.User.PersonWebUrl
                });
            }
          //  memberDto.Friends.AddRange(userFriends);
            return memberDto;
        }
    }
}
