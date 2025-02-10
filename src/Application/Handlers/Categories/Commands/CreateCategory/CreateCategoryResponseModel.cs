using AssetManager.Domain.Entities;
using AutoMapper;

namespace AssetManager.Application.Handlers.Categories.Commands.CreateCategory
{
    public class CreateCategoryResponseModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Category, CreateCategoryResponseModel>();
            }
        }
    }
}
