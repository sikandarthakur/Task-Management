using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManager.Api.Dto;
using TaskManager.Api.Repository;
using TaskPattern.Models;

namespace TaskManager.Api.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class UserTaskController : ControllerBase
    {
        private readonly IUserTask _taskContext;

        public UserTaskController(IUserTask taskContext)
        {
            _taskContext = taskContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadTaskDto>>> GetUserTasks()
        {
            try
            {
                return Ok(await _taskContext.GetUserTasks());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving User Task details");
            }
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<User>>> CreateTask(CreateTaskDto createTaskDto)
        {
            try
            {
                await _taskContext.CreateTask(createTaskDto);

                return Ok(createTaskDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while adding user task data to the database");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ReadTaskDto>>> GetUserTask(int id)
        {
            var taskResult = await _taskContext.GetUserTask(id);
            if (taskResult != null)
            {
                return Ok(taskResult);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, $"Requested id - {id} is not found");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<IEnumerable<UserTask>>> UpdateTask(int id, UserTask userTask)
        {

            var taskResult = await _taskContext.UpdateTask(id, userTask);
            if (taskResult != null)
            {
                return Ok(taskResult);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Error while Updating employee in database");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserTask>> DeleteTask(int id)
        {
            try
            {
                await _taskContext.DeleteTask(id);
                return Ok("Requested Record has been deleted");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status404NotFound, $"Requested Id - {id} not found");
            }
        }
    }
}
