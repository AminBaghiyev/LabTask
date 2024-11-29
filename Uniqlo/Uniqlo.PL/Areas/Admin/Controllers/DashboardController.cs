using Microsoft.AspNetCore.Mvc;

namespace Uniqlo.PL.Areas.Admin.Controllers;

[Area("Admin")]
public class DashboardController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
