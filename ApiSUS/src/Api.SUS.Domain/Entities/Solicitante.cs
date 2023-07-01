using Api.SUS.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.SUS.Domain.Entities
{
    public class Solicitante
    {
        public Guid SolicitanteId { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataConsulta { get; set; }

        public List<Relatorio> RelatorioList { get; set; }
    }
}
