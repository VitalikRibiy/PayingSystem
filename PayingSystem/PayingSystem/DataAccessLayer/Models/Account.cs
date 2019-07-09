// <copyright file="Account.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PayingSystem.DataAccessLayer.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Model of account in database.
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Account"/> class.
        /// </summary>
        public Account()
        {
            Shops = new HashSet<Shop>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Account"/> class.
        /// </summary>
        /// <param name="cardNumber">Card number.</param>
        /// <param name="clientId">Unique id of the client.</param>
        /// <param name="expire">Expire date.</param>
        /// <param name="balance">Current balance.</param>
        /// <param name="hashPassword">Hased password.</param>
        public Account(int cardNumber, int clientId, DateTime expire, double balance, string hashPassword)
        {
            CardNumber = cardNumber;
            ClientId = clientId;
            Expire = expire;
            Balance = balance;
            HashPassword = hashPassword;
        }

        /// <summary>
        /// Gets or sets card number.
        /// </summary>
        public int CardNumber { get; set; }

        /// <summary>
        /// Gets or sets client id.
        /// </summary>
        public int ClientId { get; set; }

        /// <summary>
        /// Gets or sets expiration date.
        /// </summary>
        public DateTime Expire { get; set; }

        /// <summary>
        /// Gets or sets balance.
        /// </summary>
        public double Balance { get; set; }

        /// <summary>
        /// Gets or sets HashPassword.
        /// </summary>
        public string HashPassword { get; set; }

        /// <summary>
        /// Gets or sets whoom acount this is.
        /// </summary>
        public virtual Client Client { get; set; }

        /// <summary>
        /// Gets or sets shops connected to this account.
        /// </summary>
        public virtual ICollection<Shop> Shops { get; set; }

        /// <summary>
        /// Print base information about account.
        /// </summary>
        /// <returns>string information.</returns>
        public string PrintBase()
        {
            return $"{CardNumber,10},{Expire,10},{Balance,10}";
        }

        /// <summary>
        /// Print all information about account and client.
        /// </summary>
        /// <returns>string information.</returns>
        public string PrintTotal()
        {
            return $"{CardNumber,10},{Expire,10},{Balance,10},{Client.PrintBase()}";
        }
    }
}