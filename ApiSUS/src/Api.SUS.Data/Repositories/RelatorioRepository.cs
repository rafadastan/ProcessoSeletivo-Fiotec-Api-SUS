using Api.SUS.Data.Contexts;
using Api.SUS.Domain.Contracts.Infra.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.SUS.Data.Repositories
{
    public class RelatorioRepository : IRelatorioRepository
    {
        private readonly SqlContext _sqlContext;

        public RelatorioRepository(SqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }
    }
}
