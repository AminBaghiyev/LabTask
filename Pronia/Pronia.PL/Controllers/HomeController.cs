using Microsoft.AspNetCore.Mvc;
using Pronia.BL.Services.Abstractions;
using Pronia.DAL.Models;

namespace Pronia.PL.Controllers;

public class HomeController : Controller
{
    private readonly ISliderItemService _service;

    public HomeController(ISliderItemService service)
    {
        _service = service;
    }

    public IActionResult Index()
    {
        IEnumerable<SliderItem> sliderItems = _service.GetAllSliderItems();

        return View(sliderItems);
    }
}
