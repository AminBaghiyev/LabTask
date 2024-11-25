using Pronia.DAL.Models.Base;
using System.Diagnostics.CodeAnalysis;

namespace Pronia.DAL.Models;

public class SliderItem : BaseAuditableEntity
{
    [DisallowNull]
    public string Title { get; set; }

    [DisallowNull]
    public string ShortDesc { get; set; }

    [DisallowNull]
    public int Offer { get; set; }

    [DisallowNull]
    public string ImagePath { get; set; }
}
