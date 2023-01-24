using MediatR;
using PatientInformation.Application.Model;
using PatientInformation.Application.Services.GenericRepository;
using PatientInformation.Domain.Common;
using PatientInformation.Domain.Models;
using System.Linq;

namespace PatientInformation.Application.Query.Allergies
{
    public record GetAllergies(RecordStatus? status) : IRequest<OperationResult<List<Allergy>>>;
    public class GetAllergiesHandler : IRequestHandler<GetAllergies, OperationResult<List<Allergy>>>

    {
        private readonly IRepositoryBase<Allergy> _allergyrepository;
        public GetAllergiesHandler(IRepositoryBase<Allergy> allergyrepository) => _allergyrepository = allergyrepository;
        public async Task<OperationResult<List<Allergy>>> Handle(GetAllergies request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<List<Allergy>>();
            var allergies = _allergyrepository.Where(x => x.RecordStatus != RecordStatus.Deleted).ToList();
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
