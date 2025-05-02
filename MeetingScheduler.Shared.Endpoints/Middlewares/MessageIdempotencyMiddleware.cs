using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Wolverine;

namespace MeetingScheduler.Shared.Endpoints.Middlewares;

public static class MessageIdempotencyMiddleware
{
    private const string IdempotencyKey = "IdempotencyKey";

    public static HandlerContinuation Before(
        ICommand cmd,
        IMessageContext ctx,
        IDistributedCache cache)
    {
        if (ctx.Envelope == null)
            return HandlerContinuation.Continue;

        if (!ctx.Envelope.Headers.TryGetValue("Idempotency-Key", out var idemValue)
            || string.IsNullOrWhiteSpace(idemValue))
            throw new BadHttpRequestException("Missing or empty Idempotency-Key header");

        var key = $"{IdempotencyKey}:{idemValue}";

        if (cache.Get(key) != null)
            throw new ApplicationException("Idempotency Error: Duplicated request");

        cache.Set(key, [1], new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(3)
        });
        return HandlerContinuation.Continue;
    }
}