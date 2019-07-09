// <copyright file="ShopRepository.cs" company="PlaceholderCompany">
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
    public class ShopRepository : Repository<Shop>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShopRepository"/> class.
        /// </summary>
        /// <param name="context">Database context.</param>
        public ShopRepository(PayingSystemDataBaseContext context)
            : base(context)
        {
        }

        /// <inheritdoc/>
        public override IEnumerable<Shop> Get() => DataSet.Include(p => p.Account).Include(p => p.Address).Include(p => p.ProductLists).ThenInclude(p => p.Products).AsEnumerable();

        /// <inheritdoc/>
        public override IEnumerable<Shop> Get(Expression<Func<Shop, bool>> predicate) => DataSet.Include(p => p.Account).Include(p => p.Address).Include(p => p.ProductLists).ThenInclude(p => p.Products).Where(predicate).AsEnumerable();

        /// <summary>
        /// Check if account with specified cardnumber is an owner of the shop.
        /// </summary>
        /// <param name="cardnumber">Card number of account.</param>
        /// <returns>True or false.</returns>
        public bool IsHaveShop(int cardnumber) => Get(p => p.CardNumber == cardnumber).Any();
    }
}