using AutoMapper;
using ExpertDirectory.Application.Contracts;
using ExpertDirectory.Application.Exceptions;
using ExpertDirectory.Application.Models.MemberConnection;
using ExpertDirectory.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ExpertDirectory.Application.Features.Headings.Queries
{
    /// <summary>
    ///       HeadingSearchQueryHandler
    /// </summary>
    public class HeadingSearchQueryHandler : IRequestHandler<HeadingSearchQuery, List<MemberSearchDTO>>
    {
        #region Fields
        private readonly IUserHeadingRepository _userHeadingRepository;
        private readonly IMapper _mapper;
        #endregion

        public HeadingSearchQueryHandler(IUserHeadingRepository userRepository, IMapper mapper)
        {
            _userHeadingRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<List<MemberSearchDTO>> Handle(HeadingSearchQuery request, CancellationToken cancellationToken)
        {
            var headings = await _userHeadingRepository.GetMemberList(request);
            var searchResult = new List<MemberSearchDTO>();
            if (headings == null || headings.Count == 0) 
            {
                throw new NotFoundException(nameof(UserHeadings), request.SearchTerm);
            }          
            foreach (var item in headings) 
            {
                var searchItem = new MemberSearchDTO
                {
                    Id = item.UserId,
                    UserName = item.User.UserName
                };
                if (item.User.UserConnections.Count > 0)
                {                     
                    searchItem.Members.AddRange(GetFriends(item.User.UserConnections));
                }
                if (item.User.FriendConnections.Count > 0)
                {
                    searchItem.Members.AddRange(GetFriends(item.User.FriendConnections, false));
                }
                searchResult.Add(searchItem);
            }
            return searchResult;
        }

        private List<FriendDTO> GetFriends(ICollection<UserConnection> connections, bool directfriend = true) 
        {
            var friendList = new List<FriendDTO>();
            if (directfriend)
            {
                foreach (var friend in connections)
                {
                    var item = new FriendDTO
                    {
                        Id = friend.User.Id,
                        UserName = friend.User.UserName
                    };

                    if (friend.Connection.UserConnections.Any())
                    {
                        item.Friends.AddRange(GetFriends(friend.Connection.UserConnections));
                    }                    
                    friendList.Add(item);
                }
            }
            else 
            {
                foreach (var friend in connections)
                {
                    var item = new FriendDTO
                    {
                        Id = friend.Connection.Id,
                        UserName = friend.Connection.UserName
                    };
                    if (friend.Connection.FriendConnections.Any())
                    {
                        item.Friends.AddRange(GetFriends(friend.Connection.FriendConnections));
                    }
                    
                    friendList.Add(item);
                }
            }
            return friendList;
        }
    }
}
