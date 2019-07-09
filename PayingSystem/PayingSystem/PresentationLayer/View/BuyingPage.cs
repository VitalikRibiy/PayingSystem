// <copyright file="BuyingPage.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PayingSystem.PresentationLayer.View
{
    using System;
    using PayingSystem.BusinessLayer;
    using PayingSystem.BusinessLayer.DTO_s;

    /// <summary>
    /// Class for buying products.
    /// </summary>
    public class BuyingPage : Page
    {
        private readonly ProductDTO _product;
        private readonly int _numberOfProduct;
        private readonly int _shopCardNumber;
        private ResponsePage _responsePage;

        /// <summary>
        /// Initializes a new instance of the <see cref="BuyingPage"/> class.
        /// </summary>
        /// <param name="dataProvider">DataProvider.</param>
        /// <param name="account">Account.</param>
        /// <param name="shopCardNumber">Shop'sCardNumber.</param>
        /// <param name="product">Product.</param>
        /// <param name="numberOfProduct">Number of products to buy.</param>
        public BuyingPage(DataProvider dataProvider, AccountDTO account, int shopCardNumber, ProductDTO product, int numberOfProduct)
            : base(dataProvider, account)
        {
            _shopCardNumber = shopCardNumber;
            _product = product;
            _numberOfProduct = numberOfProduct;
        }

        /// <inheritdoc/>
        public override void Display()
        {
            Print();
            switch (Console.ReadKey().KeyChar)
            {
                case '1':
                    _responsePage = new ResponsePage(_dataProvider, Account, _shopCardNumber, _product.Price * _numberOfProduct);
                    _responsePage.Display();
                    break;
                case '2':
                    break;
                default:
                    Console.WriteLine("Input is not valid");
                    Console.ReadKey();
                    Display();
                    break;
            }
        }

        /// <inheritdoc/>
        public override void Print()
        {
            Console.Clear();
            Console.WriteLine($"Your ordered {_numberOfProduct} {_product.ProductName} ,{_product.Price} each.\t Total Price:{_product.Price * _numberOfProduct}\nDo you really want to buy it ?\n1)Yes\t2)No ");
        }
    }
}
