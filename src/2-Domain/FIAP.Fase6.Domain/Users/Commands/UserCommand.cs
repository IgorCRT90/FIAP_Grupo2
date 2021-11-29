using FIAP.Fase6.Core.Commands;
using FIAP.Fase6.Domain.Contracts.Models;
using System;

namespace FIAP.Fase6.Domain.Users.Commands
{
    /// <summary>
    /// Defines the <see cref="UserCommand" />
    /// </summary>
    public abstract class UserCommand : CommandBase
    {
        public UserCommand (Guid id, string name)
        {
            Name = name;
            Id = id;
        }

        public UserCommand(Guid id)
        {
            Id = id;
        }

        public UserCommand(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Gets the Name
        /// Gets or sets the Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the Status
        /// Gets or sets the Status
        /// </summary>
        public string Status { get; set; }

        public Guid Id { get; set; }
    }
}
