using MeetingScheduler.Shared.Domain.Enumerations;

namespace MeetingScheduler.Shared.Domain.Results;

public interface IDomainResult<out T>
{
    bool IsError { get; }
    string ErrorMessage { get; }
    ErrorCodesEnum ErrorCodesEnum { get; }
    T Data { get; }
}

public class DomainResult<T> : IDomainResult<T>
{
    public bool IsError { get; private init; }
    public string ErrorMessage { get; private init; } = string.Empty;
    public ErrorCodesEnum ErrorCodesEnum { get; private init; } = ErrorCodesEnum.None;
    public T Data { get; private init; } = default!;

    public static IDomainResult<T> Success(T data)
    {
        return new DomainResult<T>
        {
            IsError = false,
            Data = data
        };
    }

    public static IDomainResult<T> Error(ErrorCodesEnum errorCodesEnum)
    {
        return new DomainResult<T>
        {
            IsError = true,
            ErrorCodesEnum = errorCodesEnum,
            ErrorMessage = errorCodesEnum.ErrorMessage,
            Data = default!
        };
    }

    public IResult<T2> ToErrorResult<T2>()
    {
        return IsError
            ? BadRequestResult<T2>.Create(ErrorCodesEnum)
            : throw new InvalidOperationException("Domain Result is not null");
    }
}