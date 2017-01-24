#region File Attributes

// Product Catalog  Project: ProductCatalog.Data
// File:  Base.cs
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
    public abstract class Base
    {
        [DataMember]
        public Guid CreatedBy { get; set; }

        [DataMember]
        public DateTime? CreatedOn { get; set; }

        [DataMember]
        public Guid? UpdatedBy { get; set; }

        [DataMember]
        public DateTime? UpdatedOn { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public byte SortOrder { get; set; }
    }
}
