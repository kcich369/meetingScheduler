using System.Collections.Immutable;

namespace MeetingScheduler.Domain.ValueObjects;

public record TimeRange
{
    public DateTime StartedAt { get; }
    public DateTime EndedAt { get; }

    private TimeRange(DateTime startedAt, DateTime endedAt)
    {
        StartedAt = startedAt;
        EndedAt = endedAt;
    }

    public static TimeRange Create(DateTime startedAt, DateTime endedAt)
    {
        if (endedAt <= startedAt)
            throw new ArgumentException("End time must be later than start time");

        var duration = endedAt - startedAt;

        if (duration.TotalHours > 12)
            throw new ArgumentException("Time range must be less than 12 hours");

        return new TimeRange(startedAt, endedAt);
    }

    public TimeSpan GetDuration()
    {
        return EndedAt - StartedAt;
    }


    public bool Overlaps(TimeRange other)
    {
        return StartedAt < other.EndedAt && other.StartedAt < EndedAt;
    }

    public ImmutableList<TimeRange> HasConflictWith(IEnumerable<TimeRange> otherRanges)
    {
        return otherRanges.Where(Overlaps).ToImmutableList();
    }
}