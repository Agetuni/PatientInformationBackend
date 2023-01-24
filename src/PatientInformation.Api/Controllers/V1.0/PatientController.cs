using PatientInformation.Api.Contracts.Patients;
using PatientInformation.Application.Command.Patients;
using PatientInformation.Application.Query.Patients;

namespace PatientInformation.Api.Controllers.V1._0
{
    public class PatientController : BaseController
    {
        [HttpPost("Create")]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] PatientInformationRequest request)
        {
            var result = await _mediator.Send(new AddPatientInfomation
            {
                FullName = request.FullName,
                Disease = request.Disease,
                Epilepsy = request.Epilepsy,
                NCDsDetails = request.NCDsDetails,
                AllergiesDetails = request.AllergiesDetails,
            });
            var patientInfo = _mapper.Map<PatientInformationResponse>(result.Payload);
            return result.IsError ? HandleErrorResponse(result.Errors) : Ok(patientInfo);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllPatientInformation());
            var patientsInfo = _mapper.Map<List<PatientInformationResponse>>(result.Payload);
            return result.IsError ? HandleErrorResponse(result.Errors) : Ok(patientsInfo);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _mediator.Send(new GetPatientById(id));
            var patient = _mapper.Map<PatientInformationResponse>(result.Payload);
            return result.IsError ? HandleErrorResponse(result.Errors) : Ok(patient);
        }
    }
}
