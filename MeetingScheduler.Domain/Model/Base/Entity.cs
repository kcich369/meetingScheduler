namespace MeetingScheduler.Domain.Model.Base;

public abstract class Entity
{
    public DateTime CreatedAt { get; protected set; }
    public DateTime? UpdatedAt { get; protected set; }
}