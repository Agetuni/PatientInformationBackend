using MediatR;
using PatientInformation.Application.Model;
using PatientInformation.Application.Services.GenericRepository;
using PatientInformation.Domain.Common;
using PatientInformation.Domain.Models;

namespace PatientInformation.Application.Command.Allergies
{
    public record UpdateAllergy(long id, string Name, string Description) : IRequest<OperationResult<Allergy>>;

    public class UpdateAllergyHandler : IRequestHandler<UpdateAllergy, OperationResult<Allergy>>
    {
        private readonly IRepositoryBase<Allergy> _allergyrepository;
        public UpdateAllergyHandler(IRepositoryBase<Allergy> allergyrepository) => _allergyrepository = allergyrepository;
        public async Task<OperationResult<Allergy>> Handle(UpdateAllergy request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Allergy>();
            var allergy = await _allergyrepository.FirstOrDefaultAsync(x => x.Id == request.id && x.RecordStatus == RecordStatus.Active);
            if (allergy is null)
            {
                result.AddError(ErrorCode.NotFound, "Unable to get Allergy data.");
                return result;
            }
            allergy.Update(request.Name, request.Description);
            _allergyrepository.Update(allergy);
            result.Payload = allergy;
            return result;
        }
    }

}
