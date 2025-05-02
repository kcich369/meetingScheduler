using System.Collections.Immutable;
using MeetingScheduler.Shared.Domain.Enumerations;

namespace MeetingScheduler.Shared.Domain.Results;

public interface IResult<out T>
{
    bool IsError { get; }
    ImmutableList<ErrorInfo> Errors { get; }
    T Data { get; }
}

public class ErrorInfo
{
    public string Module { get; private set; }
    public string Category { get; private set; }
    public string Code { get; private set; }
    public string Message { get; private set; }

    private ErrorInfo(string module, string category, string code, string message)
    {
        Module = module;
        Category = category;
        Code = code;
        Message = message;
    }

    public static ErrorInfo Create(ErrorCodesEnum errorCode) =>
        new ErrorInfo(errorCode.Module, errorCode.Category.ToString(), errorCode.Id.ToString(), errorCode.ErrorMessage);
}

public abstract class Result<T>(bool isError, IEnumerable<ErrorCodesEnum> errorCodes, T data)
    : IResult<T>
{
    public bool IsError { get; protected init; } = isError;

    public ImmutableList<ErrorInfo> Errors { get; protected init; } =
        errorCodes.Select(ErrorInfo.Create).ToImmutableList();

    public T Data { get; protected init; } = data;
}

public class SuccessResult<T> : Result<T>
{
    private SuccessResult(T data) : base(false, [], data)
    {
    }

    public static SuccessResult<T> Create(T data) => new(data);
}

public class ErrorResult<T> : Result<T>
{
    private ErrorResult(IEnumerable<ErrorCodesEnum> errorCodes) : base(true, errorCodes, default!)
    {
    }

    public static ErrorResult<T> Create(params ErrorCodesEnum[] errorCodes)
        => new(errorCodes);
}

public class NotFoundResult<T> : Result<T>
{
    private NotFoundResult(IEnumerable<ErrorCodesEnum> errorCodes) : base(true, errorCodes, default!)
    {
    }

    public static NotFoundResult<T> Create(params ErrorCodesEnum[] errorCodes)
        => new(errorCodes);
}

public class BadRequestResult<T> : Result<T>
{
    private BadRequestResult(IEnumerable<ErrorCodesEnum> errorCodes) : base(true, errorCodes, default!)
    {
    }

    public static BadRequestResult<T> Create(params ErrorCodesEnum[] errorCodes)
        => new(errorCodes);
}

public class ValidationResult<T> : Result<T>
{
    private ValidationResult(IEnumerable<ErrorCodesEnum> errorCodes) : base(true, errorCodes, default!)
    {
    }

    public static ValidationResult<T> Create(params ErrorCodesEnum[] errorCodes)
        => new(errorCodes);
}