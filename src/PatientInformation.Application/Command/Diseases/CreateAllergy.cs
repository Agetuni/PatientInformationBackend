using MediatR;
using PatientInformation.Application.Model;
using PatientInformation.Application.Services.GenericRepository;
using PatientInformation.Domain.Models;

namespace PatientInformation.Application.Command.Allergies
{
    public record CreateDisease(string Name, string Description): IRequest<OperationResult<Disease>>;

    public class CreateDiseaseHandler : IRequestHandler<CreateDisease, OperationResult<Disease>>
    {
        private readonly IRepositoryBase<Disease> _diseaserepository;
        public CreateDiseaseHandler(IRepositoryBase<Disease> diseaserepository) => _diseaserepository = diseaserepository;
        public async Task<OperationResult<Disease>> Handle(CreateDisease request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Disease>();
            var existingDisease = await _diseaserepository.ExistWhereAsync(x => x.Name == request.Description);
            if (existingDisease)
            {
                result.AddError(ErrorCode.RecordFound, "Disease already registerd.");
                return result;
            }
            var disease = Disease.Create(request.Name, request.Description);
            await _diseaserepository.AddAsync(disease);

            result.Payload = disease;
            return result;
        }
    }

}
