using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.SUS.Application.Dto
{
    public class SolicitanteDto
    {
        public Guid SolicitanteId { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataConsulta { get; set; }
    }
}
