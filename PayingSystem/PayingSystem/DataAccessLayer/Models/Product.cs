// <copyright file="Product.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PayingSystem.DataAccessLayer.Models
{
    /// <summary>
    /// Model of product in database.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Gets or sets unique id of product.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets unique id of product list.
        /// </summary>
        public int ProductListId { get; set; }

        /// <summary>
        /// Gets or sets unique id of product name.
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets price of product.
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Gets or sets product list.
        /// </summary>
        public virtual ProductList ProductList { get; set; }

        /// <summary>
        /// Print information about product.
        /// </summary>
        /// <returns>string information.</returns>
        public string PrintBase() => $"{ProductName,-25}{Price,10}грн";
    }
}
