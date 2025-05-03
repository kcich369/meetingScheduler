namespace MeetingScheduler.Shared.Domain.Enumerations;

public class ErrorCategoryEnum: Enumeration
{
    public static readonly ErrorCategoryEnum None = new(-1, nameof(None));
    public static readonly ErrorCategoryEnum UserData = new(0, nameof(UserData));
    protected ErrorCategoryEnum(int id, string name) : base(id, name)
    {
    }
}
