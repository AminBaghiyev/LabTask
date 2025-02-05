using Microsoft.EntityFrameworkCore;
using Uniqlo.BL.Services.Abstractions;
using Uniqlo.BL.Services.Concretes;
using Uniqlo.DAL.Contexts;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("MsSql"))
);
builder.Services.AddScoped<ISliderItemService, SliderItemService>();
builder.Services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();
app.UseStaticFiles();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
 );


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
