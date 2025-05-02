using MeetingScheduler.Shared.Domain.Enumerations;

namespace MeetingScheduler.Domain.Enums;

public class SlotStatus : Enumeration
{
    public static SlotStatus Available = new(1, nameof(Available));
    public static SlotStatus Reserved = new(2, nameof(Reserved));
    public static SlotStatus Unavailable = new(3, nameof(Unavailable));

    private SlotStatus(int id, string name) : base(id, name)
    {
    }
}