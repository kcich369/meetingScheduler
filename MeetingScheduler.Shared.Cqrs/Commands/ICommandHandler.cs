using MeetingScheduler.Shared.Domain.Results;

namespace MeetingScheduler.Shared.Application.Commands;

public interface ICommandHandler<in TCommand, TResponse>
    where TCommand : ICommand<TResponse>
    where TResponse : ICommandResult
{
    Task<IResult<TResponse>> HandleAsync(TCommand command, CancellationToken cancellationToken);
}
