using MediatR;
using PatientInformation.Application.Model;
using PatientInformation.Application.Services.GenericRepository;
using PatientInformation.Domain.Common;
using PatientInformation.Domain.Models;

namespace PatientInformation.Application.Query.Allergies
{
    public record GetNCDById(long Id) : IRequest<OperationResult<NonCommunicableDisease>>;

    public class GetNCDByIdHandler : IRequestHandler<GetNCDById, OperationResult<NonCommunicableDisease>>

    {
        private readonly IRepositoryBase<NonCommunicableDisease> _ncdrepository;
        public GetNCDByIdHandler(IRepositoryBase<NonCommunicableDisease> ncdrepository) => _ncdrepository = ncdrepository;
        public async Task<OperationResult<NonCommunicableDisease>> Handle(GetNCDById request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<NonCommunicableDisease>();

            var allergy = await _ncdrepository.FirstOrDefaultAsync(x => x.Id == request.Id && x.RecordStatus == RecordStatus.Active);
            if (allergy is null)
            {
                result.AddError(ErrorCode.NotFound, "Unable to get NCD data.");
                return result;
            }
            result.Payload = allergy;
            return result;

        }
    }

}
