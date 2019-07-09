// <copyright file="AuthenticationPage.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PayingSystem.PresentationLayer.View
{
    using System;
    using PayingSystem.BusinessLayer;

    /// <summary>
    /// Authentication class.
    /// </summary>
    public class AuthenticationPage : Page
    {
        private readonly LoginPage _loginPage;
        private readonly AccountRegistrationPage _registrationPage;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationPage"/> class.
        /// </summary>
        /// <param name="dataProvider">DataProvider.</param>
        public AuthenticationPage(DataProvider dataProvider)
            : base(dataProvider)
        {
            _loginPage = new LoginPage(dataProvider);
            _registrationPage = new AccountRegistrationPage(dataProvider);
        }

        /// <inheritdoc/>
        public override void Display()
        {
            Print();
            switch (Console.ReadKey().KeyChar)
            {
                case '1':
                    _loginPage.Display();
                    break;
                case '2':
                    _registrationPage.Display();
                    break;
                case '3':
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Wrong button :(");
                    Display();
                    break;
            }
        }

        /// <inheritdoc/>
        public override void Print()
        {
            Console.Clear();
            Console.WriteLine($"1)Login\n2)Registration\n3)Exit");
        }
    }
}