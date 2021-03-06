﻿namespace Bocatasion.API.Data.Contracts.Entities
{
    public class Sandwich : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public bool Disabled { get; set; }
        public string ImageUrl { get; set; }
    }
}
