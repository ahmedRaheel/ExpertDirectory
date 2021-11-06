using ExpertDirectory.Application.Features.Headings.Queries;
using ExpertDirectory.Application.Models.MemberConnection;
using ExpertDirectory.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpertDirectory.Application.Contracts
{
    public interface IUserHeadingRepository : IRepository<UserHeadings> 
    {
        Task<List<UserHeadings>> GetMemberList(HeadingSearchQuery query);
    }
}
