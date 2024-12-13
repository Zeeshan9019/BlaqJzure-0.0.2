using BlaqJzure.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlaqJzure.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    public class AdminsController : Controller
    {
        private readonly IadminService _adminService;
        public AdminsController(IadminService adminServices)
        {
            _adminService = adminServices;
        }
        public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
        {
            var (adminSettings, totalCount) = await _adminService.GetAll(page, pageSize);

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            return View(adminSettings);
        }

    }
}
