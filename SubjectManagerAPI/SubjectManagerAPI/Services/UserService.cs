using Microsoft.AspNetCore.Identity;
using SubjectManagerAPI.Entities;
using SubjectManagerAPI.Models;

namespace SubjectManagerAPI.Services
{
    public interface IUserService
    {
        Task RegisterUser(RegisterUserDto dto);
    }

    public class UserService : IUserService
    {
        private readonly SubjectManagerDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserService(SubjectManagerDbContext context, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public async Task RegisterUser(RegisterUserDto dto)
        {
            var newUser = new User()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
            };
            newUser.PasswordHash = _passwordHasher.HashPassword(newUser, dto.Password);
           await _context.Users.AddAsync(newUser);
           await _context.SaveChangesAsync();
        }
    }
}
