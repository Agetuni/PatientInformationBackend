namespace PatientInformation.Api.Registrars
{
    public interface IWebApplicationBuilderRegistrar : IRegistrar
    {
       public void RegisterServices(WebApplicationBuilder builder);

    }
}
