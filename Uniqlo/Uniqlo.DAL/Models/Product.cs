using System.ComponentModel.DataAnnotations.Schema;
using Uniqlo.DAL.Models.Base;

namespace Uniqlo.DAL.Models;

public class Product : BaseAuditableEntity
{
    public string Title { get; set; }
    public double OldPrice { get; set; }
    public double NewPrice { get; set; }
    public string ThumbnailPath { get; set; }
    public int CategoryId { get; set; }

    [NotMapped]
    public Category Category { get; set; }
}
