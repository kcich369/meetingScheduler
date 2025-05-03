using MeetingScheduler.Shared.Application;
using MeetingScheduler.Shared.Application.Commands;

namespace MeetingScheduler.Application.Slots.Create;

public record NewSlot(DateTime StartedAt, DateTime EndedAt);

public record CreateSlotsCommand(IEnumerable<NewSlot> Slots) : ICommand<CreateSlotCommandResult>;

public record CreateSlotCommandResult(IEnumerable<NewSlot> Added, IEnumerable<NewSlot> Errors) : ICommandResult;