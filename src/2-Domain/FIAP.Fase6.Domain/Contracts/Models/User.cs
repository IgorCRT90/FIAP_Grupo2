using FIAP.Fase6.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace FIAP.Fase6.Domain.Contracts.Models
{
    /// <summary>
    /// Defines the <see cref="User" />
    /// </summary>
    public class User: Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User()
        {
        }

        /// <summary>
        /// Gets the Name
        /// Gets or sets the Name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the Status
        /// Gets or sets the Status
        /// </summary>
        public string Status { get; private set; }
        

        /// <summary>
        /// The SetStatus
        /// </summary>
        /// <param name="status">The status<see cref="UserStatus"/></param>
        /// <returns>The <see cref="User"/></returns>
        public User SetStatus(string status)
        {
            Status = status;
            return this;
        }

        public User SetName(string name)
        {
            Name = name;
            return this;
        }
    }
}
