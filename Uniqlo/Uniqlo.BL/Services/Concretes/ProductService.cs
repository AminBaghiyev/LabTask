using Microsoft.EntityFrameworkCore;
using Uniqlo.BL.Services.Abstractions;
using Uniqlo.DAL.Contexts;
using Uniqlo.DAL.Models;

namespace Uniqlo.BL.Services.Concretes;

public class ProductService : BaseService<Product>, IProductService
{
    public ProductService(AppDbContext db) : base(db) { }

    public async Task<List<Product>> GetProductsByCategoryAsync(int categoryId)
    {
        return await _db.Products.Where(p => p.CategoryId == categoryId).ToListAsync();
    }
}
