using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace PatientInformation.Api.Options
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;
        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }
        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateVersionInfro(description));

            }
        }

        private OpenApiInfo CreateVersionInfro(ApiVersionDescription description)
        {
            var info = new OpenApiInfo
            {
                Title = "PatientInformation",
                Version = description.ApiVersion.ToString()

            };
            if (description.IsDeprecated)
                info.Description = "This API version has been deprecated";
            return info;
        }
    }
}
