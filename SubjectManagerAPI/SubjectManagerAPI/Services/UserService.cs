using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SubjectManagerAPI.Entities;
using SubjectManagerAPI.Exceptions;
using SubjectManagerAPI.Models;
using SubjectManagerAPI.Models.UserDtos;

namespace SubjectManagerAPI.Services
{
    public interface IUserService
    {
        Task<string> GenerateJwt(LoginDto dto);
        Task RegisterUser(RegisterUserDto dto);
    }

    public class UserService : IUserService
    {
        private readonly SubjectManagerDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly AuthenticationSettings _authenticationSettings;

        public UserService(SubjectManagerDbContext context, IPasswordHasher<User> passwordHasher, AuthenticationSettings authenticationSettings)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
        }

        public async Task RegisterUser(RegisterUserDto dto)
        {
            var newUser = new User()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
            };
            newUser.PasswordHash = _passwordHasher.HashPassword(newUser, dto.Password);
           await _context.Users.AddAsync(newUser);
           await _context.SaveChangesAsync();
        }

        public async Task<string> GenerateJwt(LoginDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);

            if(user == null)
            {
                throw new BadRequestException("Invalid username or password");
            }

           var result = _passwordHasher.VerifyHashedPassword(user,user.PasswordHash,dto.Password); 

            if(result == PasswordVerificationResult.Failed)
            {
                throw new BadRequestException("Invalid username or password");
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,
                _authenticationSettings.JwtIssuer,
                claims,
                expires:expires,
                signingCredentials:cred);

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }
}
