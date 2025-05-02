using MeetingScheduler.Shared.Application;
using MeetingScheduler.Shared.Application.Queries;

namespace MeetingScheduler.Application.ErrorCodes.GetErrorCodes;

public record GetMeetingErrorCodesQueryResult(List<string> Codes) : IQueryResult;
