using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.SUS.Client.Dto;

namespace Api.SUS.Client.Contracts
{
    public interface ISusClientService
    {
        Task<List<ResponseSusDto>?> GetInformationAsync();
    }
}
