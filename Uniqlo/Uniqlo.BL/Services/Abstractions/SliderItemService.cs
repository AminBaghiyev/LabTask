using Microsoft.EntityFrameworkCore;
using Uniqlo.BL.Services.Concretes;
using Uniqlo.DAL.Contexts;
using Uniqlo.DAL.Models;

namespace Uniqlo.BL.Services.Abstractions;

public class SliderItemService : ISliderItemService
{
    readonly AppDbContext _db;

    public SliderItemService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<SliderItem>> GetActiveSliderItemsAsync()
    {
        return await _db.SliderItems.Where(s => !s.IsDeleted).ToListAsync();
    }

    public async Task<List<SliderItem>> GetAllSliderItemsAsync()
    {
        return await _db.SliderItems.ToListAsync();
    }

    public async Task<SliderItem?> GetSliderItemByIdAsync(int Id)
    {
        return await _db.SliderItems.FindAsync(Id);
    }

    public async Task HardDeleteSliderItemAsync(int Id)
    {
        SliderItem? sliderItem = await GetSliderItemByIdAsync(Id);
        if (sliderItem == null)
        {
            return;
        }

        _db.SliderItems.Remove(sliderItem);
        await _db.SaveChangesAsync();
    }

    public async Task SoftDeleteSliderItemAsync(int Id)
    {
        SliderItem? sliderItem = await GetSliderItemByIdAsync(Id);
        if (sliderItem == null)
        {
            return;
        }

        sliderItem.IsDeleted = true;

        await _db.SaveChangesAsync();
    }

    public async Task UpdateSliderItemAsync(int Id, SliderItem newSliderItem)
    {
        SliderItem? sliderItem = await GetSliderItemByIdAsync(Id);
        if (sliderItem == null)
        {
            return;
        }

        sliderItem.Title = newSliderItem.Title;
        sliderItem.ButtonText = newSliderItem.ButtonText;
        sliderItem.Url = newSliderItem.Url;
        sliderItem.BackgroundImagePath = newSliderItem.BackgroundImagePath;
        sliderItem.UpdatedAt = DateTime.Now;

        await _db.SaveChangesAsync();
    }

    public async Task CreateSliderItemAsync(SliderItem sliderItem)
    {
        sliderItem.CreatedAt = DateTime.Now;
        await _db.SliderItems.AddAsync(sliderItem);
        await _db.SaveChangesAsync();
    }

    public async Task RecoverSliderItemAsync(int Id)
    {
        SliderItem? sliderItem = await GetSliderItemByIdAsync(Id);
        if (sliderItem == null)
        {
            return;
        }

        sliderItem.IsDeleted = false;

        await _db.SaveChangesAsync();
    }
}
