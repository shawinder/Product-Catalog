#region File Attributes

// Product Catalog  Project: ProductCatalog.Data
// File:  IUnitOfWork.cs
// Created By: Shawinder Sekhon 
// https://github.com/shawinder/product-catalog

#endregion

namespace ProductCatalog.Data.UnitsOfWork.Interfaces
{
    #region Includes

    using System;
    using System.Data.Entity;

    #endregion

    public interface IUnitOfWork<out TContext> : IDisposable
        where TContext : DbContext
    {

        TContext Context { get; }

        void Save();

    }
}
