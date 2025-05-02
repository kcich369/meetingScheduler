using MeetingScheduler.Shared.Application;
using MeetingScheduler.Shared.Application.Queries;
using MeetingScheduler.Shared.Endpoints.Extensions;
using Microsoft.AspNetCore.Http;
using Wolverine;

namespace MeetingScheduler.Shared.Endpoints.Queries;

public abstract class QueryEndpoint<TQuery, TResult>
    where TQuery : IQuery<TResult>
    where TResult : IQueryResult
{
    protected async Task<IResult> ExecuteQuery(TQuery query, IMessageBus bus, CancellationToken ct)
    {
        return Results.Ok(await bus.QueryAsync<TQuery, TResult>(query, ct));
    }

    public abstract Task<IResult> HandleQuery([AsParameters] TQuery query, IMessageBus bus, CancellationToken ct);
}