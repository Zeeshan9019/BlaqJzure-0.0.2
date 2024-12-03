using Microsoft.AspNetCore.Mvc;

namespace BlaqJzure.Web.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
