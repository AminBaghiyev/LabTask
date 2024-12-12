using GameStore.BL.Services.Abstractions;
using GameStore.DAL.Models;
using GameStore.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.PL.Controllers;

public class HomeController : Controller
{
    readonly IBaseAuditableService<Game> _gameManager;

    public HomeController(IBaseAuditableService<Game> gameManager)
    {
        _gameManager = gameManager;
    }

    public async Task<IActionResult> Index()
    {
        HomeVM VM = new()
        {
            Games = await _gameManager.GetAllCurrentAsync(),
        };

        return View(VM);
    }
}
