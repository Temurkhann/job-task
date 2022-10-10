using JobTask.Domain.Entities;
using JobTask.Service.DTOs;
using JobTask.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        /// <summary>
        /// create new user
        /// </summary>
        /// <param name="dto">user create</param>
        /// <returns>Created user infortaions</returns>
        /// <response code="200">If user is created successfully</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async ValueTask<ActionResult<User>> CreateAsync(UserForCreationDto dto) =>
            Ok(await userService.CreateAsync(dto));

        /// <summary>
        /// delete user by id (for only admins)
        /// </summary>
        /// <param name="id"></param>
        /// <returns>true if user deleted succesfully else false</returns>
        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public async ValueTask<ActionResult<bool>> DeleteAsync([FromRoute] long id) =>
            Ok(await userService.DeleteAsync(user => user.Id == id));

        /// <summary>
        /// get all of users
        /// </summary>
        /// <param name="params">pagenation params</param>
        /// <returns> user collection </returns>
        [HttpGet, Authorize(Roles = "Admin")]
        public async ValueTask<ActionResult<IEnumerable<User>>> GetAllAsync() =>
            Ok(await userService.GetAllAsync());

        /// <summary>
        /// get one user information
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns>user</returns>
        /// <response code="400">if user data is not in the base</response>
        /// <response code="200">if user data have in database</response>
        //[HttpGet("{id}"), Authorize("AllPolicy")]
        [HttpGet("{id}")]
        public async ValueTask<ActionResult<User>> GetAsync([FromRoute] long id) =>
            Ok(await userService.GetAsync(user => user.Id == id));

        /// <summary>
        /// update user 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut, Authorize("AllPolicy")]
        public async ValueTask<ActionResult<User>> UpdateAsync(
            long id, [FromBody] UserForCreationDto dto) =>
                Ok(await userService.UpdateAsync(id, dto));
    }
}
