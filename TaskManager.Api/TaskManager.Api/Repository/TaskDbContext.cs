using Microsoft.EntityFrameworkCore;
using TaskPattern.Models;

namespace TaskManager.Api.Repository
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options) { }

        public DbSet<UserTask> UserTasks { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User { UserId = 1, Firstname = "Sikandar", Lastname = "Thakur" });
            modelBuilder.Entity<User>().HasData(new User { UserId = 2, Firstname = "Yash", Lastname = "Sonawane" });
            modelBuilder.Entity<User>().HasData(new User { UserId = 3, Firstname = "Kalpesh", Lastname = "Patil" });
            modelBuilder.Entity<User>().HasData(new User { UserId = 4, Firstname = "Pranali", Lastname = "Yeole" });
        }
    }
}
