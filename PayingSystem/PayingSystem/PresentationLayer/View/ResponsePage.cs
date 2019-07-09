// <copyright file="ResponsePage.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PayingSystem.PresentationLayer.View
{
    using System;
    using PayingSystem.BusinessLayer;
    using PayingSystem.BusinessLayer.DTO_s;

    /// <summary>
    /// Class for Response on buying product.
    /// </summary>
    public class ResponsePage : Page
    {
        private readonly double _totalPrice;
        private readonly int _shopCardNumber;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponsePage"/> class.
        /// </summary>
        /// <param name="dataProvider">DataProvider.</param>
        /// <param name="account">Account.</param>
        /// <param name="shopCardNumber">ShopCardNumber.</param>
        /// <param name="totalPrice">TotalPrice.</param>
        public ResponsePage(DataProvider dataProvider, AccountDTO account, int shopCardNumber, double totalPrice)
            : base(dataProvider, account)
        {
            _shopCardNumber = shopCardNumber;
            _totalPrice = totalPrice;
        }

        /// <inheritdoc/>
        public override void Display()
        {
            if (Account.Balance < _totalPrice)
            {
                PrintNegative();
            }
            else
            {
                _dataProvider.SendMoney(Account, _shopCardNumber, -_totalPrice);
                PrintPositive();
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Print positive answer.
        /// </summary>
        protected void PrintPositive()
        {
            Console.Clear();
            Console.WriteLine($"Your order is accepted and will be delivered to {Account.Client.Address.Print()} in {DateTime.Now.AddDays(3).Date} ");
        }

        /// <summary>
        /// Print negative answer.
        /// </summary>
        protected void PrintNegative()
        {
            Console.Clear();
            Console.WriteLine("Sorry your balance is too low");
        }
    }
}
