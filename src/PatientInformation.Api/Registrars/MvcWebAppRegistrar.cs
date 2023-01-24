using Microsoft.AspNetCore.Mvc.ApiExplorer;
namespace PatientInformation.Api.Registrars
{
    public class MvcWebAppRegistrar : IWebApplicationRegistrar
    {
        public void RegisterPipelineComponents(WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"{description.GroupName}/swagger.json", description.ApiVersion.ToString());
                }
            });
            app.MapGet("/", () => "PatientInformation - API");
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.MigrateDatabase();
        }
    }
}
