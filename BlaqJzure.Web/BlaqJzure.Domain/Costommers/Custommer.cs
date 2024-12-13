using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaqJzure.Domain.Costommers
{
    public class Custommer : Base<int>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
