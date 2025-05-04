namespace MeetingScheduler.Domain.Model.Base;

public abstract class Entity(DateTime createdAt, string createdBy)
{
    public DateTime CreatedAt { get; protected set; } = createdAt;
    public string CreatedBy { get; protected set; } = createdBy;
    public DateTime? UpdatedAt { get; protected set; }
    public string? UpdatedBy { get; protected set; }

    public void SetCreation(DateTime createdAt, string createdBy)
    {
        CreatedAt = createdAt;
        CreatedBy = createdBy;
    }

    public void SetUpdate(DateTime updatedAt, string updatedBy)
    {
        UpdatedAt = updatedAt;
        UpdatedBy = updatedBy;
    }
}

public abstract class Entity<TId>(TId id, DateTime createdAt, string createdBy) : Entity(createdAt, createdBy)
    where TId : IEntityId
{
    public TId Id { get; protected set; } = id;
}