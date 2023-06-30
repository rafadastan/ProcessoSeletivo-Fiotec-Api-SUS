using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.SUS.Client.Contracts;
using Api.SUS.Client.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Api.SUS.Client
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSusClient(this IServiceCollection services, string urlAPI)
        {
            services.AddHttpClient<ISusClientService, SusClientService>(client =>
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = new Uri(urlAPI);
            });

            return services;
        }
    }
}
