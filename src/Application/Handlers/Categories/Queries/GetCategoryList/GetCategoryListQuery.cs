using AssetManager.Application.Common;
using MediatR;

namespace AssetManager.Application.Handlers.Categories.Queries.GetCategoryList
{
    public class GetCategoryListQuery : IRequest<ListResponse<GetCategoryListModel>>
    {
    }
}
