#region File Attributes

// Product Catalog  Project: ProductCatalog.Data
// File:  ProductRepository.cs
// Created By: Shawinder Sekhon 
// https://github.com/shawinder/product-catalog

#endregion

namespace ProductCatalog.Data.Repositories
{
    #region Includes

    using System;
    using System.Linq;
    using System.Data;
    using System.Collections.Generic;

    using Interfaces;
    using System.Data.Entity;

    #endregion

    public class ProductRepository : BaseRepository<Models.Product>, IProductRepository
    {
        public ProductRepository(CatalogContext context)
            : base(context)
        { }

        #region IProductRepository Members

        public ICollection<Models.Product> GetProducts(bool all = false)
        {
            return all == true ? Context.Products.ToList() : Context.Products.Where(t => t.IsActive).OrderBy(o => o.SortOrder).ThenBy(o => o.Category.CategoryName).Include(c => c.Category).ToList();
        }

        public ICollection<Models.Product> GetProductByCategory(string CategoryName = null, bool all = false)
        {
            if (!String.IsNullOrEmpty(CategoryName))
            {
                var category = Context.Categories.ToList().Where(c => c.CategoryName.Equals(CategoryName)).FirstOrDefault();

                return category != null ? Context.Products.Where(p => p.IsActive && p.Category.LeftNode >= category.LeftNode && p.Category.RightNode <= category.RightNode).ToList() : null;
            }

            return all == true ? Context.Products.ToList() : Context.Products.Where(t => t.IsActive).ToList();

            //return (String.IsNullOrEmpty(CategoryName) || CategoryName == "All") ? (all == true ? Context.Products.ToList() : Context.Products.Where(t => t.IsActive).ToList()) : Context.Products.Where(p => p.IsActive && p.Category.CategoryName.Equals(CategoryName)).ToList();
        }

        public void CreateProduct(Models.Product model)
        {
            Context.Products.Add(model);
        }

        public void CreateCategory(Models.Category model)
        {
            Context.Categories.Add(model);
        }

        public void UpdateProduct(Models.Product model)
        {
            Context.Products.Attach(model);
            Context.Entry(model).State = EntityState.Modified;
        }

        public void UpdateCategory(Models.Category model)
        {
            Context.Categories.Attach(model);
            Context.Entry(model).State = EntityState.Modified;
        }

        #endregion
    }
}
