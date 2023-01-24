namespace PatientInformation.Api.Contracts.Allergies
{
    public class NCDResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public RecordStatus RecordStatus { get; set; }
    }
}
