namespace MeetingScheduler.Shared.Domain.Enumerations;

public class ErrorCodesEnum(string module, ErrorCategoryEnum category, int id, string name, string errorMessage)
    : Enumeration(id, name)
{
    public string Module { get; } = module;

    public ErrorCategoryEnum Category { get; } = category;
    public string ErrorMessage { get; } = errorMessage;

    public static readonly ErrorCodesEnum None = new(string.Empty, ErrorCategoryEnum.None, 0, nameof(None), "No error");
}