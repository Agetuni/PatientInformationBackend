using PatientInformation.Domain.Common;

namespace PatientInformation.Domain.Models
{
    public class Patient : BaseEntity
    {
        public string FullName { get; set; }
        public long DiseaseId { get; set; }//forign key 
        public Epilepsy Epilepsy { get; set; }
        public ICollection<PatientAllergies> PatientAllergies { get; set; }
        public ICollection<PatientNCDs> PatientNCDs { get; set; }
        public virtual Disease Disease { get; set; }

        public static Patient Create(string name, long diseaseId, Epilepsy epilepsy)
        {
            var validator = new PatientValidation();
            var patient = new Patient
            {
                FullName = name,
                DiseaseId = diseaseId,
                Epilepsy = epilepsy
            };
            var validationResult = validator.Validate(patient);
            if (validationResult.IsValid) return patient;
            var exception = new NotValidException("Patient is not valid");
            validationResult.Errors.ForEach(vr => exception.ValidationErrors.Add(vr.ErrorMessage));
            throw exception;

        }
        public void Update(string name, long diseaseId, Epilepsy epilepsy)
        {
            FullName = name;
            DiseaseId = diseaseId;
            Epilepsy = epilepsy;
        }
    }

}
