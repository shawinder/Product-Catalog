#region File Attributes

// Product Catalog  Project: ProductCatalog.Data
// File:  DBContext.cs
// Created By: Shawinder Sekhon 
// https://github.com/shawinder/product-catalog

#endregion

namespace ProductCatalog.Data
{
    #region Includes

    using System.Data.Entity;

    #endregion

    public class CatalogContext : DbContext
    {
        public CatalogContext()
            : base("name=CatalogContext")
        {
            //this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Models.Category> Categories { get; set; }
        public DbSet<Models.Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new Mappings.ProductMap());
            modelBuilder.Configurations.Add(new Mappings.CategoryMap());
        }
    }
}
