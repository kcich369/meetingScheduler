namespace MeetingScheduler.Shared.Domain.Services;

public interface IDateTimeProvider
{
    DateTime CurrentDate() => DateTime.UtcNow;
}