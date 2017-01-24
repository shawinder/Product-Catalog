#region File Attributes

// Product Catalog  Project: ProductCatalog.Website
// File:  HomeController.cs
// Created By: Shawinder Sekhon 
// https://github.com/shawinder/product-catalog

#endregion

namespace ProductCatalog.Website.Controllers
{
    #region Includes

    using System.Web.Mvc;
    using System.Collections.Generic;
    using Data.Models;
    using Service.Context;
    using Service.Context.Loader;
    using PagedList;

    #endregion

    public class HomeController : Controller
    {
        private readonly WcfServiceInvoker _wcfService;

        public HomeController()
        {
            _wcfService = new WcfServiceInvoker();
        }

        // GET: Products
        public ActionResult Index(string cat, int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            var products = GetProductsByCategory(cat);
            return View(products.ToPagedList(pageNumber, pageSize));
        }

        #region Private Methods

        private ICollection<Product> GetProductsByCategory(string CategoryName = null, bool all = false)
        {
            return _wcfService.InvokeService<ICatalogService, ICollection<Product>>(
                            (svc) => svc.GetProductsByCategory(CategoryName, all));
        }
        
        #endregion
    }
}