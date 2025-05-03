using System;
using MeetingScheduler.Shared.Domain.Results;
using MeetingScheduler.Shared.Domain.ValueObjects;

namespace MeetingScheduler.Shared.Domain.Models;

public class UserData
{
    public UserId Id { get; }
    public UserName Name { get; }
    public UserRole Role { get; }

    private UserData(UserId id, UserName name, UserRole role)
    {
        Id = id;
        Name = name;
        Role = role;
    }

    public static IDomainResult<UserData> Create(Guid? id, string? name, string? role)
    {
        var userIdResult = UserId.Create(id);
        var userNameResult = UserName.Create(name);
        var userRoleResult = UserRole.Create(role);
        return DomainResult<UserData>.FromResults(
            () => new UserData(userIdResult.Data, userNameResult.Data, userRoleResult.Data),
            userIdResult, userNameResult, userRoleResult
        );
    }
}