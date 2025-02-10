using AssetManager.Application.Common;
using MediatR;

namespace AssetManager.Application.Handlers.Assets.Queries.GetAssetList
{
    public class GetAssetListQuery : IRequest<ListResponse<GetAssetListModel>>
    {
    }
}
