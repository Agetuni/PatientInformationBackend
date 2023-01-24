using MediatR;
using PatientInformation.Application.Model;
using PatientInformation.Application.Services.GenericRepository;
using PatientInformation.Domain.Models;

namespace PatientInformation.Application.Command.Allergies
{
    public record DeleteDisease(long Id) : IRequest<OperationResult<bool>>;
    public class DeleteDiseaseHandler : IRequestHandler<DeleteDisease, OperationResult<bool>>
    {
        private readonly IRepositoryBase<Disease> _diseaserepository;
        public DeleteDiseaseHandler(IRepositoryBase<Disease> diseaserepository) => _diseaserepository = diseaserepository;
        public async Task<OperationResult<bool>> Handle(DeleteDisease request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<bool>();
            var disease = await _diseaserepository.FindAsync(request.Id);
            disease.Delete();
            _diseaserepository.Update(disease);
            result.Payload = true;
            return result;
        }
    }
}
