
namespace PatientInformation.Domain.Common;
public enum UserStatusAction
{
    [Description("Mark As Active")]
    MarkAsActive = 1,
    [Description("Mark As In Active")]
    MarkAsInActive = 2
}
public enum VisaMode
{
    [Description("New")]
    New,
    [Description("Extension")]
    Extension
}

public enum RecordStatus
{
    InActive=1,
    Active=2,
    Deleted
}
