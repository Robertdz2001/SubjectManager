using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SubjectManagerAPI.Entities;

namespace SubjectManagerAPI.Models.Validators
{
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserDtoValidator(SubjectManagerDbContext _context)
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password)
                .MinimumLength(6);

            RuleFor(x => x.Email)
                .Custom((value, context) =>
                {
                    var emailInUse = _context.Users.Any(u => u.Email == value);
                    if (emailInUse)
                    {
                        context.AddFailure("Email", "That email is taken");
                    }
                });
        }
    }
}
