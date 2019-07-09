// <copyright file="AccountRepository.cs" company="PlaceholderCompany">
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
    public class AccountRepository : Repository<Account>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountRepository"/> class.
        /// </summary>
        /// <param name="context">Database context.</param>
        public AccountRepository(PayingSystemDataBaseContext context)
            : base(context)
        {
        }

        /// <inheritdoc/>
        public override IEnumerable<Account> Get() => DataSet.Include(p => p.Client).ThenInclude(c => c.Address).AsEnumerable();

        /// <summary>
        /// Overloaded Get fucntion for specified type.
        /// </summary>
        /// <param name="cardnumber">Card number of account.</param>
        /// <returns>Account object.</returns>
        public Account Get(int cardnumber)
        {
            var accounts = DataSet.Include(p => p.Client).ThenInclude(c => c.Address).Where(c => c.CardNumber == cardnumber).ToList();
            if (accounts.Count != 0)
            {
                return accounts.ElementAt(0);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Check if account with specified cardnumber is in database.
        /// </summary>
        /// <param name="cardnumber">Card number of account.</param>
        /// <returns>True or false.</returns>
        public bool IsInBase(int cardnumber)
        {
            foreach (var i in Get())
            {
                if (i.CardNumber == cardnumber)
                {
                    return true;
                }
            }

            return false;
        }

        /// <inheritdoc/>
        public override IEnumerable<Account> Get(Expression<Func<Account, bool>> predicate) => DataSet.Include(p => p.Client).Where(predicate).AsEnumerable();
    }
}
