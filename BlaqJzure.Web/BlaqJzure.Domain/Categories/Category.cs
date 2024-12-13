using BlaqJzure.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaqJzure.Domain.Categories
{
    public class Category : Base<int>
    {
        public string Name { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
