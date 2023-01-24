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

namespace PatientInformation.Application.Command.Patients
{
    public class AddPatientInfomation :IRequest<OperationResult<Patient>>
    {
        public string FullName { get; set; }
        public long Disease { get; set; }
        public Epilepsy Epilepsy { get; set; }
        public List<long> NCDsDetails { get; set; }
        public List<long> AllergiesDetails { get; set; }
    }

    public class AddPatientInfomationHandler : IRequestHandler<AddPatientInfomation, OperationResult<Patient>>
    {
        private readonly IRepositoryBase<Patient> _patientRepository;
        public AddPatientInfomationHandler(IRepositoryBase<Patient> patientRepository) => _patientRepository = patientRepository;
        public async Task<OperationResult<Patient>> Handle(AddPatientInfomation request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Patient>();
            var patient = Patient.Create(request.FullName, request.Disease, request.Epilepsy);
            request.NCDsDetails.ForEach(d => patient.PatientNCDs.Add(PatientNCDs.Create(patient.Id,d)));
            request.AllergiesDetails.ForEach(d => patient.PatientAllergies.Add(PatientAllergies.Create(patient.Id,d)));
            await _patientRepository.AddAsync(patient);
            return result;
        }
    }
}
