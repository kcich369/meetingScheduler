using Marten;
using MeetingScheduler.Domain.Enums;
using MeetingScheduler.Domain.Model;
using MeetingScheduler.Shared.Application.Queries;
using MeetingScheduler.Shared.Domain.Services;

namespace MeetingScheduler.Application.Slots.GetAvailable;

public class GetFreeSlotsQueryHandler(IQuerySession querySession, IDateTimeProvider dateTimeProvider)
    : IQueryHandler<GetFreeSlotsQuery, GetFreeSlotsQueryResult>
{
    public async Task<GetFreeSlotsQueryResult> HandleAsync(GetFreeSlotsQuery query, CancellationToken cancellationToken)
    {
        var currentDate = DateOnly.FromDateTime(dateTimeProvider.CurrentDateTime());
        var availableSlots = await querySession.Query<Slot>()
            .Where(x => DateOnly.FromDateTime(x.TimeRange.StartedAt) >= currentDate
                        && DateOnly.FromDateTime(x.TimeRange.StartedAt) <= query.EndDate
                        && x.Status == SlotStatus.Available)
            .Select(x => new GetFreeSlotsQueryElement(x.Id.Value, x.TimeRange.StartedAt, x.TimeRange.EndedAt))
            .ToListAsync(cancellationToken);

        return new GetFreeSlotsQueryResult(availableSlots);
    }
}