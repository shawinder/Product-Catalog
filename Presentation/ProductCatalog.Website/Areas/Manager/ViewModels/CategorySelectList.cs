using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductCatalog.Website.Areas.Manager.ViewModels
{
    public class CategorySelectList
    {
        public Guid CategoryId { get; set; }
        public Guid ParentId { get; set; }
        public string CategoryName { get; set; }
        public string ParentName { get; set; }
    }
}