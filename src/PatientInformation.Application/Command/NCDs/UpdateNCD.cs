using MediatR;
using PatientInformation.Application.Model;
using PatientInformation.Application.Services.GenericRepository;
using PatientInformation.Domain.Common;
using PatientInformation.Domain.Models;

namespace PatientInformation.Application.Command.Allergies
{
    public record UpdateNCD(long id, string Name, string Description) : IRequest<OperationResult<NonCommunicableDisease>>;

    public class UpdateNCDHandler : IRequestHandler<UpdateNCD, OperationResult<NonCommunicableDisease>>
    {
        private readonly IRepositoryBase<NonCommunicableDisease> _ncdrepository;
        public UpdateNCDHandler(IRepositoryBase<NonCommunicableDisease> ncdrepository) => _ncdrepository = ncdrepository;
        public async Task<OperationResult<NonCommunicableDisease>> Handle(UpdateNCD request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<NonCommunicableDisease>();
            var ncd = await _ncdrepository.FirstOrDefaultAsync(x => x.Id == request.id && x.RecordStatus == RecordStatus.Active);
            if (ncd is null)
            {
                result.AddError(ErrorCode.NotFound, "Unable to get NCD data.");
                return result;
            }
            ncd.Update(request.Name, request.Description);
            _ncdrepository.Update(ncd);
            result.Payload = ncd;
            return result;
        }
    }

}
