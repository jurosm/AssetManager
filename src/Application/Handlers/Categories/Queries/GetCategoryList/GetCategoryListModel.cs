using AssetManager.Domain.Entities;
using AutoMapper;

namespace AssetManager.Application.Handlers.Categories.Queries.GetCategoryList
{
    public class GetCategoryListModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Category, GetCategoryListModel>();
            }
        }
    }
}
