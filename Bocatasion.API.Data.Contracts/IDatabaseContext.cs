using Microsoft.EntityFrameworkCore;
using Bocatasion.API.Data.Contracts.Entities;

namespace Bocatasion.API.Data.Contracts
{
    public interface IDatabaseContext
    {
        DbSet<Sandwich> Sandwiches { get; set; }
        int SaveChanges();
    }
}
