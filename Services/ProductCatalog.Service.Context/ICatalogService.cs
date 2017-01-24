#region File Attributes

// Product Catalog  Project: ProductCatalog.Service.Context
// File:  ICatalogService.cs
// Created By: Shawinder Sekhon 
// https://github.com/shawinder/product-catalog

#endregion

namespace ProductCatalog.Service.Context
{
    #region Includes

    using System;
    using System.Collections.Generic;
    using System.ServiceModel;

    using Data.Models;

    #endregion

    [ServiceContract]
    public interface ICatalogService
    {
        #region Get Types

        [OperationContract]
        ICollection<Product> GetProducts(bool all = false);

        [OperationContract]
        ICollection<Product> GetProductsByCategory(string CategoryName = null, bool all = false);

        [OperationContract]
        ICollection<Category> GetCategories(bool all = false);

        [OperationContract]
        Product FindProduct(Guid? ProductId);

        [OperationContract]
        Category FindCategory(Guid? CategoryId);

        #endregion

        #region Create Types

        [OperationContract]
        void CreateProduct(Product model);

        [OperationContract]
        void CreateCategory(Category model);

        #endregion

        #region Update Types

        [OperationContract]
        void UpdateProduct(Product model);

        [OperationContract]
        void UpdateCategory(Category model);

        #endregion
    }

}
