namespace MeetingScheduler.Domain.IDs;

public class SlotId
{
    private Guid Id { get; }

    private SlotId(Guid id)
    {
        Id = id;
    }

    public static SlotId Create(Guid? id = null)
    {
        return new SlotId(id ?? Guid.NewGuid());
    }
}