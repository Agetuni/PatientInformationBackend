namespace PatientInformation.Api.Contracts.Patients
{
    public class PatientInformationResponse
    {
        public long Id { get; set; }
        public string FullName { get; private set; }
        public long DiseaseId { get; private set; }//forign key 
        public Epilepsy Epilepsy { get; private set; }
        public List<PatientAllergyResponse> PatientAllergies { get; set; }
        public List<PatientNCDResponse> PatientNCDs { get; set; }
        public DiseaseResponse Disease { get; set; }
        public PatientInformationResponse()
        {
            PatientAllergies = new List<PatientAllergyResponse>();
            PatientNCDs = new List<PatientNCDResponse>();
        }
    }
    public class PatientAllergyResponse
    {
        public long Id { get; set; }
        public AllergyResponse Allergy { get; set; }
    }
    public class PatientNCDResponse
    {
        public long Id { get; set; }
        public NCDResponse NonCommunicableDisease { get; set; }

    }
}
