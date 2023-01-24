using MediatR;
using PatientInformation.Application.Model;
using PatientInformation.Application.Services.GenericRepository;
using PatientInformation.Domain.Common;
using PatientInformation.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientInformation.Application.Query.Patients
{
    public record GetAllPatientInformation : IRequest<OperationResult<List<Patient>>>;
    public class GetAllPatientInformationHandler : IRequestHandler<GetAllPatientInformation, OperationResult<List<Patient>>>
    {
        private readonly IRepositoryBase<Patient> _patientRepository;
        public GetAllPatientInformationHandler(IRepositoryBase<Patient> patientRepository) => _patientRepository = patientRepository;
        public async Task<OperationResult<List<Patient>>> Handle(GetAllPatientInformation request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<List<Patient>>();
            var patients = _patientRepository.Where(x=>x.RecordStatus== RecordStatus.Active,
                "PatientAllergies.Allergy", "PatientNCDs.NonCommunicableDisease", "Disease")
                .ToList();
            result.Payload = patients;
            return result;
        }
    }
}
