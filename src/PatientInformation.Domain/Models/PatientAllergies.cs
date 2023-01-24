namespace PatientInformation.Domain.Models
{
    public class PatientAllergies:BaseEntity
    {
        public long PatientId { get; set; }//fk
        public long AllergyId { get; set; }//fk
        public virtual Allergy Allergy { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
