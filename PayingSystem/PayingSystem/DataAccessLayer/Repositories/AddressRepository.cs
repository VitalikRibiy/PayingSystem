// <copyright file="AddressRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PayingSystem.DataAccessLayer.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using PayingSystem.DataAccessLayer.Models;
    using PayingSystem.Implementations;

    /// <summary>
    /// Class that implements Repository of specific type.
    /// </summary>
    public class AddressRepository : Repository<Address>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddressRepository"/> class.
        /// </summary>
        /// <param name="context">Database context.</param>
        public AddressRepository(PayingSystemDataBaseContext context)
            : base(context)
        {
        }

        /// <inheritdoc/>
        public override IEnumerable<Address> Get() => DataSet.AsEnumerable();

        /// <inheritdoc/>
        public override IEnumerable<Address> Get(Expression<Func<Address, bool>> predicate) => DataSet.Where(predicate).AsEnumerable();
    }
}
