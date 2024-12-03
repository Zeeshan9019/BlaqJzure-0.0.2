using BlaqJzure.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlaqJzure.Web.Controllers
{
    [ServiceFilter(typeof(AouthFilter))]
    [Authorize(Roles = "User")]
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
