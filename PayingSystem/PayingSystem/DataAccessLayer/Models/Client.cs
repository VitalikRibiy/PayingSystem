// <copyright file="Client.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PayingSystem.DataAccessLayer.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Model of client in database.
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class.
        /// </summary>
        public Client()
        {
            Accounts = new HashSet<Account>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class.
        /// </summary>
        /// <param name="firstname">Firstname.</param>
        /// <param name="lastname">Lastname.</param>
        /// <param name="email">email.</param>
        /// <param name="phone">phone number.</param>
        /// <param name="address">address.</param>
        public Client(string firstname, string lastname, string email, string phone, Address address)
        {
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            PhoneNumber = phone;
            Address = address;
        }

        /// <summary>
        /// Gets or sets unique id of client.
        /// </summary>
        public int ClientId { get; set; }

        /// <summary>
        /// Gets or sets firstname.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets lastname.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets phone number.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets address id that respond to client address in Addresses table.
        /// </summary>
        public int AddressId { get; set; }

        /// <summary>
        /// Gets or sets address of this client.
        /// </summary>
        public virtual Address Address { get; set; }

        /// <summary>
        /// Gets or sets list of accounts that conneted to this client.
        /// </summary>
        public virtual ICollection<Account> Accounts { get; set; }

        /// <summary>
        /// Gets Fullname of client.
        /// </summary>
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        /// <summary>
        /// Print client information with address.
        /// </summary>
        /// <returns>string information.</returns>
        public string PrintTotal()
        {
            return $"{ClientId,5}{FirstName,20}{LastName,20}{Email,40}{PhoneNumber,12}\n\t{Address.PrintBase()}";
        }

        /// <summary>
        /// Print client information without address.
        /// </summary>
        /// <returns>string information.</returns>
        public string PrintBase()
        {
            return $"{ClientId,5}{FirstName,20}{LastName,20}{Email,40}{PhoneNumber,12}";
        }
    }
}
