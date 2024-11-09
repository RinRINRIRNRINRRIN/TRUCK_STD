using System;
using System.Data;
using System.Windows.Forms;
using TRUCK_STD.Design;
using TRUCK_STD.Function;
using TRUCK_STD.Functions;
using TRUCK_STD.MSACCESSCommand;
namespace TRUCK_STD
{
    public partial class frmTest : Form
    {
        public frmTest()
        {
            InitializeComponent();
        }

        private void frmTest_Load(object sender, EventArgs e)
        {


        }



        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {

            Console.WriteLine(serialPort1.ReadLine());
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            registy.Get();
            Func_Database.CONNECTION_SERVER();
            tbWGH tbWGH = new tbWGH();
            // ดึงข้อมูลมาที่ datatable 
            DataTable tb = tbWGH.SELECT_SEARCH_DATA("67/02/0002");

            // ดึงข้อมูลมาแสดงที่ Report
            foreach (DataRow rw in tb.Rows)
            {
                Func_Report.rtp_carnumber = Convert.ToString(rw["CARNUM"]);
                Func_Report.rtp_dateIn = Convert.ToString(rw["DATE_IN"]);
                Func_Report.rtp_timeIn = Convert.ToString(rw["TIME_IN"]);
                Func_Report.rtp_dateOut = Convert.ToString(rw["DATE_OUT"]);
                Func_Report.rtp_timeOut = Convert.ToString(rw["TIME_OUT"]);

                Func_Report.rtp_wghIn = Convert.ToString(rw["W_IN"]);
                Func_Report.rtp_wghOut = Convert.ToString(rw["W_OUT"]);
                Func_Report.rtp_ordernumber = Convert.ToString(rw["ORDER_NUMB"]);
                Func_Report.rtp_gross = Convert.ToString(rw["GROSS"]);
                Func_Report.rtp_product = Convert.ToString(rw["TYPEDESC"]);

                Func_Report.rtp_price = Convert.ToString(rw["PRICE"]); ;
                Func_Report.rtp_priceNet = $"{rw["price_net"]:#,###,###.##}";
            }

            frmReport frmReport = new frmReport();
            frmReport.reportType = "HAVE_PRICE";
            frmReport.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            registy.Get();
            Func_Database.CONNECTION_SERVER();
            tbWGH tbWGH = new tbWGH();
            // ดึงข้อมูลมาที่ datatable 
            DataTable tb = tbWGH.SELECT_SEARCH_DATA("67/02/0002");

            // ดึงข้อมูลมาแสดงที่ Report
            foreach (DataRow rw in tb.Rows)
            {
                Func_Report.rtp_carnumber = Convert.ToString(rw["CARNUM"]);
                Func_Report.rtp_dateIn = Convert.ToString(rw["DATE_IN"]);
                Func_Report.rtp_timeIn = Convert.ToString(rw["TIME_IN"]);
                Func_Report.rtp_dateOut = Convert.ToString(rw["DATE_OUT"]);
                Func_Report.rtp_timeOut = Convert.ToString(rw["TIME_OUT"]);

                Func_Report.rtp_wghIn = Convert.ToString(rw["W_IN"]);
                Func_Report.rtp_wghOut = Convert.ToString(rw["W_OUT"]);
                Func_Report.rtp_ordernumber = Convert.ToString(rw["ORDER_NUMB"]);
                Func_Report.rtp_gross = Convert.ToString(rw["GROSS"]);
                Func_Report.rtp_product = Convert.ToString(rw["TYPEDESC"]);
            }

            frmReport frmReport = new frmReport();
            frmReport.reportType = "NO_PRICE";
            frmReport.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            registy.Get();
            Func_Database.CONNECTION_SERVER();
            tbHireWeight tbHireWeight = new tbHireWeight();           // ดึงข้อมูลมาที่ datatable 
            DataTable tb = tbHireWeight.SELECT_SEARCH_DATA("67/02/0001");

            // ดึงข้อมูลมาแสดงที่ Report
            foreach (DataRow rw in tb.Rows)
            {
                Func_Report.rtp_carnumber = Convert.ToString(rw["CARNUM_H"]);
                Func_Report.rtp_dateIn = Convert.ToString(rw["DATE_IN"]);
                Func_Report.rtp_timeIn = Convert.ToString(rw["TIME_IN"]);
                Func_Report.rtp_company = Convert.ToString(rw["comdesc"]);
                Func_Report.rtp_product = Convert.ToString(rw["typedesc"]);
                Func_Report.rtp_ordernumber = Convert.ToString(rw["ORDERNUM"]);
                Func_Report.rtp_gross = Convert.ToString(rw["WG"]);
                Func_Report.rtp_product = Convert.ToString(rw["TYPEDESC"]);
            }

            frmReport frmReport = new frmReport();
            frmReport.reportType = "HIRE";
            frmReport.ShowDialog();
        }
    }
}
