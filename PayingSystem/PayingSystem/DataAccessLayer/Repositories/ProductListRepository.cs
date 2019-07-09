// <copyright file="ProductListRepository.cs" company="PlaceholderCompany">
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
    public class ProductListRepository : Repository<ProductList>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductListRepository"/> class.
        /// </summary>
        /// <param name="context">Database context.</param>
        public ProductListRepository(PayingSystemDataBaseContext context)
            : base(context)
        {
        }

        /// <inheritdoc/>
        public override IEnumerable<ProductList> Get() => DataSet.Include(p => p.Shops).Include(p => p.Products);

        /// <inheritdoc/>
        public override IEnumerable<ProductList> Get(Expression<Func<ProductList, bool>> predicate) => DataSet.Include(p => p.Shops).Include(p => p.Products).Where(predicate);
    }
}
