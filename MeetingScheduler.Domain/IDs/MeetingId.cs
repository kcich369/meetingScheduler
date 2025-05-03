using MeetingScheduler.Domain.Model.Base;

namespace MeetingScheduler.Domain.IDs;

public class MeetingId : IEntityId
{
    public Guid Value { get; }

    private MeetingId(Guid value)
    {
        Value = value;
    }

    public static MeetingId Create(Guid? id = null)
    {
        return new MeetingId(id ?? Guid.NewGuid());
    }
}