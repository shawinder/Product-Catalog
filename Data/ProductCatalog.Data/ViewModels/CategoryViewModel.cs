using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Data.ViewModels
{
    class CategoryViewModel
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int LeftNode { get; set; }
        public int RightNode { get; set; }
        public List<CategoryViewModel> children { get; set; }
    }
}
