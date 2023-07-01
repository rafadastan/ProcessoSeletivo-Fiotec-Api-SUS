using Api.SUS.Data.Contexts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Api.SUS.Data.Configuration
{
    public class SqlServerConfiguration
    {
        public static void AddSqlServerEntityFramework(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ApiSUS");

            services.AddDbContext<SqlContext>(opt =>
                opt.UseSqlServer(connectionString));
        }
    }
}
