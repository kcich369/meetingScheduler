using System;
using MeetingScheduler.Shared.Domain.Results;
using MeetingScheduler.Shared.Domain.ValueObjects;

namespace MeetingScheduler.Shared.Domain.Models;

public class User
{
    public UserId Id { get; }
    public UserName Name { get; }
    public UserRole Role { get; }

    private User(UserId id, UserName name, UserRole role)
    {
        Id = id;
        Name = name;
        Role = role;
    }

    public static IDomainResult<User> Create(Guid? id, string? name, string? role)
    {
        var userIdResult = UserId.Create(id);
        var userNameResult = UserName.Create(name);
        var userRoleResult = UserRole.Create(role);
        return DomainResult<User>.FromResults(
            () => new User(userIdResult.Data, userNameResult.Data, userRoleResult.Data),
            userIdResult, userNameResult, userRoleResult
        );
    }
}