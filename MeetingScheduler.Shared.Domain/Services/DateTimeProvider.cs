namespace MeetingScheduler.Shared.Domain.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime CurrentDate() => DateTime.UtcNow;
}