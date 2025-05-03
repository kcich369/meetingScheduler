namespace MeetingScheduler.Shared.Domain.Services;

public interface IDateTimeProvider
{
    DateTime CurrentDateTime() => DateTime.UtcNow;
}