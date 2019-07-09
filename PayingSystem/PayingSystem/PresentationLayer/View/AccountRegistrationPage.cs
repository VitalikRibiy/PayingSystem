// <copyright file="AccountRegistrationPage.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PayingSystem.PresentationLayer.View
{
    using System;
    using PayingSystem.BusinessLayer;

    /// <summary>
    /// Page for Account registration.
    /// </summary>
    public class AccountRegistrationPage : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountRegistrationPage"/> class.
        /// </summary>
        /// <param name="dataProvider">DataProvider.</param>
        public AccountRegistrationPage(DataProvider dataProvider)
            : base(dataProvider)
        {
        }

        /// <inheritdoc/>
        public override void Display()
        {
            Print();
            _dataProvider.AccountRegistration();
        }

        /// <inheritdoc/>
        public override void Print()
        {
            Console.Clear();
        }
    }
}
