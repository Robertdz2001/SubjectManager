using System.Web.Http.Cors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SubjectManagerAPI.Models.LearningMaterialDtos;
using SubjectManagerAPI.Models.TestDtos;
using SubjectManagerAPI.Services;

namespace SubjectManagerAPI.Controllers
{
    [Route("api/subjects/{sid}/learningMaterials")]
    [ApiController]
    [Authorize]
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class LearningMaterialController : ControllerBase
    {
        private readonly ILearningMaterialService _service;

        public LearningMaterialController(ILearningMaterialService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LearningMaterialDto>>> GetAllSubjectMaterials([FromRoute] int sid)
        {
            var learningMaterials = await _service.GetAllSubjectMaterials(sid);

            return Ok(learningMaterials);

        }
        [HttpGet("{lid}")]
        public async Task<ActionResult<LearningMaterialDto>> GetById([FromRoute] int lid, [FromRoute] int sid)
        {
            var learningMaterial = await _service.GetById(lid, sid);
            return Ok(learningMaterial);
        }

        [HttpPost]
        public async Task<ActionResult> CreateLearningMaterial([FromRoute] int sid, [FromBody] CreateLearningMaterialDto dto)
        {
            int id = await _service.CreateLearningMaterial(sid, dto);
            return Created($"/api/subjects/{sid}/learningMaterials/{id}", null);
        }
        [HttpPut("{lid}")]
        public async Task<ActionResult> UpdateLearningMaterial([FromRoute] int sid, [FromBody] CreateLearningMaterialDto dto, [FromRoute] int lid)
        {
            await _service.UpdateLearningMaterial(sid, dto, lid);
            return Ok(dto);
        }

        [HttpDelete("{lid}")]
        public async Task<ActionResult> DeleteLearningMaterial([FromRoute] int sid, [FromRoute] int lid)
        {
            await _service.DeleteLearningMaterial(sid, lid);
            return NoContent();
        }
    }
}
