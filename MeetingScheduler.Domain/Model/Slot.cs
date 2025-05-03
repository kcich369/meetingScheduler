using MeetingScheduler.Domain.Enums;
using MeetingScheduler.Domain.IDs;
using MeetingScheduler.Domain.Model.Base;
using MeetingScheduler.Domain.ValueObjects;
using MeetingScheduler.Shared.Domain.Results;

namespace MeetingScheduler.Domain.Model;

public class Slot : Entity<SlotId>
{
    public TimeRange TimeRange { get; private set; }
    public SpecialistId SpecialistId { get; private set; }
    public SlotStatus Status { get; private set; }

    private Slot(SlotId id, DateTime createdAt, string createdBy, TimeRange timeRange, SpecialistId specialistId) :
        base(id, createdAt, createdBy)
    {
        Id = id;
        TimeRange = timeRange;
        SpecialistId = specialistId;
        Status = SlotStatus.Available;
    }

    public static IDomainResult<Slot> Create(SlotId id, DateTime createdAt, string createdBy, DateTime startedAt,
        DateTime endedAt, SpecialistId specialistId)
    {
        return DomainResult<Slot>.Success(new Slot(id, createdAt, createdBy, TimeRange.Create(startedAt, endedAt),
            specialistId));
    }

    public Slot MarkAsAvailable()
    {
        Status = SlotStatus.Available;
        return this;
    }

    public Slot MarkAsReserved()
    {
        Status = SlotStatus.Reserved;
        return this;
    }

    public Slot MarkAsUnavailable()
    {
        Status = SlotStatus.Unavailable;
        return this;
    }
}