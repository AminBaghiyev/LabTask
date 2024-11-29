using Microsoft.AspNetCore.Mvc;

namespace Uniqlo.PL.Controllers;

public class AboutController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
