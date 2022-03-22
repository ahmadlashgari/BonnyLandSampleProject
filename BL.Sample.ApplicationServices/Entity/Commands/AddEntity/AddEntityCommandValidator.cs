using FluentValidation;

namespace BL.Sample.ApplicationServices.Entity.Commands.AddEntity
{
    public class AddEntityCommandValidator : AbstractValidator<AddEntityCommand>
    {
        public AddEntityCommandValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("{PropertyName} should not be empty")
                .NotNull().WithMessage("{PropertyName} should not be null")
                .MinimumLength(5).WithMessage("{PropertyName} should have minimum {MinimumLength} characters")
                .WithName("Name");
        }
    }
}