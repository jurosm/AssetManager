using AssetManager.Application.Exceptions;
using AssetManager.Domain.Entities;
using AutoMapper;
using Contracts.Database;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AssetManager.Application.Handlers.Assets.Command.CreateAsset
{
    public class CreateAssetCommandHandler(IAssetManagerContext context, IMapper mapper, ILogger<CreateAssetCommandHandler> logger) : IRequestHandler<CreateAssetCommand, CreateAssetResponseModel>
    {
        public async Task<CreateAssetResponseModel> Handle(CreateAssetCommand request, CancellationToken cancellationToken)
        {
            var category = await context.Categories.FindAsync(request.CategoryId, cancellationToken);

            if (category == null) {
                logger.LogWarning("Test");
                throw new BadRequestException($"Category with ID={request.CategoryId} not found!", "asset.category.not_found");
            }

            var createdAsset = await context.Assets.AddAsync(mapper.Map<Asset>(request), cancellationToken);

            await context.SaveChangesAsync(cancellationToken);

            return mapper.Map<CreateAssetResponseModel>(createdAsset.Entity);
        }
    }
}
