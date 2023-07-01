using Api.SUS.Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraReports.UI;

namespace Api.SUS.Application.Contracts
{
    public interface ISolicitanteAppService
    {
        Task<XtraReport> SendAsync(SolicitanteModel model);
    }
}
