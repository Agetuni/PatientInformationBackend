namespace PatientInformation.Api.Contracts.Allergies
{
    public class AllergyResponse
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public RecordStatus RecordStatus { get; set; }
    }
}
