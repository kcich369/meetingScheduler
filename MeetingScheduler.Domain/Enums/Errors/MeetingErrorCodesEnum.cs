using MeetingScheduler.Shared.Domain.Enumerations;

namespace MeetingScheduler.Domain.Enums.Errors;

public class MeetingErrorCodesEnum(ErrorCategoryEnum category, int id, string name, string errorMessage)
    : ErrorCodesEnum("Meetings", category, id, name, errorMessage)
{
    public static readonly MeetingErrorCodesEnum SlotInvalidTiming = new(
        MeetingErrorCategoryEnum.Slot, 1, nameof(SlotInvalidTiming), "The slot timing is invalid");

    public static readonly MeetingErrorCodesEnum SlotOverlapping = new(
        MeetingErrorCategoryEnum.Slot, 2, nameof(SlotOverlapping), "The slot overlaps with existing slots");

    public static readonly MeetingErrorCodesEnum SlotNotFound = new(
        MeetingErrorCategoryEnum.Slot, 3, nameof(SlotNotFound), "The requested slot was not found");

    public static readonly MeetingErrorCodesEnum MeetingInvalidParticipants = new(
        MeetingErrorCategoryEnum.Meeting, 1, nameof(MeetingInvalidParticipants),
        "Invalid participants for the meeting");

    public static readonly MeetingErrorCodesEnum MeetingNotFound = new(
        MeetingErrorCategoryEnum.Meeting, 2, nameof(MeetingNotFound), "The requested meeting was not found");

    public static readonly MeetingErrorCodesEnum MeetingAlreadyScheduled = new(
        MeetingErrorCategoryEnum.Meeting, 3, nameof(MeetingAlreadyScheduled), "The meeting is already scheduled");

    public static readonly MeetingErrorCodesEnum UserNotFound = new(
        MeetingErrorCategoryEnum.User, 1, nameof(UserNotFound), "The user was not found");

    public static readonly MeetingErrorCodesEnum UserInvalidData = new(
        MeetingErrorCategoryEnum.User, 2, nameof(UserInvalidData), "The user data is invalid");

    public static readonly MeetingErrorCodesEnum AccountLocked = new(
        MeetingErrorCategoryEnum.Account, 1, nameof(AccountLocked), "The account is locked");

    public static readonly MeetingErrorCodesEnum InvalidCredentials = new(
        MeetingErrorCategoryEnum.Account, 2, nameof(InvalidCredentials), "Invalid login credentials");
}