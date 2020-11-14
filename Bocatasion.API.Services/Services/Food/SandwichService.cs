using Bocatasion.API.Bocatasion.API.Contracts.DTOs.Food;
using Bocatasion.API.Bocatasion.API.Data.Contracts.Repositories;
using Bocatasion.API.Services.Contracts;
using Bocatasion.API.Services.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bocatasion.API.Services
{
    public class SandwichService : ISandwichService
    {
        private readonly ISandwichRepository _sandwichRepository;

        public SandwichService(ISandwichRepository sandwichRepository)
        {
            _sandwichRepository = sandwichRepository ?? throw new ArgumentNullException(nameof(sandwichRepository));
        }

        public SandwichDto CreateSandwich(SandwichCreatableDto creatableDto)
        {
            if (creatableDto == null) throw new ArgumentNullException(nameof(creatableDto));

            var model = SandwichMapper.MapToSandwichModel(creatableDto);
            var entity = SandwichMapper.MapToSandwichEntity(model);
            try
            {
                _sandwichRepository.Insert(entity);
                _sandwichRepository.Save();
            }
            catch (Exception ex)
            {
                throw new DbUpdateException("Error at inserting data");
            }

            var dto = SandwichMapper.MapToSandwichDto(entity);
            return dto;

        }

        public void DeleteSandwich(int id)
        {
            if (id == 0) throw new ArgumentNullException(nameof(id));

            var existingSandwich = _sandwichRepository.GetById(id);
            if (existingSandwich == null) return;

            _sandwichRepository.Delete(id);
        }

        public IEnumerable<SandwichDto> GetAllSandwiches()
        {
            var data = _sandwichRepository.GetAll().ToList();

            var sandwichModels = SandwichMapper.MapToSandwichModelList(data);

            var dtos = SandwichMapper.MapToSandwichDtoList(sandwichModels);

            return dtos;
        }

        public SandwichDto GetSandwichById(int id)
        {
            if (id == 0) return null;

            var data = _sandwichRepository.GetById(id);

            var model = SandwichMapper.MapToSandwichModel(data);
            var dto = SandwichMapper.MapToSandwichDto(model);

            return dto;
        }
    }
}
