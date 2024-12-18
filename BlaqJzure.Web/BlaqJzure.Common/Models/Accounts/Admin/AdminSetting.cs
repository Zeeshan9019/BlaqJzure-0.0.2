﻿using BlaqJzure.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaqJzure.Common.Models.Accounts.Admin
{
    public class AdminSetting
    {
        [DisplayName("AdminId")]
        public string Id { get; set; }
        public string? UserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string? ProfileImage { get; set; }
        public UserRole? Role { get; set; }
    }
}
