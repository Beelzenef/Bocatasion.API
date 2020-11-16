using Bocatasion.API.Bocatasion.API.Data.Contracts.Repositories;
using Bocatasion.API.Data.Contracts;
using Bocatasion.API.Data.Contracts.Entities;
using System;
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
            if (entityId == 0) throw new ArgumentNullException(nameof(entityId));

            var entityToDelete = GetById(entityId);
            if (entityToDelete == null)
            {
                return;
            }

            _context.Sandwiches.Remove(entityToDelete);
        }

        public IEnumerable<Sandwich> GetAll()
        {
            return _context.Sandwiches.ToList();
        }

        public Sandwich GetById(int entityId)
        {
            if (entityId == 0) return null;

            return _context.Sandwiches.Where(x => x.Id == entityId).FirstOrDefault();
        }

        public void Insert(Sandwich entity)
        {
            _context.Sandwiches.Add(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Sandwich entity)
        {
            throw new System.NotImplementedException();
        }
    }
}