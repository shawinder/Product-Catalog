#region File Attributes

// Product Catalog  Project: ProductCatalog.Data
// File:  ICategoryRepository.cs
// Created By: Shawinder Sekhon 
// https://github.com/shawinder/product-catalog

#endregion

namespace ProductCatalog.Data.Repositories.Interfaces
{
    #region Includes

    using System.Collections.Generic;

    #endregion

    public interface ICategoryRepository : IRepository<Models.Category>
    {
        ICollection<Models.Category> GetCategories(bool all = false);

        void CreateCategory(Models.Category model);

        void UpdateCategory(Models.Category model);
    }
}
