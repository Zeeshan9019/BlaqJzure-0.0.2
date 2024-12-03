using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaqJzure.Common.Models.Accounts.Users
{
    public class UserLogin
    {
        public string emailOrUserName { get; set; }
        public string password { get; set; }
    }
}
