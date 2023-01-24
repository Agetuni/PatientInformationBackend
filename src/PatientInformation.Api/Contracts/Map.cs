
namespace PatientInformation.Api.Contracts
{
    public class Map : Profile
    {
        public Map()
        {
            CreateMap<Allergy, AllergyResponse>();
        }
    }
}
