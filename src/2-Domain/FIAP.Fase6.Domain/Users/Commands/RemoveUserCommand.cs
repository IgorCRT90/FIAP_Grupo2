using System;
using System.Collections.Generic;
using System.Text;

namespace FIAP.Fase6.Domain.Users.Commands
{
    public class RemoveUserCommand : UserCommand
    {
        public RemoveUserCommand(Guid id) : base(id) { }

    }
}
