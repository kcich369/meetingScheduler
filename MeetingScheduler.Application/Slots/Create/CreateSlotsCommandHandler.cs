using Marten;
using MeetingScheduler.Domain.Model;
using MeetingScheduler.Shared.Application.Commands;
using MeetingScheduler.Shared.Domain.Results;
using MeetingScheduler.Shared.Domain.Services;

namespace MeetingScheduler.Application.Slots.Create;

public class CreateSlotsCommandHandler(IDateTimeProvider dateTimeProvider, IDocumentSession documentSession)
    : ICommandHandler<CreateSlotsCommand, CreateSlotCommandResult>
{
    public Task<IResult<CreateSlotCommandResult>> HandleAsync(CreateSlotsCommand command,
        CancellationToken cancellationToken)
    {
        var newSlots = command.Slots.Select(x=>Slot.Create());
    }
}