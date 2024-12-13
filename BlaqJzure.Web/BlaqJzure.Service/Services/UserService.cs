using BlaqJzure.Common.Enums;
using BlaqJzure.Common.Models.Accounts.Admin;
using BlaqJzure.Common.Models.Accounts.Users;
using BlaqJzure.Domain.Users;
using BlaqJzure.Repository.IrepositoryServices;
using BlaqJzure.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaqJzure.Service.Services
{
    public class UserService : IuserService
    {
        private readonly Irepository<User> _Irepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserService(Irepository<User> irepository, IHttpContextAccessor httpContextAccessor)
        {
            _Irepository = irepository;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<(List<UserViewModel>, int)> GetAll(int pageNumber, int pageSize)
        {
            try
            {
                var skip = (pageNumber - 1) * pageSize;
                var usersQuery = _Irepository.Get(filter: x => x.Role == UserRole.User);

                var totalCount = await usersQuery.CountAsync();
                var user = await usersQuery.Skip(skip).Take(pageSize).ToListAsync();

                var adminList = user.Select(admin => new UserViewModel
                {
                    Id = admin.Id,
                    UserName = admin.UserName,
                    Email = admin.Email,
                    Phone = admin.PhoneNumber,
                    Address = admin.Address,
                }).ToList();

                return (adminList, totalCount);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return (new List<UserViewModel>(), 0);
            }
        }
    }
}
