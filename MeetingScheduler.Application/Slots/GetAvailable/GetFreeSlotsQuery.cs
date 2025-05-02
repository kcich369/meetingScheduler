using MeetingScheduler.Shared.Application;
using MeetingScheduler.Shared.Application.Commands;
using MeetingScheduler.Shared.Application.Queries;

namespace MeetingScheduler.Application.Slots.GetSlots;

public class GetFreeSlotsQuery : IQuery<GetFreeSlotsQueryResult>
{
}

public class GetFreeSlotsQueryResult : IQueryResult, ICommandResult
{
    public Guid Id { get; set; }
    public DateTime StartedAt { get; set; }
    public DateTime EndedAt { get; set; }

}