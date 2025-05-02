using MeetingScheduler.Shared.Application;
using MeetingScheduler.Shared.Application.Commands;

namespace MeetingScheduler.Application.Slots.Create;

public record Slot(DateTime StartedAt, DateTime EndedAt);

public record CreateSlotCommand(IEnumerable<Slot> Slots) : ICommand<CreateSlotCommandResult>;

public record CreateSlotCommandResult(int Created, IEnumerable<Slot> Errors) : ICommandResult;