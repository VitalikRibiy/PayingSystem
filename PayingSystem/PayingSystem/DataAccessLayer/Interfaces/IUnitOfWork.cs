// <copyright file="IUnitOfWork.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PayingSystem.DataAccessLayer.Interfaces
{
    using System;

    /// <summary>
    /// Interface that implement Unit of work pattern.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Save changes that were done in database.
        /// </summary>
        void SaveChanges();
    }
}
