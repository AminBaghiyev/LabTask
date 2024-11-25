using Pronia.DAL.Models;

namespace Pronia.BL.Services.Abstractions;

public interface ISliderItemService
{
    Task<int> AddSliderItemAsync(SliderItem sliderItem);
    Task<int> UpdateSliderItemAsync(SliderItem sliderItem);
    void DeleteSliderItem(int id);
    SliderItem? GetSliderItem(int id);
    IEnumerable<SliderItem> GetAllSliderItems();
}
