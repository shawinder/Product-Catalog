#region File Attributes

// Product Catalog  Project: ProductCatalog.Service.Context
// File:  CatalogService.cs
// Created By: Shawinder Sekhon 
// https://github.com/shawinder/product-catalog

#endregion

namespace ProductCatalog.Service.Context
{
    #region Includes

    using System;
    using System.Linq;
    using System.Dynamic;
    using System.Collections.Generic;

    using Data.Models;
    using Data.UnitsOfWork;
    using AutoMapper;
    using Data.Repositories.Interfaces;

    #endregion

    public class CatalogService : ICatalogService
    {
        #region Implementation of ICatalogService

        #region Get Types

        public ICollection<Product> GetProducts(bool all = false)
        {
            var result = new List<Product>();

            using (var uow = new LookupsUnitOfWork())
            {
                var raw = uow.ProductRepository.GetProducts(all);
                Mapper.CreateMap<Product, Product>();
                result = Mapper.Map<ICollection<Product>, List<Product>>(raw);
            }

            return result;
        }

        public ICollection<Product> GetProductsByCategory(string CategoryName = null, bool all = false)
        {
            var result = new List<Product>();

            using (var uow = new LookupsUnitOfWork())
            {
                var raw = uow.ProductRepository.GetProductByCategory(CategoryName, all);
                Mapper.CreateMap<Product, Product>();
                result = Mapper.Map<ICollection<Product>, List<Product>>(raw);
            }

            return result;
        }

        public Product FindProduct(Guid? ProductId)
        {
            var result = new List<Product>();

            using (var uow = new LookupsUnitOfWork())
            {
                var raw = uow.ProductRepository.GetProducts();
                Mapper.CreateMap<Product, Product>();
                result = Mapper.Map<ICollection<Product>, List<Product>>(raw);
            }

            return result.Find(c => c.ProductId.Equals(ProductId));
        }

        public ICollection<Category> GetCategories(bool all = false)
        {
            var result = new List<Category>();

            using (var uow = new LookupsUnitOfWork())
            {
                var raw = uow.CategoryRepository.GetCategories(all);
                Mapper.CreateMap<Category, Category>();
                result = Mapper.Map<ICollection<Category>, List<Category>>(raw);
            }

            return result;
        }
        
        public Category FindCategory(Guid? CategoryId)
        {
            var result = new List<Category>();

            using (var uow = new LookupsUnitOfWork())
            {
                var raw = uow.CategoryRepository.GetCategories();
                Mapper.CreateMap<Category, Category>();
                result = Mapper.Map<ICollection<Category>, List<Category>>(raw);
            }

            return result.Find(c=>c.CategoryId.Equals(CategoryId));
        }
        
        #endregion

        #region Create Types

        public void CreateProduct(Product model)
        {
            //using (var uow = new LookupsUnitOfWork())
            //{
            //    uow.LookupsRepository.CreateProduct(model);
            //    uow.Save();
            //}
        }

        public void CreateCategory(Category model)
        {
            //using (var uow = new LookupsUnitOfWork())
            //{
            //    uow.LookupsRepository.CreateCategory(model);
            //    uow.Save();
            //}
        }

        #endregion

        #region Update Types

        public void UpdateProduct(Product model)
        {
            //using (var uow = new LookupsUnitOfWork())
            //{
            //    uow.LookupsRepository.UpdateProduct(model);
            //    uow.Save();
            //}
        }

        public void UpdateCategory(Category model)
        {
            //using (var uow = new LookupsUnitOfWork())
            //{
            //    uow.LookupsRepository.UpdateCategory(model);
            //    uow.Save();
            //}
        }

        #endregion

        #endregion
    }
}
