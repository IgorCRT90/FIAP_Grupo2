using FIAP.Fase6.Application.ViewModel;
using FIAP.Fase6.Core.Commands;
using FIAP.Fase6.Domain.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FIAP.Fase6.Application.Interfaces
{
    /// <summary>
    /// Defines the <see cref="IUserAppService" />
    /// </summary>
    public interface IUserAppService
    {
        /// <summary>
        /// The Save
        /// </summary>
        /// <param name="name">The user<see cref="string"/></param>
        /// <returns>The <see cref="Result"/></returns>
        Result Save(string name);

        /// <summary>
        /// The Update
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <param name="name">The user<see cref="string"/></param>
        /// <returns>The <see cref="Result"/></returns>
        Result AlterName(Guid id, string name);

        /// <summary>
        /// The Remove
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="Result"/></returns>
        Result Remove(Guid id);

        /// <summary>
        /// The GetAll
        /// </summary>
        /// <returns>The <see cref="IEnumerable{User}"/></returns>
        IEnumerable<User> GetAll();

        /// <summary>
        /// Gets the.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>An User.</returns>
        User Get(Guid id);
    }
}
