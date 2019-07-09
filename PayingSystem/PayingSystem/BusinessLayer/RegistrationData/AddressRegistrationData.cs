// <copyright file="AddressRegistrationData.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PayingSystem.BusinessLayer.RegistrationData
{
    using System;
    using PayingSystem.DataAccessLayer.Models;

    /// <summary>
    /// Class used to create and register address.
    /// </summary>
    public class AddressRegistrationData
    {
        private readonly DataProvider _dataProvider;
        private string _country;
        private string _city;
        private string _street;
        private string _house;
        private int _flat;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressRegistrationData"/> class.
        /// </summary>
        public AddressRegistrationData()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressRegistrationData"/> class.
        /// </summary>
        /// <param name="dataProvider">Data provider object.</param>
        public AddressRegistrationData(DataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        /// <summary>
        /// Start registration process.
        /// </summary>
        /// <returns>address object.</returns>
        public Address Register()
        {
            Console.Clear();
            Console.Write("Address\n\tCountry:");
            _country = Console.ReadLine();
            Console.Write("\tCity:");
            _city = Console.ReadLine();
            Console.Write("\tStreet:");
            _street = Console.ReadLine();
            Console.Write("\tHouse:");
            _house = Console.ReadLine();
            Console.Write("\tFlat:");
            try
            {
                _flat = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
            }

            return new Address
            {
                Country = _country,
                City = _city,
                Street = _street,
                House = _house,
                Flat = _flat,
            };
        }
    }
}
