namespace MeetingScheduler.Domain.IDs;

public class MeetingId
{
    private Guid Id { get; }

    private MeetingId(Guid id)
    {
        Id = id;
    }

    public static MeetingId Create(Guid? id = null)
    {
        return new MeetingId(id ?? Guid.NewGuid());
    }
}