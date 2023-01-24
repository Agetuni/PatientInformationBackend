using PatientInformation.Application.Command.Allergies;
using PatientInformation.Application.Query.Allergies;

namespace PatientInformation.Api.Controllers.V1._0
{
    public class AllergyController : BaseController
    {
        [HttpPost("Create")]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AllergyRequest request)
        {
            var result = await _mediator.Send(new CreateAllergy(request.Name, request.Description));
            var allergy = _mapper.Map<AllergyResponse>(result.Payload);
            return result.IsError ? HandleErrorResponse(result.Errors) : Ok(allergy);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] AllergyRequest request, long id)
        {
            var result = await _mediator.Send(new UpdateAllergy(id, request.Name, request.Description));
            var allergy = _mapper.Map<AllergyResponse>(result.Payload);
            return result.IsError ? HandleErrorResponse(result.Errors) : Ok(allergy);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _mediator.Send(new DeleteAllergy(id));
            return result.IsError ? HandleErrorResponse(result.Errors) : Ok();
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(RecordStatus? status)
        {
            var result = await _mediator.Send(new GetAllergies( status));
            var allergies = _mapper.Map<List<AllergyResponse>>(result.Payload);
            return result.IsError ? HandleErrorResponse(result.Errors) : Ok(allergies);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _mediator.Send(new GetAllergyById(id));
            var allergy = _mapper.Map<AllergyResponse>(result.Payload);
            return result.IsError ? HandleErrorResponse(result.Errors) : Ok(allergy);
        }
    }
}
