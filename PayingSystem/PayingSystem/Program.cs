// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PayingSystem
{
    using PayingSystem.BusinessLayer;
    using PayingSystem.DataAccessLayer.Implementations;
    using PayingSystem.PresentationLayer.View;

    /// <summary>
    /// Entry class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point.
        /// </summary>
        public static void Main()
        {
            PayingSystemDataBaseContext db = new PayingSystemDataBaseContext();

            DataProvider dataProvider = new DataProvider(new UnitOfWork(db));

            AuthenticationPage authentication = new AuthenticationPage(dataProvider);
            authentication.Display();
        }
    }
}