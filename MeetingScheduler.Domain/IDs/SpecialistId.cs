namespace MeetingScheduler.Domain.IDs;

public class SpecialistId
{
    private Guid Id { get; }

    private SpecialistId(Guid id)
    {
        Id = id;
    }

    public static SpecialistId Create(Guid? id = null)
    {
        return new SpecialistId(id ?? Guid.NewGuid());
    }  
}