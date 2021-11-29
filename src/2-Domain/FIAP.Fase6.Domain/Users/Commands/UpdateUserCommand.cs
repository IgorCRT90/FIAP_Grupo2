using System;
using System.Collections.Generic;
using System.Text;

namespace FIAP.Fase6.Domain.Users.Commands
{
    public class UpdateUserCommand : UserCommand
    {
        public UpdateUserCommand(Guid id, string name) : base(id, name) { }


    }
}
