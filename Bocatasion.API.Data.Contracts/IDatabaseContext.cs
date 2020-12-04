using Bocatasion.API.Data.Contracts.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bocatasion.API.Data.Contracts
{
    public interface IDatabaseContext
    {
        DbSet<Sandwich> Sandwiches { get; set; }
        int SaveChanges();
    }
}
