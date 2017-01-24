#region File Attributes

// Product Catalog  Project: ProductCatalog.Data
// File:  IProductRepository.cs
// Created By: Shawinder Sekhon 
// https://github.com/shawinder/product-catalog

#endregion

namespace ProductCatalog.Data.Repositories.Interfaces
{
    #region Includes

    using System.Collections.Generic;

    #endregion

    public interface IProductRepository : IRepository<Models.Product>
    {
        ICollection<Models.Product> GetProducts(bool all = false);

        ICollection<Models.Product> GetProductByCategory(string CategoryName = null, bool all = false);

        void CreateProduct(Models.Product model);

        void UpdateProduct(Models.Product model);
    }
}
