using Microsoft.AspNetCore.Mvc;
using Pronia.BL.Services.Abstractions;
using Pronia.DAL.Models;

namespace Pronia.PL.Areas.Admin.Controllers;

[Area("Admin")]
public class SliderController : Controller
{
    private readonly ISliderItemService _service;

    public SliderController(ISliderItemService service)
    {
        _service = service;
    }

    public IActionResult Index()
    {
        IEnumerable<SliderItem> sliderItems = _service.GetAllSliderItems();

        return View(sliderItems);
    }

    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(SliderItem sliderItem)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        sliderItem.CreatedAt = DateTime.Now;
        await _service.AddSliderItemAsync(sliderItem);

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit(int Id)
    {
        SliderItem? item = _service.GetSliderItem(Id);

        if (item == null)
        {
            return NotFound();
        }

        return View(item);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(SliderItem item)
    {
        if (!ModelState.IsValid)
        {
            return View(item);
        }

        int affectedRows = await _service.UpdateSliderItemAsync(item);
        if (affectedRows == 0)
        {
            return BadRequest("something went wrong!");
        }

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Remove(int Id)
    {
        _service.DeleteSliderItem(Id);

        return RedirectToAction(nameof(Index));
    }
}
