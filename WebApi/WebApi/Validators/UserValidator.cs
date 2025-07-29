using FluentValidation;
using WebApi.Model;

namespace WebApi.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(s => s.Name).NotEmpty().WithMessage("Name cannot be emppty")
                .NotNull().WithMessage("Name cannot be null")
                .MinimumLength(3).WithMessage("Name must be atleast 3 Characters");
            RuleFor(s => s.Surname).NotEmpty().WithMessage("Surname cannot be empty")
                .NotNull().WithMessage("Surname cannot be null").MinimumLength(3)
                .WithMessage("Surname must atleast have 3 characters");
            RuleFor(s => s.Salt).NotEmpty().WithMessage("Salt cannot be empty")
                .NotNull().WithMessage("Salt cannot be null");
            RuleFor(s => s.PasswordHash).NotNull().WithMessage("Password cannot be null")
                .NotEmpty().WithMessage("Password cannot be empty");
        }


       
    }
}
