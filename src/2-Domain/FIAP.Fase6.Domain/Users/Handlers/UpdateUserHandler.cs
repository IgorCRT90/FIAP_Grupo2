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
    public class UpdateUserHandler : CommandHandlerBase, ICommandHandler<UpdateUserCommand>
    {
        /// <summary>
        /// Defines the repository
        /// </summary>
        private readonly IUserRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterNewUserHandler"/> class.
        /// </summary>
        /// <param name="repository">The repository<see cref="IUserRepository"/></param>
        public UpdateUserHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// The Handle
        /// </summary>
        /// <param name="message">The message<see cref="RegisterNewUserCommand"/></param>
        /// <returns>The <see cref="Task"/></returns>
        public Result Handle(UpdateUserCommand message)
        {
            //var validationResult = Validate(command, _createAuthorCommandValidator);

            //if (validationResult.IsValid)
            //{
            var user = Mapper<FIAP.Fase6.Domain.Contracts.Models.User, UpdateUserCommand>.CommandToEntity(message);
            _repository.Update(user);
            _repository.SaveChanges();
            //}

            return Return();
        }


    }
}
