using PatientInformation.Application.Command.Allergies;
using PatientInformation.Application.Query.Allergies;

namespace PatientInformation.Api.Controllers.V1._0
{
    public class NCDController : BaseController
    {
        [HttpPost("Create")]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] NCDRequest request)
        {
            var result = await _mediator.Send(new CreateNCD(request.Name, request.Description));
            var ncd = _mapper.Map<NCDResponse>(result.Payload);
            return result.IsError ? HandleErrorResponse(result.Errors) : Ok(ncd);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] NCDRequest request, long id)
        {
            var result = await _mediator.Send(new UpdateNCD(id, request.Name, request.Description));
            var ncd = _mapper.Map<NCDResponse>(result.Payload);
            return result.IsError ? HandleErrorResponse(result.Errors) : Ok(ncd);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _mediator.Send(new DeleteNCD(id));
            return result.IsError ? HandleErrorResponse(result.Errors) : Ok();
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(RecordStatus? status)
        {
            var result = await _mediator.Send(new GetNCDs( status));
            var ncd = _mapper.Map<List<NCDResponse>>(result.Payload);
            return result.IsError ? HandleErrorResponse(result.Errors) : Ok(ncd);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _mediator.Send(new GetNCDById(id));
            var ncd = _mapper.Map<NCDResponse>(result.Payload);
            return result.IsError ? HandleErrorResponse(result.Errors) : Ok(ncd);
        }
    }
}
