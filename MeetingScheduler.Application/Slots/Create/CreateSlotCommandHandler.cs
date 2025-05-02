using Marten;
using MeetingScheduler.Shared.Application;
using MeetingScheduler.Shared.Application.Commands;
using MeetingScheduler.Shared.Domain.Results;
using MeetingScheduler.Shared.Domain.Services;

namespace MeetingScheduler.Application.Slots.Create;

public class CreateSlotCommandHandler(IDateTimeProvider dateTimeProvider, IDocumentSession documentSession)
    : ICommandHandler<CreateSlotCommand, CreateSlotCommandResult>
{
    public Task<IResult<CreateSlotCommandResult>> HandleAsync(CreateSlotCommand command,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}