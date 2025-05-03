namespace MeetingScheduler.Domain.Model.Base;

public abstract class Entity<TId>(TId id, DateTime createdAt, string createdBy)
    where TId : IEntityId
{
    public TId Id { get; protected set; } = id;
    public DateTime CreatedAt { get; protected set; } = createdAt;
    public string CreatedBy { get; protected set; } = createdBy;
    public DateTime? UpdatedAt { get; protected set; }
    public string? UpdatedBy { get; protected set; }

    protected void SetCreation(DateTime createdAt, string createdBy)
    {
        CreatedAt = createdAt;
        CreatedBy = createdBy;
    }

    protected void SetUpdate(DateTime updatedAt, string updatedBy)
    {
        UpdatedAt = updatedAt;
        UpdatedBy = updatedBy;
    }
}