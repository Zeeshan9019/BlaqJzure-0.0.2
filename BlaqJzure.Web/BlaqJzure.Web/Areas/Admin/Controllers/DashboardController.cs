using System.Diagnostics;
using BlaqJzure.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlaqJzure.Web.Areas.Admin.Controllers;
[Area("admin")]
/*[ServiceFilter(typeof(AouthFilter))]
[Authorize(Roles = "Admin")]*/
public class DashboardController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
