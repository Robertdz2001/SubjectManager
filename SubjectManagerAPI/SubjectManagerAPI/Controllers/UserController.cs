using Microsoft.AspNetCore.Mvc;
using SubjectManagerAPI.Models;
using SubjectManagerAPI.Services;

namespace SubjectManagerAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }


        [HttpPost("register")]
        public async Task<ActionResult> RegisterUser([FromBody]RegisterUserDto dto)
        {
            await _service.RegisterUser(dto);
            return Ok();
        }

        
    }
}
