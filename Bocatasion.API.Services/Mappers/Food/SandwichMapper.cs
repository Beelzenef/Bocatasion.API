using Bocatasion.API.Contracts.DTOs;
using Bocatasion.API.Data.Contracts.Entities;
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

        public static List<SandwichDto> MapToSandwichDtoList(List<SandwichModel> models)
        {
            return models.Select(MapToSandwichDto).ToList();
        }

        public static SandwichModel MapToSandwichModel(Sandwich entity)
        {
            var model = new SandwichModel
            {
                Name = entity.Name,
                Description = entity.Description,
                Disabled = entity.Disabled,
                ImageUrl = entity.ImageUrl,
                Price = entity.Price
            };

            return model;
        }

        public static List<SandwichModel> MapToSandwichModelList(List<Sandwich> entities)
        {
            return entities.Select(MapToSandwichModel).ToList();
        }
    }
}
