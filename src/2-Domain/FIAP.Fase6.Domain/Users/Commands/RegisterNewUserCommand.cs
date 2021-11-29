using FIAP.Fase6.Domain.Contracts.Models;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace FIAP.Fase6.Domain.Users.Commands
{
    /// <summary>
    /// Defines the <see cref="RegisterNewUserCommand" />
    /// </summary>
    public class RegisterNewUserCommand : UserCommand
    {

        public RegisterNewUserCommand(string name) : base(name) { }

    }
}
