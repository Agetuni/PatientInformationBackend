using MediatR;
using PatientInformation.Application.Model;
using PatientInformation.Application.Services.GenericRepository;
using PatientInformation.Domain.Models;

namespace PatientInformation.Application.Command.Allergies
{
    public record CreateAllergy(string Name, string Description): IRequest<OperationResult<Allergy>>;

    public class CreateAllergyHandler : IRequestHandler<CreateAllergy, OperationResult<Allergy>>
    {
        private readonly IRepositoryBase<Allergy> _allergyrepository;
        public CreateAllergyHandler(IRepositoryBase<Allergy> allergyrepository) => _allergyrepository = allergyrepository;
        public async Task<OperationResult<Allergy>> Handle(CreateAllergy request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Allergy>();
            var existingAllergy = await _allergyrepository.ExistWhereAsync(x => x.Name == request.Description);
            if (existingAllergy)
            {
                result.AddError(ErrorCode.RecordFound, "Allergyis already registerd.");
                return result;
            }
            var allergy = Allergy.Create(request.Name, request.Description);
            await _allergyrepository.AddAsync(allergy);

            result.Payload = allergy;
            return result;
        }
    }

}
