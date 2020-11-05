using Bocatasion.API.Data.Contracts;
using Bocatasion.API.Data.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace Bocatasion.API.Bocatasion.API.Data
{
    public class Context : DbContext, IDatabaseContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                   .AddJsonFile("appsettings.json")
                   .Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection")).EnableSensitiveDataLogging();
            }
        }

        public override int SaveChanges()
        {
            var modifiedEntites = ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);

            modifiedEntites.ToList().ForEach(x =>
            {
                var entity = x.Entity as BaseEntity;
                entity?.SetAudit(x.State);
            });

            return base.SaveChanges();
        }

        public DbSet<Sandwich> Sandwiches { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Sandwich>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();
            builder.Entity<Sandwich>()
                .ToTable("Sandwich");
        }
    }
}