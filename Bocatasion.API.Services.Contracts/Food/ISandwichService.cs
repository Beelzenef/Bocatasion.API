using Bocatasion.API.Contracts.DTOs;
using System.Collections.Generic;

namespace Bocatasion.API.Services.Contracts
{
    public interface ISandwichService
    {
        IEnumerable<SandwichDto> GetAllSandwiches();
        SandwichDto GetSandwichById(int id);
    }
}
