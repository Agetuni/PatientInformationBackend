namespace PatientInformation.Domain.Models
{
    public class Disease : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public static Disease Create(string name, string description)
        {
            var validator = new DiseaseValidation();
            var disease = new Disease
            {
                Name = name,
                Description = description,
            };
            var validationResult = validator.Validate(disease);
            if (validationResult.IsValid) return disease;
            var exception = new NotValidException("Disease is not valid");
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
