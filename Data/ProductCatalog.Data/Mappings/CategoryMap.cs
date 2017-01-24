#region File Attributes

// Product Catalog  Project: ProductCatalog.Data
// File:  CategoryMap.cs
// Created By: Shawinder Sekhon 
// https://github.com/shawinder/product-catalog

#endregion

namespace ProductCatalog.Data.Mappings
{
    #region Includes

    using System.Data.Entity.ModelConfiguration;
    using System.ComponentModel.DataAnnotations.Schema;

    #endregion

    public class CategoryMap : EntityTypeConfiguration<Models.Category>
    {
        public CategoryMap()
        {
            // Primary Key
            HasKey(t => t.CategoryId);

            // Properties
            Property(t => t.CategoryName).IsRequired().HasMaxLength(150);
            Property(t => t.LeftNode).IsRequired();
            Property(t => t.RightNode).IsRequired();

            // Table & Column Mappings
            ToTable("Categories");
            Property(t => t.CategoryId).HasColumnName("CategoryId").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
