﻿namespace Bocatasion.API.Models
{
    public class SandwichModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public bool Disabled { get; set; }
        public string ImageUrl { get; set; }
    }
}
