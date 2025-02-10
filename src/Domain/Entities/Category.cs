﻿namespace AssetManager.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public ICollection<Asset>? Assets { get; set; }
    }
}
