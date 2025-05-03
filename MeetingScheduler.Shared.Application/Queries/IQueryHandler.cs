namespace MeetingScheduler.Shared.Application.Queries;

public interface IQueryHandler<in TQuery, TResponse>
    where TQuery : IQuery<TResponse>
    where TResponse : IQueryResult
{
    Task<TResponse> HandleAsync(TQuery query, CancellationToken cancellationToken);
}
