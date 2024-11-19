using EntityFrameworkPr.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkPr.Contexts;

internal class ApplicationDbContext : DbContext
{
    private readonly string connStr = "Server=localhost;Database=AB_AcademyDB;Trusted_Connection=True;TrustServerCertificate=True";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connStr);
        base.OnConfiguring(optionsBuilder);
    }
    public DbSet<Student> students { get; set; }
}