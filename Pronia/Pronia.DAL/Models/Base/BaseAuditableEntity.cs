using System.Diagnostics.CodeAnalysis;

namespace Pronia.DAL.Models.Base;

public abstract class BaseAuditableEntity : BaseEntity
{
    [AllowNull]
    public DateTime? CreatedAt { get; set; }

    [AllowNull]
    public DateTime? UpdatedAt { get; set; }
}
