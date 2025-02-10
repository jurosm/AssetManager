using AssetManager.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AssetManager.Application.Handlers.Assets.Command.CreateAsset
{
    public class CreateAssetCommand : IRequest<CreateAssetResponseModel>
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required int Quantity { get; set; }
        public required int CategoryId { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<CreateAssetCommand, Asset>();
            }
        }
    }
}
