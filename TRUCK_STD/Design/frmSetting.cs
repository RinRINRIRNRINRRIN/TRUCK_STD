using Bunifu.UI.WinForms;
using Guna.UI2.WinForms;
using RestSharp;
using Serilog;
using System;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using TRUCK_STD.Function;
using TRUCK_STD.Functions;


namespace TRUCK_STD.Design
{
    public partial class frmSetting : Form
    {
        public frmSetting()
        {
            InitializeComponent();

        }

        #region LOCAL VIRABLE

        // ตัวแปลที่เมื่อมีการเปลี่ยนแปลงการแก้ไขจะ เปลี่ยนเป็น False จะทำไปเช็คตอนออกจากโปรแกรม
        // true = ยังไม่ได้มีการบันทึกหรือแก้ไขอะไร
        bool chkStatusSave = true;
        bool systemLineNotify = false;
        bool systemLIneTemplate = false;
        bool systemAPI = false;
        // key MD5 สำหรับเก็บค่ารหัส เพื่อนำไปเปรียบเทียบจากที่ผู้ใช้คีย์เข้ามา
        //
        string key_md5 = "";
        #endregion


        BunifuSnackbar msg = new BunifuSnackbar();

        #region LOCAL FUNCTION


        /// <summary>
        /// สำหรับดึงค่าจาก Registy มาแสดงที่ส่วนของแก้ไขหัวตั๋ว
        /// </summary>
        void GET_PARAMETER_REGISTY()
        {
            // ดึงค่า Comport เครื่องชั่ง
            cbbWGH_COM.Items.Clear();
            cbbWGH_BUADRATE.Items.Clear();
            cbbWGH_COM.Items.Add(registy.scale.scalePort);
            cbbWGH_BUADRATE.Items.Add(registy.scale.scaleBaudrate.ToString());
            cbbWGH_BUADRATE.SelectedIndex = 0;
            cbbWGH_COM.SelectedIndex = 0;

            // ดึงค่า Comport PLC
            cbbPLC_COM.Items.Clear();
            cbbPLC_BAUDRATE.Items.Clear();
            cbbPLC_COM.Items.Add(registy.plc.plcPort);
            cbbPLC_BAUDRATE.Items.Add(registy.plc.plcBaudrate.ToString());
            cbbPLC_BAUDRATE.SelectedIndex = 0;
            cbbPLC_COM.SelectedIndex = 0;
            txtSlave.Text = registy.plc.slave;
            txtAddress1.Text = registy.plc.command1;
            txtAddress2.Text = registy.plc.command2;

            // เช็คว่ามีฟังชั่น Barrierr หรือไม่
            if (registy.function.BARRIERState == "TRUE")
            {
                // หากมีให้เช็คว่าได้ใช้หรือไม่
                if (registy.plc.slave != "")
                    tgsBarrierr.Checked = true;
            }
            // ดีงค่า Line noty
            if (registy.function.LINEState == "TRUE")
            {
                tgsLineNotify.Checked = true;
                txtLineToken.Text = registy.function.LINE_TOKEN;
            }


            // หลังจากดึงค่ามาแสดงให้นำข้อมูลมาแสดงที่โปรแกรม
            label58.Text = registy.tickets.company;
            label57.Text = registy.tickets.address;
            label56.Text = registy.tickets.phone;

            txtTicTax.Text = registy.tickets.tax;
            txtTickPhone.Text = registy.tickets.phone;
        }

        #endregion


        private void frmSetting_Load(object sender, EventArgs e)
        {
            // ดึงข้อมูลใน Registry มาแสดงที่โปรแกรม ส่วนของแก้ไขหัวตั๋ว
            GET_PARAMETER_REGISTY();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            if (!chkStatusSave)
            {
                Application.ExitThread();
            }
        }


        #region SETTING COMPORT
        private void DropDown_When_Close(object sender, EventArgs e)
        {
            Guna2ComboBox cbb = sender as Guna2ComboBox;

            if (cbb.Text == "")
            {
                cbb.Items.Clear();

                switch (cbb.Tag)
                {
                    case "comport":
                        cbb.Items.Add("--COM--");
                        break;
                    case "baudrate":
                        cbb.Items.Add("--BAUDRATE--");
                        break;
                }
                cbb.SelectedIndex = 0;
            }

        }

        private void DropDown_When_dropdown(object sender, EventArgs e)
        {
            Guna2ComboBox cbb = sender as Guna2ComboBox;
            SerialPort sd = new SerialPort();
            cbb.Items.Clear();

            switch (cbb.Tag)
            {
                case "comport":
                    string[] com = SerialPort.GetPortNames();
                    foreach (string element in com)
                    {
                        cbb.Items.Add(element);
                    }
                    break;
                case "baudrate":
                    cbb.Items.Add("300");
                    cbb.Items.Add("1200");
                    cbb.Items.Add("2400");
                    cbb.Items.Add("4800");
                    cbb.Items.Add("9600");
                    cbb.Items.Add("19200");
                    cbb.Items.Add("38400");
                    cbb.Items.Add("57600");
                    cbb.Items.Add("74880");
                    cbb.Items.Add("115200 ");
                    break;
            }
        }
        #endregion

        #region SETTING LINE NOTIFY



        private async void tgsLineNotify_CheckedChanged(object sender, BunifuToggleSwitch.CheckedChangedEventArgs e)
        {
            try
            {
                // หากมีการเปิดฟังชั่น line แต่แรก
                if (tgsLineNotify.Checked == true)
                {
                    // ตรวจสอบก่อนว่าโปรแกรมได้มีการใช้งานฟังชั่น line ตั้งแค่ตอนติดตั้งหรือไม่
                    if (registy.function.LINEState == "TRUE")
                    {
                        txtLineToken.Enabled = true;
                    }
                    else
                    {
                        // แต่หากไม่ได้มีการเปิดฟังชั่น line แต่แรกให้ถามผู้ใช้ก่อนว่าต้องการเปิดฟังชั่นหรือไม่
                        DialogResult dialogResult = MessageBox.Show("แพ็คเกจคุณไม่ได้เปิดใช้งานฟังชั่น Line คุณต้องการเปิดการใช้งานฟังชั่นไลน์ Line notify หรือไม่", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        if (dialogResult == DialogResult.Yes)
                        {
                            frmProgramMessageAlert frmProgramMessageAlert = new frmProgramMessageAlert();
                            frmProgramMessageAlert.alertLevel = 2;
                            frmProgramMessageAlert.extension = "LINE";
                            frmProgramMessageAlert.ShowDialog();
                            if (frmProgramMessageAlert.chckUnlock == false)
                            {
                                tgsLineNotify.Checked = false;
                            }
                            else
                            {
                                tgsLineNotify.Checked = true;
                                registy.Set();
                            }
                        }
                        else
                        {
                            tgsLineNotify.Checked = false;
                        }
                    }
                }
                else if (tgsLineNotify.Checked == false)
                {
                    // หากเชื่อมต่อไม่ได้ ให้ปิดฟังชั่นการใช้งาน 
                    txtLineToken.Enabled = false;
                    btnLineTest.Enabled = false;
                    // กำหนดว่าไม่ใช้งานฟังชั่น Line Notify
                    systemLineNotify = false;
                }

            }
            catch (Exception ex)
            {
                // หากเชื่อมต่อไม่ได้ ให้ปิดฟังชั่นการใช้งาน 
                tgsLineNotify.Checked = false;
                txtLineToken.Enabled = false;
                // กำหนดว่าwไม่ใช้งานฟังชั่น Line Notify
                systemLineNotify = false;
                msg.Show(this, "ไม่สามารถใช้งานได้ กรุณาตรวจสอบการเชื่อมต่ออินเตอร์เน็ต " + ex.Message, BunifuSnackbar.MessageTypes.Warning, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
            }
        }
        private void tgsBarrierr_CheckedChanged(object sender, BunifuToggleSwitch.CheckedChangedEventArgs e)
        {
            if (tgsBarrierr.Checked == true)
            {
                // เช็คว่ามีฟังชั่นมีแต่แรกหรือไม่
                if (registy.function.BARRIERState == "TRUE")
                {
                    pnComPLC.Enabled = true;
                    pnAddress.Enabled = true;
                }
                else
                {
                    // แต่หากไม่ได้มีการเปิดฟังชั่น line แต่แรกให้ถามผู้ใช้ก่อนว่าต้องการเปิดฟังชั่นหรือไม่
                    DialogResult dialogResult = MessageBox.Show("แพ็คเกจคุณไม่ได้เปิดใช้งานฟังชั่น ไม้กั้น คุณต้องการเปิดการใช้งานฟังชั่น ไม้กั้น หรือไม่", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (dialogResult == DialogResult.Yes)
                    {

                        frmProgramMessageAlert frmProgramMessageAlert = new frmProgramMessageAlert();
                        frmProgramMessageAlert.alertLevel = 2;
                        frmProgramMessageAlert.messageAlert = "รหัสสำหรับเปิดฟังชั่นไม้กั้น";
                        frmProgramMessageAlert.extension = "BARRIER";
                        frmProgramMessageAlert.ShowDialog();
                        if (frmProgramMessageAlert.chckUnlock == false)
                        {
                            tgsBarrierr.Checked = false;
                        }
                        else
                        {
                            registy.Set();
                            tgsBarrierr.Checked = true;
                        }
                    }
                    else
                    {
                        tgsBarrierr.Checked = false;
                    }
                }
            }
            else if (tgsBarrierr.Checked == false)
            {
                pnComPLC.Enabled = false;
                pnAddress.Enabled = false;
            }

        }

        private void txtLineToken_IconRightClick(object sender, EventArgs e)
        {
            // สั่งเปิด หน้าเว็บวิธีของ Line token
            Process.Start("https://www.smith.in.th/%E0%B8%AA%E0%B8%A3%E0%B9%89%E0%B8%B2%E0%B8%87-line-notify-%E0%B8%AA%E0%B8%B3%E0%B8%AB%E0%B8%A3%E0%B8%B1%E0%B8%9A-post-%E0%B8%A5%E0%B8%87%E0%B8%81%E0%B8%A5%E0%B8%B8%E0%B9%88%E0%B8%A1/");
        }

        private void txtLineSimple_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '[' || e.KeyChar == ']')
            {
                e.Handled = true;
                msg.Show(this, "ไม่สามารถพิมพ์ ENTER , [ , ] ได้เนื่องจากเป็นคำเฉพาะ", BunifuSnackbar.MessageTypes.Warning, 5000, "OK", BunifuSnackbar.Positions.TopCenter);
            }
        }



        private async void btnLineTest_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. ตรวจสอบว่ากรอกข้อมูลครหรือไม่
                if (txtLineToken.Text == "")
                {
                    msg.Show(this, "กรุณากรอกข้อมูลให้ครบก่อนทำการทดสอบ Line notify", BunifuSnackbar.MessageTypes.Warning, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                    return;
                }

                // 2. ทดสอบส่ง Line notify
                RestClientOptions restClientOptions = new RestClientOptions("https://notify-api.line.me/api/notify")
                {
                    MaxTimeout = -1,
                };

                RestClient restClient = new RestClient(restClientOptions);
                RestRequest restRequest = new RestRequest("https://notify-api.line.me/api/notify", Method.Post);

                restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                restRequest.AddHeader("Authorization", "Bearer " + txtLineToken.Text);
                string LinePlatterPGMUsePrice = "\n" +
           "โหมดการชั่ง : ชั่งปกติ\n" +
          "เลขที่ออเดอร์ : " + registy.system.stationName + "24100001\n" +
          "วันที่ชั่งเข้า : 19-10-2014\n" +
          "เวลาที่ชั่งเข้า : 11:11:20\n" +
          "วันที่ชั่งออก : 19-10-2014\n" +
          "เวลาที่ชั่งออก : 11:12:20\n" +
          "ทะเบียนรถยนต์ : 303023\n" +
          "ชื่อสินค้า : โหลดเซล\n" +
          "ชื่อลูกค้า : กรินทร์ เตชะรัตนยืนง\n" +
          "น้ำหนักชั่งเข้า : 50000\n" +
          "น้ำหนักชั่งออก : 30000\n" +
          "น้ำหนักสุทธิ์ : 20000\n" +
          "ราคาสินค้า/กก. : 30\n" +
          "ราคาสุทธิ์ : 600,000";
                restRequest.AddParameter("message", LinePlatterPGMUsePrice);
                RestResponse restResponse = await restClient.ExecuteAsync(restRequest);

                // ตรวจสอบว่าส่งสำเร็จหรือไม่
                if (restResponse.StatusCode == HttpStatusCode.OK)
                {
                    msg.Show(this, "เชื่อมต่อ Line notify สำเร็จ", BunifuSnackbar.MessageTypes.Success, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                }
                else
                {
                    msg.Show(this, "เชื่อมต่อ Line notify ไม่สำเร็จ", BunifuSnackbar.MessageTypes.Error, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                }
            }
            catch (Exception ex)
            {
                msg.Show(this, "เชื่อมต่อ Line notify ไม่สำเร็จ " + ex.Message, BunifuSnackbar.MessageTypes.Error, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
            }

        }

        #endregion

        #region SETTING EDIT HEADER TICK

        private void txtTickPhone_TextChanged(object sender, EventArgs e)
        {
            label56.Text = txtTickPhone.Text;
        }
        private void btnUnlock_Click(object sender, EventArgs e)
        {
            // ตรวจสอบก่อนว่า สามารถแก้ไขได้หรือไม่ โดยการเช็คจาก state 
            if (registy.tickets.state == "FALSE")
            {
                // ตรวจสอบก่อนว่ามีข้อมูลว่างหรือไม
                if (txtTickPass.Text == "")
                {
                    msg.Show(this, "กรุณากรอกรหัสที่ได้จาก ไทยเครื่องชั่ง", BunifuSnackbar.MessageTypes.Warning, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                    return;
                }

                // ยังไม่มีการแก้ไขในวันนี้สามารถแก้ไขได้
                // ทำการ GEN pass มาเพื่อเปรียบเทียบกับรหัสแก้ไขหัวตั๋ว หากมีการแก้ไขหัวตั๋ว

                Func_MD5._key_programNumber = registy.system.id;
                Func_MD5._key_type = "EDIT";
                key_md5 = Func_MD5.GEN_MD5();
                // ตรวจอสอบค่าคีย์ที่ ระบบ gen มาตรงกับที่ผู้ใช้คีย์มาหรือไม่
                if (key_md5 == txtTickPass.Text)
                {
                    // หากตรวจสอบแล้วถูกต้องให้้ visible gbTickPass และเปิด txtTickAddress,txtTickPhone
                    gbTickPass.Visible = false;
                    txtTickPhone.Enabled = true;
                }
                else
                {
                    // แจ้งให้ผู้ใช้ทราบ
                    msg.Show(this, "รหัสผ่านไม่ถูกต้อง", BunifuSnackbar.MessageTypes.Warning, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                    txtTickPass.Clear();
                }
            }
            else
            {
                msg.Show(this, "กรุณาแก้ไขตั๋วในวันถัดไปเนื่องจากสามารถแก้ไขได้วันละ 1 ครั้งเท่านั้น", BunifuSnackbar.MessageTypes.Warning, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                return;
            }
        }
        #endregion



        /// <summary>
        /// บันทึกตั้งค่่าทั้งหมด
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            try
            {
                #region ตรวจสอบค่าว่าง

                // ตรวจสอบ ค่าว่าง cbb
                foreach (Guna.UI2.WinForms.Guna2ComboBox cbb in panel1.Controls.OfType<Guna.UI2.WinForms.Guna2ComboBox>())
                {
                    if (cbb.Text.Contains('-'))
                    {
                        msg.Show(this, "กรุณากรอกข้อมูลในส่วนของการเชื่อมต่อเครื่องชั่ง!!", BunifuSnackbar.MessageTypes.Warning, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                        return;
                    }
                }

                // ตรวบสอบค่าว่างของ Line notify หากมีการกำหนดการใช้งาน TRUE
                if (registy.function.LINEState == "TRUE")
                {
                    if (tgsLineNotify.Checked == true)
                    {
                        if (txtLineToken.Text == "")
                        {
                            msg.Show(this, "กรุณากรอกข้อมุลในส่วนของ Line notify", BunifuSnackbar.MessageTypes.Warning, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                            return;
                        }
                    }

                }

                // ตรวจสอบว่าหากมีฟังัช่นไม้กั้นจะต้องใส่ข้อมูลเกียวกับ PLC
                if (registy.function.BARRIERState == "TRUE")
                {
                    // หากมีการใช้งานฟังชั่น BARRIER ให้ตรวจสอบว่าผู้ใช้ได้ใช้งานหรือไม่
                    if (tgsBarrierr.Checked == true)
                    {
                        foreach (Guna2ComboBox cbk in pnComPLC.Controls.OfType<Guna2ComboBox>())
                        {
                            if (cbk.Text == "")
                            {
                                msg.Show(this, "กรุณากรอกข้อมูลส่วนการเชื่อมต่อ PLC ให้ครบก่อนบันทึก", BunifuSnackbar.MessageTypes.Warning, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                                return;
                            }
                        }
                    }
                }



                // กำหนดค่าว่างของ หัวตั๋ว 
                if (txtTickPhone.Enabled == true)
                {
                    if (txtTickPhone.Text == "" || txtTicTax.Text == "")
                    {
                        msg.Show(this, "กรุณากรอกข้อมูลตั๋วให้ครบก่อนทำการบันทึก", BunifuSnackbar.MessageTypes.Warning, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                        return;
                    }
                }
                // กำหนดค่าส่วนเครื่องชั่ง
                registy.scale.scalePort = cbbWGH_COM.Text;
                registy.scale.scaleBaudrate = int.Parse(cbbWGH_BUADRATE.Text);
                // กำหนดค่าส่วน PLC
                registy.plc.plcPort = cbbPLC_COM.Text;

                registy.plc.plcBaudrate = int.Parse(cbbPLC_BAUDRATE.Text);
                registy.plc.slave = txtSlave.Text;
                registy.plc.command1 = txtAddress1.Text;
                registy.plc.command2 = txtAddress2.Text;
                // กำหนดค่าส่วน LINE
                registy.function.LINE_TOKEN = txtLineToken.Text;
                registy.Set();
                MessageBox.Show("บันทึกรายการสำเร็จ โปรแกรมจะปิดกรุณาเปิดใหม่", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
                #endregion
            }
            catch (Exception ex)
            {
                msg.Show(this, "เกิดข้อผิดผลาด " + ex.Message, BunifuSnackbar.MessageTypes.Error, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                Log.Error("frmSetting bunifuButton1_Click " + ex.Message);
            }
        }

        private async void TESTPLC(object sender, EventArgs e)
        {
            var btn = sender as BunifuTextBox;

            // เช็ค COMPORT Baudreate
            if (cbbPLC_COM.Text.Contains('-') || cbbPLC_BAUDRATE.Text.Contains('-'))
            {
                msg.Show(this, "กรุณาเลือกพอร์ตการเชื่อมต่อก่อน", BunifuSnackbar.MessageTypes.Warning, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                return;
            }
            switch (btn.Tag)
            {
                case "1":
                    int add1 = int.Parse(txtAddress1.Text);

                    break;
                case "2":
                    int add2 = int.Parse(txtAddress2.Text);

                    break;
            }

            await Task.Delay(5000);
        }

        private void cbbWGH_BUADRATE_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}

