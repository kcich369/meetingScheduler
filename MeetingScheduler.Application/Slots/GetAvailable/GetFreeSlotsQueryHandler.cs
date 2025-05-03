using Marten;
using MeetingScheduler.Domain.Model;
using MeetingScheduler.Shared.Application.Queries;

namespace MeetingScheduler.Application.Slots.GetAvailable;

public class GetFreeSlotsQueryHandler(IQuerySession querySession)
    : IQueryHandler<GetFreeSlotsQuery, GetFreeSlotsQueryResult>
{
    public async Task<GetFreeSlotsQueryResult> HandleAsync(GetFreeSlotsQuery query, CancellationToken cancellationToken)
    {
        var availableSlots = await querySession.Query<Slot>()
            .Where(x => x.TimeRange.StartedAt.Date == query.Date.ToDateTime(TimeOnly.MinValue))
            .Select(x => new GetFreeSlotsQueryElement(x.Id.Value, x.TimeRange.StartedAt, x.TimeRange.EndedAt))
            .ToListAsync(cancellationToken);

        return new GetFreeSlotsQueryResult(availableSlots);
    }
}