using System;
using FIAP.Fase6.Core.Entity;

namespace FIAP.Fase6.Core.Interfaces
{
    public interface IRepository<in T> : IDisposable where T : IEntity
    {
        int SaveChanges();
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}
