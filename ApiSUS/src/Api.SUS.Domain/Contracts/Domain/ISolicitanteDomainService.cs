using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.SUS.Domain.Entities;
using Api.SUS.Domain.Model;

namespace Api.SUS.Domain.Contracts.Domain
{
    public interface ISolicitanteDomainService
    {
        Task CreateSolicitanteAsync(Solicitante entity);
    }
}
