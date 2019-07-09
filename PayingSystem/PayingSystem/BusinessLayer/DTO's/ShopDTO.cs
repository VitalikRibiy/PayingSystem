// <copyright file="ShopDTO.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PayingSystem.BusinessLayer.DTO_s
{
    using System.Collections.Generic;

    /// <summary>
    /// DTO for address.
    /// </summary>
    public class ShopDTO
    {
        /// <summary>
        /// Gets or sets shop name.
        /// </summary>
        public string ShopName { get; set; }

        /// <summary>
        /// Gets or sets address id.
        /// </summary>
        public int AddressId { get; set; }

        /// <summary>
        /// Gets or sets card number.
        /// </summary>
        public int CardNumber { get; set; }

        /// <summary>
        /// Gets or sets address.
        /// </summary>
        public virtual AddressDTO Address { get; set; }

        /// <summary>
        /// Gets or sets account.
        /// </summary>
        public virtual AccountDTO Account { get; set; }

        /// <summary>
        /// Gets or sets collection of product lists.
        /// </summary>
        public virtual ICollection<ProductListDTO> ProductLists { get; set; }

        /// <summary>
        /// Print information about shop.
        /// </summary>
        /// <returns>string information.</returns>
        public string PrintBase() => $"{ShopName,-10}{Address.PrintBase()}";

        /// <summary>
        /// Print information about shop including products.
        /// </summary>
        /// <returns>string information.</returns>
        public string PrintTotal()
        {
            string productList = string.Empty;
            foreach (var i in ProductLists)
            {
                productList += i.PrintBase();
            }

            return $"{ShopName}{Address.PrintBase()},{productList}";
        }
    }
}
