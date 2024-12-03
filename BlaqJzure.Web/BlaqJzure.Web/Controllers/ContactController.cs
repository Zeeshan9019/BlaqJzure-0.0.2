using Microsoft.AspNetCore.Mvc;

namespace BlaqJzure.Web.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
