#region File Attributes

// Product Catalog  Project: ProductCatalog.Data
// File:  ProductMap.cs
// Created By: Shawinder Sekhon 
// https://github.com/shawinder/product-catalog

#endregion

namespace ProductCatalog.Data.Mappings
{
    #region Includes

    using System.Data.Entity.ModelConfiguration;
    using System.ComponentModel.DataAnnotations.Schema;

    #endregion

    public class ProductMap : EntityTypeConfiguration<Models.Product>
    {
        public ProductMap()
        {
            // Primary Key
            HasKey(t => t.ProductId);
            
            // Properties
            Property(t => t.ProductSku).IsRequired().HasMaxLength(150);
            Property(t => t.ProductName).IsRequired().HasMaxLength(150);
            Property(t => t.ProductDesc).HasMaxLength(500);
            Property(t => t.ProductPrice).IsRequired();

            // Table & column Mappings
            ToTable("Products");
            Property(t => t.ProductId).HasColumnName("ProductId").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Relationships
            HasRequired(t => t.Category).WithMany(t => t.Products).HasForeignKey(t => t.CategoryId);
        }
    } 
}
