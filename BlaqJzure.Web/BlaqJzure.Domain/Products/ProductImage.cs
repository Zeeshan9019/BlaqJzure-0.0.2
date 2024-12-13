using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaqJzure.Domain.Products
{
    public class ProductImage : Base<int>
    {
        public string? name { get; set; }
    }
}
