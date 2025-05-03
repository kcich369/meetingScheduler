using MeetingScheduler.Domain.Model.Base;

namespace MeetingScheduler.Domain.IDs;

public class SpecialistId : IEntityId
{
    public Guid Value { get; }

    private SpecialistId(Guid value)
    {
        Value = value;
    }

    public static SpecialistId Create(Guid? id = null)
    {
        return new SpecialistId(id ?? Guid.NewGuid());
    }
}