#region File Attributes

// Product Catalog  Project: ProductCatalog.Data
// File:  CatalogInitializer.cs
// Created By: Shawinder Sekhon 
// https://github.com/shawinder/product-catalog

#endregion

namespace ProductCatalog.Data
{
    #region Includes

    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;

    #endregion

    public class CatalogInitializer : DropCreateDatabaseAlways<CatalogContext>
    {
        protected override void Seed(CatalogContext context)
        {
            context.Categories.AddOrUpdate(c => c.CategoryName,
               new Models.Category { CategoryId = Guid.NewGuid(), CategoryName = "All", LeftNode = 1, RightNode = 28, IsActive = true },
               new Models.Category
               {
                   CategoryId = Guid.NewGuid(),
                   CategoryName = "Computers",
                   LeftNode = 2,
                   RightNode = 21,
                   IsActive = true,
                   Products = new List<Models.Product> {
                               new Models.Product {ProductId = Guid.NewGuid(), ProductName = "Computer 1", ProductSku="C001", ProductPrice=500, IsActive=true },
                               new Models.Product {ProductId = Guid.NewGuid(), ProductName = "Computer 2", ProductSku="C002", ProductPrice=500 , IsActive=true}
                   }
               },
               new Models.Category
               {
                   CategoryId = Guid.NewGuid(),
                   CategoryName = "Accessories",
                   LeftNode = 3,
                   RightNode = 8,
                   IsActive = true,
                   Products = new List<Models.Product> {
                               new Models.Product {ProductId = Guid.NewGuid(), ProductName = "Accessory 1", ProductSku="AC001", ProductPrice=500, IsActive=true },
                               new Models.Product {ProductId = Guid.NewGuid(), ProductName = "Accessory 2", ProductSku="AC002", ProductPrice=500, IsActive=true }
                   }
               },
               new Models.Category
               {
                   CategoryId = Guid.NewGuid(),
                   CategoryName = "Keyboards",
                   LeftNode = 4,
                   RightNode = 5,
                   IsActive = true,
                   Products = new List<Models.Product> {
                               new Models.Product {ProductId = Guid.NewGuid(), ProductName = "Keyboards 1", ProductSku="KB001", ProductPrice=500, IsActive=true },
                               new Models.Product {ProductId = Guid.NewGuid(), ProductName = "Keyboards 2", ProductSku="KB002", ProductPrice=500 , IsActive=true}
                   }
               },
               new Models.Category
               {
                   CategoryId = Guid.NewGuid(),
                   CategoryName = "Mouse",
                   LeftNode = 6,
                   RightNode = 7,
                   IsActive = true,
                   Products = new List<Models.Product> {
                               new Models.Product {ProductId = Guid.NewGuid(), ProductName = "Mouse 1", ProductSku="MS001", ProductPrice=500, IsActive=true },
                               new Models.Product {ProductId = Guid.NewGuid(), ProductName = "Mouse 2", ProductSku="MS002", ProductPrice=500, IsActive=true }
                   }
               },
               new Models.Category
               {
                   CategoryId = Guid.NewGuid(),
                   CategoryName = "Tablets",
                   LeftNode = 9,
                   RightNode = 14,
                   IsActive = true,
                   Products = new List<Models.Product> {
                               new Models.Product {ProductId = Guid.NewGuid(), ProductName = "Tablets 1", ProductSku="TB001", ProductPrice=500, IsActive=true },
                               new Models.Product {ProductId = Guid.NewGuid(), ProductName = "Tablets 2", ProductSku="TB002", ProductPrice=500, IsActive=true }
                   }
               },
               new Models.Category
               {
                   CategoryId = Guid.NewGuid(),
                   CategoryName = "IPads",
                   LeftNode = 10,
                   RightNode = 11,
                   IsActive = true,
                   Products = new List<Models.Product> {
                               new Models.Product {ProductId = Guid.NewGuid(), ProductName = "IPads 1", ProductSku="IP001", ProductPrice=500, IsActive=true },
                               new Models.Product {ProductId = Guid.NewGuid(), ProductName = "IPads 2", ProductSku="IP002", ProductPrice=500, IsActive=true }
                   }
               },
               new Models.Category
               {
                   CategoryId = Guid.NewGuid(),
                   CategoryName = "Android Tablets",
                   LeftNode = 12,
                   RightNode = 13,
                   IsActive = true,
                   Products = new List<Models.Product> {
                               new Models.Product {ProductId = Guid.NewGuid(), ProductName = "Android Tablets 1", ProductSku="AT001", ProductPrice=500, IsActive=true },
                               new Models.Product {ProductId = Guid.NewGuid(), ProductName = "Android Tablets 2", ProductSku="AT002", ProductPrice=500, IsActive=true }
                   }
               },
               new Models.Category
               {
                   CategoryId = Guid.NewGuid(),
                   CategoryName = "Networking",
                   LeftNode = 15,
                   RightNode = 20,
                   IsActive = true,
                   Products = new List<Models.Product> {
                               new Models.Product {ProductId = Guid.NewGuid(), ProductName = "Networking 1", ProductSku="NTW001", ProductPrice=500 , IsActive=true},
                               new Models.Product {ProductId = Guid.NewGuid(), ProductName = "Networking 2", ProductSku="NTW002", ProductPrice=500 , IsActive=true}
                   }
               },
               new Models.Category
               {
                   CategoryId = Guid.NewGuid(),
                   CategoryName = "Modems",
                   LeftNode = 16,
                   RightNode = 17,
                   IsActive = true,
                   Products = new List<Models.Product> {
                               new Models.Product {ProductId = Guid.NewGuid(), ProductName = "Modems 1", ProductSku="MDM001", ProductPrice=500, IsActive=true },
                               new Models.Product {ProductId = Guid.NewGuid(), ProductName = "Modems 2", ProductSku="MDM002", ProductPrice=500 , IsActive=true}
                   }
               },
               new Models.Category
               {
                   CategoryId = Guid.NewGuid(),
                   CategoryName = "Routers",
                   LeftNode = 18,
                   RightNode = 19,
                   IsActive = true,
                   Products = new List<Models.Product> {
                               new Models.Product {ProductId = Guid.NewGuid(), ProductName = "Routers 1", ProductSku="RT001", ProductPrice=500, IsActive=true },
                               new Models.Product {ProductId = Guid.NewGuid(), ProductName = "Routers 2", ProductSku="RT002", ProductPrice=500 , IsActive=true}
                   }
               },
               new Models.Category
               {
                   CategoryId = Guid.NewGuid(),
                   CategoryName = "Cameras",
                   LeftNode = 22,
                   RightNode = 27,
                   IsActive = true,
                   Products = new List<Models.Product> {
                               new Models.Product {ProductId = Guid.NewGuid(), ProductName = "Cameras 1", ProductSku="CR001", ProductPrice=500, IsActive=true },
                               new Models.Product {ProductId = Guid.NewGuid(), ProductName = "Cameras 2", ProductSku="CR002", ProductPrice=500, IsActive=true }
                   }
               },
               new Models.Category
               {
                   CategoryId = Guid.NewGuid(),
                   CategoryName = "Point&Shoot",
                   LeftNode = 23,
                   RightNode = 24,
                   IsActive = true,
                   Products = new List<Models.Product> {
                               new Models.Product {ProductId = Guid.NewGuid(), ProductName = "Point&Shoot 1", ProductSku="PS001", ProductPrice=500 , IsActive=true},
                               new Models.Product {ProductId = Guid.NewGuid(), ProductName = "Point&Shoot 2", ProductSku="PS002", ProductPrice=500 , IsActive=true}
                   }
               },
               new Models.Category
               {
                   CategoryId = Guid.NewGuid(),
                   CategoryName = "Waterproof",
                   LeftNode = 25,
                   RightNode = 26,
                   IsActive = true,
                   Products = new List<Models.Product> {
                               new Models.Product {ProductId = Guid.NewGuid(), ProductName = "Waterproof 1", ProductSku="WPF001", ProductPrice=500, IsActive=true },
                               new Models.Product {ProductId = Guid.NewGuid(), ProductName = "Waterproof 2", ProductSku="WPF002", ProductPrice=500 , IsActive=true}
                   }
               }
          );

            base.Seed(context);

        }
    }
}
