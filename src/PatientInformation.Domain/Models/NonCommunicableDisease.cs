using PatientInformation.Domain.Validator;

namespace PatientInformation.Domain.Models
{
    public class NonCommunicableDisease : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public static NonCommunicableDisease Create(string name, string description)
        {
            var validator = new NonCommunicableDiseaseValidation();
            var nonCommunicableDisease = new NonCommunicableDisease
            {
                Name = name,
                Description = description,
            };
            var validationResult = validator.Validate(nonCommunicableDisease);
            if (validationResult.IsValid) return nonCommunicableDisease;
            var exception = new NotValidException("NCD is not valid");
            validationResult.Errors.ForEach(vr => exception.ValidationErrors.Add(vr.ErrorMessage));
            throw exception;

        }
        public void Update(string name, string description)
        {
            Name = name;
            Description = description;
            UpdateAudit(String.Empty);
        }
    }
}
