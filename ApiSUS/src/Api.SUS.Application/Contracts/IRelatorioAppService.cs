using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.SUS.Application.Dto;
using Api.SUS.Domain.Entities;

namespace Api.SUS.Application.Contracts
{
    public interface IRelatorioAppService
    {
        Task<IEnumerable<RelatorioDto>> GetAll();
    }
}
