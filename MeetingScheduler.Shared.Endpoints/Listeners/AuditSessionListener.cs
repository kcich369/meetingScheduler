using Marten;
using MeetingScheduler.Domain.Model.Base;
using MeetingScheduler.Shared.Domain.Services;

namespace MeetingScheduler.Shared.Endpoints.Listeners;

public class AuditSessionListener(IUserService userService, IDateTimeProvider dateTimeProvider)
    : DocumentSessionListenerBase
{
    public override void BeforeSaveChanges(IDocumentSession session)
    {
        var userData = userService.GetCurrentUser();

        foreach (var insert in session.PendingChanges.Inserts())
        {
            if (insert is Entity entity)
            {
                entity.SetCreation(dateTimeProvider.CurrentDateTime(), userData.Name);
            }
        }
        
        foreach (var insert in session.PendingChanges.Updates())
        {
            if (insert is Entity entity)
            {
                entity.SetUpdate(dateTimeProvider.CurrentDateTime(), userData.Name);
            }
        }
    }
}