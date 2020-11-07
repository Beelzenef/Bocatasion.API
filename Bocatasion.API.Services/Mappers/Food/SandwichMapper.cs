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
            if (model == null) return null;

            var dto = new SandwichDto
            {
                Id = model.Id,
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
            if (models == null || models.Count == 0) return null;

            return models.Select(MapToSandwichDto).ToList();
        }

        public static SandwichModel MapToSandwichModel(Sandwich entity)
        {
            if (entity == null) return null;

            var model = new SandwichModel
            {
                Id = entity.Id,
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
            if (entities == null || entities.Count == 0) return null;

            return entities.Select(MapToSandwichModel).ToList();
        }
    }
}
