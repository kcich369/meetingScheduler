using MeetingScheduler.Shared.Domain.Results;

namespace MeetingScheduler.Shared.Domain.ValueObjects;

public record UserId
{
    public Guid Value { get; }

    private UserId(Guid value)
    {
        Value = value;
    }

    public static IDomainResult<UserId> Create(Guid? id = null)
    {
        return DomainResult<UserId>.Success(new UserId(id ?? Guid.Empty));
    }

    public override string ToString() => Value.ToString();

    public static implicit operator Guid(UserId userId) => userId.Value;
    public static implicit operator UserId(Guid value) => new(value);
}