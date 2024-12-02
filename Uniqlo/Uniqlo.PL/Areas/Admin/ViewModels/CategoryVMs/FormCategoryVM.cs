using Uniqlo.DAL.Models;

namespace Uniqlo.PL.Areas.Admin.ViewModels.CategoryVMs;

public class FormCategoryVM
{
    public int Id { get; set; }
    public string Title { get; set; }

    public static implicit operator FormCategoryVM(Category item)
    {
        return new FormCategoryVM()
        {
            Id = item.Id,
            Title = item.Title
        };
    }
}
