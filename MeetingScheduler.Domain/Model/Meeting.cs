using MeetingScheduler.Domain.IDs;

namespace MeetingScheduler.Domain.Model;

public class Meeting
{
    public MeetingId Id { get; private set; }
}