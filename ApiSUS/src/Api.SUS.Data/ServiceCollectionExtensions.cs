using Api.SUS.Data.ReadRepositories;
using Api.SUS.Data.Repositories;
using Api.SUS.Domain.Contracts.ReadRepo;
using Api.SUS.Domain.Contracts.Repo;
using Microsoft.Extensions.DependencyInjection;

namespace Api.SUS.Data
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfraDependencyInjection(
            this IServiceCollection services)
        {
            services.AddTransient<IRelatorioReadRepository, RelatorioReadRepository>();
            services.AddTransient<ISolicitanteReadRepository, SolicitanteReadRepository>();

            services.AddTransient<IRelatorioRepository, RelatorioRepository>();
            services.AddTransient<ISolicitanteRepository, SolicitanteRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
