using GameStore.BL.Services.Abstractions;
using GameStore.BL.Services.Concretes;
using GameStore.DAL.Models;
using GameStore.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GameStore.PL.Controllers;

public class CartController : Controller
{
    readonly IGameService _gameService;

    public CartController(IGameService gameService)
    {
        _gameService = gameService;
    }

    public async Task<IActionResult> Index()
    {
        ICartManager cartManager = JsonConvert.DeserializeObject<CartManager>(Request.Cookies["cart"] ?? "{}") ?? new CartManager();

        CartVM VM = new()
        {
            Quantities = cartManager.Items
        };
        Game? game = new();

        foreach (var item in cartManager.Items)
        {
            game = await _gameService.GetByIdAsNoTrackingAsync(item.Key);
            if (game is not null)
            {
                VM.Games.Add(game);
                VM.Subtotal += (game.Price * cartManager[game.Id]);
            }
        }

        return View(VM);
    }

    [HttpPost]
    public async Task<IActionResult> Add(int id, int quantity = 1)
    {
        if (quantity <= 0) return BadRequest();

        ICartManager cartManager = JsonConvert.DeserializeObject<CartManager>(Request.Cookies["cart"] ?? "{}") ?? new CartManager();

        cartManager.Add(id, quantity);

        Response.Cookies.Append("cart", JsonConvert.SerializeObject(cartManager));

        return Ok(JsonConvert.SerializeObject(cartManager));
    }

    [HttpPost]
    public async Task<IActionResult> Remove(int id, int quantity = 1)
    {
        if (quantity <= 0) return BadRequest();

        ICartManager cartManager = JsonConvert.DeserializeObject<CartManager>(Request.Cookies["cart"] ?? "{}") ?? new CartManager();

        cartManager.Remove(id, quantity);

        Response.Cookies.Append("cart", JsonConvert.SerializeObject(cartManager));

        return Ok(JsonConvert.SerializeObject(cartManager));
    }
}
