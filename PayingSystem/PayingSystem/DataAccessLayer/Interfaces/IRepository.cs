// <copyright file="IRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PayingSystem.DataAccessLayer.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface that implements repository pattern.
    /// </summary>
    /// <typeparam name="T">Type of entity.</typeparam>
    public interface IRepository<T>
        where T : class
    {
        /// <summary>
        /// Function that returns data from database.
        /// </summary>
        /// <returns>IEnumerable T.</returns>
        IEnumerable<T> Get();

        /// <summary>
        /// Add entity to database.
        /// </summary>
        /// <param name="entity">Entity.</param>
        void Add(T entity);

        /// <summary>
        /// Delete entity from database.
        /// </summary>
        /// <param name="entity">Entity.</param>
        void Delete(T entity);

        /// <summary>
        /// Delete entity from database.
        /// </summary>
        /// <param name="key">Unique key of entity.</param>
        void Delete(object key);

        /// <summary>
        /// Update entity in database.
        /// </summary>
        /// <param name="entity">Entity.</param>
        void Update(T entity);
    }
}
