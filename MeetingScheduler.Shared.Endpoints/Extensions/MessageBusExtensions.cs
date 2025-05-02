using MeetingScheduler.Shared.Application;
using MeetingScheduler.Shared.Application.Commands;
using MeetingScheduler.Shared.Application.Queries;
using MeetingScheduler.Shared.Domain.Results;
using Wolverine;

namespace MeetingScheduler.Shared.Endpoints.Extensions;

public static class MessageBusExtensions
{
    public static Task<TResult> QueryAsync<TQuery, TResult>(this IMessageBus bus, TQuery query, CancellationToken ct)
        where TQuery : IQuery<TResult>
        where TResult : IQueryResult =>
        bus.InvokeAsync<TResult>(query, ct);

    public static Task<IResult<TCommandResult>> SendCommandAsync<TCommand, TCommandResult>(this IMessageBus bus,
        TCommand command, CancellationToken ct)
        where TCommand : ICommand<TCommandResult>
        where TCommandResult : ICommandResult =>
        bus.InvokeAsync<IResult<TCommandResult>>(command, ct);
}