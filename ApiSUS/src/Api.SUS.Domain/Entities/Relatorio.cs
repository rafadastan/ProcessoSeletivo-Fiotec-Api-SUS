using Api.SUS.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.SUS.Domain.Entities
{
    public class Relatorio : Entity<Guid>
    {
        public Relatorio(Guid id) : base(id)
        {
        }

        public Guid RelatorioId { get; set; }
        public Guid SolicitanteId { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public DateTime DataAplicacao { get; set; }
        public string Descricao { get; set; }
        public int TotalVacinados { get; set; }
        
        public Solicitante Solicitante { get; set; }
    }
}
