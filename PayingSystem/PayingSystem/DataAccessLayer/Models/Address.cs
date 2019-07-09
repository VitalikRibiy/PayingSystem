// <copyright file="Address.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PayingSystem.DataAccessLayer.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Model of address in database.
    /// </summary>
    public class Address
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Address"/> class.
        /// </summary>
        public Address()
        {
            Clients = new HashSet<Client>();
            Shops = new HashSet<Shop>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Address"/> class.
        /// </summary>
        /// <param name="country">Country.</param>
        /// <param name="city">City.</param>
        /// <param name="street">Street.</param>
        /// <param name="house">House.</param>
        /// <param name="flat">Flat.</param>
        public Address(string country, string city, string street, string house, int? flat)
        {
            Country = country;
            City = city;
            Street = street;
            House = house;
            Flat = flat;
        }

        /// <summary>
        /// Gets or sets unique id of address.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets country.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets city.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets street.
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Gets or sets house.
        /// </summary>
        public string House { get; set; }

        /// <summary>
        /// Gets or sets flat.
        /// </summary>
        public int? Flat { get; set; }

        /// <summary>
        /// Gets or sets all clients that connecte to this address.
        /// </summary>
        public virtual ICollection<Client> Clients { get; set; }

        /// <summary>
        /// Gets or sets all shops that connecte to this address.
        /// </summary>
        public virtual ICollection<Shop> Shops { get; set; }

        /// <summary>
        /// Print address with tabulation.
        /// </summary>
        /// <returns>string information.</returns>
        public string PrintBase()
        {
            return $"{Country,15}{City,15}{Street,25}{House,5}{Flat,5}";
        }

        /// <summary>
        /// Print address in csv format.
        /// </summary>
        /// <returns>string information.</returns>
        public string Print()
        {
            return $"{Country},{City},{Street},{House},{Flat}";
        }
    }
}