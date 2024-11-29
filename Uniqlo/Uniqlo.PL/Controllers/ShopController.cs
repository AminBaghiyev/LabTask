using Microsoft.AspNetCore.Mvc;

namespace Uniqlo.PL.Controllers;

public class ShopController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
