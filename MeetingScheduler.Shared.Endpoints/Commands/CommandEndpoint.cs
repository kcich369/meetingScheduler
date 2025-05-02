using MeetingScheduler.Shared.Application;
using MeetingScheduler.Shared.Application.Commands;
using MeetingScheduler.Shared.Domain.Results;
using MeetingScheduler.Shared.Endpoints.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wolverine;

namespace MeetingScheduler.Shared.Endpoints.Commands;

public abstract class CommandEndpoint<TCommand, TCommandResult>
    where TCommand : ICommand<TCommandResult>
    where TCommandResult : ICommandResult
{
    protected async Task<IResult> ExecuteCommand(TCommand command, IMessageBus bus, CancellationToken ct)
    {
        var result = await bus.SendCommandAsync<TCommand, TCommandResult>(command, ct);
        return result switch
        {
            SuccessResult<TCommandResult> successResult => Results.Ok(successResult),
            BadRequestResult<TCommandResult> badRequest => Results.BadRequest(badRequest),
            NotFoundResult<TCommandResult> notFoundResult => Results.NotFound(notFoundResult),
            ValidationResult<TCommandResult> validationResult => Results.Conflict(validationResult),
            ErrorResult<TCommandResult> errorResult => Results.Json(data: errorResult,
                statusCode: StatusCodes.Status500InternalServerError),
            _ => throw new InvalidOperationException($"Unknown result type")
        };
    }

    public abstract Task<IResult> Handle([AsParameters] TCommand command, IMessageBus bus, CancellationToken ct);
}