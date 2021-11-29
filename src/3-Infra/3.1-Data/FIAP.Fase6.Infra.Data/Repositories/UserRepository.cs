using FIAP.Fase6.Domain.Contracts.Models;
using FIAP.Fase6.Domain.Contracts.Repositories;
using FIAP.Fase6.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP.Fase6.Infra.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(Fase6Context fase6Context) : base(fase6Context)
        {
        }

        public void Delete(Guid id)
        {
            var entity = _fase6Context.User.FirstOrDefault(b => b.Id == id);
            _fase6Context.User.Remove(entity);
        }

        public async Task<bool> ExistsAsync(string name)
        {
            return await _fase6Context.User.AnyAsync(b => b.Name.Equals(name));
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _fase6Context.User.ToListAsync();
        }

        public User GetById(Guid id)
        {
            return _fase6Context.User
                .AsNoTracking()
                .Include(b => b.Name)
                .Include(b => b.Status)
                .FirstOrDefault(b => b.Id == id);
        }
    }
}
