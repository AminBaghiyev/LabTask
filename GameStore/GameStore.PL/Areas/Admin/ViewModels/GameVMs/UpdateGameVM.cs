using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GameStore.PL.Areas.Admin.ViewModels;

public class UpdateGameVM
{
    public int Id { get; set; }
    [Display(Name = "Game ID")]
    public string GameId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string? ThumbnailPath { get; set; }
    public IFormFile? Thumbnail { get; set; }
}
