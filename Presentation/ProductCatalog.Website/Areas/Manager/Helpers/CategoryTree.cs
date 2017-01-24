#region File Attributes

// Product Catalog  Project: ProductCatalog.Website
// File:  Category.cs
// Created By: Shawinder Sekhon 
// https://github.com/shawinder/product-catalog

#endregion

namespace ProductCatalog.Website.Areas.Manager.Helpers
{
    #region Includes

    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Data;
    using Data.Models;
    using Service.Context;
    using Service.Context.Loader;

    #endregion

    public static class CategoryTree
    {
        public static IList<ViewModels.CategorySelectList> Traverse(CatalogContext db)
        {
            var query = @"SELECT node.CategoryId, node.CategoryId as ParentId, CONCAT( REPLICATE('---', COUNT(parent.CategoryName) - 1), node.CategoryName) AS CategoryName,
                        CONCAT( REPLICATE('---', COUNT(parent.CategoryName) - 1), node.CategoryName) AS ParentName
                        FROM Categories AS node, Categories AS parent
                        WHERE node.LeftNode BETWEEN parent.LeftNode AND parent.RightNode And parent.LeftNode > 1
                        GROUP BY node.CategoryName, node.LeftNode, node.CategoryId
                        ORDER BY node.LeftNode;";

            return db.Database.SqlQuery<ViewModels.CategorySelectList>(query).ToList();
        }

        public static List<ViewModels.CategorySelectList> FindParent(CatalogContext db, int LeftNode, int RightNode)
        {
            var query = @"SELECT top 1 CategoryId as ParentId, CategoryName as ParentName
                        FROM Categories
                        WHERE LeftNode < {0} AND RightNode > {1}
                        ORDER BY LeftNode desc";

            return db.Database.SqlQuery<ViewModels.CategorySelectList>(query, LeftNode, RightNode).ToList();
        }

        public static void AddNode(CatalogContext db, Guid PreviousNodeId, string NewNodeName)
        {
            using (var dbTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    var query = @"Declare @right int;

                                SELECT @right = RightNode FROM Categories
                                WHERE CategoryId = {0};

                                UPDATE Categories SET RightNode = RightNode + 2 WHERE RightNode > @right;
                                UPDATE Categories SET LeftNode = LeftNode + 2 WHERE LeftNode > @right;

                                INSERT INTO Categories(CategoryName, LeftNode, RightNode, CreatedBy, IsActive, SortOrder) VALUES({1}, @right + 1, @right + 2, '00000000-0000-0000-0000-000000000000', 1, 0);";

                    db.Database.ExecuteSqlCommand(query, PreviousNodeId, NewNodeName);

                    db.SaveChanges();

                    dbTransaction.Commit();
                }
                catch (Exception ex)
                {
                    dbTransaction.Rollback();
                }
            }
        }

        public static void DeleteNode(CatalogContext db, Guid DeleteNodeId)
        {
            using (var dbTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    var query = @"Declare @right int;
                                Declare @left int;
                                Declare @width int;

                                SELECT @left = LeftNode, @right = RightNode, @width = RightNode - LeftNode + 1
                                FROM Categories
                                WHERE CategoryId = {0};

                                DELETE FROM Categories WHERE LeftNode BETWEEN @left AND @right;

                                UPDATE Categories SET RightNode = RightNode - @width WHERE RightNode > @right;
                                UPDATE Categories SET LeftNode = LeftNode - @width WHERE LeftNode > @right;";

                    db.Database.ExecuteSqlCommand(query, DeleteNodeId);

                    db.SaveChanges();

                    dbTransaction.Commit();
                }
                catch (Exception ex)
                {
                    dbTransaction.Rollback();
                    throw;
                }
            }
        }
    }
}