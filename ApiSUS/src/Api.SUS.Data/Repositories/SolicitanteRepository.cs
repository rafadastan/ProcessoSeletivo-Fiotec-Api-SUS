using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.SUS.Data.Contexts;
using Api.SUS.Domain.Contracts.Repo;
using Api.SUS.Domain.Entities;
using Api.SUS.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace Api.SUS.Data.Repositories
{
    public class SolicitanteRepository : BaseRepository<Solicitante, Guid>, 
        ISolicitanteRepository
    {
        private readonly SqlContext _context;

        public SolicitanteRepository(SqlContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Solicitante> CreateNewSolicitante(Solicitante solicitante)
        {
            _context.Entry(solicitante).State = EntityState.Added;
           await _context.SaveChangesAsync();
           
           return solicitante;
        }
    }
}
