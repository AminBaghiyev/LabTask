using Uniqlo.DAL.Models.Base;

namespace Uniqlo.DAL.Models;

public class SliderItem : BaseAuditableEntity
{
    public string Title { get; set; }
    public string ButtonText { get; set; }
    public string Url { get; set; }
    public string BackgroundImagePath { get; set; }
    public bool IsDeleted { get; set; }
}
