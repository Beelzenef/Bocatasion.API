using Bocatasion.API.Bocatasion.API.Data.Contracts.Repositories;

namespace Bocatasion.API.Data.Contracts
{
    public interface IUnitOfWork
    {
        ISandwichRepository SandwichRepository { get; }
    }
}
