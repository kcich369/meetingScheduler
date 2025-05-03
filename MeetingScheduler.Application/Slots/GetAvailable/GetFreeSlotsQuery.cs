using MeetingScheduler.Shared.Application.Commands;
using MeetingScheduler.Shared.Application.Queries;

namespace MeetingScheduler.Application.Slots.GetAvailable;
public record GetFreeSlotsQuery(DateOnly EndDate) : IQuery<GetFreeSlotsQueryResult>;

public record GetFreeSlotsQueryResult(IEnumerable<GetFreeSlotsQueryElement> Slots) : IQueryResult;
public record GetFreeSlotsQueryElement(Guid Id, DateTime StartedAt, DateTime EndedAt);
