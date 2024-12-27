using Bunifu.UI.WinForms;
using Guna.UI2.WinForms;
using Serilog;
using System;
using System.IO.Ports;
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



            // เช็คว่ามีฟังชั่น Barrierr หรือไม่
            if (registy.function.BARRIERState == "TRUE")
            {
                // หากมีให้เช็คว่าได้ใช้หรือไม่
                tgsBarrier.Checked = true;
            }

            cbbPLC_COM.Items.Clear();
            cbbPLC_COM.Items.Add(registy.function.BARRIERCOM);
            cbbPLC_COM.SelectedIndex = 0;

            cbbPLC_BAUDRATE.Items.Clear();
            cbbPLC_BAUDRATE.Items.Add(registy.function.BARRIERBaudrate);
            cbbPLC_BAUDRATE.SelectedIndex = 0;


            // Check lpr Barrier
            if (registy.function.LPRState == "TRUE")
            {
                tgsLPR.Checked = true;
            }





            // Check CCTV 
            if (registy.function.CAMERAState == "TRUE")
            {
                tgsCCTV.Checked = true;
            }

            if (registy.function.RFIDState == "TRUE")
            {
                tgsRFID.Checked = true;
            }

            cbbComRFID.Items.Clear();
            cbbComRFID.Items.Add(registy.function.RFID_COM);
            cbbComRFID.SelectedIndex = 0;

            cbbBardrateRFID.Items.Clear();
            cbbBardrateRFID.Items.Add(registy.function.RFID_BAUDRATE);
            cbbBardrateRFID.SelectedIndex = 0;


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



        private void tgsBarrierr_CheckedChanged(object sender, BunifuToggleSwitch.CheckedChangedEventArgs e)
        {
            if (tgsBarrier.Checked == true)
            {
                // เช็คว่ามีฟังชั่นมีแต่แรกหรือไม่
                if (registy.function.BARRIERKey != "")
                {
                    pnComPLC.Enabled = true;
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
                            tgsBarrier.Checked = false;
                        }
                        else
                        {
                            registy.Set();
                            tgsBarrier.Checked = true;
                        }
                    }
                    else
                    {
                        tgsBarrier.Checked = false;
                    }
                }
            }
            else if (tgsBarrier.Checked == false)
            {
                pnComPLC.Enabled = false;
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
                #region ตรวจสอบเครื่องชั่ง
                if (cbbWGH_COM.Text.Contains("--") || cbbWGH_BUADRATE.Text.Contains("--"))
                {
                    sb.Show(this, "กรุณากรอกข้อมูลการเชื่อมต่อเครื่องชั่งก่อนการบันทึก", BunifuSnackbar.MessageTypes.Warning, 3000, "", BunifuSnackbar.Positions.TopCenter);
                    return;
                }
                #endregion
                #region ตรวจสอบฟังชั่น RFID,CCTV,CAM,BARRIER
                // เช็คไม้กั้น
                if (tgsBarrier.Checked == true)
                    if (cbbPLC_COM.Text.Contains("--") || cbbPLC_BAUDRATE.Text.Contains("--"))
                    {
                        sb.Show(this, "กรุณากรอกข้อมูลการเชื่อมต่อไม้กั้นก่อนการบันทึก", BunifuSnackbar.MessageTypes.Warning, 3000, "", BunifuSnackbar.Positions.TopCenter);
                        return;
                    }
                // เช็ค RFID
                if (tgsRFID.Checked == true)
                    if (cbbComRFID.Text.Contains("--") || cbbBardrateRFID.Text.Contains("--"))
                    {
                        sb.Show(this, "กรุณากรอกข้อมูลการเชื่อมต่อ RFID ก่อนการบันทึก", BunifuSnackbar.MessageTypes.Warning, 3000, "", BunifuSnackbar.Positions.TopCenter);
                        return;
                    }
                #endregion
                #region เช็คตั๋วว่าได้บันทึกหรือไม่
                if (gbTickPass.Visible == false)
                    if (txtTickPhone.Text == "" || txtTicTax.Text == "")
                    {
                        sb.Show(this, "กรุณากรอกข้อมูลตั๋วก่อนการบันทึก", BunifuSnackbar.MessageTypes.Warning, 3000, "", BunifuSnackbar.Positions.TopCenter);
                        return;
                    }
                #endregion

                DialogResult dialogResult = MessageBox.Show("ยืนยันการบันทึกข้อมูลหรือไม่?\nเมื่อบันทึกแล้วโปรแกรมจะปิดตัวเองกรุณาเปิดโปรแกรมใหม่อีกครั้ง", "บันทึกข้อมูล", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    #region บันทึกค่าที่ registry
                    // SAVE Scale
                    registy.scale.scalePort = cbbWGH_COM.Text;
                    registy.scale.scaleBaudrate = int.Parse(cbbWGH_BUADRATE.Text);
                    // SAVE Rfid
                    if (!cbbComRFID.Text.Contains("--"))
                        registy.function.RFID_COM = cbbComRFID.Text;
                    if (!cbbBardrateRFID.Text.Contains("--"))
                        registy.function.RFID_BAUDRATE = cbbBardrateRFID.Text;
                    // SAVE Barrier
                    if (!cbbPLC_COM.Text.Contains("--"))
                        registy.function.BARRIERCOM = cbbPLC_COM.Text;
                    if (!cbbPLC_BAUDRATE.Text.Contains("--"))
                        registy.function.BARRIERBaudrate = cbbPLC_BAUDRATE.Text;
                    registy.function.RFIDState = tgsRFID.Checked.ToString();
                    // SAVE CCTV
                    registy.function.CAMERAState = tgsCCTV.Checked.ToString();
                    // SAVE LPR
                    registy.function.LPRState = tgsLPR.Checked.ToString();
                    // SAVE TICKET
                    if (gbTickPass.Visible == false)
                    {
                        registy.tickets.phone = txtTickPhone.Text;
                        registy.tickets.tax = txtTicTax.Text;
                    }
                    #endregion
                    registy.Set();
                    MessageBox.Show("บันทึกรายการสำเร็จ โปรแกรมจะปิดกรุณาเปิดใหม่", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                msg.Show(this, "เกิดข้อผิดผลาด " + ex.Message, BunifuSnackbar.MessageTypes.Error, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                Log.Error("frmSetting bunifuButton1_Click " + ex.Message);
            }
        }

        private void tgsLPR_CheckedChanged(object sender, BunifuToggleSwitch.CheckedChangedEventArgs e)
        {
            if (tgsLPR.Checked == true)
            {
                // เช็คว่ามีฟังชั่นมีแต่แรกหรือไม่
                if (registy.function.LPRKey == "")
                {
                    // แต่หากไม่ได้มีการเปิดฟังชั่น line แต่แรกให้ถามผู้ใช้ก่อนว่าต้องการเปิดฟังชั่นหรือไม่
                    DialogResult dialogResult = MessageBox.Show("แพ็คเกจคุณไม่ได้เปิดใช้งานฟังชั่น กล้องอ่านทะเบียน คุณต้องการเปิดการใช้งานฟังชั่น กล้องอ่านทะเบียน หรือไม่", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (dialogResult == DialogResult.Yes)
                    {
                        frmProgramMessageAlert frmProgramMessageAlert = new frmProgramMessageAlert();
                        frmProgramMessageAlert.alertLevel = 2;
                        frmProgramMessageAlert.messageAlert = "รหัสสำหรับเปิดฟังชั่นกล้องอ่านทะเบียน";
                        frmProgramMessageAlert.extension = "LPR";
                        frmProgramMessageAlert.ShowDialog();
                        if (frmProgramMessageAlert.chckUnlock == false)
                        {
                            tgsLPR.Checked = false;
                        }
                        else
                        {
                            registy.Set();
                            tgsRFID.Checked = false;
                        }
                    }
                    else
                    {
                        tgsLPR.Checked = false;
                    }
                }
                else
                {

                    tgsRFID.Checked = false;
                }
            }
        }

        private void tgsCCTV_CheckedChanged(object sender, BunifuToggleSwitch.CheckedChangedEventArgs e)
        {
            if (tgsCCTV.Checked == true)
            {
                // เช็คว่ามีฟังชั่นมีแต่แรกหรือไม่
                if (registy.function.CAMERAKey == "")
                {
                    // แต่หากไม่ได้มีการเปิดฟังชั่น line แต่แรกให้ถามผู้ใช้ก่อนว่าต้องการเปิดฟังชั่นหรือไม่
                    DialogResult dialogResult = MessageBox.Show("แพ็คเกจคุณไม่ได้เปิดใช้งานฟังชั่น CCTV คุณต้องการเปิดการใช้งานฟังชั่น CCTV หรือไม่", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (dialogResult == DialogResult.Yes)
                    {
                        frmProgramMessageAlert frmProgramMessageAlert = new frmProgramMessageAlert();
                        frmProgramMessageAlert.alertLevel = 2;
                        frmProgramMessageAlert.messageAlert = "รหัสสำหรับเปิดฟังชั่นกล้อง CCTV";
                        frmProgramMessageAlert.extension = "CCTV";
                        frmProgramMessageAlert.ShowDialog();
                        if (frmProgramMessageAlert.chckUnlock == false)
                        {
                            tgsCCTV.Checked = false;
                        }
                        else
                        {
                            registy.Set();
                            tgsCCTV.Checked = true;
                        }
                    }
                    else
                    {
                        tgsCCTV.Checked = false;
                    }
                }
            }
        }

        private void tgsRFID_CheckedChanged(object sender, BunifuToggleSwitch.CheckedChangedEventArgs e)
        {
            if (tgsRFID.Checked == true)
            {
                // เช็คว่ามีฟังชั่นมีแต่แรกหรือไม่
                if (registy.function.RFIDKey == "")
                {
                    // แต่หากไม่ได้มีการเปิดฟังชั่น line แต่แรกให้ถามผู้ใช้ก่อนว่าต้องการเปิดฟังชั่นหรือไม่
                    DialogResult dialogResult = MessageBox.Show("แพ็คเกจคุณไม่ได้เปิดใช้งานฟังชั่น RFID คุณต้องการเปิดการใช้งานฟังชั่น RFID หรือไม่", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (dialogResult == DialogResult.Yes)
                    {
                        frmProgramMessageAlert frmProgramMessageAlert = new frmProgramMessageAlert();
                        frmProgramMessageAlert.alertLevel = 2;
                        frmProgramMessageAlert.messageAlert = "รหัสสำหรับเปิดฟังชั่น RFID";
                        frmProgramMessageAlert.extension = "RFID";
                        frmProgramMessageAlert.ShowDialog();
                        if (frmProgramMessageAlert.chckUnlock == false)
                        {
                            tgsRFID.Checked = false;
                        }
                        else
                        {
                            pnComRFID.Enabled = true;
                            tgsLPR.Checked = false;
                        }
                    }
                    else
                    {
                        tgsRFID.Checked = false;
                    }
                }
                else
                {
                    pnComRFID.Enabled = true;
                    tgsLPR.Checked = false;
                }
            }
        }
    }
}

