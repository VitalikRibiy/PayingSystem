// <copyright file="ShopPage.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PayingSystem.PresentationLayer.View
{
    using System;
    using System.Collections.Generic;
    using PayingSystem.BusinessLayer;
    using PayingSystem.BusinessLayer.DTO_s;

    /// <summary>
    /// class for shopping.
    /// </summary>
    public class ShopPage : Page
    {
        private readonly List<ProductDTO> _totalProducts;
        private readonly ShopDTO _shopDTO;
        private BuyingPage _buyingPage;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShopPage"/> class.
        /// </summary>
        /// <param name="dataProvider">DataProvider.</param>
        /// <param name="account">Account.</param>
        /// <param name="shopDTO">ShopDTO.</param>
        public ShopPage(DataProvider dataProvider, AccountDTO account, ShopDTO shopDTO)
            : base(dataProvider, account)
        {
            _shopDTO = shopDTO;
            _totalProducts = new List<ProductDTO>();
            foreach (ProductListDTO pl in _shopDTO.ProductLists)
            {
                foreach (ProductDTO p in pl.Products)
                {
                    _totalProducts.Add(p);
                }
            }
        }

        /// <inheritdoc/>
        public override void Display()
        {
            Print();
            int index = _dataProvider.TryIntParse();
            if (index != 0)
            {
                Console.Write("\nHow many you want to buy?:");
                int numberOfProduct = _dataProvider.TryIntParse();
                if (numberOfProduct == -1)
                {
                    Console.ReadKey();
                    Display();
                }

                _buyingPage = new BuyingPage(_dataProvider, Account, _shopDTO.CardNumber, _totalProducts[index - 1], numberOfProduct);
                _buyingPage.Display();
            }
        }

        /// <inheritdoc/>
        public override void Print()
        {
            Console.Clear();
            foreach (var i in _totalProducts)
            {
                Console.WriteLine($"{_totalProducts.IndexOf(i) + 1}){i.PrintBase()}");
            }

            Console.WriteLine("0)Back");
            Console.Write("Choose Product or Get back:");
        }
    }
}
