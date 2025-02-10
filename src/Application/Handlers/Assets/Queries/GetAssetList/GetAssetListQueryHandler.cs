using AutoMapper;
using AutoMapper.QueryableExtensions;
using Contracts.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AssetManager.Application.Handlers.Assets.Queries.GetAssetList
{
    public class GetAssetListQueryHandler(IAssetManagerContext context, IMapper mapper) : IRequestHandler<GetAssetListQuery, List<GetAssetListModel>>
    {
        public async Task<List<GetAssetListModel>> Handle(GetAssetListQuery request, CancellationToken cancellationToken)
        {
            var assets = await context.Assets.ProjectTo<GetAssetListModel>(mapper.ConfigurationProvider).ToListAsync(cancellationToken);

            return assets;
        }
    }
}
