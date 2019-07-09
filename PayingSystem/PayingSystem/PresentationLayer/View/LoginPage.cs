// <copyright file="LoginPage.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PayingSystem.PresentationLayer.View
{
    using System;
    using PayingSystem.BusinessLayer;

    /// <summary>
    /// Class for loging.
    /// </summary>
    public class LoginPage : Page
    {
        private MainMenuPage _mainMenuPage;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginPage"/> class.
        /// </summary>
        /// <param name="dataProvider">DataProvider.</param>
        public LoginPage(DataProvider dataProvider)
            : base(dataProvider)
        {
        }

        /// <inheritdoc/>
        public override void Display()
        {
            while (_mainMenuPage == null)
            {
                Print();
                _mainMenuPage = new MainMenuPage(_dataProvider, _dataProvider.Login());
            }

            _mainMenuPage.Display();
        }

        /// <inheritdoc/>
        public override void Print()
        {
            Console.Clear();
            Console.WriteLine($"Hello");
        }
    }
}
