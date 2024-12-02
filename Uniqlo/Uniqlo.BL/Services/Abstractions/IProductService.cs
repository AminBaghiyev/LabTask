using Uniqlo.DAL.Models;

namespace Uniqlo.BL.Services.Abstractions;

public interface IProductService : IBaseService<Product>
{
    Task<List<Product>> GetProductsByCategoryAsync(int categoryId);
}
