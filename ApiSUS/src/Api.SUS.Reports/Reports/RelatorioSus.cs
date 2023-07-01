using System;
using Api.SUS.Domain.Model.QueryModel;
using DevExpress.XtraReports.UI;

namespace Api.SUS.Reports.Reports
{
    public partial class RelatorioSus
    {
        public RelatorioSus(IEnumerable<RelatorioBySolicitanteDto> data)
        {
            InitializeComponent();

            DataSource = data;
        }
    }
}
