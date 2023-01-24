using Microsoft.AspNetCore.Mvc.Filters;

namespace PatientInformation.Api.Filters
{
    public class AuthorizationHandler : IAuthorizationFilter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMediator _mediator;
        public AuthorizationHandler(IHttpContextAccessor httpContextAccessor, IMediator mediator)
        {
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
           // Authrization here 
        }
    }
}
