using Bunifu.UI.WinForms;
using Serilog;
using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TRUCK_STD.Function;
using TRUCK_STD.Functions;
using TRUCK_STD.MSACCESSCommand;

namespace TRUCK_STD.Design
{
    public partial class frmWeightingNoPrice : Form
    {
        public frmWeightingNoPrice()
        {
            InitializeComponent();
            // กำหนดขนาดความกว้างหน้าจอ
            this.Width = 1330;
        }

        #region "VARIABLE LOCAL"
        // ตัวแปล Class mdb
        tbID_FI tbID_FI = new tbID_FI();
        tbTYPE tbTYPE = new tbTYPE();
        tbCOMPANY tbCOMPANY = new tbCOMPANY();
        tbWGH tbWGH = new tbWGH();

        // ตัวแปร App.config 
        string WGH_COM_NAME = ConfigurationManager.AppSettings["WGH_COM_NAME"];
        string WGH_COM_BUADRATE = ConfigurationManager.AppSettings["WGH_COM_BUADRATE"];
        string WGH_COM_PARITY = ConfigurationManager.AppSettings["WGH_COM_PARITY"];
        string WGH_COM_DATABIT = ConfigurationManager.AppSettings["WGH_COM_DATABIT"];
        string WGH_COM_STOPBIT = ConfigurationManager.AppSettings["WGH_COM_STOPBIT"];
        string SYSTEM_API = ConfigurationManager.AppSettings["systemAPI"];
        string SYSTEM_LINE = ConfigurationManager.AppSettings["systemLINE"];

        // ตัวแปรทั่วไป
        string carnum_h = "";// สำหรหับเก็บทะเบียนรถ เมื่อกด dgv
        string wg_in = "";   // สำหรับเก็บน้ำหนัก รอบแรก เมื่อกด dgv
        string date_in = ""; // สำหรับเก็บวันที่รอบแรก เมื่อกดที่ dgv
        string time_in = ""; // สำหรับเก็บเวลารอบแรก เมื่อกดที่ dgv
        double gross = 0;
        // ตัวแปร การเช็คน้ำหนักว่ามีการส่งมาหรือไม่ ถ้าไม่มีจะเป็น error
        string datavalue = "";
        // เก็บน้ำหนักของเก่า
        string oleWeight = "";
        BunifuSnackbar msg = new BunifuSnackbar();
        #endregion

        #region FUCSION LOCAL"
        /// <summary>
        /// ใช้สำหรับ คืนค่าตอนมีการยกเลิกการชั่งเข้า
        /// </summary>
        void CLEAR_FROM_WEIGHT_IN()
        {
            foreach (Guna.UI2.WinForms.Guna2TextBox textBox in gbWeightIN.Controls.OfType<Guna.UI2.WinForms.Guna2TextBox>())
            {
                textBox.Clear();
            }
            txtCarRegistration.Clear();
        }

        /// <summary>
        /// ใช้สำหรับ คืนค่าตอนมีการยกเลิกการชั่งเข้า
        /// </summary>
        void CLEAR_FROM_WEIGHT_OUT()
        {
            foreach (Guna.UI2.WinForms.Guna2TextBox textBox in gbWeightOUT.Controls.OfType<Guna.UI2.WinForms.Guna2TextBox>())
            {
                textBox.Clear();
            }
            lbCarNumber.Text = "--";
            wg_in = "";
            date_in = "";
            time_in = "";
        }

        /// <summary>
        /// ใช้สำหรับ เอาข้อมูลในฐานข้อมูลมาแสดงและมีการเรียงข้อมูลใหม่
        /// </summary>
        void SHOW_DGV_WEIGH_IN()
        {
            // 1.ดึงค่ามาที่ datatable 
            DataTable tb = tbID_FI.SELECT_ALL_DATA();
            DataTable tb1 = new DataTable();

            foreach (DataColumn cd in tb.Columns)
            {
                tb1.Columns.Add(cd.ColumnName);
            }

            // 2.ทำการเรียบข้อมูลใหม่
            foreach (DataRow rw in tb.Rows)
            {
                tb1.Rows.Add(rw[0], rw[1], rw[2], rw[3], rw[4], rw[5], rw[6], rw[7], rw[8]);
            }
            // โยนข้อมูลที่ได้จากการเรียงไปที่ dgv
            dgvWeighIN.DataSource = tb1;
        }

        /// <summary>
        /// สำหรับเช็คว่า เมนูนี้ใช้สิทธิ์อะไรได้บ้าง
        /// </summary>
        void CHECK_PRIVIRAGE()
        {
            // ตรวจสอบว่าใช้สิทธิ์ sa หรือไม่ เพราะ sa เข้าได้หมดทุกเมนู
            if (Func_Privilage.emp_usernmae != "sa")
            {
                if (Func_Privilage.pr_weight.pr_systemDel == "FALSE")
                {
                    dgvWeighIN.Columns["Column12"].Visible = false;
                }
            }
        }

        /// <summary>
        /// สำหรับ เช็คกว่า rs232 มีข้อมูลหรือไม่
        /// </summary>
        /// <returns></returns>
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

        private void tmStableWeight_Tick(object sender, EventArgs e)
        {
            BeginInvoke(new MethodInvoker(delegate ()
            {
                if (label4.Text == "ERROR")
                {
                    btnSaveWeightIN.Enabled = true;
                    btnSaveWeightOUT.Enabled = true;
                }
                else if (oleWeight == label4.Text)
                {
                    btnSaveWeightIN.Enabled = true;
                    btnSaveWeightOUT.Enabled = true;
                }
                else
                {
                    btnSaveWeightIN.Enabled = false;
                    btnSaveWeightOUT.Enabled = false;
                    oleWeight = label4.Text;
                }
            }));
        }
        #endregion
        private void frmWeighting_Load(object sender, EventArgs e)
        {
            try
            {
                lbIndicator.Text = "เครื่องชั่ง : " + registy.scale.scaleName;
                // 1. ดึงข้อมูลมาแสดงที่ dgv
                SHOW_DGV_WEIGH_IN();
                // 2. เช็คสิทธิ์การใช้งาน เมนูนี้
                CHECK_PRIVIRAGE();
                // 3. กำหนดสีของ dgv
                dgvWeighIN.ColumnHeadersDefaultCellStyle.Font = new Font("Athiti", 12);
                dgvCustomer.ColumnHeadersDefaultCellStyle.Font = new Font("Athiti", 12);
                dgvProduct.ColumnHeadersDefaultCellStyle.Font = new Font("Athiti", 12);

                dgvWeighIN.DefaultCellStyle.ForeColor = Color.Black;
                dgvProduct.DefaultCellStyle.ForeColor = Color.Black;
                dgvCustomer.DefaultCellStyle.ForeColor = Color.Black;

                dgvWeighIN.RowTemplate.Height = 30;
                dgvCustomer.RowTemplate.Height = 30;
                dgvProduct.RowTemplate.Height = 30;

                // 4. เปิดการเชื่อมต่อ RS232
                saWGH.PortName = WGH_COM_NAME;
                saWGH.BaudRate = int.Parse(WGH_COM_BUADRATE);
                saWGH.Parity = (Parity)Enum.Parse(typeof(Parity), WGH_COM_PARITY);
                saWGH.DataBits = int.Parse(WGH_COM_DATABIT);
                saWGH.StopBits = (StopBits)Enum.Parse(typeof(StopBits), WGH_COM_STOPBIT);
                saWGH.Open();
                // ทำการเช็คว่า rs232 มีการส่งค่ามาหรือไม่
                CHECK_DATA_RS232();
                // ตรวจสอบน้ำหนักนิ่งหรือไม่
                tmStableWeight.Start();
            }
            catch (Exception ex)
            {
                msg.Show(this, "frmWeighting_load " + ex.Message, BunifuSnackbar.MessageTypes.Error, 4000, "", BunifuSnackbar.Positions.TopCenter);
            }
        }

        private void btnSearchProduct_Click(object sender, EventArgs e)
        {
            BunifuImageButton btn = sender as BunifuImageButton;

            // ตรวจสอบว่าผู้ใช้กดที่ปุ่มไหน
            if (btn.Name == "btnSearchProduct")
            {
                dgvProduct.DataSource = tbTYPE.SELECT_ALL_DATA();

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

        private void btnClose_Click(object sender, EventArgs e)
        {
            gbCustomer.Location = new Point(318, 792);
            gbProduct.Location = new Point(318, 792);
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            try
            {
                tmStableWeight.Stop();
                saWGH.Close();

                // หน้าโปรแกรม
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR WEIGHT 04");
                Console.WriteLine("ERROR WEIGHT 04" + ex.Message);

            }
        }

        #region "Serial port"
        /// <summary>
        /// ใช้สำหรับ รับค่าจาก เครื่องชั่ง
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saWGH_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                datavalue = "1";
                scales.RS232_DataReceived(sender, label4);
            }
            catch (IOException ex)
            {
                Console.WriteLine("ERROR WEIGHT 05" + ex.Message);
                Log.Error("frmWeightingNoPrice " + ex.Message);
            }
        }
        #endregion
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

        private void btnCANCEL(object sender, EventArgs e)
        {
            Bunifu.UI.WinForms.BunifuButton.BunifuButton btn = sender as Bunifu.UI.WinForms.BunifuButton.BunifuButton;
            switch (btn.Name)
            {
                case "btnCancelWeighIN":
                    foreach (Guna.UI2.WinForms.Guna2TextBox txt in gbWeightIN.Controls.OfType<Guna.UI2.WinForms.Guna2TextBox>())
                    {
                        txt.Clear();
                    }
                    txtCarRegistration.Clear();
                    break;
                case "btnCancelWeightOUT":
                    foreach (Guna.UI2.WinForms.Guna2TextBox txt in gbWeightOUT.Controls.OfType<Guna.UI2.WinForms.Guna2TextBox>())
                    {
                        txt.Clear();
                    }
                    lbCarNumber.Text = "";
                    break;
            }
        }

        private async void btnSaveWeightIN_Click(object sender, EventArgs e)
        {
            try
            {
                Bunifu.UI.WinForms.BunifuButton.BunifuButton btn = sender as Bunifu.UI.WinForms.BunifuButton.BunifuButton;

                bool chkSave = true;
                string ORDER_NUMB = "";// ไว้เก็บเลขที่ออเดอร์
                string dateOut = "";  // ไว้เก็บค่าวันเดือนปี ค.ศ. กรณีชั่งเข้าก็จะเป็นวันที่ชั่งเข้า กรณีชั่งออกก็จะเป็นวันที่ชั่งออก
                string timeOut = ""; // ไว้เก็บค่าเวลา กรณีชั่งเข้าก็จะเป็นวันที่ชั่งเข้า กรณีชั่งออกก็จะเป็นวันที่ชั่งออก

                #region ตรวจสอบข้อมูล

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

                // 2.ตรวจสอบว่ากดปุ่มอะไรเข้ามา
                switch (btn.Name)
                {
                    // 2.2 ปุ่มบันทึก ชั่งเข้า
                    case "btnSaveWeightIN":
                        #region บันทึกชั่งเข้า          

                        #region ตรวจสอบค่าว่าง
                        // 2.2.1 การบันทึกชั่งเข้า จำเป็นต้องเช็คทะเบียนรถ
                        if (txtCarRegistration.Text == "")
                        {
                            msg.Show(this, "กรุณากรอกทะเบียนรถที่ต้องการชั่งก่อน", BunifuSnackbar.MessageTypes.Warning, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                            return;
                        }

                        foreach (Guna.UI2.WinForms.Guna2TextBox textBox1 in gbWeightIN.Controls.OfType<Guna.UI2.WinForms.Guna2TextBox>())
                        {
                            // ถ้าเจอข้อมูลว่างให้ทำการ flag chk =  false;
                            if (textBox1.Text == "")
                            {
                                msg.Show(this, "กรุณากรอกข้อมูลให้ครบก่อนทำการบันทึก", BunifuSnackbar.MessageTypes.Warning, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                                return;
                            }
                        }

                        #endregion

                        #region ตรวจสอบทะเบียนซ้ำ
                        // 2.2.3 ก่อนทำการบันทึกให้เช็คว่า คีย์ข้อมูลซ้ำหรือไม่
                        foreach (DataGridViewRow rw in dgvWeighIN.Rows)
                        {
                            if (txtCarRegistration.Text == Convert.ToString(rw.Cells["Column1"].Value))
                            {
                                bunifuSnackbar1.Show(this, "ทะเบียนรถ " + txtCarRegistration.Text + " มีทำรายการอยู่ยังไม่เสร็จกรุณาตรวจสอบรายการอีกครั้ง", BunifuSnackbar.MessageTypes.Warning, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                                return;
                            }
                        }
                        #endregion

                        #region บันทึกข้อมูล
                        // 2.2.4 ดึงค่าวันเวลาเพื่อแปลงให้เป็น ค.ศ เพื่อนำไปบันทึกฐานข้อมูล
                        string[] c = DateTime.Now.ToString("d/M/yyyy | HH:mm:ss").Split('|');
                        date_in = c[0].Trim();
                        time_in = c[1].Trim();

                        // 2.2.5 บันทึกข้อมูล
                        if (tbID_FI.INSERT_ALL_DATA(txtCarRegistration.Text, label4.Text, date_in, time_in, "0", txtCusID.Text, txtCusName.Text, txtPrdCode.Text, txtPrdName.Text))
                        {
                            // 2.2.6 หากทำการบันทึกให้แสดงข้อมูล dgv และเครียค่าออก
                            SHOW_DGV_WEIGH_IN();
                            // 2.2.7 เครีย์ตัวแปรและ Textbox ต่าง ๆ ให้ว่างเหมือนเดิม
                            CLEAR_FROM_WEIGHT_IN();
                            bunifuSnackbar1.Show(this, "บันทึกรายการสำเร็จ", BunifuSnackbar.MessageTypes.Success, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                        }
                        else
                        {
                            bunifuSnackbar1.Show(this, "ไม่สามารถบันทึกรายการได้", BunifuSnackbar.MessageTypes.Warning, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                            return;
                        }

                        #endregion

                        #endregion
                        break;
                    // 2.3 ปุ่มบันทึก ชั่งออก
                    case "btnSaveWeightOUT":
                        #region บันทึกชั่งออก

                        #region ตรวจสอบค่าว่าง
                        if (lbCarNumber.Text == "")
                        {
                            msg.Show(this, "กรุณาเลือกรถที่ต้องการจะชั่งออก", BunifuSnackbar.MessageTypes.Warning, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                            return;
                        }

                        foreach (Guna.UI2.WinForms.Guna2TextBox textBox1 in gbWeightOUT.Controls.OfType<Guna.UI2.WinForms.Guna2TextBox>())
                        {
                            // ถ้าเจอข้อมูลว่างให้ทำการ flag chk =  false;
                            if (textBox1.Text == "")
                            {
                                msg.Show(this, "กรุณากรอกข้อมูลให้ครบก่อนทำการบันทึก", BunifuSnackbar.MessageTypes.Warning, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                                return;
                            }
                        }
                        #endregion

                        #region GEN ORDER


                        // 2.3.1 ทำการสร้างวันที่เพื่อที่จะทำวันทีนี้ไปหาในฐานข้อมูลและจะได้ gEN order ถูก
                        string dateCurrent = DateTime.Now.ToString("yy/MM", System.Globalization.CultureInfo.CreateSpecificCulture("th-TH"));
                        // ดึงข้อมูลมาเพื่อ หาออเดอร์ล่าสุด
                        DataTable db = tbWGH.SELECT_ALL_DATA_DESC();

                        // ลูปหา Order แรก เพราะว่าดึงมาแบบ DESC
                        if (db.Rows.Count == 0)
                        {
                            ORDER_NUMB = dateCurrent + "/0001";
                        }
                        else
                        {
                            foreach (DataRow rw in db.Rows)
                            {
                                ORDER_NUMB = rw["ORDER_NUMB"].ToString();
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

                        #region สร้างวันที่
                        // 2.3.3 สร้างวันเวลาให้เป็น ค.ศ. เพื่อบันทึกไปที่ฐานข้อมูล
                        string[] b = DateTime.Now.ToString("d/M/yyyy | HH:mm:ss").Split('|');
                        dateOut = b[0].Trim();
                        timeOut = b[1].Trim();
                        #endregion

                        #region คำนวนน้ำหนักไม่ให้ติดลบ

                        // 2.3.4 ทำการคำนวน น้ำหนักสุทธิ์ เพื่อนำไปบันทีกที่ฐานข้อมูล
                        double aa = double.Parse(wg_in);
                        double bb = double.Parse(label4.Text);
                        if (aa > bb)
                        {
                            gross = aa - bb;
                        }
                        else if (bb > aa)
                        {
                            gross = bb - aa;
                        }
                        else
                        {
                            gross = aa - bb;
                        }
                        #endregion

                        #region บันทึกข้อมูล
                        // 2.3.5  เมื่อได้ ORDERNUM ที่แท้จริงให้ทำการบันทึกลงฐานข้อมูลโดยไม่ต้องเช็คว่าใช้งานฟังชั่นคำนวนราคาหรือไม่
                        if (tbWGH.INSERT_ALL_DATA(ORDER_NUMB, date_in, dateOut, time_in, timeOut, lbCarNumber.Text, wg_in, label4.Text, txtPrd_Name.Text, txtCus_Name.Text, txtPrd_Code.Text, txtCus_ID.Text, 0, Convert.ToString(gross), 0))
                        {
                            // 2.3.6 ทำการลบข้อมูลเก่าที่อยู่ในตาราง ID_FI
                            tbID_FI.DELETE_ALL_DATA(lbCarNumber.Text);
                            // แจ้งให้ผู้ใช้ทราบ 
                            SHOW_DGV_WEIGH_IN();

                            bunifuSnackbar1.Show(this, "บันทึกรายการสำเร็จ", BunifuSnackbar.MessageTypes.Success, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                        }
                        else
                        {
                            bunifuSnackbar1.Show(this, "ไม่สามารถบันทึกรายการได้", BunifuSnackbar.MessageTypes.Warning, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                            return;
                        }
                        #endregion

                        #region แสดงข้อมูล
                        gbWeightOUT.Enabled = false;
                        if (registy.function.LINEState == "TRUE")
                        {
                            // 2.3.6 ทำการเช็คว่าโปรแกรมเปิดฟังชั่น Line หรือไม่
                            if (SYSTEM_LINE == "TRUE")
                            {
                                // หากมีการใช้งานฟังชั่น Line ให้ส่งไลน์ไป แต่ต้องกำหนดค่าก่อน
                                Func_Linenotify.parameters.Clear();
                                Func_Linenotify.parameters.Add("[@Para_Order]", ORDER_NUMB);
                                Func_Linenotify.parameters.Add("[@Para_DateIn]", date_in);
                                Func_Linenotify.parameters.Add("[@Para_TimeIn]", time_in);
                                Func_Linenotify.parameters.Add("[@Para_DateOut]", dateOut);
                                Func_Linenotify.parameters.Add("[@Para_TimeOut]", timeOut);
                                Func_Linenotify.parameters.Add("[@Para_CarRegistration]", lbCarNumber.Text);
                                Func_Linenotify.parameters.Add("[@Para_Product]", txtPrd_Name.Text);
                                Func_Linenotify.parameters.Add("[@Para_Customer]", txtCus_Name.Text);
                                Func_Linenotify.parameters.Add("[@Para_WghIn]", wg_in);
                                Func_Linenotify.parameters.Add("[@Para_WghOut]", label4.Text);
                                Func_Linenotify.parameters.Add("[@Para_WghNet]", Convert.ToString(gross));
                                Func_Linenotify.parameters.Add("[@Para_mode]", "ชั่งปกติ");

                                // ตรวจสอบว่าส่ง API สำเร็จหรือไม่
                                if (await Func_Linenotify.SEND_LINE_NOTIFY())
                                {
                                    bunifuSnackbar1.Show(this, "Success to send Line Notify", BunifuSnackbar.MessageTypes.Success, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                                }
                                else
                                {
                                    bunifuSnackbar1.Show(this, "Faild to send Line Notify", BunifuSnackbar.MessageTypes.Error, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                                }
                            }
                        }

                        // 2.3.9 เครียค่าให้ว่างเพื่อเร่ิมชั่งใหม่
                        CLEAR_FROM_WEIGHT_OUT();
                        // ดึงข้อมูลมาที่ datatable 
                        DataTable tb = tbWGH.SELECT_SEARCH_DATA(ORDER_NUMB);


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
                        gbWeightOUT.Enabled = true;
                        #endregion
                        #endregion
                        break;
                }
            }
            catch (Exception ex)
            {
                msg.Show(this, "frmWeightNoPrice btnSaveWeight_Click : " + ex.Message);
                Log.Error("frmWeighNotPrice btnSaveWeight_Click : " + ex.Message);
            }
        }

        private void dgvWeighIN_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string comdesc = "";
                string typedesc = "";
                string price = "";
                string comcode = "";
                string typecode = "";

                carnum_h = Convert.ToString(dgvWeighIN.Rows[e.RowIndex].Cells["Column1"].Value);
                wg_in = Convert.ToString(dgvWeighIN.Rows[e.RowIndex].Cells["Column2"].Value);
                comdesc = Convert.ToString(dgvWeighIN.Rows[e.RowIndex].Cells["Column5"].Value);
                typedesc = Convert.ToString(dgvWeighIN.Rows[e.RowIndex].Cells["Column6"].Value);
                date_in = Convert.ToString(dgvWeighIN.Rows[e.RowIndex].Cells["Column10"].Value);
                time_in = Convert.ToString(dgvWeighIN.Rows[e.RowIndex].Cells["Column4"].Value);
                comcode = Convert.ToString(dgvWeighIN.Rows[e.RowIndex].Cells["Column7"].Value);
                typecode = Convert.ToString(dgvWeighIN.Rows[e.RowIndex].Cells["Column9"].Value);

                switch (dgvWeighIN.Columns[e.ColumnIndex].Name)
                {
                    case "cl_del":
                        if (MessageBox.Show("คุณต้องการ ลบข้อมูลออกจาการชั่งหรือ", "Warnning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            string carnum_hd = Convert.ToString(dgvWeighIN.Rows[e.RowIndex].Cells["Column1"].Value);
                            if (tbID_FI.DELETE_ALL_DATA(carnum_hd))
                            {
                                SHOW_DGV_WEIGH_IN();
                            }
                        }
                        break;
                    case "cl_select":
                        lbCarNumber.Text = carnum_h;
                        txtCus_ID.Text = comcode;
                        txtCus_Name.Text = comdesc;
                        txtPrd_Code.Text = typecode;
                        txtPrd_Name.Text = typedesc;
                        break;
                }
            }
            catch (Exception exx)
            {
                bunifuSnackbar1.Show(this, exx.Message, BunifuSnackbar.MessageTypes.Warning, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
            }
        }

        private void txtSearchProduct_IconRightClick(object sender, EventArgs e)
        {
            if (txtSearchProduct.Text == "")
            {
                //หากค้นหาว่าง ๆ จะทำการแสดงข้อมูลทังหมด
                dgvProduct.DataSource = tbTYPE.SELECT_ALL_DATA();
            }
            else
            {
                // แต่ถ้านอกเหนือจากนั้นให้ ทำการแสดงข้อมูลที่ค้นหา
                dgvProduct.DataSource = tbTYPE.SELECT_PRODUCT_CODE_LIKE(txtSearchProduct.Text);
            }
        }

        private void txtSearchCustomer_IconRightClick(object sender, EventArgs e)
        {
            if (txtSearchCustomer.Text == "")
            {
                //หากค้นหาว่าง ๆ จะทำการแสดงข้อมูลทังหมด
                dgvCustomer.DataSource = tbCOMPANY.SELECT_ALL_DATA();
            }
            else
            {
                // แต่ถ้านอกเหนือจากนั้นให้ ทำการแสดงข้อมูลที่ค้นหา
                dgvCustomer.DataSource = tbCOMPANY.SELECT_SEARCH(txtSearchCustomer.Text);
            }
        }
    }
}
