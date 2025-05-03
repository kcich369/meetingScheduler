using MeetingScheduler.Shared.Domain.Enumerations;
using MeetingScheduler.Shared.Domain.Results;

namespace MeetingScheduler.Shared.Domain.ValueObjects;

public record UserRole
{
    private const string DefaultRole = "Guest";
    private const int Length = 50;
    public string Value { get; }

    private UserRole(string value)
    {
        Value = value;
    }

    public static IDomainResult<UserRole> Create(string? role)
    {
        return role?.Length > Length
            ? DomainResult<UserRole>.Error(ErrorCodesEnum.UserRoleLength.WithParams(Length))
            : DomainResult<UserRole>.Success(new UserRole(role ?? DefaultRole));
    }

    public static implicit operator string(UserRole role) => role.Value;
    public static implicit operator UserRole(string value) => new(value);
}