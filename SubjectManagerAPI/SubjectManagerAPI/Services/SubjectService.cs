using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SubjectManagerAPI.Entities;
using SubjectManagerAPI.Exceptions;

namespace SubjectManagerAPI.Services
{
    
    public interface ISubjectService
    {
        Task<IEnumerable<Subject>> GetAll(int userId);
        Task<Subject> GetById(int sid, int userId);
    }
    public class SubjectService : ISubjectService
    {
        private readonly SubjectManagerDbContext _context;

        public SubjectService(SubjectManagerDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Subject>> GetAll(int userId)
        {
            var subjects = await _context.Subjects
                .Where(s => s.UserId == userId)
                .ToListAsync();

            if(subjects.Count == 0)
            {
                throw new NotFoundException("Not Found");
            }
            return subjects;
        }

        public async Task<Subject> GetById(int sid, int userId)
        {
            var subject = await _context.Subjects
                .Where(s => s.UserId == userId)
                .FirstOrDefaultAsync(s => s.Id == sid);
            if(subject == null)
            {
                throw new NotFoundException("Not Found");
            }
            return subject;
        }
    }
}
