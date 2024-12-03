using Microsoft.AspNetCore.Mvc;

namespace BlaqJzure.Web.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
