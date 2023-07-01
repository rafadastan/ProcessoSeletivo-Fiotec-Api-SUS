using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.SUS.Domain.Model.QueryModel
{
    public class RelatorioBySolicitanteDto
    {
        public Guid RelatorioId { get; set; }
        public Guid SolicitanteId { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public DateTime DataAplicacao { get; set; }
        public string Descricao { get; set; }
        public int TotalVacinados { get; set; }
        public string Nome { get; set; }
    }
}
