namespace MeetingScheduler.Shared.Domain.Enumerations;

public class ErrorCodesEnum(string module, ErrorCategoryEnum category, int id, string name, string errorMessage)
    : Enumeration(id, name)
{
    public string Module { get; } = module;

    public ErrorCategoryEnum Category { get; } = category;
    public string ErrorMessage { get; private set; } = errorMessage;

    public static readonly ErrorCodesEnum None = new(string.Empty, ErrorCategoryEnum.None, 0, nameof(None), "No error");

    public static readonly ErrorCodesEnum UserId = new(nameof(ErrorCategoryEnum.UserData), ErrorCategoryEnum.UserData,
        1, nameof(UserId), "Incorrect user id: {0}");

    public static readonly ErrorCodesEnum UserRole = new(nameof(ErrorCategoryEnum.UserData), ErrorCategoryEnum.UserData,
        2, nameof(UserRole), "Incorrect user role: {0}");

    public static readonly ErrorCodesEnum UserName = new(nameof(ErrorCategoryEnum.UserData), ErrorCategoryEnum.UserData,
        3, nameof(UserName), "Incorrect user name: {0}"); 
    public static readonly ErrorCodesEnum UserNameLength = new(nameof(ErrorCategoryEnum.UserData), ErrorCategoryEnum.UserData,
        4, nameof(UserName), "UserName cannot exceed {0} characters.");
    
    public static readonly ErrorCodesEnum UserRoleLength = new(nameof(ErrorCategoryEnum.UserData), ErrorCategoryEnum.UserData,
        5, nameof(UserRole), "UserRole cannot exceed {0} characters.");

    public ErrorCodesEnum WithParams(params object[] args)
    {
        if (args.Length == 0)
            return this;
        ErrorMessage = string.Format(ErrorMessage, args);
        return this;
    }
}