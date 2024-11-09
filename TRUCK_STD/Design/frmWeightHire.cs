using Bunifu.UI.WinForms;
using Serilog;
using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TRUCK_STD.Function;
using TRUCK_STD.Functions;
using TRUCK_STD.MSACCESSCommand;
namespace TRUCK_STD.Design
{
    public partial class frmWeightHire : Form
    {
        public frmWeightHire()
        {
            InitializeComponent();
            this.Size = new Size(742, 537);
        }

        #region VARIABLE LOCAL

        // ตัวแปร App.config 
        // ตัวแปร App.config 
        string WGH_COM_NAME = ConfigurationManager.AppSettings["WGH_COM_NAME"];
        string WGH_COM_BUADRATE = ConfigurationManager.AppSettings["WGH_COM_BUADRATE"];
        string WGH_COM_PARITY = ConfigurationManager.AppSettings["WGH_COM_PARITY"];
        string WGH_COM_DATABIT = ConfigurationManager.AppSettings["WGH_COM_DATABIT"];
        string WGH_COM_STOPBIT = ConfigurationManager.AppSettings["WGH_COM_STOPBIT"];
        string SYSTEM_API = ConfigurationManager.AppSettings["systemAPI"];
        string SYSTEM_LINE = ConfigurationManager.AppSettings["systemLINE"];

        string datavalue = "";
        // ตัวแปล Class mdb

        tbTYPE tbTYPE = new tbTYPE();
        tbCOMPANY tbCOMPANY = new tbCOMPANY();
        tbHireWeight tbHireWeight1 = new tbHireWeight();
        BunifuSnackbar msg = new BunifuSnackbar();
        string oleWeight = "";
        string wg_in = "";   // สำหรับเก็บน้ำหนัก รอบแรก เมื่อกด dgv
        #endregion


        #region FUNCTION LOCAL
        async Task CHECK_DATA_RS232()
        {
            while (true)
            {
                if (datavalue == "")
                {
                    label4.ForeColor = Color.Red;
                    label4.Text = "ERROR";
                }
                datavalue = "";
                await Task.Delay(500);
            }
        }


        #endregion

        private void frmHireWeight_Load(object sender, EventArgs e)
        {

            lbIndicator.Text = "เครื่องชั่ง : " + registy.scale.scaleName;
            // 3. กำหนดสีของ dgv       
            dgvCustomer.ColumnHeadersDefaultCellStyle.Font = new Font("Athiti", 12);
            dgvProduct.ColumnHeadersDefaultCellStyle.Font = new Font("Athiti", 12);

            dgvProduct.DefaultCellStyle.ForeColor = Color.Black;
            dgvCustomer.DefaultCellStyle.ForeColor = Color.Black;

            dgvCustomer.RowTemplate.Height = 30;
            dgvProduct.RowTemplate.Height = 30;

            // 4. เปิดการเชื่อมต่อ RS232
            serialPort1.PortName = WGH_COM_NAME;
            serialPort1.BaudRate = int.Parse(WGH_COM_BUADRATE);
            serialPort1.Parity = (Parity)Enum.Parse(typeof(Parity), WGH_COM_PARITY);
            serialPort1.DataBits = int.Parse(WGH_COM_DATABIT);
            serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), WGH_COM_STOPBIT);
            serialPort1.Open();
            // ทำการเช็คว่า rs232 มีการส่งค่ามาหรือไม่            
            CHECK_DATA_RS232();
            // ตรวจสอบน้ำหนักนิ่งหรือไม่
            tmStableWeight.Start();
        }
        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            BunifuImageButton btn = sender as BunifuImageButton;

            // ตรวจสอบว่าผู้ใช้กดที่ปุ่มไหน
            if (btn.Name == "btnSearchProduct")
            {
                dgvProduct.DataSource = tbTYPE.SELECT_ALL_DATA(); ;

                int x = (this.Width - gbProduct.Width) / 2;
                int y = (this.Height - gbProduct.Height) / 2;
                gbProduct.Location = new Point(x, y);
                gbProduct.Visible = false;
                bunifuTransition1.ShowSync(gbProduct);
            }
            else if (btn.Name == "btnSearchCustomer")
            {
                dgvCustomer.DataSource = tbCOMPANY.SELECT_ALL_DATA();

                int x = (this.Width - gbCustomer.Width) / 2;
                int y = (this.Height - gbCustomer.Height) / 2;
                gbCustomer.Location = new Point(x, y);
                gbCustomer.Visible = false;
                bunifuTransition1.ShowSync(gbCustomer);
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            Func_Main.CHECK_CHARATER_KEY_NUMBER_ONLY(sender, e, this);
        }

        private async void btnSaveWeightIN_Click(object sender, EventArgs e)
        {
            try
            {
                string ORDER_NUMB = "";// ไว้เก็บเลขที่ออเดอร์
                string dateOut = "";  // ไว้เก็บค่าวันเดือนปี ค.ศ. กรณีชั่งเข้าก็จะเป็นวันที่ชั่งเข้า กรณีชั่งออกก็จะเป็นวันที่ชั่งออก
                string timeOut = ""; // ไว้เก็บค่าเวลา กรณีชั่งเข้าก็จะเป็นวันที่ชั่งเข้า กรณีชั่งออกก็จะเป็นวันที่ชั่งออก

                #region ตรวจสอบน้ำหนัก
                // ตรวจสอบก่อนว่าน้ำหนักติดลบหรือไม่
                if (label4.Text.Contains('-'))
                {
                    msg.Show(this, "น้ำหนักติดลบไม่สามารถบันทึกได้", BunifuSnackbar.MessageTypes.Warning, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                    return;
                }

                if (label4.Text == "ERROR")
                {
                    msg.Show(this, "ไม่สามารถบันทึกได้เนื่องจาก ไม่มีน้ำหนัก", BunifuSnackbar.MessageTypes.Warning, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                    return;
                }
                #endregion

                #region ตรวจสอบค่าว่าง

                foreach (Guna.UI2.WinForms.Guna2TextBox textBox1 in gbWeightIN.Controls.OfType<Guna.UI2.WinForms.Guna2TextBox>())
                {
                    if (textBox1.Visible == true)
                    {
                        // ถ้าเจอข้อมูลว่างให้ทำการ flag chk =  false;
                        if (textBox1.Text == "")
                        {
                            msg.Show(this, "กรุณากรอกข้อมูลให้ครบก่อนทำการบันทึก", BunifuSnackbar.MessageTypes.Warning, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                            return;
                        }
                    }
                }

                // 2.2.1 ในการบันทึกชั่งเข้าจำเป็นต้องเช็คว่ามีเลขทะเบียนหรือไม่
                if (txtCarRegistration.Text == "")
                {
                    msg.Show(this, "กรุณากรอกทะเบียนรถที่ต้องการชั่งก่อน", BunifuSnackbar.MessageTypes.Warning, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                    return;
                }


                #endregion

                #region สร้างวันที่
                // 2.2.4 ดึงค่าวันเวลาเพื่อแปลงให้เป็น ค.ศ เพื่อนำไปบันทึกฐานข้อมูล
                string[] c = DateTime.Now.ToString("d/M/yyyy | HH:mm:ss").Split('|');
                string date_in = c[0].Trim();
                string time_in = c[1].Trim();
                #endregion

                #region GEN ORDER

                // 2.3.1 ทำการสร้างวันที่เพื่อที่จะทำวันทีนี้ไปหาในฐานข้อมูลและจะได้ gEN order ถูก
                string dateCurrent = DateTime.Now.ToString("yy/MM", System.Globalization.CultureInfo.CreateSpecificCulture("th-TH"));
                // ดึงข้อมูลมาเพื่อ หาออเดอร์ล่าสุด
                DataTable db = new DataTable();

                db = tbHireWeight1.SELECT_SEARCH_DATA(ORDER_NUMB);

                // ลูปหา Order แรก เพราะว่าดึงมาแบบ DESC
                if (db.Rows.Count == 0)
                {
                    ORDER_NUMB = dateCurrent + "/0001";
                }
                else
                {
                    foreach (DataRow rw in db.Rows)
                    {
                        ORDER_NUMB = rw["ORDERNUM"].ToString();
                        break;
                    }

                    // ทำการแยกเพื่อนนำเลขที่ได้จาก ฐานข้อมูลมา เรียงใหม่
                    string[] a = ORDER_NUMB.Split('/');
                    // กำหนดเลขให้ตัวแปร
                    int i = int.Parse(a[2]);
                    // ทำการ บวกไป 1 ออเดอร์
                    string ORDER_COUNT = Convert.ToString(i + 1);
                    // เมื่อได้เลขที่ order ให้ทำการเรียงเลขใหม่เพื่อ GEN ORDER ที่จะไปใช้จริง                   
                    // 2.3.2 ทำการเรียงเลขออเดอร์ใหม่อีกครั้ง
                    if (ORDER_COUNT.Length == 1)
                    {
                        // หมายถึงหลัก หน่วย
                        ORDER_NUMB = dateCurrent + "/000" + ORDER_COUNT;
                    }
                    else if (ORDER_COUNT.Length == 2)
                    {
                        // หมายถึงหลักสิบ
                        ORDER_NUMB = dateCurrent + "/00" + ORDER_COUNT;
                    }
                    else if (ORDER_COUNT.Length == 3)
                    {
                        // หมายถึงหลักร้อย
                        ORDER_NUMB = dateCurrent + "/0" + ORDER_COUNT;
                    }
                    else
                    {
                        ORDER_NUMB = dateCurrent + "/" + ORDER_COUNT;
                    }
                }
                #endregion


                #region บันทึกข้อมูล
                if (!tbHireWeight1.INSERT_ALL_DATA(ORDER_NUMB, txtCarRegistration.Text, label4.Text, date_in, time_in, txtCusID.Text, txtCusName.Text, txtPrdCode.Text, txtPrdName.Text))
                {
                    msg.Show(this, "เกิดข้อมูลผลาดในการบันทึก", BunifuSnackbar.MessageTypes.Warning, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                    return;
                }
                #endregion


                #region แสดงข้อมูล
                // เครียข้อมูล


                gbWeightIN.Enabled = false;
                // 2.3.6 ทำการเช็คว่าโปรแกรมเปิดฟังชั่น Line หรือไม่ ทั้งใน app.config and registry
                if (registy.function.LINEState == "TRUE")
                {
                    if (SYSTEM_LINE == "TRUE")
                    {
                        // หากมีการใช้งานฟังชั่น Line ให้ส่งไลน์ไป แต่ต้องกำหนดค่าก่อน
                        Func_Linenotify.parameters.Clear();
                        Func_Linenotify.parameters.Add("[@Para_Order]", ORDER_NUMB);
                        Func_Linenotify.parameters.Add("[@Para_DateIn]", date_in);
                        Func_Linenotify.parameters.Add("[@Para_TimeIn]", time_in);
                        Func_Linenotify.parameters.Add("[@Para_DateOut]", "--");
                        Func_Linenotify.parameters.Add("[@Para_TimeOut]", "--");
                        Func_Linenotify.parameters.Add("[@Para_CarRegistration]", txtCarRegistration.Text);
                        Func_Linenotify.parameters.Add("[@Para_Product]", txtPrdName.Text);
                        Func_Linenotify.parameters.Add("[@Para_Customer]", txtCusName.Text);
                        Func_Linenotify.parameters.Add("[@Para_WghIn]", "--");
                        Func_Linenotify.parameters.Add("[@Para_WghOut]", "--");
                        Func_Linenotify.parameters.Add("[@Para_WghNet]", label4.Text);
                        Func_Linenotify.parameters.Add("[@Para_mode]", "จ้างชั่ง");
                        Func_Linenotify.parameters.Add("[@Para_PriceNet]", "0");
                        Func_Linenotify.parameters.Add("[@Para_PricePerKG]", "0");



                        // ตรวจสอบว่าส่ง API สำเร็จหรือไม่
                        if (await Func_Linenotify.SEND_LINE_NOTIFY())
                        {
                            msg.Show(this, "Success to send Line Notify", BunifuSnackbar.MessageTypes.Success, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                        }
                        else
                        {
                            msg.Show(this, "Faild to send Line Notify", BunifuSnackbar.MessageTypes.Error, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                        }
                    }
                }

                // 2.3.9 เครียค่าให้ว่างเพื่อเร่ิมชั่งใหม่

                tbHireWeight tbHireWeight = new tbHireWeight(); // ดึงข้อมูลมาที่ datatable 
                DataTable tb = tbHireWeight.SELECT_SEARCH_DATA(ORDER_NUMB);

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

                gbWeightIN.Enabled = true;

                CLEAR_FROM_WEIGHT_OUT();
                #endregion
            }
            catch (Exception ex)
            {
                msg.Show(this, "frmWeightPrice btnSaveWeight_Click : " + ex.Message);
                Log.Error("frmWeightPrice btnSaveWeight_Click : " + ex.Message);
            }
        }

        void CLEAR_FROM_WEIGHT_OUT()
        {
            txtCarRegistration.Clear();
            foreach (Guna.UI2.WinForms.Guna2TextBox textBox in gbWeightIN.Controls.OfType<Guna.UI2.WinForms.Guna2TextBox>())
            {
                textBox.Clear();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            gbCustomer.Location = new Point(318, 792);
            gbProduct.Location = new Point(318, 792);
        }

        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // เช็คว่าได้กดที่รูปหรือไม่
            if (dgvCustomer.Columns[e.ColumnIndex].Name == "dataGridViewImageColumn1")
            {
                // โยนค่าจาก dgv มาเก็บไว้ที่ตัวแปร
                string cus_code = Convert.ToString(dgvCustomer.Rows[e.RowIndex].Cells[1].Value);
                string cus_name = Convert.ToString(dgvCustomer.Rows[e.RowIndex].Cells[2].Value);
                // กำหนดค่าที่ได้จากตัวแปรให้กับ textbox
                txtCusID.Text = cus_code;
                txtCusName.Text = cus_name;
                // ปิด Groupbox 
                gbCustomer.Location = new Point(318, 792);
                gbProduct.Location = new Point(318, 792);
            }
        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // เช็คว่าได้กดที่รูปหรือไม่
            if (dgvProduct.Columns[e.ColumnIndex].Name == "Column8")
            {
                // โยนค่าจาก dgv มาเก็บไว้ที่ตัวแปร
                string prd_code = Convert.ToString(dgvProduct.Rows[e.RowIndex].Cells[1].Value);
                string prd_name = Convert.ToString(dgvProduct.Rows[e.RowIndex].Cells[2].Value);
                // กำหนดค่าที่ได้จากตัวแปรให้กับ textbox
                txtPrdCode.Text = prd_code;
                txtPrdName.Text = prd_name;
                // ปิด Groupbox 
                gbCustomer.Location = new Point(318, 792);
                gbProduct.Location = new Point(318, 792);
            }
        }

        private void btnCancelWeighIN_Click(object sender, EventArgs e)
        {
            foreach (Guna.UI2.WinForms.Guna2TextBox txt in gbWeightIN.Controls.OfType<Guna.UI2.WinForms.Guna2TextBox>())
            {
                txt.Clear();
            }
            txtCarRegistration.Clear();
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                datavalue = "1";
                scales.RS232_DataReceived(sender, label4);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR WEIGHT 05" + ex.Message);
                Log.Error("frmWeightingNoPrice " + ex.Message);
            }
        }

        private void tmStableWeight_Tick(object sender, EventArgs e)
        {
            BeginInvoke(new MethodInvoker(delegate ()
            {
                if (label4.Text == "ERROR")
                {
                    btnSaveWeightIN.Enabled = true;
                }
                else if (oleWeight == label4.Text)
                {
                    btnSaveWeightIN.Enabled = true;
                }
                else
                {
                    btnSaveWeightIN.Enabled = false;
                    oleWeight = label4.Text;
                }
            }));
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            try
            {
                tmStableWeight.Stop();
                serialPort1.Close();

                // หน้าโปรแกรม
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR WEIGHT 04");
                Console.WriteLine("ERROR WEIGHT 04" + ex.Message);

            }
        }
    }
}
