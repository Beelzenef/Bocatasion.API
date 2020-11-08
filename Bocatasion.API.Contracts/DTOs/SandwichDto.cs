namespace Bocatasion.API.Contracts.DTOs
{
    public class SandwichDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public bool Disabled { get; set; }
        public string ImageUrl { get; set; }
    }
}
