using MediatR;
using PatientInformation.Application.Model;
using PatientInformation.Application.Services.GenericRepository;
using PatientInformation.Domain.Common;
using PatientInformation.Domain.Models;
using System.Linq;

namespace PatientInformation.Application.Query.Allergies
{
    public record GetDiseases(RecordStatus? status) : IRequest<OperationResult<List<Disease>>>;
    public class GetDiseasesHandler : IRequestHandler<GetDiseases, OperationResult<List<Disease>>>

    {
        private readonly IRepositoryBase<Disease> _diseaserepository;
        public GetDiseasesHandler(IRepositoryBase<Disease> diseaserepository) => _diseaserepository = diseaserepository;
        public async Task<OperationResult<List<Disease>>> Handle(GetDiseases request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<List<Disease>>();
            var diseases = _diseaserepository.Where(x => x.RecordStatus != RecordStatus.Deleted).ToList();
            diseases = request.status switch
            {
                RecordStatus.Active => diseases.Where(at => at.RecordStatus == RecordStatus.Active).ToList(),
                RecordStatus.InActive => diseases.Where(at => at.RecordStatus == RecordStatus.InActive).ToList(),
                _ => diseases
            };
            result.Payload = diseases;
            return result;
        }
    }
}
