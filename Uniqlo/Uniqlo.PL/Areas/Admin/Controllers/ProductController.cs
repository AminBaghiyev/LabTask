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
    readonly IWebHostEnvironment _webHostEnvironment;

    public ProductController(IBaseService<Category> categoryManager, IProductService productManager, IWebHostEnvironment webHostEnvironment)
    {
        _categoryManager = categoryManager;
        _productManager = productManager;
        _webHostEnvironment = webHostEnvironment;
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

        if (formProduct.Thumbnail.Length >= 1 * 1024 * 1024)
        {
            ProductVM VM = new()
            {
                Categories = new(await _categoryManager.GetAllCurrentAsync(), nameof(Category.Id), nameof(Category.Title))
            };

            ModelState.AddModelError("Thumbnail", "The size of the photo must be less than 1 MB.");

            return View(VM);
        }

        string uploadsPath = Path.Combine(_webHostEnvironment.WebRootPath, "images", "uploads", "products");
        string thumbnailPath =
            Path.GetFileNameWithoutExtension(formProduct.Thumbnail.FileName) +
            Guid.NewGuid().ToString() +
            Path.GetExtension(formProduct.Thumbnail.FileName);

        if (!Directory.Exists(uploadsPath)) Directory.CreateDirectory(uploadsPath);

        using (FileStream img = new(Path.Combine(uploadsPath, thumbnailPath), FileMode.Create))
        {
            await formProduct.Thumbnail.CopyToAsync(img);
        }

        Product product = new()
        {
            Title = formProduct.Title,
            OldPrice = formProduct.OldPrice,
            NewPrice = formProduct.NewPrice,
            ThumbnailPath = thumbnailPath,
            CategoryId = formProduct.CategoryId
        };

        await _productManager.CreateAsync(product);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Update(int Id)
    {
        Product? product = await _productManager.GetByIdAsync(Id);

        if (product is null)
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
        if (product is null)
        {
            return RedirectToAction(nameof(Index));
        }

        product.Category = await _categoryManager.GetByIdAsNoTrackingAsync(product.CategoryId);

        return View(product);
    }
}
