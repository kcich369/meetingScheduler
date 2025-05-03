using MeetingScheduler.Application.Slots.GetAvailable;
using MeetingScheduler.Shared.Endpoints.Queries;
using Microsoft.AspNetCore.Http;
using Wolverine;
using Wolverine.Http;

namespace MeetingScheduler.Endpoints.Slots;

public class GetSlotsEndpoint : QueryEndpoint<GetFreeSlotsQuery, GetFreeSlotsQueryResult>
{
    [WolverineGet("slots")]
    public override Task<IResult> HandleQuery(GetFreeSlotsQuery query, IMessageBus bus, CancellationToken ct)
    {
        return ExecuteQuery(query, bus, ct);
    }
}