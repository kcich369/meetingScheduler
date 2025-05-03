using MeetingScheduler.Shared.Application.Services;
using MeetingScheduler.Shared.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MeetingScheduler.Shared.Endpoints;

public static class Register
{
    public static IServiceCollection MapEndpoints(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IDateTimeProvider, DateTimeProvider>();
        serviceCollection.AddScoped<IUserService, UserService>();
        serviceCollection.AddDistributedMemoryCache();
        serviceCollection.AddHttpContextAccessor();
        
        
        return serviceCollection;
    }
}