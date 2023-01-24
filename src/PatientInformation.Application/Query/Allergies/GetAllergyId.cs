using MediatR;
using PatientInformation.Application.Model;
using PatientInformation.Application.Services.GenericRepository;
using PatientInformation.Domain.Common;
using PatientInformation.Domain.Models;

namespace PatientInformation.Application.Query.Allergies
{
    public record GetAllergyById(long Id) : IRequest<OperationResult<Allergy>>;

    public class GetAllergyIdHandler : IRequestHandler<GetAllergyById, OperationResult<Allergy>>

    {
        private readonly IRepositoryBase<Allergy> _allergyrepository;
        public GetAllergyIdHandler(IRepositoryBase<Allergy> allergyrepository) => _allergyrepository = allergyrepository;
        public async Task<OperationResult<Allergy>> Handle(GetAllergyById request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Allergy>();

            var allergy = await _allergyrepository.FirstOrDefaultAsync(x => x.Id == request.Id && x.RecordStatus == RecordStatus.Active);
            if (allergy is null)
            {
                result.AddError(ErrorCode.NotFound, "Unable to get Allergy data.");
                return result;
            }
            result.Payload = allergy;
            return result;

        }
    }

}
