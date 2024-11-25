using Microsoft.EntityFrameworkCore;
using Pronia.BL.Services.Abstractions;
using Pronia.DAL.Contexts;
using Pronia.DAL.Models;

namespace Pronia.BL.Services.Concretes;

public class SliderItemService : ISliderItemService
{
    private readonly AppDbContext _db;

    public SliderItemService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<int> AddSliderItemAsync(SliderItem sliderItem)
    {
        await _db.SliderItems.AddAsync(sliderItem);
        return await _db.SaveChangesAsync();
    }

    public void DeleteSliderItem(int id)
    {
        SliderItem? item = _db.SliderItems.Find(id);

        if (item == null)
        {
            return;
        }

        _db.SliderItems.Remove(item);
        _db.SaveChanges();
    }

    public SliderItem? GetSliderItem(int id)
    {
        return _db.SliderItems.AsNoTracking().SingleOrDefault(sI => sI.Id == id);
    }

    public IEnumerable<SliderItem> GetAllSliderItems() => _db.SliderItems.ToList();

    public async Task<int> UpdateSliderItemAsync(SliderItem sliderItem)
    {
        SliderItem? ogItem = GetSliderItem(sliderItem.Id);
        if (ogItem == null)
        {
            return 0;
        }

        sliderItem.CreatedAt = ogItem.CreatedAt;
        sliderItem.UpdatedAt = DateTime.Now;

        _db.SliderItems.Update(sliderItem);
        return await _db.SaveChangesAsync();
    }
}
