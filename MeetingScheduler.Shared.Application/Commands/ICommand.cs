namespace MeetingScheduler.Shared.Application.Commands;

public interface ICommand<TResponse> where TResponse : ICommandResult
{
}
