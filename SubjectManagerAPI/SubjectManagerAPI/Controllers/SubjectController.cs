using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SubjectManagerAPI.Entities;
using SubjectManagerAPI.Services;

namespace SubjectManagerAPI.Controllers
{
    [Route("api/subjects")]
    [ApiController]
    [Authorize]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _service;

        public SubjectController(ISubjectService service)
        {
            _service = service;
        }

        [HttpGet]
        
        public async Task<ActionResult<IEnumerable<Subject>>> GetAll()
        {

            var claims = HttpContext.User.Claims.ToList();
            var claim = claims[0];
            int userId = int.Parse(claim.Value);
            var subjects = await _service.GetAll(userId);
            return Ok(subjects);
        }

        [HttpGet("{sid}")]

        public async Task<ActionResult<Subject>> GetById([FromRoute] int sid)
        {
            var claims = HttpContext.User.Claims.ToList();
            var claim = claims[0];
            int userId = int.Parse(claim.Value);

            var subject = await _service.GetById(sid, userId);
            return Ok(subject);

        }
    }
}
