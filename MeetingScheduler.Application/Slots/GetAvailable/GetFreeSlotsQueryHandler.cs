using Marten;
using MeetingScheduler.Application.Slots.GetSlots;
using MeetingScheduler.Shared.Application;
using MeetingScheduler.Shared.Application.Queries;
using MeetingScheduler.Shared.Domain.Services;

namespace MeetingScheduler.Application.Slots.GetAvailable;

public class GetFreeSlotsQueryHandler(IQuerySession querySession, IDateTimeProvider dateTimeProvider)
    : IQueryHandler<GetFreeSlotsQuery, GetFreeSlotsQueryResult>
{
    public async Task<GetFreeSlotsQueryResult> HandleAsync(GetFreeSlotsQuery query, CancellationToken cancellationToken)
    {
        return new GetFreeSlotsQueryResult();
    }
}