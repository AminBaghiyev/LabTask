using Microsoft.AspNetCore.Mvc;
using Uniqlo.BL.Services.Abstractions;
using Uniqlo.DAL.Models;
using Uniqlo.PL.Areas.Admin.ViewModels.ProductVMs;

namespace Uniqlo.PL.Areas.Admin.Controllers;

[Area("Admin")]
public class ProductController : Controller
{
    readonly IBaseService<Category> _categoryManager;
    readonly IProductService _productManager;

    public ProductController(IBaseService<Category> categoryManager, IProductService productManager)
    {
        _categoryManager = categoryManager;
        _productManager = productManager;
    }

    public async Task<IActionResult> Index()
    {
        IEnumerable<Product> products = await _productManager.GetAllAsync();

        return View(products);
    }

    public async Task<IActionResult> Create()
    {
        ProductVM VM = new()
        {
            Categories = new(await _categoryManager.GetAllCurrentAsync(), nameof(Category.Id), nameof(Category.Title))
        };

        return View(VM);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ProductVM formProduct)
    {
        if (!ModelState.IsValid)
        {
            ProductVM VM = new()
            {
                Categories = new(await _categoryManager.GetAllCurrentAsync(), nameof(Category.Id), nameof(Category.Title))
            };
            return View(VM);
        }

        Product product = new()
        {
            Title = formProduct.Title,
            OldPrice = formProduct.OldPrice,
            NewPrice = formProduct.NewPrice,
            ThumbnailPath = formProduct.ThumbnailPath,
            CategoryId = formProduct.CategoryId
        };

        await _productManager.CreateAsync(product);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Update(int Id)
    {
        Product? product = await _productManager.GetByIdAsync(Id);

        if (product == null)
        {
            return RedirectToAction(nameof(Index));
        }

        ProductVM VM = new()
        {
            Categories = new(await _categoryManager.GetAllCurrentAsync(), nameof(Category.Id), nameof(Category.Title)),
            Id = product.Id,
            Title = product.Title,
            OldPrice = product.OldPrice,
            NewPrice = product.NewPrice,
            ThumbnailPath = product.ThumbnailPath,
            CategoryId = product.CategoryId
        };

        return View("Create", VM);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(ProductVM formProduct)
    {
        if (!ModelState.IsValid)
        {
            return View("Create");
        }

        Product product = new()
        {
            Title = formProduct.Title,
            OldPrice = formProduct.OldPrice,
            NewPrice = formProduct.NewPrice,
            ThumbnailPath = formProduct.ThumbnailPath,
            CategoryId = formProduct.CategoryId
        };

        await _productManager.UpdateAsync(formProduct.Id, product);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> HardDelete(int Id)
    {
        await _productManager.HardDeleteAsync(Id);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> SoftDelete(int Id)
    {
        await _productManager.SoftDeleteAsync(Id);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Recover(int Id)
    {
        await _productManager.RecoverAsync(Id);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Details(int Id)
    {
        Product? product = await _productManager.GetByIdAsNoTrackingAsync(Id);
        if (product == null)
        {
            return RedirectToAction(nameof(Index));
        }

        product.Category = await _categoryManager.GetByIdAsNoTrackingAsync(product.CategoryId);

        return View(product);
    }
}
