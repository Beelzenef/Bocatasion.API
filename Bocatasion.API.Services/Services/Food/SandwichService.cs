using Bocatasion.API.Contracts.DTOs;
using Bocatasion.API.QA;
using Bocatasion.API.Services.Mappers;
using System.Collections.Generic;

namespace Bocatasion.API.Services
{
    public class SandwichService
    {
        public SandwichService()
        {

        }

        public IEnumerable<SandwichDto> GetAllSandwiches()
        {
            var sandwichModels = SandwichBuilder.GenerateSandwichModels();

            var dtos = SandwichMapper.MapToSandwichDtoList(sandwichModels);

            return dtos;
        }

        
    }
}
