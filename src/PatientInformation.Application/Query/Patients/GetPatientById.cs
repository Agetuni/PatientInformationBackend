using MediatR;
using PatientInformation.Application.Model;
using PatientInformation.Application.Services.GenericRepository;
using PatientInformation.Domain.Common;
using PatientInformation.Domain.Models;

namespace PatientInformation.Application.Query.Patients
{
    public record GetPatientById(long id): IRequest<OperationResult<Patient>>;

    public class GetPatientByIdHandler : IRequestHandler<GetPatientById, OperationResult<Patient>>
    {
        private readonly IRepositoryBase<Patient> _patientRepository;
        public GetPatientByIdHandler(IRepositoryBase<Patient> patientRepository) => _patientRepository = patientRepository;
        public async Task<OperationResult<Patient>> Handle(GetPatientById request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Patient>();
            var patients = _patientRepository.Where(x => x.RecordStatus == RecordStatus.Active,
                "PatientAllergies.Allergy", "PatientNCDs.NonCommunicableDisease", "Disease")
                .FirstOrDefault();
            result.Payload = patients;
            return result;
        }
    }
}
