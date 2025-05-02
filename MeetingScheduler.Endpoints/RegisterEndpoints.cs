using System.Reflection;
using MeetingScheduler.Application.ErrorCodes.GetErrorCodes;
using MeetingScheduler.Shared.Endpoints.Middlewares;
using Wolverine;

namespace MeetingScheduler.Endpoints;

public static class RegisterEndpoints
{
    public static void RegisterMeetingEndpoints(this WolverineOptions options)
    {
        options.Discovery.IncludeAssembly( Assembly.GetAssembly(typeof(RegisterEndpoints))!);
        options.Discovery.IncludeAssembly( Assembly.GetAssembly(typeof(GetMeetingErrorCodesQuery))!);
        options.Policies
            .ForMessagesOfType<ICommand>()
            .AddMiddleware(typeof(MessageIdempotencyMiddleware));
    }
}