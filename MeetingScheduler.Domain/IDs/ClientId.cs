namespace MeetingScheduler.Domain.IDs;

public class ClientId
{
    private Guid Id { get; }

    private ClientId(Guid id)
    {
        Id = id;
    }

    public static ClientId Create(Guid? id = null)
    {
        return new ClientId(id ?? Guid.NewGuid());
    }
}