namespace PatientInformation.Domain.Validator
{
    public class NonCommunicableDiseaseValidation : AbstractValidator<NonCommunicableDisease>
    {
        public NonCommunicableDiseaseValidation()
        {
            RuleFor(x => x.Name)
               .NotNull().WithMessage("NCD name  can't be null")
               .NotEmpty().WithMessage("NCD name  can't be empty");
            RuleFor(x => x.Description)
              .NotNull().WithMessage("NCD description   can't be null")
              .NotEmpty().WithMessage("NCD description   can't be empty");
        }
    }
}
