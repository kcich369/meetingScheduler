using MeetingScheduler.Domain.Enums.Errors;
using MeetingScheduler.Shared.Application;
using MeetingScheduler.Shared.Application.Queries;
using MeetingScheduler.Shared.Domain.Enumerations;

namespace MeetingScheduler.Application.ErrorCodes.GetErrorCodes;

public class
    GetMeetingErrorCodesQueryHandler : IQueryHandler<GetMeetingErrorCodesQuery, GetMeetingErrorCodesQueryResult>
{
    public Task<GetMeetingErrorCodesQueryResult> HandleAsync(GetMeetingErrorCodesQuery query,
        CancellationToken cancellationToken) =>
        Task.FromResult(new GetMeetingErrorCodesQueryResult(
            Enumeration.GetAll<MeetingErrorCodesEnum>().Select(x => x.Name).ToList()));
}