using AssetManager.Domain.Entities;
using AutoMapper;

namespace AssetManager.Application.Handlers.Assets.Queries.GetAssetList
{
    public class GetAssetListModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required int Quantity { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Asset, GetAssetListModel>();
            }
        }
    }
}
