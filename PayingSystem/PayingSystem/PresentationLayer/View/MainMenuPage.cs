// <copyright file="MainMenuPage.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PayingSystem.PresentationLayer.View
{
    using System;
    using PayingSystem.BusinessLayer;
    using PayingSystem.BusinessLayer.DTO_s;

    /// <summary>
    /// Class for MainMenu.
    /// </summary>
    public class MainMenuPage : Page
    {
        private readonly MyAccountPage _myAccountPage;
        private ShopPage _shopPage;
        private ShopManagerPage _shopManagerPage;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainMenuPage"/> class.
        /// </summary>
        /// <param name="dataProvider">DataProvider.</param>
        /// <param name="account">Account.</param>
        public MainMenuPage(DataProvider dataProvider, AccountDTO account)
            : base(dataProvider, account)
        {
            _myAccountPage = new MyAccountPage(_dataProvider, account);
        }

        /// <inheritdoc/>
        public override void Display()
        {
            Console.Clear();
            Print();

            switch (Console.ReadKey().KeyChar)
            {
                case '1':
                    _myAccountPage.Display();
                    Display();
                    break;
                case '2':
                    _shopPage = new ShopPage(_dataProvider, Account, _dataProvider.ChooseShopByUser());
                    _shopPage.Display();
                    Display();
                    break;
                case '3':
                    _dataProvider.ShopRegistration(Account.CardNumber);
                    Display();
                    break;
                case '4':
                    _shopManagerPage = new ShopManagerPage(_dataProvider, _dataProvider.ChooseShopByOwner(Account.CardNumber));
                    _shopManagerPage.Display();
                    Display();
                    break;
                case '0':
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Input is not valid");
                    Display();
                    break;
            }
        }

        /// <inheritdoc/>
        public override void Print()
        {
            Console.Clear();
            Console.WriteLine($"Hello {Account.Client.FirstName} {Account.Client.LastName}\n1)My Account\n2)List of shops\n3)Register new shop");
            if (_dataProvider.IsHaveShop(Account.CardNumber))
            {
                Console.WriteLine("4)MyShops");
            }

            Console.WriteLine("0)Exit");
        }
    }
}
