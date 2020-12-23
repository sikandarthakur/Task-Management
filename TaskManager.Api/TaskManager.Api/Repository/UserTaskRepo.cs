using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Api.Dto;
using TaskPattern.Models;
using TaskStatus = TaskPattern.Models.TaskStatus;

namespace TaskManager.Api.Repository
{
    public class UserTaskRepo : IUserTask
    {
        private readonly TaskDbContext _taskContext;
        public UserTaskRepo(TaskDbContext taskContext)
        {
            _taskContext = taskContext;
        }

        public async Task<IEnumerable<ReadTaskDto>> GetUserTasks()
        {
            return await _taskContext.UserTasks.Select(s=> new ReadTaskDto { 
                TaskId = s.TaskId,
                TaskName = s.TaskName,
                TaskDescription = s.TaskDescription,
                StartDate = s.StartDate,
                EndDate = s.EndDate,
                IsOpen = s.IsOpen,
                Status = s.Status
            }).ToListAsync();
        }

        public async Task<ReadTaskDto> GetUserTask(int taskId)
        {
            return await _taskContext.UserTasks.Select(s => new ReadTaskDto
            {
                TaskId = s.TaskId,
                TaskName = s.TaskName,
                TaskDescription = s.TaskDescription,
                StartDate = s.StartDate,
                EndDate = s.EndDate,
                IsOpen = s.IsOpen,
                Status = s.Status
            }).FirstOrDefaultAsync(x => x.TaskId == taskId);
        }

        public async Task<UserTask> CreateTask(CreateTaskDto createTaskDto)
        {
            User userResult;
            if (createTaskDto.UserId == 0)
            {
                userResult = null;
            }
            else
            {
                userResult = await _taskContext.Users.FirstOrDefaultAsync(x => x.UserId == createTaskDto.UserId);
            }
            UserTask userTask = new UserTask()
            {
                TaskName = createTaskDto.TaskName,
                TaskDescription = createTaskDto.TaskDescription,
                StartDate = createTaskDto.StartDate,
                EndDate = createTaskDto.EndDate,
                Status = TaskStatus.Active.ToString(),
                IsOpen = true,
                user = userResult
            };
            var taskResult = await _taskContext.UserTasks.AddAsync(userTask);
            await _taskContext.SaveChangesAsync();
            return taskResult.Entity;
        }

        public async Task<UserTask> DeleteTask(int taskId)
        {
            var taskResult = await _taskContext.UserTasks.FindAsync(taskId);

            _taskContext.UserTasks.Remove(taskResult);
            await _taskContext.SaveChangesAsync();
            return taskResult;
        }
        public async Task<UserTask> UpdateTask(int taskId, UserTask userTask)
        {
            var selectedTask = await _taskContext.UserTasks.FirstOrDefaultAsync(x => x.TaskId == taskId);
            if (selectedTask != null)
            {
                selectedTask.TaskName = userTask.TaskName;
                selectedTask.TaskDescription = userTask.TaskDescription;
                selectedTask.StartDate = userTask.StartDate;
                selectedTask.EndDate = userTask.EndDate;
                selectedTask.IsOpen = userTask.IsOpen;
                selectedTask.Status = userTask.Status;

            }
            _taskContext.SaveChanges();
            return selectedTask;
        }
    }
}
