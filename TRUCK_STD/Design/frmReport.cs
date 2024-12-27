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

        /// <summary>
        /// ประเภทของ report (MN,Cassava,Paddy,Corn,LPR,ReportAll) สำหรับการพิมพ์
        /// </summary>
        public string reportType { get; set; }

        /// <summary>
        /// สถานะการชั่ง สำหรับการพิมพ์ค้นหาทั้งหมดที่หน้าประวัติการชั่ง
        /// </summary>
        public string state { get; set; }


        /// <summary>
        /// เลขที่ JobOrder
        /// </summary>
        public string id { get; set; }


        void ShowError()
        {
            msg.Icon = MessageDialogIcon.Error;
            msg.Buttons = MessageDialogButtons.OK;
            msg.Show($"Error show the report Order : {id}\n{jobDetail.ERR}", "Report error");
            this.Close();
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            switch (reportType)
            {
                case "HIRE":
                    // Func_Report.Report_hire_weight(reportViewer1);
                    break;
                case "Cassava":
                    if (!Func_Report.ReportCassava())
                        ShowError();
                    break;
                case "Paddy":
                    if (!Func_Report.ReportPaddy())
                        ShowError();
                    break;
                case "Corn":
                    if (!Func_Report.ReportCorn())
                        ShowError();
                    break;
                //case "LPR":
                //    Func_Report.ReportLPR(reportViewer1);
                //    break;
                case "MN":
                    if (!Func_Report.ReportManual())
                        ShowError();
                    break;
                case "ReportAll":
                    if (!Func_Report.ReportAllData(state))
                        ShowError();
                    break;
            }
        }
    }
}
