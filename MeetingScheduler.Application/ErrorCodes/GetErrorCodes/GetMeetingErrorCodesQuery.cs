using Marten.Linq.QueryHandlers;
using MeetingScheduler.Shared.Application;
using MeetingScheduler.Shared.Application.Queries;

namespace MeetingScheduler.Application.ErrorCodes.GetErrorCodes;

public record GetMeetingErrorCodesQuery() : IQuery<GetMeetingErrorCodesQueryResult>;