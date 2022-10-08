using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SubjectManagerAPI.Entities;
using SubjectManagerAPI.Exceptions;
using SubjectManagerAPI.Models.LearningMaterialDtos;
using SubjectManagerAPI.Models.TestDtos;

namespace SubjectManagerAPI.Services
{
    public interface ILearningMaterialService
    {
        Task<int> CreateLearningMaterial(int sid, CreateLearningMaterialDto dto);
        Task DeleteLearningMaterial(int sid, int lid);
        Task<IEnumerable<LearningMaterialDto>> GetAllSubjectMaterials(int sid);
        Task<LearningMaterialDto> GetById(int lid, int sid);
        Task UpdateLearningMaterial(int sid, CreateLearningMaterialDto dto, int lid);
    }

    public class LearningMaterialService : ILearningMaterialService
    {
        private readonly SubjectManagerDbContext _context;
        private readonly IUserContextService _userContextService;
        private readonly IMapper _mapper;
        public LearningMaterialService(IUserContextService userContextService, SubjectManagerDbContext context, IMapper mapper)
        {
            _userContextService = userContextService;
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<LearningMaterialDto>> GetAllSubjectMaterials(int sid)
        {
            int? userId = _userContextService.GetUserId;
            var learningMaterials = await _context.LearningMaterials
                .Where(l => l.Subject.UserId == userId)
                .Where(l => l.SubjectId == sid)
                .ToListAsync();
            if (learningMaterials.Count == 0)
            {
                throw new NotFoundException("Not Found");

            }
            var learningMaterialDtos = _mapper.Map<List<LearningMaterialDto>>(learningMaterials);
            return learningMaterialDtos;
        }
        public async Task<LearningMaterialDto> GetById(int lid, int sid)
        {
            int? userId = _userContextService.GetUserId;

            var learningMaterial = await _context.LearningMaterials
                .Where(l => l.Subject.UserId == userId)
                .Where(l => l.SubjectId == sid)
                .FirstOrDefaultAsync(l => l.Id == lid);

            if (learningMaterial == null)
            {
                throw new NotFoundException("Not Found");
            }

            var learningMaterialDto = _mapper.Map<LearningMaterialDto>(learningMaterial);
            return learningMaterialDto;

        }
        public async Task<int> CreateLearningMaterial(int sid, CreateLearningMaterialDto dto)
        {
            int? userId = _userContextService.GetUserId;
            var learningMaterial = _mapper.Map<LearningMaterial>(dto);

            learningMaterial.SubjectId = sid;
            var subject = await _context.Subjects.FirstOrDefaultAsync(s => s.Id == sid);
            if (subject == null)
            {
                throw new NotFoundException("Not Found");
            }

            if (subject.UserId != userId)
            {
                throw new BadRequestException("Bad Request");
            }
            await _context.LearningMaterials.AddAsync(learningMaterial);
            await _context.SaveChangesAsync();
            return learningMaterial.Id;
        }

        public async Task UpdateLearningMaterial(int sid, CreateLearningMaterialDto dto, int lid)
        {
            int? userId = _userContextService.GetUserId;

            var updateLearningMaterial = await _context.LearningMaterials
                .Where(l => l.Subject.UserId == userId)
                .Where(l => l.SubjectId == sid)
                .FirstOrDefaultAsync(l => l.Id == lid);

            if (updateLearningMaterial == null)
            {
                throw new NotFoundException("Not Found");
            }

            updateLearningMaterial.Name = dto.Name;
            updateLearningMaterial.Source = dto.Source;

            await _context.SaveChangesAsync();

        }
        public async Task DeleteLearningMaterial(int sid, int lid)
        {
            int? userId = _userContextService.GetUserId;

            var removeLearningMaterial = await _context.LearningMaterials
                .Where(l => l.Subject.UserId == userId)
                .Where(l => l.SubjectId == sid)
                .FirstOrDefaultAsync(l => l.Id == lid);

            if (removeLearningMaterial == null)
            {
                throw new NotFoundException("Not Found");
            }
            _context.LearningMaterials.Remove(removeLearningMaterial);
            await _context.SaveChangesAsync();
        }
    }
}
