using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;

namespace FS_REST.Event.Report
{
    public partial class PrintPreview : Form
    {
        ReportClass rpt;
        public PrintPreview(ReportClass rpt, DataSet ds)
        {
            InitializeComponent();
            this.rpt = rpt;
            this.rpt.SetDataSource(ds);
        }
        public void refresh()
        {
            crv.Refresh();
        }
        public void reportRefresh()
        {
            crv.RefreshReport();
        }
        public void setParam(string name, object value)
        {
            rpt.SetParameterValue(name, value);
        }
        public void setReport()
        {
            try
            {
                crv.ReportSource = rpt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
