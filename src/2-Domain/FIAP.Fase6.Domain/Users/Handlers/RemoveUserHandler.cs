using FIAP.Fase6.Core.AutoMapper;
using FIAP.Fase6.Core.Commands;
using FIAP.Fase6.Core.Interfaces;
using FIAP.Fase6.Domain.Contracts.Repositories;
using FIAP.Fase6.Domain.Users.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace FIAP.Fase6.Domain.Users.Handlers
{
    public class RemoveUserHandler : CommandHandlerBase, ICommandHandler<RemoveUserCommand>
    {
        /// <summary>
        /// Defines the repository
        /// </summary>
        private readonly IUserRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterNewUserHandler"/> class.
        /// </summary>
        /// <param name="repository">The repository<see cref="IUserRepository"/></param>
        public RemoveUserHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// The Handle
        /// </summary>
        /// <param name="message">The message<see cref="RegisterNewUserCommand"/></param>
        /// <returns>The <see cref="Task"/></returns>
        public Result Handle(RemoveUserCommand message)
        {
            //var validationResult = Validate(command, _createAuthorCommandValidator);

            //if (validationResult.IsValid)
            //{
            var user = Mapper<FIAP.Fase6.Domain.Contracts.Models.User, RemoveUserCommand>.CommandToEntity(message);
            _repository.Remove(user);
            _repository.SaveChanges();
            //}

            return Return();
        }


    }
}
