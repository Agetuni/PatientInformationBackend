namespace PatientInformation.Domain.Validator
{
    public class DiseaseValidation : AbstractValidator<Disease>
    {
        public DiseaseValidation()
        {
            RuleFor(x => x.Name)
               .NotNull().WithMessage("Disease name  can't be null")
               .NotEmpty().WithMessage("Disease name  can't be empty");
            RuleFor(x => x.Description)
              .NotNull().WithMessage("Disease description   can't be null")
              .NotEmpty().WithMessage("Disease description   can't be empty");
        }
    }
}
