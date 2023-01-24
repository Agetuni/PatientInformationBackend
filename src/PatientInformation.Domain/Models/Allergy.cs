namespace PatientInformation.Domain.Models
{
    public class Allergy : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public static Allergy Create(string name, string description)
        {
            var validator = new AllergyValidation();
            var allergy = new Allergy
            {
                Name = name,
                Description = description,
            };
            var validationResult = validator.Validate(allergy);
            if (validationResult.IsValid) return allergy;
            var exception = new NotValidException("Allergy is not valid");
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
