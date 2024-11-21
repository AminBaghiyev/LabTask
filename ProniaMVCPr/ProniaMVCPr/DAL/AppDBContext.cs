using Microsoft.EntityFrameworkCore;
using ProniaMVCPr.Models;

namespace ProniaMVCPr.DAL
{
    public class AppDBContext : DbContext
    {
        public DbSet<SliderItem> SliderItems { get; set; }

        public AppDBContext(DbContextOptions options) : base(options) { }
    }
}
