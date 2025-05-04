using System.Security.Claims;
using MeetingScheduler.Shared.Domain.Models;
using MeetingScheduler.Shared.Domain.Services;
using Microsoft.AspNetCore.Http;

namespace MeetingScheduler.Shared.Application.Services;

public class UserService(IHttpContextAccessor contextAccessor) : IUserService
{
    public UserData GetCurrentUser()
    {
        var identity = contextAccessor.HttpContext?.User?.Identity as  ClaimsIdentity;

        var userName = identity!.FindFirst(ClaimTypes.Name)?.Value ;
        var userId = identity.FindFirst(ClaimTypes.NameIdentifier)?.Value ;
        var userRole = identity.FindFirst(ClaimTypes.Role)?.Value ;

        return UserData.Create(Guid.Parse( userId ?? Guid.Empty.ToString()), userName, userRole).Data;
    }
}

