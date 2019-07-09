// <copyright file="Page.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PayingSystem.PresentationLayer.View
{
    using PayingSystem.BusinessLayer;
    using PayingSystem.BusinessLayer.DTO_s;

    /// <summary>
    /// Base class for Pages.
    /// </summary>
    public abstract class Page
    {
        /// <summary>
        /// DataProvider.
        /// </summary>
        protected DataProvider _dataProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="Page"/> class.
        /// </summary>
        /// <param name="dataProvider">DataProvider.</param>
        protected Page(DataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Page"/> class.
        /// </summary>
        /// <param name="dataProvider">DataProvider.</param>
        /// <param name="account">Account.</param>
        protected Page(DataProvider dataProvider, AccountDTO account)
        {
            _dataProvider = dataProvider;
            Account = account;
        }

        /// <summary>
        /// Gets account that uses program.
        /// </summary>
        protected AccountDTO Account { get; }

        /// <summary>
        /// Start displaying page.
        /// </summary>
        public virtual void Display()
        {
        }

        /// <summary>
        /// print main data of page.
        /// </summary>
        public virtual void Print()
        {
        }
    }
}
