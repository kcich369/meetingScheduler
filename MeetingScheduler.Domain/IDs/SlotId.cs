using MeetingScheduler.Domain.Model.Base;

namespace MeetingScheduler.Domain.IDs;

public class SlotId : IEntityId
{
    public Guid Value { get; }

    private SlotId(Guid value)
    {
        Value = value;
    }

    public static SlotId Create(Guid? id = null)
    {
        return new SlotId(id ?? Guid.NewGuid());
    }
}