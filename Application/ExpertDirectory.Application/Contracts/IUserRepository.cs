using ExpertDirectory.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpertDirectory.Application.Contracts
{
    public interface IUserRepository : IRepository<User> 
    {
        Task<List<User>> GetUsersAsync();
        Task<User> GetUserById(long userId);
    }
}
