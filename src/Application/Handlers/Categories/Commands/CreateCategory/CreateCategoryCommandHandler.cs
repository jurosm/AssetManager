using AssetManager.Domain.Entities;
using AutoMapper;
using Contracts.Database;
using MediatR;

namespace AssetManager.Application.Handlers.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler(IAssetManagerContext context, IMapper mapper) : IRequestHandler<CreateCategoryCommand, CreateCategoryResponseModel>
    {
        public async Task<CreateCategoryResponseModel> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var createdCategory = await context.Categories.AddAsync(mapper.Map<Category>(request), cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            return mapper.Map<CreateCategoryResponseModel>(createdCategory.Entity);
        }
    }
}

