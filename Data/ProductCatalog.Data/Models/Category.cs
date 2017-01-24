#region File Attributes

// Product Catalog  Project: ProductCatalog.Data
// File:  Category.cs
// Created By: Shawinder Sekhon 
// https://github.com/shawinder/product-catalog

#endregion

namespace ProductCatalog.Data.Models
{
    #region Includes

    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    
    #endregion

    [DataContract]
    public class Category : Base
    {
        [DataMember]
        public Guid CategoryId { get; set; }

        [DataMember]
        public string CategoryName { get; set; }

        [DataMember]
        public int LeftNode { get; set; }

        [DataMember]
        public int RightNode { get; set; }
        
        public ICollection<Product> Products { get; set; }
    }
}