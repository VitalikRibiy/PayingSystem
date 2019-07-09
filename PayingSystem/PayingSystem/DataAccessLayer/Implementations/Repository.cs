// <copyright file="Repository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PayingSystem.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using PayingSystem.DataAccessLayer.Interfaces;

    /// <summary>
    /// Implementation of IRepository.
    /// </summary>
    /// <typeparam name="T">Type of entity.</typeparam>
    public abstract class Repository<T> : IRepository<T>
        where T : class
    {
        /// <summary>
        /// DataSet from database specified by type.
        /// </summary>
        protected readonly DbSet<T> DataSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{T}"/> class.
        /// </summary>
        /// <param name="context">Context of database.</param>
        public Repository(PayingSystemDataBaseContext context)
        {
            if (DataSet == null)
            {
                DataSet = context.Set<T>();
            }
        }

        /// <inheritdoc/>
        public void Add(T entity)
        {
            DataSet.Add(entity);
        }

        /// <inheritdoc/>
        public void Delete(T entity)
        {
            if (DataSet.Contains(entity))
            {
                DataSet.Remove(entity);
            }
        }

        /// <inheritdoc/>
        public void Delete(object key)
        {
            T entity = DataSet.Find(key);
            Delete(entity);
        }

        /// <inheritdoc/>
        public virtual IEnumerable<T> Get()
        {
            return DataSet.AsEnumerable<T>();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="predicate">Condition.</param>
        /// <returns>Data that respond to predicate.</returns>
        public virtual IEnumerable<T> Get(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return DataSet.Where(predicate).AsEnumerable<T>();
        }

        /// <inheritdoc/>
        public void Update(T entity)
        {
            DataSet.Update(entity);
        }
    }
}
