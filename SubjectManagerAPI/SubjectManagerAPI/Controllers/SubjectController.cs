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

            var subjects = await _service.GetAll();
            return Ok(subjects);
        }

        [HttpGet("{sid}")]

        public async Task<ActionResult<SubjectDto>> GetById([FromRoute] int sid)
        {

            var subject = await _service.GetById(sid);
            return Ok(subject);

        }

        [HttpPost]

        public async Task<ActionResult> CreateSubject([FromBody] CreateSubjectDto dto)
        {

            int id = await _service.CreateSubject(dto);

            return Created($"/api/subjects/{id}", null);
        }

        [HttpPut("{sid}")]

        public async Task<ActionResult> UpdateSubject([FromBody] CreateSubjectDto dto, [FromRoute] int sid)
        {

            await _service.UpdateSubject(dto, sid);

            return Ok();

        }

        [HttpDelete("{sid}")]

        public async Task<ActionResult> DeleteSubject([FromRoute] int sid)
        {

            await _service.DeleteSubject(sid);

            return NoContent();
        }


    }
}
