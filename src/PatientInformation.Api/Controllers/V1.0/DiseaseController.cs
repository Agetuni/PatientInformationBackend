using PatientInformation.Application.Command.Allergies;
using PatientInformation.Application.Query.Allergies;

namespace PatientInformation.Api.Controllers.V1._0
{
    public class DiseaseController : BaseController
    {
        [HttpPost("Create")]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] DiseaseRequest request)
        {
            var result = await _mediator.Send(new CreateDisease(request.Name, request.Description));
            var disease = _mapper.Map<DiseaseResponse>(result.Payload);
            return result.IsError ? HandleErrorResponse(result.Errors) : Ok(disease);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] DiseaseRequest request, long id)
        {
            var result = await _mediator.Send(new UpdateDisease(id, request.Name, request.Description));
            var disease = _mapper.Map<UpdateDisease>(result.Payload);
            return result.IsError ? HandleErrorResponse(result.Errors) : Ok(disease);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _mediator.Send(new DeleteDisease(id));
            return result.IsError ? HandleErrorResponse(result.Errors) : Ok();
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(RecordStatus? status)
        {
            var result = await _mediator.Send(new GetDiseases(status));
            var diseases = _mapper.Map<List<DiseaseResponse>>(result.Payload);
            return result.IsError ? HandleErrorResponse(result.Errors) : Ok(diseases);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _mediator.Send(new GetDiseaseById(id));
            var disease = _mapper.Map<DiseaseResponse>(result.Payload);
            return result.IsError ? HandleErrorResponse(result.Errors) : Ok(disease);
        }
    }
}
