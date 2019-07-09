// <copyright file="ShopRegistrationData.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PayingSystem.BusinessLayer.RegistrationData
{
    using System;
    using PayingSystem.BusinessLayer.DTO_s;

    /// <summary>
    /// Class used to create and register shop.
    /// </summary>
    public class ShopRegistrationData
    {
        private DataProvider _dataProvider;
        private string _shopName;
        private AddressDTO _address;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShopRegistrationData"/> class.
        /// </summary>
        public ShopRegistrationData()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShopRegistrationData"/> class.
        /// </summary>
        /// <param name="dataProvider">Data provider object.</param>
        public ShopRegistrationData(DataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        /// <summary>
        /// Start registration process.
        /// </summary>
        /// <param name="cardnumber">Card number.</param>
        /// <returns>Shop object.</returns>
        public ShopDTO Register(int cardnumber)
        {
            Console.Clear();
            Console.Write("Write shop name:");
            _shopName = Console.ReadLine();
            _address = _dataProvider.CreateAddress();

            return new ShopDTO
            {
                CardNumber = cardnumber,
                ShopName = _shopName,
                AddressId = _address.Id,
            };
        }
    }
}
