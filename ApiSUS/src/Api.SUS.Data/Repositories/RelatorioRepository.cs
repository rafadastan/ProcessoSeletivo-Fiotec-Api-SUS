using Api.SUS.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.SUS.Domain.Contracts.Repo;
using Api.SUS.Domain.Entities;

namespace Api.SUS.Data.Repositories
{
    public class RelatorioRepository : BaseRepository<Relatorio, Guid>, 
        IRelatorioRepository
    {
        public RelatorioRepository(SqlContext context) : base(context)
        {
        }
    }
}
