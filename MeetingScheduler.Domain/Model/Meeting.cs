using MeetingScheduler.Domain.IDs;
using MeetingScheduler.Domain.Model.Base;
using MeetingScheduler.Shared.Domain.Results;

namespace MeetingScheduler.Domain.Model;

public class Meeting : Entity<MeetingId>
{
    private Meeting(MeetingId id, DateTime createdAt, string createdBy) : base(id, createdAt, createdBy)
    {
        Id = id;
    }
    

    public static IDomainResult<Meeting> Create(MeetingId id, DateTime createdAt, string createdBy)
    {
        var meeting = new Meeting(id, createdAt, createdBy);
        return DomainResult<Meeting>.Success(meeting);
    }
}