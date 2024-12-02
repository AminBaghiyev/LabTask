using Microsoft.AspNetCore.Mvc;
using Uniqlo.BL.Services.Abstractions;
using Uniqlo.DAL.Models;

namespace Uniqlo.PL.Areas.Admin.Controllers;

[Area("Admin")]
public class SliderItemController : Controller
{
    readonly ISliderItemService _sliderItemService;

    public SliderItemController(ISliderItemService sliderItemService)
    {
        _sliderItemService = sliderItemService;
    }

    public async Task<IActionResult> Index()
    {
        IEnumerable<SliderItem> sliderItems = await _sliderItemService.GetAllSliderItemsAsync();

        return View(sliderItems);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(SliderItem newSliderItem)
    {
        if(!ModelState.IsValid)
        {
            return View();
        }

        await _sliderItemService.CreateSliderItemAsync(newSliderItem);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Update(int Id)
    {
        SliderItem? sliderItem = await _sliderItemService.GetSliderItemByIdAsync(Id);

        if(sliderItem == null)
        {
            return RedirectToAction(nameof(Index));
        }

        return View("Create", sliderItem);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(SliderItem newSliderItem)
    {
        if (!ModelState.IsValid)
        {
            return View("Create");
        }

        await _sliderItemService.UpdateSliderItemAsync(newSliderItem.Id, newSliderItem);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> HardDelete(int Id)
    {
        await _sliderItemService.HardDeleteSliderItemAsync(Id);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> SoftDelete(int Id)
    {
        await _sliderItemService.SoftDeleteSliderItemAsync(Id);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Recover(int Id)
    {
        await _sliderItemService.RecoverSliderItemAsync(Id);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Details(int Id)
    {
        SliderItem? sliderItem = await _sliderItemService.GetSliderItemByIdAsync(Id);
        if (sliderItem == null)
        {
            return RedirectToAction(nameof(Index));
        }

        return View(sliderItem);
    }
}
