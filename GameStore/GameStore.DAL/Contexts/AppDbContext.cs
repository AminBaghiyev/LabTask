using GameStore.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GameStore.DAL.Contexts;

public class AppDbContext : IdentityDbContext<AppUser, IdentityRole, string>
{
    public DbSet<Game> Games { get; set; }
    public DbSet<Review> Reviews { get; set; }

    public AppDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Game>()
            .HasMany(g => g.Reviews)
            .WithOne(r => r.Game)
            .HasForeignKey(r => r.GameId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<AppUser>()
            .HasMany(g => g.Reviews)
            .WithOne(r => r.User)
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<IdentityRole>()
            .HasData([
                new () {
                    Id = "eeebb659-a56c-461e-8b2e-97cbc1f8c8ed",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new () {
                    Id = "f8f8cb95-f680-4af2-abf8-0554d253695f",
                    Name = "User",
                    NormalizedName = "USER"
                }
            ]);

        base.OnModelCreating(builder);
    }
}
