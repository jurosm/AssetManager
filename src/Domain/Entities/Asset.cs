namespace AssetManager.Domain.Entities
{
    public class Asset
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required int Quantity { get; set; }
        public int CategoryId { get; set; }

        public Category? Category { get; set; }
    }
}
