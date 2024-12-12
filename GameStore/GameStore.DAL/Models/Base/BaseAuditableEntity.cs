namespace GameStore.DAL.Models.Base;

public abstract class BaseAuditableEntity : BaseEntity
{
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
}
