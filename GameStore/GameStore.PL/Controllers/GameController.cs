using GameStore.BL.Services.Abstractions;
using GameStore.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.PL.Controllers;

public class GameController : Controller
{
    readonly IGameService _gameManager;
    readonly IBaseAuditableService<Review> _reviewManager;

    public GameController(IGameService gameManager, IBaseAuditableService<Review> reviewManager)
    {
        _gameManager = gameManager;
        _reviewManager = reviewManager;
    }

    public async Task<IActionResult> Index(int id)
    {
        Game? game = await _gameManager.GetByIdAsNoTrackingAsync(id);
        if (game is null) { return NotFound(); }

        game.Reviews = await _gameManager.GetAllCurrentReviewsByIdAsync(id);

        return View(game);
    }

    [HttpPost]
    public async Task<IActionResult> AddComment(int id, string comment)
    {
        Game? game = await _gameManager.GetByIdAsNoTrackingAsync(id);
        if (game is null) return NotFound();

        Review review = new()
        {
            Comment = comment,
            GameId = id
        };

        await _reviewManager.CreateAsync(review);

        return Json(review);
    }
}
