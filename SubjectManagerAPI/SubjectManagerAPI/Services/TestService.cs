using System.Security.Cryptography;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SubjectManagerAPI.Entities;
using SubjectManagerAPI.Exceptions;
using SubjectManagerAPI.Models.TestDtos;
using static System.Net.Mime.MediaTypeNames;

namespace SubjectManagerAPI.Services
{
    public interface ITestService
    {
        Task<int> CreateTest(int sid, CreateTestDto dto);
        Task DeleteTest(int sid, int tid);
        Task<IEnumerable<TestDto>> GetAllSubjectTests(int sid);
        Task<IEnumerable<TestWithSubjectDto>> GetAllUserTests();
        Task<TestDto> GetById(int tid, int sid);
        Task UpdateTest(int sid, CreateTestDto dto, int tid);
    }

    public class TestService : ITestService
    {
        private readonly SubjectManagerDbContext _context;
        private readonly IUserContextService _userContextService;
        private readonly IMapper _mapper;
        public TestService(IUserContextService userContextService, SubjectManagerDbContext context, IMapper mapper)
        {
            _userContextService = userContextService;
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TestWithSubjectDto>> GetAllUserTests()
        {
            int? userId = _userContextService.GetUserId;
            var tests = await _context.Tests
                .Where(t => t.Subject.UserId == userId)
                .Include(t => t.Subject)
                .ToListAsync();
           
            var testDtos = _mapper.Map<List<TestWithSubjectDto>>(tests);
            return testDtos;

        }
        public async Task<IEnumerable<TestDto>> GetAllSubjectTests(int sid)
        {
            int? userId = _userContextService.GetUserId;
            var tests = await _context.Tests
                .Where(t => t.Subject.UserId == userId && t.SubjectId == sid)
                .ToListAsync();
            
            var testDtos = _mapper.Map<List<TestDto>>(tests);
            return testDtos;
        }
        public async Task<TestDto> GetById(int tid, int sid)
        {
            int? userId = _userContextService.GetUserId;

            var test = await _context.Tests
                .Where(t => t.Subject.UserId == userId && t.SubjectId == sid)
                .FirstOrDefaultAsync(t => t.Id == tid);

            if (test is null)
            {
                throw new NotFoundException("Not Found");
            }

            var testDto = _mapper.Map<TestDto>(test);
            return testDto;

        }
        public async Task<int> CreateTest(int sid, CreateTestDto dto)
        {
            int? userId = _userContextService.GetUserId;
            var newTest = _mapper.Map<Test>(dto);

            newTest.SubjectId = sid;
            var subject = await _context.Subjects.FirstOrDefaultAsync(s => s.Id == sid);
            if(subject is null)
            {
                throw new NotFoundException("Not Found");
            }

            if(subject.UserId!=userId)
            {
                throw new BadRequestException("Bad Request");
            }
            await _context.Tests.AddAsync(newTest);
            await _context.SaveChangesAsync();
            return newTest.Id;
        }

        public async Task UpdateTest(int sid, CreateTestDto dto, int tid)
        {
            int? userId = _userContextService.GetUserId;

            var updateTest = await _context.Tests
                .Where(t => t.Subject.UserId == userId && t.SubjectId == sid)
                .FirstOrDefaultAsync(t => t.Id == tid);

            if(updateTest is null)
            {
                throw new NotFoundException("Not Found");
            }

            updateTest.Name = dto.Name;
            updateTest.Description = dto.Description;
            updateTest.Date = dto.Date;

            await _context.SaveChangesAsync();

        }
        public async Task DeleteTest(int sid, int tid)
        {
            int? userId = _userContextService.GetUserId;

            var removeTest = await _context.Tests
                .Where(t => t.Subject.UserId == userId && t.SubjectId == sid)
                .FirstOrDefaultAsync(t => t.Id == tid);

            if(removeTest is null)
            {
                throw new NotFoundException("Not Found");
            }
            _context.Tests.Remove(removeTest);
            await _context.SaveChangesAsync();
        }
    }
}
