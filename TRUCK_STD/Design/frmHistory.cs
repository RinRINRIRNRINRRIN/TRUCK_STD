using Bunifu.UI.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;
namespace TRUCK_STD.Design
{
    public partial class frmHistory : Form
    {

        public frmHistory()
        {
            InitializeComponent();
        }

        #region "VARIABEL LOCAL"
        BunifuSnackbar msg = new BunifuSnackbar();
        #endregion


        private void frmHistory_Load(object sender, EventArgs e)
        {
            // กำหนดค่าให้กับ combobox
            cbbTable.Items.Clear();
            cbbTable.Items.Add("--เลือกการชั่ง--");
            cbbTable.SelectedIndex = 0;

            cbbSearchCar.Items.Clear();
            cbbSearchCar.Items.Add("--ทะเบียนรถ--");
            cbbSearchCar.SelectedIndex = 0;

            cbbSearchCustomer.Items.Clear();
            cbbSearchCustomer.Items.Add("--ชื่อลูกค้า--");
            cbbSearchCustomer.SelectedIndex = 0;

            cbbSearchProduct.Items.Clear();
            cbbSearchProduct.Items.Add("--ชื่อสินค้า--");
            cbbSearchProduct.SelectedIndex = 0;

            dgvHireWeight.DefaultCellStyle.ForeColor = Color.Black;

            // กำหนดค่าให้กลับ dtp
            DateTime dateTime = DateTime.Now;
            // แปลงวันที่เป็นรูปแบบ ค.ศ.
            string formattedDate = dateTime.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"));

            // กำหนดค่าให้กับ DateTimePicker ในรูปแบบค.ศ.
            dtpStart.Value = DateTime.ParseExact(formattedDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            dtpEnd.Value = dateTime;
            // เช็คสิทธิ์การใช้งาน เมนู
        }



        private void btnSearch_Click(object sender, EventArgs e)
        {
            #region ตรวจสอบค่าว่าง
            // ตรวจสอบก่อนว่าได้เลือกตารางก่อนค้นหาหรือไม่
            if (cbbTable.Text == "--เลือกการชั่ง--")
            {
                msg.Show(this, "กรุณา เลือกการชั่ง ที่ต้องการจะค้นหาก่อน", BunifuSnackbar.MessageTypes.Warning, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                return;
            }
            // ตรวจสอบว่าเลือกข้อมูลถูกต้องหรือไม่
            DateTime a = dtpStart.Value;
            DateTime b = dtpEnd.Value;
            // ตรวจสอบว่าถ้าวันที่สิ้นสุดมากกว่าวันที่เริ่มค้นจะ error 
            if (a > b)
            {
                msg.Show(this, "รูปแบบวันที่ที่ต้องการหาไม่ถูกต้อง", BunifuSnackbar.MessageTypes.Warning, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                return;
            }
            // ตรวจสอบว่า มีการ checkbox แล้วได้เลือกข้อมูลหรือไม่
            if (cbSearchCar.Checked == true)
            {
                if (cbbSearchCar.Text == "--ทะเบียนรถ--")
                {
                    msg.Show(this, "กรุณาเลือก " + cbbSearchCar.Text + " ที่ต้องการจะหาข้อมูล", BunifuSnackbar.MessageTypes.Warning, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                    return;
                }
            }
            if (cbSearchCustomer.Checked == true)
            {
                if (cbbSearchCustomer.Text == "--ชื่อลูกค้า--")
                {
                    msg.Show(this, "กรุณาเลือก " + cbbSearchCustomer.Text + " ที่ต้องการจะหาข้อมูล", BunifuSnackbar.MessageTypes.Warning, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                    return;
                }
            }
            if (cbSearchProduct.Checked == true)
            {
                if (cbbSearchProduct.Text == "--ชื่อสินค้า--")
                {
                    msg.Show(this, "กรุณาเลือก " + cbbSearchProduct.Text + " ที่ต้องการจะหาข้อมูล", BunifuSnackbar.MessageTypes.Warning, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                    return;
                }
            }
            #endregion
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            // ตรวจสอบก่อนว่าได้เลือกตารางก่อนค้นหาหรือไม่
            if (cbbTable.Text == "--เลือกการชั่ง--")
            {
                msg.Show(this, "กรุณา เลือกการชั่ง ที่ต้องการจะแสดงข้อมูล", BunifuSnackbar.MessageTypes.Warning, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                return;
            }
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            // ตรวจสอบก่อนว่าได้เลือกตารางก่อนค้นหาหรือไม่
            if (cbbTable.Text == "--เลือกการชั่ง--")
            {
                msg.Show(this, "กรุณา เลือกการชั่ง ที่ต้องการจะค้นหาก่อน", BunifuSnackbar.MessageTypes.Warning, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                return;
            }
            // ทำการสูตร Exxcel
            //using (SaveFileDialog sa = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
            //{
            //    if (sa.ShowDialog() == DialogResult.OK)
            //    {
            //        try
            //        {
            //            using (XLWorkbook el = new XLWorkbook())
            //            {
            //                DataTable tb = new DataTable();
            //                tb = (DataTable)dgvWGH_OUT.DataSource;
            //                el.Worksheets.Add(tb, "Data export");
            //                el.SaveAs(sa.FileName);
            //            }
            //            msg.Show(this, "Export รายการสำเร็จ", BunifuSnackbar.MessageTypes.Success, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
            //        }
            //        catch (Exception ex)
            //        {
            //            msg.Show(this, "เกิดข้อผิดผลาก " + ex.Message, BunifuSnackbar.MessageTypes.Error, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
            //        }
            //    }
            //}
        }


        #region COMBOBOX PROCESS
        private void cbSearchDate_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSearchDate.Checked == true)
            {
                dtpEnd.Enabled = true;
                dtpStart.Enabled = true;
            }
            else if (cbSearchDate.Checked == false)
            {
                dtpEnd.Enabled = false;
                dtpStart.Enabled = false;
            }
        }

        private void cbSearchProduct_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSearchProduct.Checked == true)
            {
                cbbSearchProduct.Enabled = true;
            }
            else if (cbSearchProduct.Checked == false)
            {
                cbbSearchProduct.Enabled = false;
            }
        }

        private void cbSearchCustomer_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSearchCustomer.Checked == true)
            {
                cbbSearchCustomer.Enabled = true;
            }
            else if (cbSearchCustomer.Checked == false)
            {
                cbbSearchCustomer.Enabled = false;
            }
        }

        private void cbSearchCar_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSearchCar.Checked == true)
            {
                cbbSearchCar.Enabled = true;
            }
            else if (cbSearchCar.Checked == false)
            {
                cbbSearchCar.Enabled = false;
            }
        }

        private void cbbSearchProduct_DropDown(object sender, EventArgs e)
        {

        }

        private void cbbSearchProduct_DropDownClosed(object sender, EventArgs e)
        {
            if (cbbSearchProduct.Text == "")
            {
                cbbSearchProduct.Items.Clear();
                cbbSearchProduct.Items.Add("--ชื่อสินค้า--");
                cbbSearchProduct.SelectedIndex = 0;
            }
        }

        private void cbbSearchCustomer_DropDown(object sender, EventArgs e)
        {

        }

        private void cbbSearchCustomer_DropDownClosed(object sender, EventArgs e)
        {
            if (cbbSearchCustomer.Text == "")
            {
                cbbSearchCustomer.Items.Clear();
                cbbSearchCustomer.Items.Add("--ชื่อลูกค้า--");
                cbbSearchCustomer.SelectedIndex = 0;
            }
        }

        private void cbbSearchCar_DropDown(object sender, EventArgs e)
        {

        }

        private void cbbSearchCar_DropDownClosed(object sender, EventArgs e)
        {
            if (cbbSearchCar.Text == "")
            {
                cbbSearchCar.Items.Clear();
                cbbSearchCar.Items.Add("--ทะเบียนรถ--");
                cbbSearchCar.SelectedIndex = 0;
            }
        }

        private void cbbTable_DropDown(object sender, EventArgs e)
        {
            cbbTable.Items.Clear();
            cbbTable.Items.Add("ข้อมูลรถชั่งเข้า");
            cbbTable.Items.Add("ข้อมูลรถชั่งออก");
            cbbTable.Items.Add("ข้อมูลรถจ้างชั่ง");
        }

        private void cbbTable_DropDownClosed(object sender, EventArgs e)
        {
            if (cbbTable.Text == "")
            {
                cbbTable.Items.Clear();
                cbbTable.Items.Add("--เลือกการชั่ง--");
                cbbTable.SelectedIndex = 0;


                dgvHireWeight.Visible = false;
            }
        }
        #endregion

        private void btnPrintAllReport_Click(object sender, EventArgs e)
        {
            // ตรวจสอบก่อนว่าได้เลือกตารางก่อนค้นหาหรือไม่
            if (cbbTable.Text == "--เลือกการชั่ง--")
            {
                msg.Show(this, "กรุณา เลือกการชั่ง ที่ต้องการจะพิมพ์รายงาน", BunifuSnackbar.MessageTypes.Warning, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                return;
            }
            // ทำการเรียงคำสั่ง query  เพื่อแสดงรายงาน


            // ดึงตารางในฐานข้อมูลมาแสดง
            DataSet1 dataSet1 = new DataSet1();

            frmReportAllDataSuccess frmReportAllData = new frmReportAllDataSuccess();
            // ตรวจสอบว่าปริ้นรายงานของตารางไหน
        }

        private void dgvHireWeight_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
