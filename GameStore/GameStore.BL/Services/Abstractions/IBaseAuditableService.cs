using GameStore.DAL.Models.Base;

namespace GameStore.BL.Services.Abstractions;

public interface IBaseAuditableService<T> where T : BaseAuditableEntity, new()
{
    Task<List<T>> GetAllAsync();
    Task<List<T>> GetAllCurrentAsync();
    Task<T?> GetByIdAsync(int id);
    Task<T?> GetByIdAsNoTrackingAsync(int id);
    Task CreateAsync(T item);
    Task UpdateAsync(int id, T updatedItem);
    Task HardDeleteAsync(int id);
    Task SoftDeleteAsync(int id);
    Task RecoverAsync(int id);
}
