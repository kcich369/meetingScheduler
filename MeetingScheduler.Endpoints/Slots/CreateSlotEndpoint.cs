using MeetingScheduler.Application.Slots.Create;
using MeetingScheduler.Shared.Endpoints.Commands;
using Microsoft.AspNetCore.Http;
using Wolverine;
using Wolverine.Attributes;
using Wolverine.Http;

namespace MeetingScheduler.Endpoints.Slots;

public class CreateSlotEndpoint : CommandEndpoint<CreateSlotCommand, CreateSlotCommandResult>
{
    [Transactional]
    [WolverinePost("slots")]
    public override Task<IResult> Handle(CreateSlotCommand command, IMessageBus bus, CancellationToken ct)
    {
        return ExecuteCommand(command, bus, ct);
    }
}