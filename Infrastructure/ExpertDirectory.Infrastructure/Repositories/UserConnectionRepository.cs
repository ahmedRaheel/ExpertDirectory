using ExpertDirectory.Application.Contracts;
using ExpertDirectory.Domain.Entities;
using ExpertDirectory.Infrastructure.Persistence;

namespace ExpertDirectory.Infrastructure.Repositories
{
    public class UserConnectionRepository : BaseRepository<UserConnection>, IUserConnectionRepository
    {
        /// <summary>
        ///   Constructor
        /// </summary>
        /// <param name="dbContext"></param>
        public UserConnectionRepository(ExpertDirectoryContext dbContext) : base(dbContext)
        {
        }
    }
}