using Guna.UI2.WinForms;
using Serilog;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TRUCK_STD.Function;
using TRUCK_STD.Functions;
namespace TRUCK_STD.Design
{
    public partial class frmSettingEnvironment : Form
    {
        public frmSettingEnvironment()
        {
            InitializeComponent();
        }

        #region LOCAL_VARIABLE
        bool systemCamera = false;   // ไว้เก็บตัวแปร ว่าต้องการใช้งานฟังชั่น Api หรือไม่ , Default = false = not use;
        bool systemLine = false;     // ไว้เก็บตัวแปร ว่าต้องการใช้งานฟังชั่น Line หรือไม่ , Default = false = not use;
        bool systemLPR = false;      // ไว้เก็บตัวแปร ว่าต้องการใช้งานฟังชั่น LPR กล้องอ่านทะเบียน หรือไม่ , Default = false = not use;
        bool systemPrice = false;    //ไว้เก็บตัวแปร ว่าต้องการใช้งานฟังชั่น คำนวนราคา หรือไม่ , Default = false = not use;
        bool systemRFID = false;     // ไว้เก็บตัวแปร ว่าต้องการใช้งานฟังชั่น Api หรือไม่ , Default = false = not use;
        bool systemProgramType = false;  // สำหรับเก็บค่าว่าโปรแกรมเป็น demo or production โดยจะ default = false; ,false = demo , true = production
        bool systemAPI = false;

        string systemProgramExprieDate = "";   // ใช้สำหรับเก็บค่าตอนถอดรหัสวันหมดอายุโปรแกรม
        string dateExpType = ""; // สำหรับเก็บว่าโปรแกรมต่ออายแบบไหน
        bool isReadDrive = false;
        bool systemBARRIER = false;
        #endregion

        void ShowGbCenterScreen(Guna2GroupBox gb)
        {
            int x = (this.Width - gb.Width) / 2;
            int y = (this.Height - gb.Height) / 2;
            gb.Location = new Point(x, y);
            gb.Visible = true;
        }

        #region PROGRAM_PROCESS
        private void frmSettingEnvironment_Load(object sender, EventArgs e)
        {

            // เช็คว่ามีการเปิดโปรแกรมซ้ำหรือไม่
            if (!Func_Main.CHECK_PROGRAM())
            {
                MessageBox.Show("มีการเปิดโปรแกรมอยู่แล้วไม่สามารถเปิดซ้ำได้", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Log.Information("=================================================================================================== PROGRAM CLOSE");
                Application.Exit();
            }

            // ตรวจสอบรูปแบบวันที่ ต้องเป็น พ.ศ.เท่านั้น
            if (!Func_Main.CHECK_DATE_COMPUTER_YEAR())
            {
                MessageBox.Show("พบการตั้งค่ารูปแบบวันที่ไม่ถูกต้อง", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
            }
            else
            {
                #region สร้างไฟล์ Log
                // หากตรวจสอบแล้วเป็น พ.ศ.
                DateTime logDay = DateTime.Now;
                Log.Logger = new LoggerConfiguration()
                    .WriteTo.File(Application.StartupPath + "\\Logs\\log_" + logDay.Day + logDay.Month + logDay.Year + ".txt")
                    .CreateLogger();
                Log.Information("=================================================================================================== PROGRAM OPEN");
                #endregion

                #region สร้าง โฟลเดอร์เก็บไฟล์ Backup and log
                // ทำการสร้างโฟลเดอร์ logs and bakup
                string backupFolderPathc = Path.Combine(Application.StartupPath + "\\Backup");
                Directory.CreateDirectory(backupFolderPathc);
                string LogFulderPatch = Path.Combine(Application.StartupPath + "\\Logs");
                Directory.CreateDirectory(LogFulderPatch);
                #endregion

                #region จัดหน้าจอ
                // จัดเรื่องหน้าจอ โปรแกรม
                ShowGbCenterScreen(gbPasswordInstall);

                // Program size
                this.Height = 819;

                // Controls
                cbbIndicator.Items.Clear();
                cbbIndicator.Items.Add("--เครื่องชั่ง--");
                cbbIndicator.SelectedIndex = 0;


                tcMain.Visible = false;
                btnSave.Visible = false;
                #endregion

                #region ตรวจสอบคีย์บนเครื่องคอมพิวเตอร์
                // ตรวจสอบคีย์ที่อยู่บนเครื่องได้มีการสร้างไว้หรือไม่
                if (registy.CREATE_REGISTRY())
                {
                    // ตรวจสอบว่าโปรแกรมเป็นสถานีอะไร
                    switch (registy.system.stationType)
                    {
                        case "จุดลงทะเบียน":
                            // เช็คว่าจะไปที่จุดลงทะเบียนอะไร
                            if (registy.function.RFIDState == "TRUE")
                            {
                                frmRegisterRFID frmRFID = new frmRegisterRFID();
                                frmRFID.ShowDialog();
                                return;
                            }
                            if (registy.function.LPRState == "TRUE")
                            {
                                frmRegisterLPR frmRegisterLPR = new frmRegisterLPR();
                                frmRegisterLPR.ShowDialog();
                                return;
                            }

                            break;
                        case "สถานีชั่ง":
                            frmLogin frmLogin = new frmLogin();
                            frmLogin.ShowDialog();
                            break;
                    }
                    // ปิดฟอร์มนี้
                    this.Close();

                }
                else
                {
                    // หากการตั้งค่ายังไม่เสร็จสมบูร หรือสร้างคีย์แล้วแต่ยังไม่ได้กำหนดการตั้งค่า โปรแกรมจะเปิดให้ตั้งค่าต่อ
                    tcMain.Visible = false;
                    gbPasswordInstall.Visible = true;
                }
                #endregion
            }
        }
        private void txtPassExpireDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            Func_Main.CHECK_CHARATER_KEY_NUMBER_ONLY(txtPassExpireDate, e, this);
        }
        private void btnUnlock_Click(object sender, EventArgs e)
        {
            if (txtSMSSSO.Text == "")
            {
                Log.Warning("กรุณากรอกเลขที่ SM,SS,SO");
                msg.Show(this, "กรุณากรอกเลขที่ SM,SS,SO", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 3000, "OK", Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
            }
            else
            {
                // GEN รหัสมา เปรียบเทียบกับ รหัสที่ให้ทางช่างไป
                string HasPWD = Func_Main.GEN_PASSWORD_INSTALL(txtSMSSSO.Text);

                if (txtPassInstall.Text == HasPWD)
                {
                    gbPasswordInstall.Visible = false;
                    ShowGbCenterScreen(gbStation);
                    Log.Information("รหัสติดตั้งโปรแกรมถูกต้อง");
                }
                else
                {
                    Log.Warning("รหัสติดตั้งโปรแกรมไม่ถูกต้อง หรือ รหัสผ่านหมดอายุ");
                    msg.Show(this, "รหัสติดตั้งโปรแกรมไม่ถูกต้อง หรือ รหัสผ่านหมดอายุ", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 3000, "OK", Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                    txtPassInstall.Clear();
                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Alert ให้ผู้ใช้รู้ก่อนว่าจะไม่สามาถแก้ไขได้อีก
                if (MessageBox.Show("รายการดั้งต่อไปนี้จะไม่สามารถนำมาแก้ไขได้อีก\n" +
                    "ชื่อบริษัท \n" +
                    "เครื่องชั่ง \n" +
                    "รหัสในการติดต่อฐานข้อมูล \n" +
                    "รหัสเข้าโปรแกรม \n" +
                    "หากตรวจสอบการตั้งค่าเรียบร้อยให้ได้ (YES)", "Warnning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    // ตรวจสอบประเภทสถานที
                    string station = cbbStationType.Text;
                    switch (station)
                    {
                        case "จุดลงทะเบียน":
                            #region ตรวจสอบการเชื่อมต่อฐานข้อมูลCenter
                            // ตรวจสอบค่าว่างฐานข้อมูล
                            foreach (Guna2TextBox item in pnCenter.Controls.OfType<Guna2TextBox>())
                            {
                                if (item.Text == "")
                                {
                                    msg.Show(this, "กรุณากรอกข้อมูลให้ครบก่อนบันทึก", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 3000, "OK", Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                                    return;
                                }
                            }

                            //ให้ทำการทดสอบการเชื่อมต่อฐานข้อมูล แต่ถ้าเลือกฐานข้อมูลอื่น ไม่จำเป็นต้องทำการทดสอบการเชื่อมต่อ
                            //กำหนดค่า
                            DbCenter.DbConnect.HOST = txtdbCHost.Text;
                            DbCenter.DbConnect.PORT = int.Parse(txtdbCPort.Text);
                            DbCenter.DbConnect.USER = txtdbCUser.Text;
                            DbCenter.DbConnect.PASS = txtdbCPass.Text;
                            DbCenter.DbConnect.BASS = txtdbCBase.Text;
                            //ตรวจสอบรหัสฐานข้อมูลว่าถูกต้องหรือไม่                  
                            if (!DbCenter.DbConnect.ConnectBase())
                            {
                                msg.Show(this, "ไม่สามารถเชื่อมต่อฐานข้อมูลได้", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 3000, "OK", Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                                return;
                            }
                            #endregion
                            break;
                        case "สถานีชั่ง":
                            #region ตรวจสอบค่าว่างโปรแกรม
                            // ตรวจสอบค่าว่าง Tab1
                            foreach (Guna.UI2.WinForms.Guna2TextBox txt in tabPage1.Controls.OfType<Guna.UI2.WinForms.Guna2TextBox>())
                            {
                                if (txt.Text == "")
                                {
                                    MessageBox.Show("กรุณากรอกข้อมูล ตั๋วให้ครบก่อนทำการบันทึ");
                                    Log.Warning("พบค่าว่าง " + txt.Name);
                                    txt.BorderColor = Color.Red;
                                    return;
                                }
                                else
                                {
                                    txt.BorderColor = Color.Black;
                                }
                            }
                            #endregion

                            #region ตรวจสอบค่าว่าง TAB2
                            // ตรวจสอบ ค่าว่างของ systemProgramType 
                            if (!systemProgramType) // DEMO
                            {
                                // ตรวจสอบว่า ได้เลือกวันที่หรือไม่
                                if (label56.Text == "-")
                                {
                                    msg.Show(this, "กรุณาเลือกวันสิ้นสุดการใช้งานโปรแกรม", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 3000, "OK", Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                                    return;
                                }
                            }
                            else // Production
                            {
                                // ตรวจสอบค่าว่างของ ประเภทรหัสผ่าน โดยการเลือก radiobutton 
                                if (dateExpType == "")
                                {
                                    msg.Show(this, "กรุณาเลือกประเภทการต่ออายุโปรแกรม", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 3000, "OK", Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                                    return;
                                }
                                else
                                {
                                    if (dateExpType == "ต่ออายุชั่วคราว")
                                    {
                                        if (lbDateExpire.Text == "-")
                                        {
                                            msg.Show(this, "กรุณาเลือกวันสิ้นสุดการใช้งานโปรแกรม", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 3000, "OK", Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                                            return;
                                        }
                                    }

                                    if (dateExpType == "ต่ออายุถาวร")
                                    {
                                        if (txtPassExpireDate.Text == "")
                                        {
                                            msg.Show(this, "รหัสต่ออายุโปรแกรมถาวรไม่ถูกต้อง", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 3000, "OK", Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                                            return;
                                        }
                                    }
                                }
                            }




                            // ตรวจสอบว่าได้เลือก เครื่องชั่งหรือไม่
                            if (cbbIndicator.Text == "--เครื่องชั่ง--")
                            {
                                msg.Show(this, "กรุณาเลือกเครื่องชั่ง", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 3000, "OK", Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                                return;
                            }
                            // ตรวจสอบรหัสฐานข้อมูลว่างหรือไม่
                            if (txtHost.Text == "")
                            {
                                msg.Show(this, "กรุณาเลือกกรอกรหัสติดต่อฐานข้อมูล", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 3000, "OK", Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                                return;
                            }
                            #endregion

                            #region ตรวจสอบการเชื่อมต่อฐานข้อมูล                   
                            //ให้ทำการทดสอบการเชื่อมต่อฐานข้อมูล แต่ถ้าเลือกฐานข้อมูลอื่น ไม่จำเป็นต้องทำการทดสอบการเชื่อมต่อ
                            //กำหนดค่า
                            DbBase.DbConnect.HOST = txtHost.Text;
                            DbBase.DbConnect.PORT = int.Parse(txtPort.Text);
                            DbBase.DbConnect.USER = txtUser.Text;
                            DbBase.DbConnect.PASS = txtPass.Text;
                            DbBase.DbConnect.BASS = txtDatabase.Text;

                            //ตรวจสอบรหัสฐานข้อมูลว่าถูกต้องหรือไม่                  
                            if (!DbBase.DbConnect.ConnectBase())
                            {
                                msg.Show(this, "ไม่สามารถเชื่อมต่อฐานข้อมูลได้", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 3000, "OK", Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                                return;
                            }

                            #endregion

                            #region ตรวจสอบการเชื่อมต่อฐานข้อมูลCenter
                            // ตรวจสอบว่ามีการใช้ ฐานข้อมูล center หรือไม่
                            if (cbDbCenter.Checked == true)
                            {
                                //ให้ทำการทดสอบการเชื่อมต่อฐานข้อมูล แต่ถ้าเลือกฐานข้อมูลอื่น ไม่จำเป็นต้องทำการทดสอบการเชื่อมต่อ
                                //กำหนดค่า
                                DbCenter.DbConnect.HOST = txtdbCHost.Text;
                                DbCenter.DbConnect.PORT = int.Parse(txtdbCPort.Text);
                                DbCenter.DbConnect.USER = txtdbCUser.Text;
                                DbCenter.DbConnect.PASS = txtdbCPass.Text;
                                DbCenter.DbConnect.BASS = txtdbCBase.Text;
                                //ตรวจสอบรหัสฐานข้อมูลว่าถูกต้องหรือไม่                  
                                if (!DbCenter.DbConnect.ConnectBase())
                                {
                                    msg.Show(this, "ไม่สามารถเชื่อมต่อฐานข้อมูลได้", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 3000, "OK", Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                                    return;
                                }
                            }
                            #endregion

                            #region ตรวจสอบวันหมดอายุโปรแกรม
                            // ตรวจสอบก่อนว่า ลูกค้าใช้โปรแกรมประเภทอะไร demo or production  
                            if (systemProgramType) // False = demo , True = production
                            {
                                // กรณีใช้ production
                                // ตรวจสอบว่าโปรแกรมเป็นการ ต่ออายุชั่วคราวหรือถาวร
                                switch (dateExpType)
                                {
                                    case "ต่ออายุชั่วคราว":
                                        if (lbDateExpire.Text == "")
                                        {
                                            msg.Show(this, "กรุณาเลือกวันที่หมดอายุ", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 3000, "OK", Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                                            return;
                                        }
                                        else
                                        {
                                            string[] a = lbDateExpire.Text.Split(':');
                                            systemProgramExprieDate = a[1].Trim();
                                        }
                                        break;
                                    case "ต่ออายุถาวร":
                                        // ตรวจสอบว่าได้คีย์รหัสมาหรือไม่
                                        if (txtHost.Text == "")
                                        {
                                            msg.Show(this, "กรุณาใส่รหัสต่ออายุโปรแกรม", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 3000, "OK", Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                                            return;
                                        }
                                        systemProgramExprieDate = Func_Main.CHECK_EXPRIE_DATE(txtPassExpireDate.Text.Trim());
                                        //  ทำการเช็ควันหมดหมดอายุโปรแกรม ตรวจสอบว่า คือมาว่าเป็นอะไร
                                        if (systemProgramExprieDate == "")
                                        {
                                            msg.Show(this, "รหัสต่ออายุโปรแกรมไม่ถูกต้อง", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 3000, "OK", Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                                            return;
                                        }
                                        break;
                                    case "":
                                        msg.Show(this, "ยังไม่ได้กำหนดวันหมดอายุโปรแกรม", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 3000, "OK", Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                                        return;
                                        //break;
                                }
                            }
                            else
                            {
                                // กรณีใช้ demo ให้ดึงค่าวันเดือนปีที่ผู้ใช้เลือก มาเก็บไว้ที่ตัวแปร
                                systemProgramExprieDate = cldDemo.SelectionStart.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("th-TH"));
                            }
                            #endregion

                            #region ตรวจสอบเครื่องชั่ง
                            if (txtCapacity.Text == "")
                            {
                                msg.Show(this, "กรุณาใส่พิกัดสูงสุดของเครื่องชั่ง", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 3000, "OK", Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                                return;
                            }

                            if (cbbIndicator.Text.Contains("--"))
                            {
                                msg.Show(this, "กรุณาเลือกเครื่องชั่งก่อนการบันทึก", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 3000, "OK", Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                                return;
                            }
                            #endregion

                            #region ตรวจสอบ key
                            if (txtKeyId.Text == "" || txtPublicKey.Text == "")
                            {
                                msg.Show(this, "กรุณาใส่ Key ก่อนการบันทึก", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 3000, "OK", Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                                return;
                            }
                            #endregion
                            break;
                    }

                    #region บันทึกการตั้งค่า
                    // Save funcstion
                    registy.function.APIKey = "";
                    registy.function.APIEndpoint = "";
                    registy.function.RFIDKey = "";
                    registy.function.LPRKey = "";
                    registy.function.CAMERAKey = "";
                    registy.function.BARRIERKey = "";
                    //------------------------------------------------------------------
                    registy.function.CAMERAState = systemCamera.ToString().ToUpper();
                    registy.function.BARRIERState = systemBARRIER.ToString().ToUpper();
                    registy.function.APIState = systemAPI.ToString().ToUpper();

                    if (station == "จุดลงทะเบียน")
                    {
                        registy.function.LPRState = "TRUE";
                        registy.function.RFIDState = "TRUE";
                    }
                    else
                    {
                        registy.function.LPRState = systemLPR.ToString().ToUpper();
                        registy.function.RFIDState = systemRFID.ToString().ToUpper();
                    }

                    // Save system
                    registy.system.date = DateTime.Now.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("th-TH"));
                    registy.system.dateExpire = systemProgramExprieDate;
                    registy.system.id = txtSMSSSO.Text;
                    registy.system.steate = "TRUE :";
                    registy.system.programType = systemProgramType.ToString().ToUpper();
                    registy.system.bussinessType = cbbBusinessType.Text;
                    registy.system.stationName = lblStationName.Text;
                    registy.system.stationType = lblStationType.Text;
                    registy.system.keyID = txtKeyId.Text;
                    registy.system.publicKey = txtPublicKey.Text;

                    // Save tickets
                    registy.tickets.address = txtAddress.Text;
                    registy.tickets.company = txtCompanyName.Text;
                    registy.tickets.phone = txtPhone.Text;
                    registy.tickets.state = "FALSE"; // กำหนดเป็น false = หมายถึงยังไม่มีการแก้ไข , 
                    registy.tickets.tax = txtTax.Text;

                    //Save dataBase
                    if (station == "จุดลงทะเบียน")
                    {
                        registy.dbCenter.host = txtdbCHost.Text;
                        registy.dbCenter.Port = int.Parse(txtdbCPort.Text);
                        registy.dbCenter.User = txtdbCUser.Text;
                        registy.dbCenter.Pass = txtdbCPass.Text;
                        registy.dbCenter.Base = txtdbCBase.Text;
                        registy.dbCenter.db = "TRUE";

                        registy.db.host = "";
                        registy.db.Port = 0;
                        registy.db.User = "";
                        registy.db.Pass = "";
                        registy.db.Base = "";
                    }
                    else
                    {
                        // กำหนดค่า localhost
                        registy.db.host = txtHost.Text;
                        registy.db.Port = int.Parse(txtPort.Text);
                        registy.db.User = txtUser.Text;
                        registy.db.Pass = txtPass.Text;
                        registy.db.Base = txtDatabase.Text;
                        // กำหนดค่า CenterHost

                        if (cbDbCenter.Checked == true)
                        {
                            registy.dbCenter.host = txtdbCHost.Text;
                            registy.dbCenter.Port = int.Parse(txtdbCPort.Text);
                            registy.dbCenter.User = txtdbCUser.Text;
                            registy.dbCenter.Pass = txtdbCPass.Text;
                            registy.dbCenter.Base = txtdbCBase.Text;
                            registy.dbCenter.db = "TRUE";
                        }
                        else
                        {
                            registy.dbCenter.host = "";
                            registy.dbCenter.Port = 0;
                            registy.dbCenter.User = "";
                            registy.dbCenter.Pass = "";
                            registy.dbCenter.Base = "";
                            registy.dbCenter.db = "FALSE";
                        }
                    }
                    // Set RFID Config
                    registy.function.RFID_COM = "";
                    registy.function.RFID_BAUDRATE = "";
                    // Set Barrier Config
                    registy.function.BARRIERCOM = "";
                    registy.function.BARRIERBaudrate = "";


                    // Set scale 
                    registy.scale.scaleName = cbbIndicator.Text;
                    registy.scale.scalePort = "";
                    registy.scale.scaleBaudrate = 9600;
                    registy.scale.scalecapacity = int.Parse(txtCapacity.Text);



                    // ทำการ SET ค่าให้กับ registry 
                    if (registy.Set())
                    {
                        MessageBox.Show("บันทึการตั้งค่าสำเร็จ กรุณาปิดโปรแกรมแล้วเปิดใหม่", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Application.ExitThread();
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดผลาดในการบันทึกข้อมูล", "frmSettingEnvironment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Log.Error("frmSettingEnvironment btnSave_Click เกิดข้อผิดผลาดในการบันทึกข้อมูล " + ex.Message);
            }
        }
        #endregion

        #region Tab1
        private void txtCompanyName_TextChanged(object sender, EventArgs e)
        {
            label5.Text = txtCompanyName.Text;
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            label6.Text = txtAddress.Text;
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            label7.Text = txtPhone.Text;
        }
        #endregion
        #region Tab2
        private void tgsProgramType_CheckedChanged(object sender, EventArgs e)
        {
            if (tgsProgramType.Checked == true)
            {
                label54.Text = "ใช้ งานจริง";
                label54.ForeColor = Color.Green;
                panel8.Enabled = true;
                cldDemo.Enabled = false;
                systemProgramType = true;
            }
            else if (tgsProgramType.Checked == false)
            {
                label54.Text = "ใช้ ทดสอบ";
                label54.ForeColor = Color.Red;
                panel8.Enabled = false;
                cldDemo.Enabled = true;
                systemProgramType = false;
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            MonthCalendar cld = sender as MonthCalendar;

            DateTime dateTime = e.Start;
            Console.WriteLine(dateTime.ToShortDateString());
            string c = DateTime.Now.ToString("dd/MM/yyyy");
            DateTime dayCurrent = DateTime.Parse(c);

            switch (cld.Name)
            {
                case "cldProduction":

                    if (dateTime < dayCurrent)
                    {
                        msg.Show(this, "ห้ามเลือกวันที่ย้อนหลัง", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 3000, "OK", Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                        cldProduction.SelectionStart = DateTime.Today;
                    }
                    else
                    {
                        lbDateExpire.Text = "กำหนดหมดอายุวันที่ :" + cldProduction.SelectionStart.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("th-TH")); ;
                    }

                    break;
                case "cldDemo":
                    if (dateTime < dayCurrent)
                    {
                        msg.Show(this, "ห้ามเลือกวันที่ย้อนหลัง", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 3000, "OK", Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                        cldDemo.SelectionStart = DateTime.Today;
                    }
                    else
                    {
                        label56.Text = "กำหนดหมดอายุวันที่ :" + cldDemo.SelectionStart.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("th-TH")); ;
                    }
                    break;
                default:
                    break;
            }
        }

        private void rdbB_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdb = sender as RadioButton;

            switch (rdb.Name)
            {
                case "rdbA": // ต่ออายุชั่วคราว 
                    if (rdb.Checked == true)
                    {
                        dateExpType = "ต่ออายุชั่วคราว";
                        panel7.Enabled = true;
                        panel6.Enabled = false;
                    }
                    break;
                case "rdbB": // ต่ออายุถาวร
                    if (rdb.Checked == true)
                    {
                        dateExpType = "ต่ออายุถาวร";

                        panel7.Enabled = false;
                        panel6.Enabled = true;
                    }
                    break;
            }
            Console.WriteLine(dateExpType);
        }

        private void cbbIndicator_DropDown_1(object sender, EventArgs e)
        {
            cbbIndicator.Items.Clear();
            cbbIndicator.Items.Add("RickLake IQ-800");
            cbbIndicator.Items.Add("RickLake IQ-355");
            cbbIndicator.Items.Add("RickLake 480");
            cbbIndicator.Items.Add("RickLake 680");
            cbbIndicator.Items.Add("RickLake 720i");
            cbbIndicator.Items.Add("Dini Argeo 3590ETD");
            cbbIndicator.Items.Add("Dini Argeo 3590ET8D");
            cbbIndicator.Items.Add("Dini Argeo DFWLK");
            cbbIndicator.Items.Add("Dini Argeo DFWL");
            cbbIndicator.Items.Add("Mettler Toledo 8142");
            cbbIndicator.Items.Add("Mettler Toledo Kingbird");
            cbbIndicator.Items.Add("Mettler Toledo IND-560");
            cbbIndicator.Items.Add("Commander HP01");
            cbbIndicator.Items.Add("Commander HP05");
            cbbIndicator.Items.Add("Commander HP06");
            cbbIndicator.Items.Add("Commander HP09");
            cbbIndicator.Items.Add("Linear scale PM2");
            cbbIndicator.Items.Add("Linear scale PM5");
            cbbIndicator.Items.Add("Linear scale PM7");
            cbbIndicator.Items.Add("Cardinal 205");
            cbbIndicator.Items.Add("Cardinal 210");
            cbbIndicator.Items.Add("Cardinal 225");
        }

        private void cbbIndicator_DropDownClosed(object sender, EventArgs e)
        {
            if (cbbIndicator.Text == "")
            {
                cbbIndicator.Items.Clear();
                cbbIndicator.Items.Add("--เครื่องชั่ง--");
                cbbIndicator.SelectedIndex = 0;
            }
        }
        #endregion

        #region Tab3
        private void tgs_Click(object sender, EventArgs e)
        {
            // รับ sender ของ togleswitch 
            Bunifu.UI.WinForms.BunifuToggleSwitch tgs = sender as Bunifu.UI.WinForms.BunifuToggleSwitch;
            //Guna.UI2.WinForms.Guna2ToggleSwitch tgs = sender as Guna.UI2.WinForms.Guna2ToggleSwitch;
            frmProgramMessageAlert frm = new frmProgramMessageAlert();
            frm.alertLevel = 2;
            // ตรวจสอบว่าผู้ใช้ เลือก tgs ตัวไหนเข้ามา
            switch (tgs.Name)
            {
                case "tgsCCTV":
                    if (tgs.Checked == true)
                    {
                        frm.messageAlert = "รหัสปลดล็อคฟังชั่น กล้องวงจรปิด";
                        frm.extension = "CAMERA";
                        frm.ShowDialog();
                        if (!frm.chckUnlock)
                        {
                            tgs.Checked = false;
                        }
                        else
                        {
                            systemCamera = true;
                        }
                    }
                    else if (tgs.Checked == false)
                    {
                        systemCamera = false;
                    }
                    break;
                case "tgsLPR":
                    if (tgs.Checked == true)
                    {
                        frm.messageAlert = "รหัสปลดล็อคฟังชั่น กล้องอ่านทะเบียน LPR";
                        frm.extension = "LPR";
                        frm.ShowDialog();
                        if (!frm.chckUnlock)
                        {
                            tgs.Checked = false;
                        }
                        else
                        {
                            systemLPR = true;
                        }
                    }
                    else if (tgs.Checked == false)
                    {
                        systemLPR = false;
                    }
                    break;
                case "tgsAPI":
                    if (tgs.Checked == true)
                    {
                        frm.messageAlert = "รหัสปลดล็อคฟังชั่น API";
                        frm.extension = "API";
                        frm.ShowDialog();
                        if (!frm.chckUnlock)
                        {
                            tgs.Checked = false;
                        }
                        else
                        {

                        }
                    }
                    else
                    {

                    }
                    break;
                case "tgsRFID":
                    if (tgs.Checked == true)
                    {
                        frm.messageAlert = "รหัสปลดล็อคฟังชั่น RFID";
                        frm.extension = "RFID";
                        frm.ShowDialog();
                        if (!frm.chckUnlock)
                        {
                            tgs.Checked = false;
                        }
                        else
                        {
                            systemRFID = true;
                        }
                    }
                    else if (tgs.Checked == false)
                    {
                        systemRFID = false;
                    }
                    break;
                case "tgsBARRIER":
                    if (tgs.Checked == true)
                    {
                        frm.messageAlert = "รหัสปลดล็อคฟังชั่น Barrier";
                        frm.extension = "BARRIER";
                        frm.ShowDialog();
                        if (!frm.chckUnlock)
                        {
                            tgs.Checked = false;
                        }
                        else
                        {
                            systemBARRIER = true;
                        }
                    }
                    else if (tgs.Checked == false)
                    {
                        systemBARRIER = false;
                    }
                    break;
            }
            msg.Show(this, "เปิดฟังชั่นสำเร็จ", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, "OK", Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);

            Console.WriteLine($"CAMERA :{systemCamera}\nLINE : {systemLine}\nPRICE : {systemPrice}");
        }
        #endregion

        private async void bunifuButton1_Click(object sender, EventArgs e)
        {
            gbReadKey.Visible = true;
            btnRead.Enabled = false;
            btnUnlock.Enabled = false;
            isReadDrive = true;
            await Task.Run(ReadDrive);
        }

        // อ่านคีย์จาก Flash drive เพื่อทำการกำหนดค่า
        async Task ReadDrive()
        {
            bool isFound = false;
            // Read drive all computer
            while (isReadDrive)
            {
                DriveInfo[] driveInfos = drives.Get();
                // วนลูปแสดงข้อมูลของไดรฟ์แต่ละตัว
                foreach (DriveInfo drive in driveInfos)
                {
                    Console.WriteLine("Drive: {0}", drive.Name);
                    Console.WriteLine("Volume label: {0}", drive.VolumeLabel);
                    if (drive.VolumeLabel == "TSC_KEYLOCK")
                    {
                        isFound = true;
                        Console.WriteLine("======================= Found device");
                        break;
                    }
                }

                // check found it
                if (isFound)
                {
                    break;
                }
                await Task.Delay(1000);
            }

            //



        }

        private async void btnCancal_Click(object sender, EventArgs e)
        {
            gbReadKey.Visible = false;
            btnRead.Enabled = true;
            btnUnlock.Enabled = true;
            isReadDrive = false;
            await Task.Delay(2000);
        }

        private void bunifuButton1_Click_1(object sender, EventArgs e)
        {
            if (txtStationName.Text == "")
            {
                msg.Show(this, "กรุณาตั้งชื่อสถานีก่อนไปส่วนถัดไป", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 3000, "OK", Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                return;
            }

            // Check station
            string stationType = cbbStationType.Text;
            switch (stationType)
            {
                case "จุดลงทะเบียน":
                    pnLocal.Enabled = false;
                    cbDbCenter.Checked = true;
                    pnTicket.Enabled = false;
                    gbDate.Enabled = false;
                    gbIndicator.Enabled = false;
                    gbFunction.Enabled = false;
                    break;
                case "สถานีชั่ง":
                    pnLocal.Enabled = true;
                    cbDbCenter.Checked = false;
                    pnTicket.Enabled = true;
                    gbDate.Enabled = true;
                    gbIndicator.Enabled = true;
                    gbFunction.Enabled = true;
                    break;

            }
            pnStation.Visible = true;
            lblStationType.Text = cbbStationType.Text;
            lblStationName.Text = txtStationName.Text;
            gbStation.Visible = false;
            tcMain.Visible = true;
            btnSave.Visible = true;
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            pnStation.Visible = false;
            gbStation.Visible = true;
            tcMain.Visible = false;
            btnSave.Visible = false;
        }

        private void cbDbCenter_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDbCenter.Checked == true)
            {
                pnCenter.Enabled = true;
            }
            else
            {
                pnCenter.Enabled = false;
            }

        }

        private void cbbBusinessType_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbbBusinessType.Text != "")
            {
                switch (cbbBusinessType.Text)
                {
                    case "ทั่วไป":
                        //tgsPrice.Checked = false;
                        break;
                    case "เกษตร":
                        //tgsPrice.Checked = true;
                        break;
                }
            }
        }

        private void txtTax_TextChanged(object sender, EventArgs e)
        {
            label40.Text = txtTax.Text;
        }
    }
}
