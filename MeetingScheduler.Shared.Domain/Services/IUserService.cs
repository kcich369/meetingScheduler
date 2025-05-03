using MeetingScheduler.Shared.Domain.Models;

namespace MeetingScheduler.Shared.Domain.Services;

public interface IUserService
{
    UserData GetCurrentUser();
}