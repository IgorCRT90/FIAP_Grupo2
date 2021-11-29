using FIAP.Fase6.Domain.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FIAP.Fase6.Application.Queries
{
    public class UserQueries : IUserQueries
    {
        private readonly IUserRepository _userRepository;

        public UserQueries(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<FIAP.Fase6.Domain.Contracts.Models.User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }
    }

    public interface IUserQueries
    {
        Task<IEnumerable<FIAP.Fase6.Domain.Contracts.Models.User>> GetAllAsync();
    }
}
