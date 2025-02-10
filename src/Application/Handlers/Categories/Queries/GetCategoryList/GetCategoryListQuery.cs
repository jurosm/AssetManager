using MediatR;

namespace AssetManager.Application.Handlers.Categories.Queries.GetCategoryList
{
    public class GetCategoryListQuery : IRequest<List<GetCategoryListModel>>
    {
    }
}
