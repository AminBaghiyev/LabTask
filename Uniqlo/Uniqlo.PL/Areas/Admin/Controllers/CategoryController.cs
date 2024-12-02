using Microsoft.AspNetCore.Mvc;
using Uniqlo.BL.Services.Abstractions;
using Uniqlo.DAL.Models;
using Uniqlo.PL.Areas.Admin.ViewModels.CategoryVMs;

namespace Uniqlo.PL.Areas.Admin.Controllers;

[Area("Admin")]
public class CategoryController : Controller
{
    readonly IBaseService<Category> _categoryManager;
    readonly IProductService _productManager;

    public CategoryController(IBaseService<Category> categoryManager, IProductService productManager)
    {
        _categoryManager = categoryManager;
        _productManager = productManager;
    }

    public async Task<IActionResult> Index()
    {
        IEnumerable<Category> categories = await _categoryManager.GetAllAsync();

        return View(categories);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(FormCategoryVM formCategory)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        Category category = new()
        {
            Title = formCategory.Title
        };

        await _categoryManager.CreateAsync(category);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Update(int Id)
    {
        Category? category = await _categoryManager.GetByIdAsync(Id);

        if (category == null)
        {
            return RedirectToAction(nameof(Index));
        }

        return View("Create", (FormCategoryVM) category);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(FormCategoryVM formCategory)
    {
        if (!ModelState.IsValid)
        {
            return View("Create");
        }

        Category category = new()
        {
            Title = formCategory.Title
        };

        await _categoryManager.UpdateAsync(formCategory.Id, category);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> HardDelete(int Id)
    {
        await _categoryManager.HardDeleteAsync(Id);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> SoftDelete(int Id)
    {
        await _categoryManager.SoftDeleteAsync(Id);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Recover(int Id)
    {
        await _categoryManager.RecoverAsync(Id);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Details(int Id)
    {
        Category? category = await _categoryManager.GetByIdAsNoTrackingAsync(Id);
        if (category == null)
        {
            return RedirectToAction(nameof(Index));
        }

        category.Products = await _productManager.GetProductsByCategoryAsync(Id);

        return View(category);
    }
}
