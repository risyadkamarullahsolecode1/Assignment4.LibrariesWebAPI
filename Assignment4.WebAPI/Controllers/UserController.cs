using Asp.Versioning;
using Assignment4.Domain.Entities;
using Assignment4.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Assignment4.WebAPI.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[Controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        /// <summary>
        /// You get, get by id or delete here
        /// </summary>

        /// <remarks>
        /// All the parameters in the request body can be null. 
        ///
        ///  You can search by using any of the parameters in the request.
        ///  
        ///  NOTE: You can only search by one parameter at a time
        ///  
        /// Sample request:
        ///
        ///     GET /api/v1/User
        ///     
        ///     OR
        ///     
        ///     GET /api/v1/User/{id}
        ///    
        ///     OR
        ///     
        ///     DELETE /api/v1/User/{id}
        ///     
        /// </remarks>
        /// <param name="request"></param>
        /// <returns> This endpoint returns a list of Accounts.</returns>
        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<IEnumerable<Book>>> GetAllUser()
        {
            return Ok(await _userRepository.GetAllUser());
        }

        /// <summary>
        /// You get, get by id or delete here
        /// </summary>

        /// <remarks>
        /// All the parameters in the request body can be null. 
        ///
        ///  You can search by using any of the parameters in the request.
        ///  
        ///  NOTE: You can only search by one parameter at a time
        ///  
        /// Sample request:
        ///
        ///     GET /api/v1/User
        ///     
        ///     OR
        ///     
        ///     GET /api/v1/User/{id}
        ///    
        ///     OR
        ///     
        ///     DELETE /api/v1/User/{id}
        ///     
        /// </remarks>
        /// <param name="request"></param>
        /// <returns> This endpoint returns a list of Accounts.</returns>
        [HttpGet("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        /// <summary>
        /// You can add or update user here
        /// </summary>

        /// <remarks>
        /// All the parameters in the request body can be null. 
        ///
        ///  You can search by using any of the parameters in the request.
        ///  
        ///  NOTE: You can only search by one parameter at a time
        ///  
        /// Sample request:
        ///
        ///     POST /api/v1/User
        ///     {
        ///        "id": null,
        ///        "name": "string",
        ///        "email": "string@example.com",
        ///        "noHp": 0
        ///     }
        ///     OR
        ///     
        ///     PUT /api/v1/User/{id}
        ///     {
        ///        "id": null,
        ///        "name": "string",
        ///        "email": "string@example.com",
        ///        "noHp": 0
        ///     } 
        /// </remarks>
        /// <param name="request"></param>
        /// <returns> This endpoint returns a list of Accounts.</returns>
        [HttpPost]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<User>> AddUser(User user)
        {
            var createdUser = await _userRepository.AddUser(user);
            return CreatedAtAction(nameof(AddUser), createdUser);
        }
        /// <summary>
        /// You can add or update user here
        /// </summary>

        /// <remarks>
        /// All the parameters in the request body can be null. 
        ///
        ///  You can search by using any of the parameters in the request.
        ///  
        ///  NOTE: You can only search by one parameter at a time
        ///  
        /// Sample request:
        ///
        ///     POST /api/v1/User
        ///     {
        ///        "id": null,
        ///        "name": "string",
        ///        "email": "string@example.com",
        ///        "noHp": 0
        ///     }
        ///     OR
        ///     
        ///     PUT /api/v1/User/{id}
        ///     {
        ///        "id": null,
        ///        "name": "string",
        ///        "email": "string@example.com",
        ///        "noHp": 0
        ///     } 
        /// </remarks>
        /// <param name="request"></param>
        /// <returns> This endpoint returns a list of Accounts.</returns>
        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<User>> UpdateUser(int id, User user)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var updatedUser = await _userRepository.UpdateUser(user);
            if (updatedUser == null)
            {
                return BadRequest();
            }
            return Ok(updatedUser);
        }

        /// <summary>
        /// You get, get by id or delete here
        /// </summary>

        /// <remarks>
        /// All the parameters in the request body can be null. 
        ///
        ///  You can search by using any of the parameters in the request.
        ///  
        ///  NOTE: You can only search by one parameter at a time
        ///  
        /// Sample request:
        ///
        ///     GET /api/v1/User
        ///     
        ///     OR
        ///     
        ///     GET /api/v1/User/{id}
        ///    
        ///     OR
        ///     
        ///     DELETE /api/v1/User/{id}
        ///     
        /// </remarks>
        /// <param name="request"></param>
        /// <returns> This endpoint returns a list of Accounts.</returns>
        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<bool>> DeleteUser(int id)
        {
            var deleted = await _userRepository.DeleteUser(id);
            if (!deleted)
            {
                return NotFound();
            }
            return Ok("User telah dihapus");
        }
    }
}
