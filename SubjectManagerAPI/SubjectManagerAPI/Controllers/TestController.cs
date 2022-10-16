using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SubjectManagerAPI.Entities;
using SubjectManagerAPI.Models.TestDtos;
using SubjectManagerAPI.Services;
using System.Web.Http.Cors;
namespace SubjectManagerAPI.Controllers
{
    [Route("api/subjects/{sid}/tests")]
    [ApiController]
    [Authorize]
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class TestController : ControllerBase
    {
        private readonly ITestService _service;

        public TestController(ITestService service)
        {
            _service = service;
        }

        [HttpGet("/api/tests")]
        public async Task<ActionResult<IEnumerable<TestDto>>> GetAllUserTests()
        {
            var tests = await _service.GetAllUserTests();
            return Ok(tests);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestDto>>> GetAllSubjectTests([FromRoute] int sid)
        {
            var tests = await _service.GetAllSubjectTests(sid);

            return Ok(tests);

        }
        [HttpGet("{tid}")]
        public async Task<ActionResult<TestDto>> GetById([FromRoute] int tid, [FromRoute] int sid)
        {
            var test = await _service.GetById(tid, sid);
            return Ok(test);
        }

        [HttpPost]
        public async Task<ActionResult> CreateTest([FromRoute] int sid, [FromBody] CreateTestDto dto)
        {
            int id = await _service.CreateTest(sid, dto);
            return Created($"/api/subjects/{sid}/tests/{id}",null);
        }
        [HttpPut("{tid}")]
        public async Task<ActionResult> UpdateTest([FromRoute] int sid,[FromBody] CreateTestDto dto, [FromRoute] int tid)
        {
            await _service.UpdateTest(sid, dto, tid);
            return Ok(dto);
        }

        [HttpDelete("{tid}")]
        public async Task<ActionResult> DeleteTest([FromRoute] int sid, [FromRoute] int tid)
        {
            await _service.DeleteTest(sid, tid);
            return NoContent();
        }
    }
}
