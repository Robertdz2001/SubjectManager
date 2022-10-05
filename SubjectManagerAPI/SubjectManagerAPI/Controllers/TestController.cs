using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SubjectManagerAPI.Entities;
using SubjectManagerAPI.Models.TestDtos;
using SubjectManagerAPI.Services;

namespace SubjectManagerAPI.Controllers
{
    [Route("api/subjects/{sid}/tests")]
    [ApiController]
    [Authorize]
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
    }
}
