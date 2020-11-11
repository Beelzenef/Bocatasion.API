using Bocatasion.API.Bocatasion.API.Contracts.DTOs.Food;
using System.Collections.Generic;

namespace Bocatasion.API.Services.Contracts
{
    public interface ISandwichService
    {
        IEnumerable<SandwichDto> GetAllSandwiches();
        SandwichDto GetSandwichById(int id);
        SandwichDto CreateSandwich(SandwichCreatableDto creatableDto);
    }
}
