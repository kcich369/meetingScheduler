namespace MeetingScheduler.Shared.Domain.Enumerations;

public class ErrorCategoryEnum: Enumeration
{
    public static readonly ErrorCategoryEnum None = new(0, nameof(None));
    protected ErrorCategoryEnum(int id, string name) : base(id, name)
    {
    }
}
