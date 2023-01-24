using System.ComponentModel.DataAnnotations;

namespace PatientInformation.Api.Contracts.Patients
{
    public class PatientInformationRequest
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public long Disease { get; set; }
        [Required]
        public Epilepsy Epilepsy { get; set; }
        public List<long> NCDsDetails { get; set; }
        public List<long> AllergiesDetails { get; set; }
        public PatientInformationRequest()
        {
            NCDsDetails = new List<long>();
            AllergiesDetails = new List<long>();    
        }
    }
}
