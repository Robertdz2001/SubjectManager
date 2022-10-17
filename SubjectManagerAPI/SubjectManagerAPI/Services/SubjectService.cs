using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SubjectManagerAPI.Entities;
using SubjectManagerAPI.Exceptions;
using SubjectManagerAPI.Models.SubjectDtos;

namespace SubjectManagerAPI.Services
{

    public interface ISubjectService
    {
        Task<IEnumerable<SubjectDto>> GetAll();
        Task<SubjectDto> GetById(int sid);
        Task<int> CreateSubject(CreateSubjectDto dto);
        Task UpdateSubject(CreateSubjectDto dto, int sid);
        Task DeleteSubject(int sid);
    }

    public class SubjectService : ISubjectService
    {
        private readonly SubjectManagerDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserContextService _userContextService;

        public SubjectService(SubjectManagerDbContext context, IMapper mapper, IUserContextService userContextService)
        {
            _context = context;
            _mapper = mapper;
            _userContextService = userContextService;
        }

        public async Task<IEnumerable<SubjectDto>> GetAll()
        {
            int? userId = _userContextService.GetUserId;
            var subjects = await _context.Subjects
                .Where(s => s.UserId == userId)
                .ToListAsync();

           
            var subjectDtos = _mapper.Map<List<SubjectDto>>(subjects);
            return subjectDtos;
        }

        public async Task<SubjectDto> GetById(int sid)
        {
            int? userId = _userContextService.GetUserId;
            var subject = await _context.Subjects
                .Where(s => s.UserId == userId)
                .Include(s=>s.Tests)
                .Include(s=>s.LearningMaterials)
                .FirstOrDefaultAsync(s => s.Id == sid);
            if(subject is null)
            {
                throw new NotFoundException("Not Found");
            }
            var subjectDto = _mapper.Map<SubjectDto>(subject);
            return subjectDto;
        }
        public async Task<int> CreateSubject(CreateSubjectDto dto)
        {
            int? userId = _userContextService.GetUserId;
            var newSubject = _mapper.Map<Subject>(dto);
            newSubject.UserId = (int)userId;
            await _context.Subjects.AddAsync(newSubject);
            await _context.SaveChangesAsync();

            return newSubject.Id;

        }
        public async Task UpdateSubject(CreateSubjectDto dto, int sid)
        {
            int? userId = _userContextService.GetUserId;
            var subjectToUpdate = await _context.Subjects
                .Where(s => s.UserId == userId)
                .FirstOrDefaultAsync(s => s.Id == sid);
            if(subjectToUpdate is null)
            {
                throw new NotFoundException("Not Found");
            }
            subjectToUpdate.Name = dto.Name;
            subjectToUpdate.ShortName = dto.ShortName;
            subjectToUpdate.RoomNumber = dto.RoomNumber;
            subjectToUpdate.DayOfWeek = dto.DayOfWeek;
            subjectToUpdate.Time = dto.Time;
            subjectToUpdate.PlatformUrl = dto.PlatformUrl;
            await _context.SaveChangesAsync();

        }

        public async Task DeleteSubject(int sid)
        {
            int? userId = _userContextService.GetUserId;
            var subjectToDelete = await _context.Subjects
                .Where(s => s.UserId == userId)
                .FirstOrDefaultAsync(s => s.Id == sid);

            if(subjectToDelete is null)
            {
                throw new NotFoundException("Not Found");
            }

            _context.Subjects.Remove(subjectToDelete);
            await _context.SaveChangesAsync();
        }
    }
}