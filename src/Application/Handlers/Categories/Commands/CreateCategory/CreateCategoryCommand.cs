using AssetManager.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AssetManager.Application.Handlers.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<CreateCategoryResponseModel>
    {
        public required string Name { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<CreateCategoryCommand, Category>();
            }
        }
    }
}
