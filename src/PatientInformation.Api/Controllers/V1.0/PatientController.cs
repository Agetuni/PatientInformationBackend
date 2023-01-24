using PatientInformation.Api.Contracts.Patients;
using PatientInformation.Application.Command.Patients;

namespace PatientInformation.Api.Controllers.V1._0
{
    public class PatientController : BaseController
    {
        [HttpPost("Create")]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] PatientInformationRequest request)
        {
            var result = await _mediator.Send(new AddPatientInfomation {
            FullName = request.FullName,
            Disease=request.Disease,
            Epilepsy=request.Epilepsy,
            NCDsDetails=request.NCDsDetails,
            AllergiesDetails=request.AllergiesDetails,
            });
            var patientInfo = _mapper.Map<PatientInformationResponse>(result.Payload);
            return result.IsError ? HandleErrorResponse(result.Errors) : Ok(patientInfo);
        }
    }
}
