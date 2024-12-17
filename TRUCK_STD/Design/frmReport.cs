using System;
using System.Windows.Forms;
using TRUCK_STD.Function;
namespace TRUCK_STD.Design
{
    public partial class frmReport : Form
    {
        public frmReport()
        {
            InitializeComponent();
        }

        public string reportType { get; set; }
        public string id { get; set; }
        private void frmReport_Load(object sender, EventArgs e)
        {
            switch (reportType)
            {
                case "HIRE":
                    // Func_Report.Report_hire_weight(reportViewer1);
                    break;
                case "Cassava":
                    Func_Report.ReportCassava(reportViewer1, int.Parse(id));
                    break;
                case "Paddy":
                    Func_Report.ReportPaddy(reportViewer1, int.Parse(id));
                    break;
                case "Corn":
                    Func_Report.ReportCorn(reportViewer1, int.Parse(id));
                    break;
                case "LPR":
                    Func_Report.ReportLPR(reportViewer1);
                    break;
                case "MN":
                    Func_Report.ReportManual(reportViewer1, int.Parse(id));
                    break;
            }
        }
    }
}
