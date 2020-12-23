using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManager.Api.Repository;
using TaskPattern.Models;

namespace TaskManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _userContext;

        public UserController(IUser userContext)
        {
            _userContext = userContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            try
            {
                return Ok(await _userContext.GetUsers());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving Users details");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<User>>> GetUser(int id)
        {
            var userResult = await _userContext.GetUser(id);
            if (userResult != null)
            {
                return Ok(userResult);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, $"Requested id - {id} is not found");
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<User>>> CreateUser(User user)
        {
            try
            {
                await _userContext.CreateUser(user);

                return CreatedAtAction("GetUser", new { id = user.UserId }, user);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while adding employee data to the database");
            }
        }
    }
}
