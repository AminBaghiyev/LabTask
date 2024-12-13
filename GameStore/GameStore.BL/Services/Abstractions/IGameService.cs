using GameStore.DAL.Models;

namespace GameStore.BL.Services.Abstractions;

public interface IGameService : IBaseAuditableService<Game>
{
    Task<List<Review>> GetAllCurrentReviewsByIdAsync(int id);
    Task<List<Review>> GetAllReviewsByIdAsync(int id);
}
