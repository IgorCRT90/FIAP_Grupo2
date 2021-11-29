using FIAP.Fase6.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace FIAP.Fase6.Core.Interfaces
{
    public interface ICommandHandler<in T> where T : CommandBase
    {
        Result Handle(T command);
    }
}
