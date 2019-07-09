// <copyright file="UnitOfWork.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PayingSystem.DataAccessLayer.Implementations
{
    using PayingSystem.DataAccessLayer.Interfaces;
    using PayingSystem.DataAccessLayer.Repositories;

    /// <summary>
    /// Class that implements IUnitOfWork interface.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="context">Database context.</param>
        public UnitOfWork(PayingSystemDataBaseContext context)
        {
            Context = context;
            AccountRepository = new AccountRepository(context);
            ClientRepository = new ClientRepository(context);
            AddressRepository = new AddressRepository(context);
            ShopRepository = new ShopRepository(context);
            ProductListRepository = new ProductListRepository(context);
            ProductRepository = new ProductRepository(context);
        }

        /// <summary>
        /// Gets accountRepository instance.
        /// </summary>
        public AccountRepository AccountRepository { get; }

        /// <summary>
        /// Gets client repository instance.
        /// </summary>
        public ClientRepository ClientRepository { get; }

        /// <summary>
        /// Gets address repository instance.
        /// </summary>
        public AddressRepository AddressRepository { get; }

        /// <summary>
        /// Gets shop repository instance.
        /// </summary>
        public ShopRepository ShopRepository { get; }

        /// <summary>
        /// Gets productList repository instance.
        /// </summary>
        public ProductListRepository ProductListRepository { get; }

        /// <summary>
        /// Gets product repository instance.
        /// </summary>
        public ProductRepository ProductRepository { get; }

        /// <summary>
        /// Gets database context instance.
        /// </summary>
        private PayingSystemDataBaseContext Context { get; }

        /// <inheritdoc/>
        public void Dispose()
        {
            Context.Dispose();
        }

        /// <inheritdoc/>
        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}
