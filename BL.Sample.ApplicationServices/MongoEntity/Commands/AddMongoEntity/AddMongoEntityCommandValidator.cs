using FluentValidation;

namespace BL.Sample.ApplicationServices.MongoEntity.Commands.AddMongoEntity
{
    public class AddMongoEntityCommandValidator : AbstractValidator<AddMongoEntityCommand>
    {
        public AddMongoEntityCommandValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("{PropertyName} should not be empty")
                .NotNull().WithMessage("{PropertyName} should not be null")
                .MinimumLength(5).WithMessage("{PropertyName} should have minimum {MinimumLength} characters")
                .WithName("Name");
        }
    }
}
