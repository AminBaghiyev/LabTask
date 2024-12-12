using GameStore.DAL.Models;

namespace GameStore.PL.ViewModels;

public class HomeVM
{
    public IEnumerable<Game> Games { get; set; }
}
