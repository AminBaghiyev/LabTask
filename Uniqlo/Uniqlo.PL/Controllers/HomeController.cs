﻿using Microsoft.AspNetCore.Mvc;

namespace Uniqlo.PL.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
