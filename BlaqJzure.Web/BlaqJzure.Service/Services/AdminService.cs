using BlaqJzure.Common.Models.Accounts.Admin;
using BlaqJzure.Domain.Users;
using BlaqJzure.Repository.IrepositoryServices;
using BlaqJzure.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaqJzure.Service.Services
{
    public class AdminService : IadminService
    {
        private readonly Irepository<User> _Irepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AdminService(Irepository<User> irepository, IHttpContextAccessor httpContextAccessor)
        {
            _Irepository = irepository;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<AdminSetting> Get()
        {
            var userId = _httpContextAccessor.HttpContext.Session.GetString("UserId");
            var user = await _Irepository.Get(id: userId);
            if (user == null)
            {
                return null;
            }
            var userName = user.UserName.Split(" ");
            var Pssword = _httpContextAccessor.HttpContext.Session.GetString("Password");
            var settings = new AdminSetting()
            {
                Id = user.Id,
                FirstName = userName.Length > 0 ? userName[0] : "Unknown",
                LastName = userName.Length > 1 ? userName[1] : "",
                Email = user.Email,
                Phone = user.PhoneNumber,
                Password = Pssword,
                Address = "None",
                ProfileImage = "None",
            };
            return settings;
        }
        public async Task<IAsyncResult> Update(AdminSetting setting)
        {
            return null;
        }
    }
}
