// <copyright file="ShopManagerPage.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PayingSystem.PresentationLayer.View
{
    using System;
    using System.Linq;
    using PayingSystem.BusinessLayer;
    using PayingSystem.BusinessLayer.DTO_s;

    /// <summary>
    /// Class for shop managment.
    /// </summary>
    public class ShopManagerPage : Page
    {
        private readonly ShopDTO _shopDTO;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShopManagerPage"/> class.
        /// </summary>
        /// <param name="dataProvider">DataProvider.</param>
        /// <param name="shopDTO">ShopDTO.</param>
        public ShopManagerPage(DataProvider dataProvider, ShopDTO shopDTO)
            : base(dataProvider)
        {
            _shopDTO = shopDTO;
        }

        /// <inheritdoc/>
        public override void Display()
        {
            Print();
            switch (Console.ReadKey().KeyChar)
            {
                case '+':
                    _dataProvider.AddNewProduct(_dataProvider.CreateProduct(_shopDTO.ProductLists.First().ProductListId), _shopDTO);
                    Display();
                    break;
                case '-':
                    if (_shopDTO.ProductLists.First().Products.Count == 0)
                    {
                        Console.WriteLine("There are no products to delete");
                        Console.ReadKey();
                        break;
                    }
                    else
                    {
                        _dataProvider.DeleteProduct(_shopDTO);
                        Display();
                        break;
                    }

                case '0':
                    break;
                default:
                    Console.WriteLine("Choose button from options please");
                    break;
            }
        }

        /// <inheritdoc/>
        public override void Print()
        {
            Console.Clear();
            int productCount = 1;
            if (_shopDTO.ProductLists.Count != 0)
            {
                foreach (ProductDTO p in _shopDTO.ProductLists.First().Products)
                {
                    Console.WriteLine($"{productCount++}){p.PrintBase()}");
                }
            }
            else
            {
                Console.Write("Product list is empty");
            }

            Console.WriteLine($"\n+)Add Product\n-)Remove Product\n0)Back");
            Console.Write("Choose Product or Get back:");
        }
    }
}
