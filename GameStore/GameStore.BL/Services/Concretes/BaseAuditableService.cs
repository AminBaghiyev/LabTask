using GameStore.BL.Services.Abstractions;
using GameStore.DAL.Contexts;
using GameStore.DAL.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace GameStore.BL.Services.Concretes;

public class BaseAuditableService<T> : IBaseAuditableService<T> where T : BaseAuditableEntity, new()
{
    protected AppDbContext _db;

    public BaseAuditableService(AppDbContext db)
    {
        _db = db;
    }

    public async Task CreateAsync(T item)
    {
        item.CreatedAt = DateTime.Now;
        await _db.Set<T>().AddAsync(item);
        await _db.SaveChangesAsync();
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _db.Set<T>().ToListAsync();
    }

    public async Task<List<T>> GetAllCurrentAsync()
    {
        return await _db.Set<T>().Where(i => !i.IsDeleted).ToListAsync();
    }

    public async Task<T?> GetByIdAsNoTrackingAsync(int id)
    {
        return await _db.Set<T>().AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _db.Set<T>().FindAsync(id);
    }

    public async Task HardDeleteAsync(int id)
    {
        T? item = await GetByIdAsync(id);
        if (item is null) return;

        _db.Set<T>().Remove(item);
        await _db.SaveChangesAsync();
    }

    public async Task RecoverAsync(int id)
    {
        T? item = await GetByIdAsync(id);
        if (item is null) return;

        item.IsDeleted = false;
        await _db.SaveChangesAsync();
    }

    public async Task SoftDeleteAsync(int id)
    {
        T? item = await GetByIdAsync(id);
        if (item is null) return;

        item.IsDeleted = true;
        await _db.SaveChangesAsync();
    }

    public async Task UpdateAsync(int id, T updatedItem)
    {
        T? item = await GetByIdAsNoTrackingAsync(id);
        if (item is null) return;

        updatedItem.CreatedAt = item.CreatedAt;
        updatedItem.UpdatedAt = DateTime.Now;
        _db.Set<T>().Update(updatedItem);
        await _db.SaveChangesAsync();
    }
}
