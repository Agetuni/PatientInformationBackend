namespace PatientInformation.Domain.Models
{
    public class PatientNCDs :BaseEntity
    {
        public long PatientId { get; set; }//fk
        public long NonCommunicableDiseaseId { get; set; }//fk
        public virtual NonCommunicableDisease NonCommunicableDisease { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
