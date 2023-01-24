
using PatientInformation.Api.Contracts.Patients;

namespace PatientInformation.Api.Contracts
{
    public class Map : Profile
    {
        public Map()
        {
            CreateMap<Allergy, AllergyResponse>();
            CreateMap<Disease, DiseaseResponse>();
            CreateMap<Patient, PatientInformationResponse>();
            CreateMap<NonCommunicableDisease, NCDResponse>();

            CreateMap<PatientAllergies, PatientAllergyResponse>();
            CreateMap<PatientNCDs, PatientNCDResponse>();
        }
    }
}
