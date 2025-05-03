using MeetingScheduler.Shared.Domain.Enumerations;

namespace MeetingScheduler.Shared.Domain.Results;

public interface IDomainResult
{
    bool IsError { get; }
    IEnumerable<ErrorCodesEnum> ErrorCodes { get; }
}

public interface IDomainResult<out T> : IDomainResult
{
    T Data { get; }
}

public class DomainResult<T> : IDomainResult<T>
{
    public bool IsError { get; private init; }
    public IEnumerable<ErrorCodesEnum> ErrorCodes { get; private init; } = new List<ErrorCodesEnum>();
    public T Data { get; private init; } = default!;

    public static IDomainResult<T> Success(T data)
    {
        return new DomainResult<T>
        {
            IsError = false,
            Data = data
        };
    }

    public static IDomainResult<T> Error(ErrorCodesEnum errorCodes)
    {
        return new DomainResult<T>
        {
            IsError = true,
            ErrorCodes = [errorCodes]
        };
    }

    private static IDomainResult<T> Error(IEnumerable<ErrorCodesEnum> errorCodes)
    {
        return new DomainResult<T>
        {
            IsError = true,
            ErrorCodes = errorCodes
        };
    }

    public static IDomainResult<TResult> FromResults<TResult>(Func<TResult> onSuccessResult, params IDomainResult[] results)
    {
        var errorCodes = results
            .Where(r => r.IsError)
            .SelectMany(r => r.ErrorCodes)
            .Distinct()
            .ToList();

        return errorCodes.Count != 0
            ? DomainResult<TResult>.Error(errorCodes)
            : DomainResult<TResult>.Success(onSuccessResult());
    }
}