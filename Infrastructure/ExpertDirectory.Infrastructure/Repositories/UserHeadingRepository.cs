using ExpertDirectory.Application.Contracts;
using ExpertDirectory.Application.Features.Headings.Queries;
using ExpertDirectory.Application.Models.MemberConnection;
using ExpertDirectory.Domain.Entities;
using ExpertDirectory.Infrastructure.Extentions;
using ExpertDirectory.Infrastructure.Persistence;
using ExpertDirectory.Infrastructure.Specifications.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ExpertDirectory.Infrastructure.Repositories
{
   
    /// <summary>
    ///    UserHeadingRepository
    /// </summary>
    public class UserHeadingRepository : BaseRepository<UserHeadings>, IUserHeadingRepository
    {
        #region Constructor
        public UserHeadingRepository(ExpertDirectoryContext directoryContext)
           : base(directoryContext)
        {
        }
        #endregion

        #region Methods
        public async Task<List<UserHeadings>> GetMemberList(HeadingSearchQuery query)
        {
            Expression<Func<UserHeadings, bool>> expression = (x => x.UserId != query.UserId
                                                       && !x.User.FriendConnections
                                                       .Any(u => u.ConnectionId == query.UserId));
            
            var searchTerms = query.SearchTerm.Split(' ').ToList();
            var searchWord = string.Empty;
            Expression<Func<UserHeadings, bool>> searchText = (expression => expression.HeadingTitle.Contains(query.SearchTerm));
            foreach (var item in searchTerms) 
            {
                if (string.IsNullOrWhiteSpace(item) || searchWord == item) continue;
                searchText =  searchText.Or(x => x.HeadingTitle.Contains(item));
            }
            expression = expression.AndAlso(searchText);
           
            return await _dbContext.UserHeadings
                          .Where(expression)
                          .ToListAsync();   
        } 

        #endregion
    }
}