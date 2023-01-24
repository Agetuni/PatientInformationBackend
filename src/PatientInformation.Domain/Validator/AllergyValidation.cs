namespace PatientInformation.Domain.Validator
{
    public class AllergyValidation : AbstractValidator<Allergy>
    {
        public AllergyValidation()
        {
            RuleFor(x => x.Name)
               .NotNull().WithMessage("Allergy name  can't be null")
               .NotEmpty().WithMessage("Allergy name  can't be empty");
            RuleFor(x => x.Description)
              .NotNull().WithMessage("Allergy description   can't be null")
              .NotEmpty().WithMessage("Allergy description   can't be empty");
        }
    }
}
