using Microsoft.EntityFrameworkCore;
using Pronia.DAL.Models;

namespace Pronia.DAL.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<SliderItem> SliderItems { get; set; }

    public AppDbContext(DbContextOptions options) : base(options) { }
}
