using FIAP.Fase6.Core.Interfaces;
using FIAP.Fase6.Domain.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FIAP.Fase6.Domain.Contracts.Repositories
{
    public interface IUserRepository: IRepository<User>
    {
        Task<bool> ExistsAsync(string name);
        Task<IEnumerable<User>> GetAllAsync();
    }
}
