using GameStore.BL.Services.Abstractions;
using GameStore.DAL.Contexts;
using GameStore.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStore.BL.Services.Concretes;

public class GameService : BaseAuditableService<Game>, IGameService
{
    public GameService(AppDbContext db) : base(db) { }

    public async Task<List<Review>> GetAllCurrentReviewsByIdAsync(int id)
    {
        return await _db.Reviews.Where(r => r.GameId == id && !r.IsDeleted).OrderByDescending(r => r.CreatedAt).ToListAsync();
    }

    public async Task<List<Review>> GetAllReviewsByIdAsync(int id)
    {
        return await _db.Reviews.Where(r => r.GameId == id).OrderByDescending(r => r.CreatedAt).ToListAsync();
    }
}
