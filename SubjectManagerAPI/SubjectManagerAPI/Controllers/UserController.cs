using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SubjectManagerAPI.Models;
using SubjectManagerAPI.Models.UserDtos;
using SubjectManagerAPI.Services;
using System.Web.Http.Cors;
namespace SubjectManagerAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }


        [HttpPost("register")]
        public async Task<ActionResult> RegisterUser([FromBody] RegisterUserDto dto)
        {
            await _service.RegisterUser(dto);
            return Ok();
        }
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginDto dto)
        {
            string token = await _service.GenerateJwt(dto);
            return Ok(token);

        }

    }
}
