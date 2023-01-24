namespace PatientInformation.Api.Contracts.Allergies
{
    public class DiseaseResponse
    {
        public long Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public RecordStatus RecordStatus { get; set; }
    }
}
