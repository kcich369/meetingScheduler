using Marten;
using MeetingScheduler.Endpoints;
using MeetingScheduler.Shared.Endpoints;
using Oakton.Resources;
using Wolverine;
using Wolverine.Http;
using Wolverine.Marten;
using Wolverine.Postgresql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var connectionString = builder.Configuration.GetConnectionString("MeetingScheduler")
                       ?? throw new Exception("Missing connection string");

builder.Services.AddMarten(options =>
    {
        options.Connection(connectionString);
        options.UseSystemTextJsonForSerialization();
        options.DatabaseSchemaName = "ms";
        // options.Projections.Add<UserState>(ProjectionLifecycle.Inline);
    })
    .IntegrateWithWolverine();

builder.Services.AddResourceSetupOnStartup();
builder.Services.RegisterEndpoints();

builder.Host.UseWolverine(options =>
{
    options.PersistMessagesWithPostgresql(connectionString);
    options.Policies.AutoApplyTransactions();

    options.Policies.UseDurableOutboxOnAllSendingEndpoints();
    options.Policies.UseDurableInboxOnAllListeners();

    options.RegisterMeetingEndpoints();

    options.LocalQueue("meeting-events")
        .Sequential()
        .UseDurableInbox();
});

builder.Services.AddWolverineHttp();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapWolverineEndpoints();
app.UseHttpsRedirection();


app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}