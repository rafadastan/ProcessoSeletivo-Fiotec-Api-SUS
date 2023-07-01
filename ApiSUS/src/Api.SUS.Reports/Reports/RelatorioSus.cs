using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using Api.SUS.Domain.Entities;
using Api.SUS.Domain.Model;
using Api.SUS.Domain.Model.QueryModel;

namespace Api.SUS.Reports.Reports
{
    public partial class RelatorioSus : DevExpress.XtraReports.UI.XtraReport
    {
        public RelatorioSus(IEnumerable<RelatorioBySolicitanteDto> data)
        {
            InitializeComponent();

            DataSource = data;
        }
    }
}
