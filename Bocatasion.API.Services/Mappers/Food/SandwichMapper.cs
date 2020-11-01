using Bocatasion.API.Contracts.DTOs;
using Bocatasion.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace Bocatasion.API.Services.Mappers
{
    public static class SandwichMapper
    {
        public static SandwichDto MapToSandwichDto(SandwichModel model)
        {
            var dto = new SandwichDto
            {
                Name = model.Name,
                Description = model.Description,
                Disabled = model.Disabled,
                ImageUrl = model.ImageUrl,
                Price = model.Price
            };

            return dto;
        }

        public static IEnumerable<SandwichDto> MapToSandwichDtoList(List<SandwichModel> models)
        {
            return models.Select(MapToSandwichDto);
        }
    }
}
