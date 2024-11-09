using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Windows.Forms;
namespace TRUCK_STD.Design
{
    public partial class frmReportAllDataSuccess : Form
    {
        public DataTable tb;       // สำหรับเก็บข้อมูลตารางเพื่อไปโชว์ที่ report
        public string wghNet;      // สำหรับเก็บข้อมูลจำนวนน้ำหนักรวมเพื่อไปโชว์ที่ report
        public int count;          // สำหรับเก็บค่าจำนวนของข้อมูลเพื่อไปโชว์ใน report
        public string reportType;  // สำหรับเก็บค่าประเภท Report

        public frmReportAllDataSuccess()
        {
            InitializeComponent();
        }

        private void frmReportAllData_Load(object sender, EventArgs e)
        {
            // ตรวจสอบว่า ต้องโชว์รีพอตของอะไร
            switch (reportType)
            {
                case "ข้อมูลรถชั่งเข้า":
                    reportViewer1.LocalReport.ReportEmbeddedResource = "TRUCK_STD.Report.rptCarWait.rdlc";
                    break;
                case "ข้อมูลรถชั่งออก":
                    reportViewer1.LocalReport.ReportEmbeddedResource = "TRUCK_STD.Report.rptAllreport.rdlc";
                    break;
                case "ข้อมูลรถจ้างชั่ง":
                    reportViewer1.LocalReport.ReportEmbeddedResource = "TRUCK_STD.Report.rptAllHireWGH.rdlc";

                    break;
            }

            // สร้าง parameter ใหม่
            ReportParameter rptWghNet = new ReportParameter("rptWghNet", wghNet);
            ReportParameter rptCount = new ReportParameter("rptCountList", Convert.ToString(count));


            // กำหนด ค่าให้กับ parameter ใน report
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rptWghNet });
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rptCount });

            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", tb)); // เพิ่ม DataSources ใหม่
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.PageSetupDialog();
            this.reportViewer1.RefreshReport();
        }
    }
}
