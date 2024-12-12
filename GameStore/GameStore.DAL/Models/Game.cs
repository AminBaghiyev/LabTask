using GameStore.DAL.Models.Base;

namespace GameStore.DAL.Models;

public class Game : BaseAuditableEntity
{
    public string GameId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string ThumbnailPath { get; set; }
}
