// <copyright file="ProductList.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PayingSystem.DataAccessLayer.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Model of product list in database.
    /// </summary>
    public class ProductList
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductList"/> class.
        /// </summary>
        public ProductList()
        {
            Products = new HashSet<Product>();
        }

        /// <summary>
        /// Gets or sets unique product list id.
        /// </summary>
        public int ProductListId { get; set; }

        /// <summary>
        /// Gets or sets shopName this list belong to .
        /// </summary>
        public string ShopName { get; set; }

        /// <summary>
        /// Gets or sets addressid.
        /// </summary>
        public int AddressId { get; set; }

        /// <summary>
        /// Gets or sets shop this list belong to.
        /// </summary>
        public virtual Shop Shops { get; set; }

        /// <summary>
        /// Gets or sets collection of proucts in this product list.
        /// </summary>
        public virtual ICollection<Product> Products { get; set; }

        /// <summary>
        /// Print products in this product list.
        /// </summary>
        /// <returns>string information.</returns>
        public string PrintBase()
        {
            int count = 1;
            string products = string.Empty;

            foreach (var i in Products)
            {
                products += $"{count++}){i.PrintBase()}";
            }

            return $"{products}";
        }
    }
}
