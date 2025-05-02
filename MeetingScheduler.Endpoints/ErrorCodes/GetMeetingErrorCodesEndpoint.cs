using MeetingScheduler.Application.ErrorCodes.GetErrorCodes;
using MeetingScheduler.Shared.Endpoints.Queries;
using Microsoft.AspNetCore.Http;
using Wolverine;
using Wolverine.Http;

namespace MeetingScheduler.Endpoints.ErrorCodes;

public class GetMeetingErrorCodesEndpoint : QueryEndpoint<GetMeetingErrorCodesQuery, GetMeetingErrorCodesQueryResult>
{
    [WolverineGet("/error-codes")]
    public override Task<IResult>
        HandleQuery(GetMeetingErrorCodesQuery query, IMessageBus bus, CancellationToken ct) =>
        ExecuteQuery(query, bus, ct);
}