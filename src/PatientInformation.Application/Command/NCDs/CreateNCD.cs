using MediatR;
using PatientInformation.Application.Model;
using PatientInformation.Application.Services.GenericRepository;
using PatientInformation.Domain.Models;

namespace PatientInformation.Application.Command.Allergies
{
    public record CreateNCD(string Name, string Description): IRequest<OperationResult<NonCommunicableDisease>>;

    public class CreateNCDHandler : IRequestHandler<CreateNCD, OperationResult<NonCommunicableDisease>>
    {
        private readonly IRepositoryBase<NonCommunicableDisease> _ncdrepository;
        public CreateNCDHandler(IRepositoryBase<NonCommunicableDisease> ncdrepository) => _ncdrepository = ncdrepository;
        public async Task<OperationResult<NonCommunicableDisease>> Handle(CreateNCD request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<NonCommunicableDisease>();
            var existingNCD = await _ncdrepository.ExistWhereAsync(x => x.Name == request.Description);
            if (existingNCD)
            {
                result.AddError(ErrorCode.RecordFound, "NCD already registerd.");
                return result;
            }
            var ncd = NonCommunicableDisease.Create(request.Name, request.Description);
            await _ncdrepository.AddAsync(ncd);

            result.Payload = ncd;
            return result;
        }
    }

}
