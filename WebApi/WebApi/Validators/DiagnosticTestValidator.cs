using FluentValidation;
using WebApi.Model;

namespace WebApi.Validators
{
    public class DiagnosticTestValidator : AbstractValidator<DianosticTest>
    {
        public DiagnosticTestValidator()
        {
            RuleFor(d => d.Name).NotEmpty().WithMessage("Name cannot be empty")
                .NotNull().WithMessage("Name cannot be null").MinimumLength(1)
                .WithMessage("Must be atleast 1 character");
            RuleFor(d => d.Date).NotEmpty().WithMessage("Date cannot be empty")
                .NotNull().WithMessage("Date cannot be null");
        }
    }
}
