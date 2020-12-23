using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskPattern.Models;

namespace TaskManager.Api.Repository
{
    public class UserRepo : IUser
    {
        private readonly TaskDbContext _taskContext;
        public UserRepo(TaskDbContext taskContext)
        {
            _taskContext = taskContext;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _taskContext.Users.ToListAsync();
        }

        public async Task<User> GetUser(int userId)
        {
            return await _taskContext.Users.FindAsync(userId);
        }

        public async Task<User> CreateUser(User user)
        {
            var userResult = await _taskContext.Users.AddAsync(user);
            await _taskContext.SaveChangesAsync();
            return userResult.Entity;
        }

        public async Task<User> DeleteUser(int userId)
        {
            var userResult = await _taskContext.Users.FindAsync(userId);

            _taskContext.Users.Remove(userResult);
            await _taskContext.SaveChangesAsync();

            return userResult;
        }

        public async Task<User> UpdateUser(int userId, User user)
        {
            var selectedUser = await _taskContext.Users.FindAsync(userId);
            if (selectedUser != null)
            {
                selectedUser.Firstname = user.Firstname; 
                selectedUser.Lastname = user.Lastname;
                await _taskContext.SaveChangesAsync();
            }
            return selectedUser;
        }
    }
}
