// <copyright file="AccountRegistrationData.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PayingSystem.BusinessLayer.RegistrationData
{
    using System;
    using PayingSystem.BusinessLayer.DTO_s;

    /// <summary>
    /// Class used to create and register account.
    /// </summary>
    public class AccountRegistrationData
    {
        private readonly DataProvider _dataProvider;
        public string _country;
        public string _city;
        public string _street;
        public string _house;
        public int _flat;
        public string _firstName;
        public string _lastName;
        public string _email;
        public string _phone;
        public int _cardNumber;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountRegistrationData"/> class.
        /// </summary>
        public AccountRegistrationData()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountRegistrationData"/> class.
        /// </summary>
        /// <param name="dataProvider">Data provider object.</param>
        public AccountRegistrationData(DataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        /// <summary>
        /// Register account.
        /// </summary>
        /// <returns>AccountDTO.</returns>
        public void Register()
        {
            Console.Clear();
            Console.Write("Write card number:");
            _cardNumber = _dataProvider.TryParseCard("desirable");
            if (_dataProvider.IsInBase(_cardNumber))
            {
                Console.WriteLine("This number is already taken");
                Console.ReadKey();
                Register();
            }
            else
            {
                Console.Write("Firstname:");
                _firstName = Console.ReadLine();
                Console.Write("Lastname:");
                _lastName = Console.ReadLine();
                Console.Write("Email:");
                _email = Console.ReadLine();
                //Console.Write("Phone number:");
                _phone = _dataProvider.TryIntParse("Phone number").ToString();

                AddressDTO addressDTO = _dataProvider.CreateAddress();
                ClientDTO clientDTO = new ClientDTO(_firstName, _lastName, _email, _phone);
                _dataProvider.AddNewClient(clientDTO, addressDTO.Id, out int clientId);
                Console.Write("Password:");
                AccountDTO account = new AccountDTO(_cardNumber, DateTime.Now.AddYears(3), 1000, _dataProvider.GetHash(Console.ReadLine()));
                _dataProvider.AddNewAccount(account, clientId);
            }
        }
    }
}
