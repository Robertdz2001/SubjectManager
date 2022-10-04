using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SubjectManagerAPI.Entities;
using SubjectManagerAPI.Models.SubjectDtos;
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
        
        public async Task<ActionResult<IEnumerable<SubjectDto>>> GetAll()
        {

            var claims = HttpContext.User.Claims.ToList();
            var claim = claims[0];
            int userId = int.Parse(claim.Value);
            var subjects = await _service.GetAll(userId);
            return Ok(subjects);
        }

        [HttpGet("{sid}")]

        public async Task<ActionResult<SubjectDto>> GetById([FromRoute] int sid)
        {
            var claims = HttpContext.User.Claims.ToList();
            var claim = claims[0];
            int userId = int.Parse(claim.Value);

            var subject = await _service.GetById(sid, userId);
            return Ok(subject);

        }

        [HttpPost]

        public async Task<ActionResult> CreateSubject([FromBody] CreateSubjectDto dto)
        {
            var claims = HttpContext.User.Claims.ToList();
            var claim = claims[0];
            int userId = int.Parse(claim.Value);

            int id = await _service.CreateSubject(dto, userId);

            return Created($"/api/subjects/{id}", null);
        }

        [HttpPut("{sid}")]

        public async Task<ActionResult> UpdateSubject([FromBody] CreateSubjectDto dto, [FromRoute] int sid)
        {
            var claims = HttpContext.User.Claims.ToList();
            var claim = claims[0];
            int userId = int.Parse(claim.Value);

            await _service.UpdateSubject(dto, sid, userId);

            return Ok();

        }

        [HttpDelete("{sid}")]

        public async Task<ActionResult> DeleteSubject([FromRoute] int sid)
        {
            var claims = HttpContext.User.Claims.ToList();
            var claim = claims[0];
            int userId = int.Parse(claim.Value);

            await _service.DeleteSubject(sid, userId);

            return NoContent();
        }


    }
}
