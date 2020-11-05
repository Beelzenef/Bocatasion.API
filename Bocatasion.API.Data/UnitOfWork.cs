using Bocatasion.API.Bocatasion.API.Data.Contracts.Repositories;
using Bocatasion.API.Bocatasion.API.Data.Repositories;
using Bocatasion.API.Data.Contracts;
using System;

namespace Bocatasion.API.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseContext _context;

        public UnitOfWork(IDatabaseContext databaseContext)
        {
            _context = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));

            SandwichRepository = new SandwichRepository(_context);
        }

        public ISandwichRepository SandwichRepository { get; }
    }
}
