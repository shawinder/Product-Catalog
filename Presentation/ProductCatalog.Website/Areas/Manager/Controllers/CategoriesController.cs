#region File Attributes

// Product Catalog  Project: ProductCatalog.Website
// File:  CategoriesController.cs
// Created By: Shawinder Sekhon 
// https://github.com/shawinder/product-catalog

#endregion

namespace ProductCatalog.Website.Areas.Manager.Controllers
{
    #region Includes

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;

    using Data;
    using Data.Models;
    using Service.Context;
    using Service.Context.Loader;
    
    #endregion

    public class CategoriesController : Controller
    {
        private readonly WcfServiceInvoker _wcfService;
        CatalogContext db = new CatalogContext();
        
        public CategoriesController()
        {
            _wcfService = new WcfServiceInvoker();
        }

        // GET: Manager/Categories
        public ActionResult Index()
        {
            return View(GetCategories());
        }

        // GET: Manager/Categories/Details/5
        //public ActionResult Details(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
            
        //    Category category = db.Categories.Find(id);

        //    if (category == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(category);
        //}

        // GET: Manager/Categories/Create
        public ActionResult Create()
        {
            ViewBag.ParentId = new SelectList(Helpers.CategoryTree.Traverse(db), "ParentId", "ParentName");
            return View();
        }

        // POST: Manager/Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryId,CategoryName,CreatedOn,UpdatedBy,UpdatedOn,IsActive,SortOrder")] Category category)
        {
            var parentId = Request["ParentId"];

            if (ModelState.IsValid)
            {
                Helpers.CategoryTree.AddNode(db, new Guid(parentId), category.CategoryName);
                //category.CategoryId = Guid.NewGuid();
                //db.Categories.Add(category);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            ViewBag.ParentId = new SelectList(Helpers.CategoryTree.Traverse(db), "ParentId", "ParentName", parentId);
            return View(category);
        }

        // GET: Manager/Categories/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Category category = _wcfService.InvokeService<ICatalogService, Category>(
                            (svc) => svc.FindCategory(id));
            
            if (category == null)
            {
                return HttpNotFound();
            }

            var parent = Helpers.CategoryTree.FindParent(db, category.LeftNode, category.RightNode).FirstOrDefault();

            //Used to compare parent selection for changes
            ViewBag.OldParentId = parent.ParentId;

            ViewBag.ParentId = new SelectList(Helpers.CategoryTree.Traverse(db), "ParentId", "ParentName", parent.ParentId);
            return View(category);
        }

        // POST: Manager/Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryId,CategoryName,LeftNode,RightNode,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn,IsActive,SortOrder,ParentId")] Category category)
        {
            var oldParentId = Request["OldParentId"];
            var parentId = Request["ParentId"];

            if (ModelState.IsValid)
            {
                //Check If parent is changed
                if (parentId != oldParentId)
                {
                    //Delete node from current location
                    Helpers.CategoryTree.DeleteNode(db, category.CategoryId);

                    //Re-Add the node to new location
                    Helpers.CategoryTree.AddNode(db, new Guid(parentId), category.CategoryName);
                }
                else
                {
                    db.Entry(category).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }

            //Used to compare parent selection for changes
            ViewBag.OldParentId = oldParentId;

            ViewBag.ParentId = new SelectList(Helpers.CategoryTree.Traverse(db), "ParentId", "ParentName", parentId);
            return View(category);
        }

        // GET: Manager/Categories/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Category category = _wcfService.InvokeService<ICatalogService, Category>(
                            (svc) => svc.FindCategory(id));
            
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Manager/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Helpers.CategoryTree.DeleteNode(db, id);
            //Category category = db.Categories.Find(id);
            //db.Categories.Remove(category);
            //db.SaveChanges();

            return RedirectToAction("Index");
        }

        #region Private Methods

        private ICollection<Category> GetCategories(bool all = false)
        {
            return _wcfService.InvokeService<ICatalogService, ICollection<Category>>(
                            (svc) => svc.GetCategories(all));
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
