using MeetingScheduler.Domain.Enums.Errors;
using MeetingScheduler.Domain.IDs;
using MeetingScheduler.Domain.ValueObjects;
using MeetingScheduler.Shared.Domain.Enumerations;
using MeetingScheduler.Shared.Domain.Results;

namespace MeetingScheduler.Domain.Model;

public class Slot
{
    public SlotId Id { get; private set; }
    public TimeRange TimeRange { get; private set; }
    public SpecialistId SpecialistId { get; private set; }
    
    private Slot(SlotId id, TimeRange timeRange, SpecialistId specialistId)
    {
        Id = id;
        TimeRange = timeRange;
        SpecialistId = specialistId;
    }
    
    
    public static IDomainResult<Slot> Create(SlotId id, TimeRange timeRange, SpecialistId specialistId)
    {
        return DomainResult<Slot>.Success(new Slot(id, timeRange, specialistId));
    }
}