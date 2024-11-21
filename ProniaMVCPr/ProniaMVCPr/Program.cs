using Microsoft.EntityFrameworkCore;
using ProniaMVCPr.DAL;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDBContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("MsSql")));
builder.Services.AddControllersWithViews();

var app = builder.Build();
app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");

app.Run();
