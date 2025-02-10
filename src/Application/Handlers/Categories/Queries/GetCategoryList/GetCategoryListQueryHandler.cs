using AssetManager.Application.Common;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Contracts.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AssetManager.Application.Handlers.Categories.Queries.GetCategoryList
{
    public class GetCategoryListQueryHandler(IAssetManagerContext context, IMapper mapper) : IRequestHandler<GetCategoryListQuery, ListResponse<GetCategoryListModel>>
    {
        public async Task<ListResponse<GetCategoryListModel>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
           var categories = await context.Categories.ProjectTo<GetCategoryListModel>(mapper.ConfigurationProvider).ToListAsync(cancellationToken);

            return new ListResponse<GetCategoryListModel> { Data = categories, Total = categories.Count };
        }
    }
}
