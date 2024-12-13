using BlaqJzure.Common.Models.Accounts.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaqJzure.Service.Interfaces
{
    public interface IadminService
    {
        Task<AdminSetting> Get();
        Task<(List<AdminSetting>, int)> GetAll(int pageNumber, int pageSize);
        Task<bool> Update(AdminSetting adminSetting);
    }
}
