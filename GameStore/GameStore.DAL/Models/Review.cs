using GameStore.DAL.Models.Base;

namespace GameStore.DAL.Models;

public class Review : BaseAuditableEntity
{
    public string Comment { get; set; }
    public string UserId { get; set; }
    public AppUser? User { get; set; }
    public int GameId { get; set; }
    public Game? Game { get; set; }
}
