// <copyright file="ProductListDTO.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PayingSystem.BusinessLayer.DTO_s
{
    using System.Collections.Generic;

    /// <summary>
    /// DTO for address.
    /// </summary>
    public class ProductListDTO
    {
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
        public virtual ShopDTO Shops { get; set; }

        /// <summary>
        /// Gets or sets collection of proucts in this product list.
        /// </summary>
        public virtual ICollection<ProductDTO> Products { get; set; }

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
