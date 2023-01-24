using MediatR;
using PatientInformation.Application.Model;
using PatientInformation.Application.Services.GenericRepository;
using PatientInformation.Domain.Common;
using PatientInformation.Domain.Models;
using System.Linq;

namespace PatientInformation.Application.Query.Allergies
{
    public record GetNCDs(RecordStatus? status) : IRequest<OperationResult<List<NonCommunicableDisease>>>;
    public class GetNCDsHandler : IRequestHandler<GetNCDs, OperationResult<List<NonCommunicableDisease>>>

    {
        private readonly IRepositoryBase<NonCommunicableDisease> _ncdrepository;
        public GetNCDsHandler(IRepositoryBase<NonCommunicableDisease> ncdrepository) => _ncdrepository = ncdrepository;
        public async Task<OperationResult<List<NonCommunicableDisease>>> Handle(GetNCDs request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<List<NonCommunicableDisease>>();
            var allergies = _ncdrepository.Where(x => x.RecordStatus != RecordStatus.Deleted).ToList();
            allergies = request.status switch
            {
                RecordStatus.Active => allergies.Where(at => at.RecordStatus == RecordStatus.Active).ToList(),
                RecordStatus.InActive => allergies.Where(at => at.RecordStatus == RecordStatus.InActive).ToList(),
                _ => allergies
            };
            result.Payload = allergies;
            return result;
        }
    }
}
