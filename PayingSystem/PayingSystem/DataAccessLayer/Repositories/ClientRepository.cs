// <copyright file="ClientRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PayingSystem.DataAccessLayer.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Microsoft.EntityFrameworkCore;
    using PayingSystem.DataAccessLayer.Models;
    using PayingSystem.Implementations;

    /// <summary>
    /// Class that implements Repository of specific type.
    /// </summary>
    public class ClientRepository : Repository<Client>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClientRepository"/> class.
        /// </summary>
        /// <param name="context">Database context.</param>
        public ClientRepository(PayingSystemDataBaseContext context)
            : base(context)
        {
        }

        /// <inheritdoc/>
        public override IEnumerable<Client> Get() => DataSet.Include(p => p.Address).AsEnumerable();

        /// <inheritdoc/>
        public override IEnumerable<Client> Get(Expression<Func<Client, bool>> predicate) => DataSet.Include(p => p.Address).Where(predicate).AsEnumerable();
    }
}