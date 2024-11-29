using Microsoft.EntityFrameworkCore;
using Uniqlo.DAL.Models;

namespace Uniqlo.DAL.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<SliderItem> SliderItems { get; set; }

    public AppDbContext(DbContextOptions options) : base(options) { }
}
