#region File Attributes

// Product Catalog  Project: ProductCatalog.Data
// File:  ILookupsUnitOfWork.cs
// Created By: Shawinder Sekhon 
// https://github.com/shawinder/product-catalog

#endregion

namespace ProductCatalog.Data.UnitsOfWork.Interfaces
{
    #region Includes

    using Repositories.Interfaces;
    
    #endregion

    public interface ILookupsUnitOfWork : IUnitOfWork<CatalogContext>
    {
        IProductRepository ProductRepository { get; }

        ICategoryRepository CategoryRepository { get; }
    }
}
