using FIAP.Fase6.Core.Entity;
using FIAP.Fase6.Core.Interfaces;
using FIAP.Fase6.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace FIAP.Fase6.Infra.Data.Repositories
{
    public class RepositoryBase<T> : IRepository<T> where T : IEntity
    {
        protected readonly Fase6Context _fase6Context;

        public RepositoryBase(Fase6Context fase6Context)
        {
            _fase6Context = fase6Context;
        }

        public int SaveChanges() => _fase6Context.SaveChangesAsync().Result;

        public void Add(T entity) => _fase6Context.Add(entity);
        public void Update(T entity) => _fase6Context.Update(entity);

        public void Remove(T entity) => _fase6Context.Remove(entity);

        public void Dispose()
        {
            _fase6Context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
