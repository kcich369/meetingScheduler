using MeetingScheduler.Shared.Domain.Enumerations;
using MeetingScheduler.Shared.Domain.Results;

namespace MeetingScheduler.Shared.Domain.ValueObjects;

public record UserName
{
    private const string DefaultUserName = "System";
    private const int Length = 100;
    public string Value { get; }

    private UserName(string value)
    {
        Value = value;
    }

    public static IDomainResult<UserName> Create(string? name)
    {
        return name?.Length > Length
            ? DomainResult<UserName>.Error(ErrorCodesEnum.UserNameLength.WithParams(Length))
            : DomainResult<UserName>.Success(new UserName(name ?? DefaultUserName));
    }

    public static implicit operator string(UserName userName) => userName.Value;
    public static implicit operator UserName(string value) => new(value);
}