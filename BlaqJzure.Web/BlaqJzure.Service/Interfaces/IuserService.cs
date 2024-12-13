using BlaqJzure.Common.Models.Accounts.Admin;
using BlaqJzure.Common.Models.Accounts.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaqJzure.Service.Interfaces
{
    public interface IuserService
    {
        Task<(List<UserViewModel>, int)> GetAll(int pageNumber, int pageSize);
    }
}
