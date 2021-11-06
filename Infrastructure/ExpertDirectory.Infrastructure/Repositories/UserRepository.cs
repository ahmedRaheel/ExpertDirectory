using ExpertDirectory.Application.Contracts;
using ExpertDirectory.Domain.Entities;
using ExpertDirectory.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpertDirectory.Infrastructure.Repositories
{
    /// <summary>
    ///     UserRepository
    /// </summary>
    public class UserRepository : BaseRepository<User>, IUserRepository
    {   
        /// <summary>
        ///   Constructor
        /// </summary>
        /// <param name="dbContext"></param>
        public UserRepository(ExpertDirectoryContext dbContext) : base(dbContext)
        {            
        }

        public async Task<User> GetUserById(long userId)
        {
            return await _dbContext.User.Include("UserConnections.Connection")
                                        .Include("FriendConnections.User")
                                        .Include("UserHeadings")
                                        .FirstOrDefaultAsync(x=>x.Id == userId);
        }

        /// <summary>
        ///      GetUsersAsync
        /// </summary>
        /// <returns></returns>

        public async Task<List<User>> GetUsersAsync()
        {
            return await _dbContext.User.Include(x=>x.UserConnections)
                                        .Include(x => x.FriendConnections)
                                        .ToListAsync();
        }        
    }
}