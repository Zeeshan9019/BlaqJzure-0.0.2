using BlaqJzure.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaqJzure.Common.Models.Accounts.Users
{
    public class UserViewModel
    {
        [DisplayName("UserId")]
        public string Id { get; set; }
        public string? UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
