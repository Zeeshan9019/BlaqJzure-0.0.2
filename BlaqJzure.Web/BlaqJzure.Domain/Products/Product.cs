using BlaqJzure.Domain.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaqJzure.Domain.Products
{
    public class Product : Base <int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double? CutPrice { get; set; }
        public double Price { get; set; }
        public virtual List<ProductImage>? Images { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
