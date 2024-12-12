using GameStore.BL.Services.Abstractions;
using GameStore.BL.Services.Concretes;
using GameStore.BL.Utilities;
using GameStore.DAL.Models;
using GameStore.PL.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.PL.Areas.Admin.Controllers;

[Area("Admin")]
//[Authorize(Roles = "Admin")]
public class GameController : Controller
{
    readonly IBaseAuditableService<Game> _gameManager;
    readonly IWebHostEnvironment _webHostEnvironment;

    public GameController(IBaseAuditableService<Game> gameManager, IWebHostEnvironment webHostEnvironment)
    {
        _gameManager = gameManager;
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<IActionResult> Index()
    {
        IEnumerable<Game> games = await _gameManager.GetAllAsync();

        return View(games);
    }
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateGameVM formGame)
    {
        if (!ModelState.IsValid)
        {
            return View(formGame);
        }

        if (formGame.Thumbnail is not null && !formGame.Thumbnail.CheckType("image"))
        {
            ModelState.AddModelError("Thumbnail", "File must be image!");

            return View(formGame);
        }

        if (formGame.Thumbnail is not null && !formGame.Thumbnail.CheckSize(5, FileSizeTypes.Mb))
        {
            ModelState.AddModelError("Thumbnail", "The size of the photo must be less than 5 MB.");
            return View(formGame);
        }

        string thumbnailPath = formGame.Thumbnail is not null ?
            await formGame.Thumbnail.SaveAsync(_webHostEnvironment.WebRootPath, "games") : "";

        Game game = new()
        {
            GameId = formGame.GameId,
            Name = formGame.Name,
            Description = formGame.Description,
            Price = formGame.Price,
            ThumbnailPath = thumbnailPath
        };

        await _gameManager.CreateAsync(game);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Update(int Id)
    {
        Game? game = await _gameManager.GetByIdAsync(Id);

        if (game is null)
        {
            return RedirectToAction(nameof(Index));
        }

        UpdateGameVM VM = new()
        {
            Id = game.Id,
            GameId = game.GameId,
            Name = game.Name,
            Description = game.Description,
            Price = game.Price,
            ThumbnailPath = game.ThumbnailPath
        };

        return View(VM);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(UpdateGameVM formGame)
    {
        if (!ModelState.IsValid)
        {
            return View(formGame);
        }

        if (formGame.Thumbnail is not null && !formGame.Thumbnail.CheckType("image"))
        {
            ModelState.AddModelError("Thumbnail", "File must be image!");

            return View(formGame);
        }

        if (formGame.Thumbnail is not null && !formGame.Thumbnail.CheckSize(5, FileSizeTypes.Mb))
        {
            ModelState.AddModelError("Thumbnail", "The size of the photo must be less than 5 MB.");
            return View(formGame);
        }

        if (formGame.ThumbnailPath is not null && formGame.Thumbnail is not null)
        {
            ModelState.AddModelError("Thumbnail", "This game has a thumbnail so it can't be added!");
            return View(formGame);
        }

        string thumbnailPath = formGame.ThumbnailPath ?? "";

        if (formGame.Thumbnail is not null)
        {
            thumbnailPath = await formGame.Thumbnail.SaveAsync(_webHostEnvironment.WebRootPath, "games");
        }

        Game game = new()
        {
            Id = formGame.Id,
            GameId = formGame.GameId,
            Name = formGame.Name,
            Description = formGame.Description,
            Price = formGame.Price,
            ThumbnailPath = thumbnailPath
        };

        await _gameManager.UpdateAsync(formGame.Id, game);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> DeleteThumbnail(int Id, string Photo)
    {
        string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", "games", Photo);
        if (!System.IO.File.Exists(filePath)) return BadRequest();

        Game? game = await _gameManager.GetByIdAsNoTrackingAsync(Id);
        if (game is null) return NotFound();

        game.ThumbnailPath = "";
        await _gameManager.UpdateAsync(Id, game);

        System.IO.File.Delete(filePath);

        return RedirectToAction(nameof(Update), new { Id });
    }

    public async Task<IActionResult> HardDelete(int Id)
    {
        await _gameManager.HardDeleteAsync(Id);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> SoftDelete(int Id)
    {
        await _gameManager.SoftDeleteAsync(Id);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Recover(int Id)
    {
        await _gameManager.RecoverAsync(Id);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Details(int Id)
    {
        Game? game = await _gameManager.GetByIdAsNoTrackingAsync(Id);
        if (game is null)
        {
            return RedirectToAction(nameof(Index));
        }

        return View(game);
    }
}
