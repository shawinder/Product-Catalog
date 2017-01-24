#region File Attributes

// Product Catalog  Project: ProductCatalog.Website
// File:  Extension.cs
// Created By: Shawinder Sekhon 
// https://github.com/shawinder/product-catalog

#endregion

namespace ProductCatalog.Website.Helpers
{
    #region Includes

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Text;

    #endregion

    public static class HtmlExtensions
    {
        public static MvcHtmlString CategoryTree(this HtmlHelper html)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<div class=\"tree\">");

            using (var ctx = new Data.CatalogContext())
            {
                //Find Tree Depth
                var query = @"SELECT node.CategoryName, (COUNT(parent.CategoryName) - 1) AS Depth
                            FROM Categories AS node, Categories AS parent
                            WHERE node.LeftNode BETWEEN parent.LeftNode AND parent.RightNode
                            GROUP BY node.CategoryName, node.LeftNode
                            ORDER BY node.LeftNode";

                List<ViewModels.CategoryDepth> treeDepth = ctx.Database.SqlQuery<ViewModels.CategoryDepth>(query, true).ToList();

                //To get the outer <ul>
                int curDepth = -1;

                Dictionary<string, int> stack = new Dictionary<string, int>();

                while (treeDepth.Count() > 0)
                {
                    var currentNode = treeDepth[0];
                    treeDepth.RemoveAt(0);

                    //Skip Root Node
                    //if (currentNode.Depth == 0)
                    //{
                    //    continue;
                    //}

                    //Level Down
                    if (currentNode.Depth > curDepth)
                    {
                        sb.Append("<ul class='active'>");
                    }

                    //Level Up
                    if (currentNode.Depth < curDepth)
                    {
                        sb.Append(string.Concat(Enumerable.Repeat("</ul>", curDepth - currentNode.Depth)));
                    }

                    string selectedCategory = String.Empty;

                    //Default Selection
                    if (HttpContext.Current.Request.QueryString["cat"] == null && currentNode.Depth == 0)
                    {
                        selectedCategory = "<span class=\"badge\">" + currentNode.CategoryName + "</span>";
                    }//Select current otherwise
                    else if (HttpContext.Current.Request.QueryString["cat"] != null && HttpContext.Current.Request.QueryString["cat"].ToString() == currentNode.CategoryName)
                    {
                        selectedCategory = "<span class=\"badge\">" + currentNode.CategoryName + "</span>";
                    }
                    else
                    {
                        selectedCategory = currentNode.CategoryName;
                    }

                    //Always Add Node
                    sb.Append("<li><a href='?cat=" + HttpUtility.UrlEncode(currentNode.CategoryName) + "'>" + selectedCategory + "</a></li>");

                    //Adjust current Depth
                    curDepth = currentNode.Depth;

                    //Are we finished
                    if (treeDepth.Count() == 0)
                    {
                        sb.Append(String.Concat(Enumerable.Repeat("</ul>", curDepth + 1)));
                    }
                }

                sb.Append("</div>");
            }


            return MvcHtmlString.Create(sb.ToString());

        }
    }
}