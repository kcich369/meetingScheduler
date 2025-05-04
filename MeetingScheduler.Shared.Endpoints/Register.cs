using Marten;
using MeetingScheduler.Shared.Application.Services;
using MeetingScheduler.Shared.Domain.Services;
using MeetingScheduler.Shared.Endpoints.Listeners;
using Microsoft.Extensions.DependencyInjection;

namespace MeetingScheduler.Shared.Endpoints;

public static class Register
{
    public static IServiceCollection RegisterEndpoints(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IDateTimeProvider, DateTimeProvider>();
        serviceCollection.AddScoped<IUserService, UserService>();
        serviceCollection.AddScoped<AuditSessionListener>();
        serviceCollection.AddDistributedMemoryCache();
        serviceCollection.AddHttpContextAccessor();
        
        serviceCollection.ConfigureMarten((sp, options) =>
        {
            options.AddMartenOptions(sp);
        });


        return serviceCollection;
    }

    private static StoreOptions AddMartenOptions(this StoreOptions options, IServiceProvider sp)
    {
        var listener = sp.GetRequiredService<AuditSessionListener>();
        options.Listeners.Add(listener);


        return options;
    }
}