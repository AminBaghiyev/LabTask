using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using Uniqlo.DAL.Models;

namespace Uniqlo.PL.Areas.Admin.ViewModels.ProductVMs;

public class ProductVM
{
    public int Id { get; set; }

    [Display(Name = "Name")]
    public string Title { get; set; }

    [Display(Name = "Old Price")]
    public double OldPrice { get; set; }

    [Display(Name = "New Price")]
    public double NewPrice { get; set; }
    public IFormFile Thumbnail { get; set; }
    public int CategoryId { get; set; }

    [ValidateNever]
    public SelectList Categories { get; set; }

    public static implicit operator ProductVM(Product item)
    {
        return new ProductVM()
        {
            Id = item.Id,
            Title = item.Title,
            OldPrice = item.OldPrice,
            NewPrice = item.NewPrice,
            CategoryId = item.CategoryId
        };
    }
}
