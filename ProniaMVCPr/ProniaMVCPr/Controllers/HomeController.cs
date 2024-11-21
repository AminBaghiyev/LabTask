using Microsoft.AspNetCore.Mvc;
using ProniaMVCPr.DAL;
using ProniaMVCPr.Models;
using ProniaMVCPr.ViewsModel.Home;

namespace ProniaMVCPr.Controllers;

public class HomeController : Controller
{
    private readonly AppDBContext _db;

    public HomeController(AppDBContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        /*List<SliderItem> sliderItems = [
            new SliderItem()
            {
                Offer = 65,
                Title = "New Plant 1",
                ShortDesc = "Pronia, With 100% Natural, Organic & Plant Shop.",
                ImagePath = "1-1-524x617.png"
            },
            new SliderItem()
            {
                Offer = 75,
                Title = "New Plant 2",
                ShortDesc = "Pronia, With 100% Natural, Organic & Plant Shop.",
                ImagePath = "1-2-524x617.png"
            }
        ];
        _db.SliderItems.AddRange(sliderItems);
        _db.SaveChanges();*/

        HomeVM VM = new()
        {
            SliderItems = _db.SliderItems,
        };

        return View(VM);
    }
}
