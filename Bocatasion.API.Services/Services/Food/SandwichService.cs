using Bocatasion.API.Bocatasion.API.Data.Contracts.Repositories;
using Bocatasion.API.Contracts.DTOs;
using Bocatasion.API.Services.Contracts;
using Bocatasion.API.Services.Mappers;
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

        public IEnumerable<SandwichDto> GetAllSandwiches()
        {
            var data = _sandwichRepository.GetAll().ToList();

            var sandwichModels = SandwichMapper.MapToSandwichModelList(data);

            var dtos = SandwichMapper.MapToSandwichDtoList(sandwichModels);

            return dtos;
        }
    }
}
