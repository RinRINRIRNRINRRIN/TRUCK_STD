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

        private void frmReport_Load(object sender, EventArgs e)
        {
            switch (reportType)
            {
                case "HIRE":
                    Func_Report.Report_hire_weight(reportViewer1);
                    break;
                case "NO_PRICE":
                    Func_Report.Report_no_price(reportViewer1);
                    break;
                case "HAVE_PRICE":
                    Func_Report.Report_have_price(reportViewer1);
                    break;
            }
        }
    }
}
