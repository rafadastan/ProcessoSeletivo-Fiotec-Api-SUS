using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.SUS.Application.Dto
{
    public class RelatorioDto
    {
        public DateTime DataSolicitacao { get; set; }
        public DateTime DataAplicacao { get; set; }
        public string Descricao { get; set; }
        public int TotalVacinados { get; set; }
    }
}