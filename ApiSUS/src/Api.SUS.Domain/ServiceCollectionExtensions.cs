using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.SUS.Domain.Contracts.Domain;
using Api.SUS.Domain.Notifications;
using Api.SUS.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Api.SUS.Domain
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainDependencyInjection(
            this IServiceCollection services)
        {
            //services.AddScoped<NotificationFilter>();
            services.AddScoped<NotificationContext>();

            services.AddTransient<IRelatorioDomainService, RelatorioDomainService>();
            services.AddTransient<ISolicitanteDomainService, SolicitanteDomainService>();

            return services;
        }
    }
}
