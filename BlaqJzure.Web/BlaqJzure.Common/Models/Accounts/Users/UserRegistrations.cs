using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaqJzure.Common.Models.Accounts.Users
{
    public class UserRegistrations
    {
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public bool termsAndConditions { get; set; }
    }
}
