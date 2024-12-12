using System.ComponentModel.DataAnnotations;

namespace GameStore.PL.Areas.Admin.ViewModels;

public class CreateGameVM
{
    [Display(Name = "Game ID")]
    public string GameId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public IFormFile? Thumbnail { get; set; }
}
