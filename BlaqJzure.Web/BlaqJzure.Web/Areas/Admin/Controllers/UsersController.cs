using BlaqJzure.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlaqJzure.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    public class UsersController : Controller
    {
        private readonly IuserService _userService;
        public UsersController(IuserService userServices)
        {
            _userService = userServices;
        }
        public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
        {
            var (userSettings, totalCount) = await _userService.GetAll(page, pageSize);

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            return View(userSettings);
        }
    }
}
