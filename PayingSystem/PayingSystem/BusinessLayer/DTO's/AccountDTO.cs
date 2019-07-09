// <copyright file="AccountDTO.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PayingSystem.BusinessLayer.DTO_s
{
    using System;

    /// <summary>
    /// DTO for account.
    /// </summary>
    public class AccountDTO
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountDTO"/> class.
        /// </summary>
        public AccountDTO()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountDTO"/> class.
        /// </summary>
        /// <param name="cardNumber">Card number.</param>
        /// <param name="expire">Expire date.</param>
        /// <param name="balance">Balance.</param>
        /// <param name="hashPassword">Hashed password.</param>
        public AccountDTO(int cardNumber, DateTime expire, int balance, string hashPassword)
        {
            CardNumber = cardNumber;
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
        public virtual ClientDTO Client { get; set; }

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
