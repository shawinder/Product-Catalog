#region File Attributes

// Product Catalog  Project: ProductCatalog.Website
// File:  ProductController.cs
// Created By: Shawinder Sekhon 
// https://github.com/shawinder/product-catalog

#endregion

namespace ProductCatalog.Website.Areas.Manager.Controllers
{
    #region Includes

    using System;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using System.Collections.Generic;

    using Data;
    using Data.Models;
    using Service.Context;
    using Service.Context.Loader;

    #endregion

    public class ProductsController : Controller
    {
        private readonly WcfServiceInvoker _wcfService;
        private CatalogContext db = new CatalogContext();

        public ProductsController()
        {
            _wcfService = new WcfServiceInvoker();
        }

        // GET: Manager/Products
        public ActionResult Index()
        {
            return View(GetProducts());
        }

        // GET: Manager/Products/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Manager/Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(Helpers.CategoryTree.Traverse(db), "CategoryId", "CategoryName");
            return View();
        }

        // POST: Manager/Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductSku,ProductName,ProductDesc,ProductPrice,CategoryId,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn,IsActive,SortOrder")] Product product)
        {
            if (ModelState.IsValid)
            {
                product.ProductId = Guid.NewGuid();
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(Helpers.CategoryTree.Traverse(db), "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }

        // GET: Manager/Products/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = _wcfService.InvokeService<ICatalogService, Product>(
                            (svc) => svc.FindProduct(id));

            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(Helpers.CategoryTree.Traverse(db), "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }

        // POST: Manager/Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductSku,ProductName,ProductDesc,ProductPrice,CategoryId,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn,IsActive,SortOrder")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(Helpers.CategoryTree.Traverse(db), "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }

        // GET: Manager/Products/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = _wcfService.InvokeService<ICatalogService, Product>(
                            (svc) => svc.FindProduct(id));
            
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Manager/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Product product = _wcfService.InvokeService<ICatalogService, Product>(
                            (svc) => svc.FindProduct(id));

            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        #region Private Methods

        private ICollection<Product> GetProducts(bool all = false)
        {
            //return _wcfService.InvokeService<ICatalogService, ICollection<Product>>(
            //                (svc) => svc.GetProducts(all));

            return db.Products.Include(c => c.Category).ToList();
        }

        #endregion

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
