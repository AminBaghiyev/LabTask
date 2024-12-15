using GameStore.DAL.Models;

namespace GameStore.PL.ViewModels;

public class CartVM
{
    public List<Game> Games { get; set; } = [];
    public Dictionary<int, int> Quantities { get; set; } = [];
    public decimal Subtotal { get; set; }
}
