using FIAP.Fase6.Domain.Contracts.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FIAP.Fase6.Infra.Data.Context
{
    public class Fase6Context : DbContext
    {
        public DbSet<User> User { get; set; }

        public Fase6Context(DbContextOptions options)
            : base(options)
        {
        }

        public Fase6Context()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            throw new NotImplementedException();
            ////var mutableProperties = modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string)));

            //foreach (var property in mutableProperties)
            //    property.Relational().ColumnType = "varchar(100)";

            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(Fase6Context).Assembly); base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            throw new NotImplementedException();
            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder
            //        .UseSqlServer("DefaultConnection");
            //}
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
            //foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("Created") != null))
            //{
            //    if (entry.State == EntityState.Added)
            //    {
            //        entry.Property("Created").CurrentValue = DateTime.Now;
            //        continue;
            //    }

            //    if (entry.State == EntityState.Modified)
            //    {
            //        entry.Property("Created").IsModified = false;
            //        entry.Property("Updated").CurrentValue = DateTime.Now;
            //    }
            //}

            //return base.SaveChangesAsync(cancellationToken);
        }
    }
}
