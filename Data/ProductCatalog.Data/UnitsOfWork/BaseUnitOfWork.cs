#region File Attributes

// Product Catalog  Project: ProductCatalog.Data
// File:  BaseUnitOfWork.cs
// Created By: Shawinder Sekhon 
// https://github.com/shawinder/product-catalog

#endregion

namespace ProductCatalog.Data.UnitsOfWork
{
    #region Includes

    using System;
    using System.Data.Entity.Validation;

    #endregion

    public abstract class BaseUnitOfWork : IDisposable
    {
        private bool _disposed = false;

        public CatalogContext Context { get; private set; }

        protected BaseUnitOfWork(CatalogContext context)
        {
            Context = context;
        }

        public void Save()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                throw;
            }
        }

        #region IDisposable Members

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
