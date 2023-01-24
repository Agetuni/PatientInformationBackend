namespace PatientInformation.Application.Model
{
    public enum RecordStatuss
    {
        [Description("InActive")]
        InActive = 1,
        [Description("Active")]
        Active = 2,
        [Description("Deleted")]
        Deleted = 3
    }
    public enum StatusFilter
    {
        [Description("InActive")]
        InActive = 1,
        [Description("Active")]
        Active = 2
    }
}
