using FluentValidation;

namespace AssetManager.Application.Handlers.Assets.Command.CreateAsset
{
    public class CreateAssetCommandValidator : AbstractValidator<CreateAssetCommand>
    {
        public CreateAssetCommandValidator() { 
            RuleFor(a => a.Name).NotEmpty().MinimumLength(1).MaximumLength(255);
            RuleFor(a => a.Description).NotEmpty().MinimumLength(1).MaximumLength(255);
            RuleFor(a => a.Quantity).NotEmpty().GreaterThan(0);
            RuleFor(a => a.CategoryId).NotEmpty().GreaterThan(0);
        }
    }
}
