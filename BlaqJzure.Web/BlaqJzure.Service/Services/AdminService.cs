using BlaqJzure.Common.Enums;
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
            //var userId = _httpContextAccessor.HttpContext.Session.GetString("UserId");
            var adminId = "ac897878-1857-4ef8-8394-214970712a4a";
            var admin = await _Irepository.Get(id: adminId);
            if (admin == null)
            {
                return null;
            }
            var userName = admin.UserName.Split(" ");
            //var Pssword = _httpContextAccessor.HttpContext.Session.GetString("Password");
            var Pssword = "admin.admin";
            var settings = new AdminSetting()
            {
                Id = admin.Id,
                FirstName = userName.Length > 0 ? userName[0] : "Unknown",
                LastName = userName.Length > 1 ? userName[1] : "",
                Email = admin.Email,
                Phone = admin.PhoneNumber.Substring(2),
                Password = Pssword,
                Address = admin.Address,
                Role = admin.Role,
                ProfileImage = "None",
            };
            return settings;
        }
        public async Task<bool> Update(AdminSetting adminSetting)
        {
            if (adminSetting == null)
            {
                throw new Exception("Not found.");
            }
            try
            {
                var admin = await _Irepository.Get(id: adminSetting.Id);
                if (admin == null)
                {
                    throw new Exception("Admin not found.");
                }
                admin.UserName = adminSetting.FirstName + " " + adminSetting.LastName;
                admin.FirstName = adminSetting.FirstName;
                admin.LastName = adminSetting.LastName;
                admin.Email = adminSetting.Email;
                admin.PhoneNumber = "92" + adminSetting.Phone;
                admin.Address = adminSetting.Address;
                admin.PasswordHash = adminSetting.Password;
                if (!string.IsNullOrWhiteSpace(adminSetting.Password))
                {
                    var passwordHasher = new PasswordHasher<AdminSetting>();
                    admin.PasswordHash = passwordHasher.HashPassword(adminSetting, adminSetting.Password);
                }
                await _Irepository.Update(admin);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Faild", ex);
            }
        }
        public async Task<(List<AdminSetting>, int)> GetAll(int pageNumber, int pageSize)
        {
            try
            {
                var skip = (pageNumber - 1) * pageSize;
                var adminsQuery = _Irepository.Get(filter: x => x.Role == UserRole.Admin);

                var totalCount = await adminsQuery.CountAsync();
                var admins = await adminsQuery.Skip(skip).Take(pageSize).ToListAsync();

                var adminList = admins.Select(admin => new AdminSetting
                {
                    Id = admin.Id,
                    UserName = admin.UserName,
                    Email = admin.Email,
                    Phone = admin.PhoneNumber,
                    Address = admin.Address,
                    Role = admin.Role
                }).ToList();

                return (adminList, totalCount);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return (new List<AdminSetting>(), 0);
            }
        }
    }
}
