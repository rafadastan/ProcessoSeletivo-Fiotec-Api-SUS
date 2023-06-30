using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.SUS.Data.Contexts;
using Api.SUS.Domain.Contracts.Infra.Repo;

namespace Api.SUS.Data.Repositories
{
    public class SolicitanteRepository : ISolicitanteRepository
    {
        private readonly SqlContext _sqlContext;

        public SolicitanteRepository(SqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }
    }
}
