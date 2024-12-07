using BlaqJzure.Common.Models.Accounts.Admin;
using BlaqJzure.Service.Interfaces;
using BlaqJzure.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlaqJzure.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    /*[ServiceFilter(typeof(AouthFilter))]
    [Authorize(Roles = "Admin")]*/
    public class AdminSettingsController : Controller
    {
        private readonly IadminService _userService;
        public AdminSettingsController(IadminService userService)
        {
            _userService = userService;
        }
        public async Task<IActionResult> Setting()
        {
            var admin = await _userService.Get();
            return View(admin);
        }
        [HttpPost]
        public IActionResult Update(AdminSetting adminSetting)
        {
            return null;
        }
    }
}
