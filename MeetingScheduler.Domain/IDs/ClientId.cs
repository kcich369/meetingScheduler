using MeetingScheduler.Domain.Model.Base;

namespace MeetingScheduler.Domain.IDs;

public class ClientId : IEntityId
{
    public Guid Value { get; }

    private ClientId(Guid value)
    {
        Value = value;
    }

    public static ClientId Create(Guid? id = null)
    {
        return new ClientId(id ?? Guid.NewGuid());
    }
}