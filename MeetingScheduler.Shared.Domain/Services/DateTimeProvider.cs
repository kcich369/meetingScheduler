namespace MeetingScheduler.Shared.Domain.Services;

public class DateTimeProvider
{
    public DateTime GetCurrentDate() => DateTime.UtcNow;
}