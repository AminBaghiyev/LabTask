using Uniqlo.DAL.Models;

namespace Uniqlo.BL.Services.Concretes;

public interface ISliderItemService
{
    Task CreateSliderItemAsync(SliderItem sliderItem);
    Task<List<SliderItem>> GetAllSliderItemsAsync();
    Task<List<SliderItem>> GetActiveSliderItemsAsync();
    Task<SliderItem?> GetSliderItemByIdAsync(int Id);
    Task UpdateSliderItemAsync(int Id, SliderItem sliderItem);
    Task HardDeleteSliderItemAsync(int Id);
    Task SoftDeleteSliderItemAsync(int Id);
    Task RecoverSliderItemAsync(int Id);
}
