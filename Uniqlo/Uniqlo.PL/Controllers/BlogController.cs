using Microsoft.AspNetCore.Mvc;

namespace Uniqlo.PL.Controllers;

public class BlogController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
