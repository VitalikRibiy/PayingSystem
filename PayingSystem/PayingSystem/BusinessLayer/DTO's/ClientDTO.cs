// <copyright file="ClientDTO.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PayingSystem.BusinessLayer.DTO_s
{
    /// <summary>
    /// DTO for address.
    /// </summary>
    public class ClientDTO
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClientDTO"/> class.
        /// </summary>
        public ClientDTO()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientDTO"/> class.
        /// </summary>
        /// <param name="firstName">Firstname.</param>
        /// <param name="lastName">Lastname.</param>
        /// <param name="email">email.</param>
        /// <param name="phone">phone number.</param>
        public ClientDTO(string firstName, string lastName, string email, string phone)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phone;
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
        public virtual AddressDTO Address { get; set; }

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
