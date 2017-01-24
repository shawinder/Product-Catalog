#region File Attributes

// Product Catalog  Project: ProductCatalog.Data
// File:  LookupsUnitOfWork.cs
// Created By: Shawinder Sekhon 
// https://github.com/shawinder/product-catalog

#endregion

namespace ProductCatalog.Data.UnitsOfWork
{
    #region Includes

    using System;

    using Repositories;
    using Repositories.Interfaces;
    using Interfaces;
   
    #endregion
    
    public class LookupsUnitOfWork : BaseUnitOfWork, ILookupsUnitOfWork
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public LookupsUnitOfWork(CatalogContext context)
            : base(context)
        {
            _productRepository = new ProductRepository(context);
            _categoryRepository = new CategoryRepository(context);
        }

        public LookupsUnitOfWork()
            : base(new CatalogContext())
        {
            _productRepository = new ProductRepository(Context);
            _categoryRepository = new CategoryRepository(Context);
        }

        #region ILookupUnitOfWork Members

        public IProductRepository ProductRepository
        {
            get
            {
                return _productRepository;
            }
        }

        public ICategoryRepository CategoryRepository
        {
            get
            {
                return _categoryRepository;
            }
        }

        #endregion

    }
}
