using Api.SUS.Domain.Contracts.Domain;
using Api.SUS.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.SUS.Application.Contracts;
using Api.SUS.Application.Services;

namespace Api.SUS.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationDependencyInjection(
            this IServiceCollection services)
        {
            services.AddTransient<IRelatorioAppService, RelatorioAppService>();
            services.AddTransient<ISolicitanteAppService, SolicitanteAppService>();

            return services;
        }
    }
}
