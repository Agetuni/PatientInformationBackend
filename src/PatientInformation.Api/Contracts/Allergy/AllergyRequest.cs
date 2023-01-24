using System.ComponentModel.DataAnnotations;

namespace PatientInformation.Api.Contracts.Allergies
{
    public class AllergyRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
