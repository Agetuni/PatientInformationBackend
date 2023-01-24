using MediatR;
using PatientInformation.Application.Model;
using PatientInformation.Application.Services.GenericRepository;
using PatientInformation.Domain.Common;
using PatientInformation.Domain.Models;

namespace PatientInformation.Application.Query.Allergies
{
    public record GetDiseaseById(long Id) : IRequest<OperationResult<Disease>>;

    public class GetDiseaseByIdHandler : IRequestHandler<GetDiseaseById, OperationResult<Disease>>

    {
        private readonly IRepositoryBase<Disease> _diseaserepository;
        public GetDiseaseByIdHandler(IRepositoryBase<Disease> allergyrepository) => _diseaserepository = allergyrepository;
        public async Task<OperationResult<Disease>> Handle(GetDiseaseById request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Disease>();

            var disease = await _diseaserepository.FirstOrDefaultAsync(x => x.Id == request.Id && x.RecordStatus == RecordStatus.Active);
            if (disease is null)
            {
                result.AddError(ErrorCode.NotFound, "Unable to get Disease data.");
                return result;
            }
            result.Payload = disease;
            return result;

        }
    }

}
