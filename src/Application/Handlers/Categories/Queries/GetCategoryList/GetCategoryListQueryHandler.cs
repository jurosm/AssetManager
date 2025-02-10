using AutoMapper;
using AutoMapper.QueryableExtensions;
using Contracts.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AssetManager.Application.Handlers.Categories.Queries.GetCategoryList
{
    public class GetCategoryListQueryHandler(IAssetManagerContext context, IMapper mapper) : IRequestHandler<GetCategoryListQuery, List<GetCategoryListModel>>
    {
        public async Task<List<GetCategoryListModel>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
           var categories = await context.Categories.ProjectTo<GetCategoryListModel>(mapper.ConfigurationProvider).ToListAsync(cancellationToken);

            return categories;
        }
    }
}
