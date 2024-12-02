using Uniqlo.DAL.Models.Base;

namespace Uniqlo.DAL.Models;

public class Category : BaseAuditableEntity
{
    public string Title { get; set; }
    public ICollection<Product> Products { get; set; }
}
