namespace PatientInformation.Domain.Models
{
    public class PatientNCDs :BaseEntity
    {
        public long PatientId { get; private set; }//fk
        public long NonCommunicableDiseaseId { get; private set; }//fk
        public virtual NonCommunicableDisease NonCommunicableDisease { get; set; }
        public virtual Patient Patient { get; set; }
        
        public static PatientNCDs Create(long patientId, long ncdId)
        {
            return new PatientNCDs
            {
                PatientId = patientId,
                NonCommunicableDiseaseId = ncdId,
            };
        }
    }
}
