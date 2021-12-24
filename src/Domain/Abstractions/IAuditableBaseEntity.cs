namespace Domain.Abstractions
{
    public interface IAuditableBaseEntity
    {
        DateTime CreateDate { get; set; }
        string? CreatedBy { get; set; }
        DateTime? LastModifiedDate { get; set; }
        string? LastModifiedBy { get; set; }
    }
}