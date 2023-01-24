using PatientInformation.Application.Command.Allergies;
using PatientInformation.Application.Services.GenericRepository;
using PatientInformation.Domain.Models;

namespace PatientInformation.Api.Registrars
{
    public class ApplicationLayerRegistrar : IWebApplicationBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(typeof(Program), typeof(CreateAllergy));
            builder.Services.AddMediatR(typeof(CreateAllergy));
            builder.Services.AddScoped(typeof(IRepositoryBase<Allergy>), typeof(RepositoryBase<Allergy>));
            builder.Services.AddScoped(typeof(IRepositoryBase<Disease>), typeof(RepositoryBase<Disease>));
            builder.Services.AddScoped(typeof(IRepositoryBase<NonCommunicableDisease>), typeof(RepositoryBase<NonCommunicableDisease>));

        }
    }
}
