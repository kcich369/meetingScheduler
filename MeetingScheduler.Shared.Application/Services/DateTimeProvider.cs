using MeetingScheduler.Shared.Domain.Services;

namespace MeetingScheduler.Shared.Application.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime CurrentDateTime() => DateTime.UtcNow;
}