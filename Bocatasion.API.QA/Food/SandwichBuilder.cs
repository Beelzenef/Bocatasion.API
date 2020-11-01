using Bocatasion.API.Models;
using System.Collections.Generic;

namespace Bocatasion.API.QA
{
    public static class SandwichBuilder
    {
        public static List<SandwichModel> GenerateSandwichModels()
        {
            return new List<SandwichModel>
            {
                new SandwichModel
                {
                    Name = "Sandwich mixto",
                    Description = "Delicious sandwich de jamón y queso fundido",
                    Disabled = true,
                    Price = 3.50,
                    ImageUrl = "https://i-ticketing.iwos.com/256x256-th/products/213/products_213_27.jpg"
                },
                new SandwichModel
                {
                    Name = "Hot dog",
                    Description = "Pan de perrito con salchica, a elegir con ketchup, mayonesa y/o mostaza",
                    Disabled = false,
                    Price = 4,
                    ImageUrl = "https://s3.amazonaws.com/pix.iemoji.com/images/emoji/apple/ios-12/256/hot-dog.png"
                }
            };
        }
    }
}
