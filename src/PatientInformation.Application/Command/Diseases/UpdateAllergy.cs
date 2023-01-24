using MediatR;
using PatientInformation.Application.Model;
using PatientInformation.Application.Services.GenericRepository;
using PatientInformation.Domain.Common;
using PatientInformation.Domain.Models;

namespace PatientInformation.Application.Command.Allergies
{
    public record UpdateDisease(long id, string Name, string Description) : IRequest<OperationResult<Disease>>;

    public class UpdateDiseaseHandler : IRequestHandler<UpdateDisease, OperationResult<Disease>>
    {
        private readonly IRepositoryBase<Disease> _diseaserepository;
        public UpdateDiseaseHandler(IRepositoryBase<Disease> diseaserepository) => _diseaserepository = diseaserepository;
        public async Task<OperationResult<Disease>> Handle(UpdateDisease request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Disease>();
            var disease = await _diseaserepository.FirstOrDefaultAsync(x => x.Id == request.id && x.RecordStatus == RecordStatus.Active);
            if (disease is null)
            {
                result.AddError(ErrorCode.NotFound, "Unable to get disease data.");
                return result;
            }
            disease.Update(request.Name, request.Description);
            _diseaserepository.Update(disease);
            result.Payload = disease;
            return result;
        }
    }

}
