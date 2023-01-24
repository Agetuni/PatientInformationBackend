using FluentValidation;
using PatientInformation.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientInformation.Domain.Validator
{
    public class CountryValidation : AbstractValidator<Country>
    {
        public CountryValidation()
        {
            RuleFor(x => x.Name)
               .NotNull().WithMessage("Country name  can't be null")
               .NotEmpty().WithMessage("Country name  can't be empty");
        }
    }
}
