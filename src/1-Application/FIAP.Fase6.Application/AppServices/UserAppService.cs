using FIAP.Fase6.Application.Interfaces;
using FIAP.Fase6.Application.Queries;
using FIAP.Fase6.Application.ViewModel;
using FIAP.Fase6.Core.Commands;
using FIAP.Fase6.Core.Interfaces;
using FIAP.Fase6.Domain.Contracts.Models;
using FIAP.Fase6.Domain.Users.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FIAP.Fase6.Application.AppServices
{
    public class UserAppService : IUserAppService
    {

        private readonly ICommandHandler<RegisterNewUserCommand> _registerNewUserCommandHandler;
        private readonly ICommandHandler<RemoveUserCommand> _removeUserCommandHandler;
        private readonly ICommandHandler<UpdateUserCommand> _updateUserCommandHandler;
        private readonly IUserQueries _userQueries;

        public UserAppService(ICommandHandler<RegisterNewUserCommand> registerNewUserCommandHandler,
            ICommandHandler<RemoveUserCommand> removeUserCommandHandler,
            ICommandHandler<UpdateUserCommand> updateUserCommandHandler,
            IUserQueries userQueries)
        {
            _registerNewUserCommandHandler = registerNewUserCommandHandler;
            _removeUserCommandHandler = removeUserCommandHandler;
            _updateUserCommandHandler = updateUserCommandHandler;
            _userQueries = userQueries;
        }



        public Result AlterName(Guid id, string name)
        {
            return _updateUserCommandHandler.Handle(new UpdateUserCommand(id, name));
        }


        public User Get(Guid id)
        {
            return _userQueries.GetAllAsync().Result.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return _userQueries.GetAllAsync().Result;
        }

        public Result Remove(Guid id)
        {
            return _removeUserCommandHandler.Handle(new RemoveUserCommand(id));
        }

        public Result Save(string name)
        {
            return _registerNewUserCommandHandler.Handle(new RegisterNewUserCommand(name));
        }
    }
}
