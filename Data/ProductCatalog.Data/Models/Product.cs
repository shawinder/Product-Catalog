#region File Attributes

// Product Catalog  Project: ProductCatalog.Data
// File:  Product.cs
// Created By: Shawinder Sekhon 
// https://github.com/shawinder/product-catalog

#endregion

namespace ProductCatalog.Data.Models
{
    #region Includes

    using System;
    using System.Runtime.Serialization;

    #endregion

    [DataContract]
    public class Product : Base
    {
        [DataMember]
        public Guid ProductId { get; set; }

        [DataMember]
        public string ProductSku { get; set; }

        [DataMember]
        public string ProductName { get; set; }

        [DataMember]
        public string ProductDesc { get; set; }

        [DataMember]
        public decimal ProductPrice { get; set; }

        [DataMember]
        public Guid CategoryId { get; set; }
        
        public virtual Category Category { get; set; }
    }
}
