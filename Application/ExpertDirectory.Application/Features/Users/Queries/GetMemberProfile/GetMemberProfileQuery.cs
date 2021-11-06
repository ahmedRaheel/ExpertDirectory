using ExpertDirectory.Application.Models.User;
using MediatR;
using System.Collections.Generic;

namespace ExpertDirectory.Application.Features.Users.Queries.GetMemberProfile
{
    /// <summary>
    ///      GetMemberProfileQuery
    /// </summary>
    public class GetMemberProfileQuery : IRequest<MemberProfileDTO>
    {
        public long UserId { get; set; }

        public GetMemberProfileQuery() 
        {
        }
    }
}
