namespace PatientInformation.Domain.Validator
{
    public class PatientValidation : AbstractValidator<Patient>
    {
        public PatientValidation()
        {
            RuleFor(x => x.FullName)
               .NotNull().WithMessage("Patient name  can't be null")
               .NotEmpty().WithMessage("Patient name  can't be empty");
        }
    }
}
