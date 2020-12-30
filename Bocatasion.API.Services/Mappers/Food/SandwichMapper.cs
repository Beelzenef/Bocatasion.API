using Bocatasion.API.Bocatasion.API.Contracts.DTOs.Food;
using Bocatasion.API.Contracts.DTOs.Food;
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

        public static SandwichInfoDto MapToSandwichInfoDto(SandwichModel model)
        {
            if (model == null) return null;

            var infoDto = new SandwichInfoDto
            {
                Name = model.Name,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Price = model.Price
            };

            return infoDto;
        }

        public static List<SandwichDto> MapToSandwichDtoList(List<SandwichModel> models)
        {
            if (models == null || models.Count == 0) return null;

            return models.Select(MapToSandwichDto).ToList();
        }

        public static List<SandwichInfoDto> MapToSandwichInfoDtoList(List<SandwichModel> models)
        {
            if (models == null || models.Count == 0) return null;

            return models.Select(MapToSandwichInfoDto).ToList();
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

        public static SandwichModel MapToSandwichModel(SandwichCreatableDto creatableDto)
        {
            if (creatableDto == null) return null;

            var model = new SandwichModel
            {
                Name = creatableDto.Name,
                Description = creatableDto.Description,
                Disabled = creatableDto.Disabled,
                ImageUrl = creatableDto.ImageUrl,
                Price = creatableDto.Price
            };

            return model;
        }

        public static void MapUpdatesToEntity(Sandwich entity, SandwichUpdatableDto updatable)
        {
            if (entity == null || updatable == null) return;

            entity.Name = updatable.Name;
            entity.Description = updatable.Description;
            entity.Disabled = updatable.Disabled;
            entity.ImageUrl = updatable.ImageUrl;
            entity.Price = updatable.Price;
        }

        public static Sandwich MapToSandwichEntity(SandwichModel model)
        {
            if (model == null) return null;

            var entity = new Sandwich
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Disabled = model.Disabled,
                ImageUrl = model.ImageUrl,
                Price = model.Price
            };

            return entity;
        }

        public static List<Sandwich> MapToSandwichEntityList(List<SandwichModel> models)
        {
            if (models == null || models.Count == 0) return null;

            return models.Select(MapToSandwichEntity).ToList();
        }

        public static SandwichDto MapToSandwichDto(Sandwich entity)
        {
            if (entity == null) return null;

            var dto = new SandwichDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Disabled = entity.Disabled,
                ImageUrl = entity.ImageUrl,
                Price = entity.Price
            };

            return dto;
        }
    }
}
