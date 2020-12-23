using System.Collections.Generic;
using System.Threading.Tasks;
using TaskPattern.Models;

namespace TaskManager.Api.Repository
{
    public interface IUser
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int UserId);
        Task<User> CreateUser(User user);
        Task<User> UpdateUser(int UserId, User user);
        Task<User> DeleteUser(int UserId);
    }
}
