using Microsoft.AspNetCore.Mvc.Filters;

namespace PatientInformation.Api.Filters
{
    public class AuthorizationHandler : IAuthorizationFilter
    {

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // Authrization here 
        }
    }
}
