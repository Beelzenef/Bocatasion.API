using Bocatasion.API.Bocatasion.API.Data.Contracts.Repositories;
using Bocatasion.API.Data.Contracts;
using Bocatasion.API.Data.Contracts.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Bocatasion.API.Bocatasion.API.Data.Repositories
{
    public class SandwichRepository : ISandwichRepository
    {
        private readonly IDatabaseContext _context;

        public SandwichRepository(IDatabaseContext context)
        {
            _context = context;
        }

        public void Delete(int entityId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Sandwich> GetAll()
        {
            return _context.Sandwiches.ToList();
        }

        public Sandwich GetById(int entityId)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(Sandwich entity)
        {
            throw new System.NotImplementedException();
        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Sandwich entity)
        {
            throw new System.NotImplementedException();
        }
    }
}