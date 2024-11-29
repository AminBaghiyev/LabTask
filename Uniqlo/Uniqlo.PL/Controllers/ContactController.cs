using Microsoft.AspNetCore.Mvc;

namespace Uniqlo.PL.Controllers;

public class ContactController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
