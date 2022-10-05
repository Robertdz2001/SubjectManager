using System.Security.Cryptography;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SubjectManagerAPI.Entities;
using SubjectManagerAPI.Exceptions;
using SubjectManagerAPI.Models.TestDtos;
using static System.Net.Mime.MediaTypeNames;

namespace SubjectManagerAPI.Services
{
    public interface ITestService
    {
        Task<IEnumerable<TestDto>> GetAllSubjectTests(int sid);
        Task<IEnumerable<TestDto>> GetAllUserTests();
        Task<TestDto> GetById(int tid, int sid);
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

        public async Task<IEnumerable<TestDto>> GetAllUserTests()
        {
            int? userId = _userContextService.GetUserId;
            var tests = await _context.Tests
                .Where(t => t.Subject.UserId == userId)
                .Include(t=>t.Subject)
                .ToListAsync();
            if (tests.Count == 0)
            {
                throw new NotFoundException("Not Found"); 
            }
            var testDtos = _mapper.Map<List<TestDto>>(tests);
            return testDtos;

        }
        public async Task<IEnumerable<TestDto>> GetAllSubjectTests(int sid)
        {
            int? userId = _userContextService.GetUserId;
            var tests = await _context.Tests
                .Where(t => t.Subject.UserId == userId)
                .Where(t => t.SubjectId == sid)
                .ToListAsync();
            if(tests.Count==0)
            {
                throw new NotFoundException("Not Found");

            }
            var testDtos = _mapper.Map<List<TestDto>>(tests);
            return testDtos;
        }
        public async Task<TestDto> GetById(int tid, int sid)
        {
            int? userId = _userContextService.GetUserId;

            var test = await _context.Tests
                .Where(t => t.Subject.UserId == userId)
                .Where(t => t.SubjectId == sid)
                .FirstOrDefaultAsync(t => t.Id == tid);

            if(test == null)
            {
                throw new NotFoundException("Not Found");
            }

            var testDto = _mapper.Map<TestDto>(test);
            return testDto;

        }
    }
}
