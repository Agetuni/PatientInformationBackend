using PatientInformation.Domain.Validator;

namespace PatientInformation.Domain.Models
{
    public class Country :BaseEntity
    {
        public string Name { get; private set; }
        public string Code { get; private set; }
        public static Country Create(string name, string code)
        {
            var validator = new CountryValidation();
            var country = new Country
            {
                Name = name,
                Code = code,
            };
            var validationResult = validator.Validate(country);
            if (validationResult.IsValid) return country;
            var exception = new NotValidException("Country is not valid");
            validationResult.Errors.ForEach(vr => exception.ValidationErrors.Add(vr.ErrorMessage));
            throw exception;

        }
        public void Update(string name, string code)
        {
            Name = name;
            Code = code;
            UpdateAudit(String.Empty);
        }
    }
}
