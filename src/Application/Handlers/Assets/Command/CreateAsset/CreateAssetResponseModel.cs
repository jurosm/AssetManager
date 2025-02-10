using AssetManager.Domain.Entities;
using AutoMapper;

namespace AssetManager.Application.Handlers.Assets.Command.CreateAsset
{
    public class CreateAssetResponseModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required int Quantity { get; set; }
        public required int CategoryId { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Asset, CreateAssetResponseModel>();   
            }
        }
    }
}
