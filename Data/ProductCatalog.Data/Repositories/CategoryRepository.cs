#region File Attributes

// Product Catalog  Project: ProductCatalog.Data
// File:  CategoryRepository.cs
// Created By: Shawinder Sekhon 
// https://github.com/shawinder/product-catalog

#endregion

namespace ProductCatalog.Data.Repositories
{
    #region Includes

    using System.Linq;
    using System.Data;
    using System.Collections.Generic;

    using Interfaces;
    using System.Data.Entity;

    #endregion

    public class CategoryRepository : BaseRepository<Models.Category>, ICategoryRepository
    {
        public CategoryRepository(CatalogContext context)
            : base(context)
        { }

        #region IProductRepository Members

        public ICollection<Models.Category> GetCategories(bool all = false)
        {
            return all == true ? Context.Categories.ToList() : Context.Categories.Where(t => t.IsActive).OrderBy(o => o.SortOrder).ThenBy(o => o.CategoryName).ToList();
        }
        
        public void CreateCategory(Models.Category model)
        {
            Context.Categories.Add(model);
        }

        public void UpdateCategory(Models.Category model)
        {
            Context.Categories.Attach(model);
            Context.Entry(model).State = EntityState.Modified;
        }

        #endregion
    }
}
