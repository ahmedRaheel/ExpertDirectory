using AutoMapper;
using ExpertDirectory.Application.Contracts;
using DTO = ExpertDirectory.Application.Models.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExpertDirectory.Application.Features.Users.Queries.GetMembers
{
    public class GetAllMembersQueryHandler : IRequestHandler<GetAllMembersQuery, List<DTO.MemberListDTO>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetAllMembersQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<List<DTO.MemberListDTO>> Handle(GetAllMembersQuery request, CancellationToken cancellationToken)
        {
            var memberList = await _userRepository.GetUsersAsync();
            
            if (memberList == null || memberList.Count == 0) 
            {
                return new List<DTO.MemberListDTO>();
            }

            return _mapper.Map<List<DTO.MemberListDTO>>(memberList);
        }
    }
}
