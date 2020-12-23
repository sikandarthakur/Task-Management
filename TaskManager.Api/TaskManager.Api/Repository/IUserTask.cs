using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManager.Api.Dto;
using TaskPattern.Models;

namespace TaskManager.Api.Repository
{
    public interface IUserTask
    {
        Task<IEnumerable<ReadTaskDto>> GetUserTasks();
        Task<ReadTaskDto> GetUserTask(int TaskId);
        Task<UserTask> CreateTask(CreateTaskDto createTaskDto);
        Task<UserTask> UpdateTask(int TaskId, UserTask userTask);
        Task<UserTask> DeleteTask(int TaskId);
    }
}
