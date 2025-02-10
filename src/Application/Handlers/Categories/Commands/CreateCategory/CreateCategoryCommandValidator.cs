using FluentValidation;

namespace AssetManager.Application.Handlers.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator() 
        { 
            RuleFor(c => c.Name).NotEmpty().MinimumLength(1).MaximumLength(255);
        }
    }
}
