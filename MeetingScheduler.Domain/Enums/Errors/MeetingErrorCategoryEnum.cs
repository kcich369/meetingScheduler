using MeetingScheduler.Shared.Domain.Enumerations;

namespace MeetingScheduler.Domain.Enums.Errors;

public class MeetingErrorCategoryEnum : ErrorCategoryEnum
{
    public static readonly MeetingErrorCategoryEnum Slot = new(1, nameof(Slot));
    public static readonly MeetingErrorCategoryEnum Meeting = new(2, nameof(Meeting));
    public static readonly MeetingErrorCategoryEnum User = new(3, nameof(User));
    public static readonly MeetingErrorCategoryEnum Account = new(4, nameof(Account));

    private MeetingErrorCategoryEnum(int id, string name) : base(id, name)
    {
    }
}