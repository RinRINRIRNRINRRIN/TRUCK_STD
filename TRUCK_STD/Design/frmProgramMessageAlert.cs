using Bunifu.UI.WinForms;
using Serilog;
using System;
using System.Windows.Forms;
using TRUCK_STD.Function;
using TRUCK_STD.Functions;
namespace TRUCK_STD.Design
{
    public partial class frmProgramMessageAlert : Form
    {
        public frmProgramMessageAlert()
        {
            InitializeComponent();
        }

        #region VARIABLE LOCAL
        public bool chckUnlock = false;  // ใช้สำหรับตรวจสอบว่าได้มีการปลดล็อคโปรแกรมไปหรือยัง
        public string messageAlert = ""; // สำหรับเก็บค่าข้อความที่ต้องการจะแสดงข้อความ alert
        public int alertLevel = 0;       // สำหรับเก็บระดับการแจ้งเตือน 0 = DATE,1 = UNLOCK PROGRAM,2 = EXTENSION
        public string callForm = "";     // สำหรับเก็บว่าโปรแกรมถูกเรียกจาก form ไหน จะได้ปิดฟอร์มถูก
        public string extension = "";    // เก็บค่าว่าต้องการจะใส่รหัสของ function อะไร API,LINE
        string passExpireDecry = "";     // ตัวแปรสำหรับเก็บรหัสทที่

        BunifuSnackbar msg = new BunifuSnackbar();
        #endregion

        #region FUNCTION LOCAL
        bool CHECK_PASSWORD_DATE()
        {
            // ดึงค่าวันที่ออกมาเปลี่ยนเทียบ
            passExpireDecry = Func_Main.CHECK_EXPRIE_DATE(txtPassUnlock.Text.Trim());
            Console.WriteLine(passExpireDecry);
            // ตรวจสอบความถูกต้องของรหัสที่ decrypt
            if (passExpireDecry == "")
            {
                msg.Show(this, "รหัสไม่ถูกต้อง", BunifuSnackbar.MessageTypes.Warning, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                Log.Warning("รหัสไม่ถูกต้อง : " + txtPassUnlock.Text);
                return false;
            }
            else if (passExpireDecry == "FOREVER")
            {
                Log.Warning("ปลดล็อคโปรแกรมสำเร็จ (ถาวร)");
                // กำหนดค่าให้กับ registry
                registy.system.dateExpire = "FOREVER"; // กำหนดให้โปรแกรม มีอายถาวร
                registy.system.programType = "TRUE"; // กำหนดให้โปรแกรมเป็นโปรแกรมใช้งานจริง
                registy.Set();
                return true;
            }
            else
            {
                // ตรวจสอบว่าวันที่ถูกต้องห้องไม่ โดยการเอาวันที่ปัจจุบันมาเปรียบเทียบมากกว่าน้อยกว่า กับวันที่ที่แปลงรหัสแล้ว
                DateTime dateConvert = DateTime.Parse(passExpireDecry);
                string d = DateTime.Now.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("th-TH"));
                DateTime dayCurrent = DateTime.Parse(d);

                if (dateConvert < dayCurrent)
                {
                    // ถ้าวันที่แปลงมาแล้ว น้อยกว่าวัน ปัจจุบันแปลว่ารหัสผ่านหมดอายุ
                    msg.Show(this, "รหัสไม่ถูกต้อง", BunifuSnackbar.MessageTypes.Warning, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                    Log.Warning("รหัสไม่ถูกต้อง : " + txtPassUnlock.Text);
                    return false;
                }
                else if (dateConvert == dayCurrent)
                {
                    // ถ้าวันที่ เท่ากับวันที่ปัจจุบัน ให้ถามว่ายืนยันหรือไม่
                    DialogResult dialogResult = MessageBox.Show("รหัสที่ได้ จะหมดอายุในวันนี้  ต้องการยืนยันหรือไม่", "Warnning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        registy.system.dateExpire = dateConvert.ToString("dd/MM/yyyy"); // กำหนดให้โปรแกรม มีอายถาวร
                        registy.system.programType = "TRUE"; // กำหนดให้โปรแกรมเป็นโปรแกรมใช้งานจริง
                        registy.Set();
                        return true;
                    }
                    else { return false; }
                }
                else if (dateConvert > dayCurrent)
                {
                    Log.Warning("ปลดล็อคโปรแกรมสำเร็จ (ชั่วคราว)");
                    // กำหนดค่าให้กับ registry
                    registy.system.dateExpire = dateConvert.ToString("dd/MM/yyyy"); // กำหนดให้โปรแกรม มีอายถาวร
                    registy.system.programType = "TRUE"; // กำหนดให้โปรแกรมเป็นโปรแกรมใช้งานจริง
                    registy.Set();
                    return true;
                }
            }
            return true;
        }

        bool CHECK_PASSWORD_UNLOCK()
        {
            string keyMD5 = Func_Main.GEN_PASSWORD_EXTENSION(registy.system.id, "LOCK");
            Console.WriteLine("Key unlock : " + keyMD5);

            if (keyMD5 == txtPassUnlock.Text)
            {
                Log.Warning("ปลดล็อคโปรแกรมสำเร็จ (Unlock)");
                registy.system.steate = "TRUE : ";
                registy.Set();
            }
            else
            {
                msg.Show(this, "รหัสไม่ถูกต้อง", BunifuSnackbar.MessageTypes.Warning, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                Log.Error("รหัสไม่ถูกต้อง : " + txtPassUnlock.Text);
                return false;
            }
            return true;
        }

        bool CHECK_PASSWORD_EXTENSION()
        {
            string keyMD5 = Func_Main.GEN_PASSWORD_EXTENSION(registy.system.id, extension);
            Console.WriteLine("Key extension " + extension + " : " + keyMD5);

            if (keyMD5 == txtPassUnlock.Text)
            {
                switch (extension)
                {
                    case "CAMERA":
                        registy.function.CAMERAState = "TRUE";
                        registy.function.CAMERAKey = txtPassUnlock.Text;
                        break;
                    case "LPR":
                        registy.function.LPRState = "TRUE";
                        registy.function.LPRKey = txtPassUnlock.Text;
                        break;
                    case "RFID":
                        registy.function.RFIDState = "TRUE";
                        registy.function.RFIDKey = txtPassUnlock.Text;
                        break;
                    case "API":
                        registy.function.APIState = "TRUE";
                        registy.function.APIKey = txtPassUnlock.Text;
                        registy.function.APIEndpoint = "";
                        break;
                    case "BARRIER":
                        registy.function.BARRIERState = "TRUE";
                        registy.function.BARRIERKey = txtPassUnlock.Text;
                        break;
                }
            }
            else
            {
                msg.Show(this, "รหัสไม่ถูกต้อง", BunifuSnackbar.MessageTypes.Warning, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                Log.Error("รหัสไม่ถูกต้อง : " + txtPassUnlock.Text);
                return false;
            }

            if (!registy.Set())
            {
                return false;
            }
            Log.Warning("ปลดล็อคโปรแกรมสำเร็จ (Unlock)");
            return true;
        }
        #endregion

        private void frmProgramExprie_Load(object sender, EventArgs e)
        {
            lbMessageAlert.Text = messageAlert;
            lbProgramNumber.Text = registy.system.id;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtPassUnlock.Text == "")
            {
                msg.Show(this, "กรุณาใส่รหัส ปลดล็อค โปรแกรม", BunifuSnackbar.MessageTypes.Warning, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                Log.Warning("frmProgramEXP กรุณาใส่รหัส ปลดล็อคโปรแกรม");
            }
            else
            {
                switch (alertLevel)
                {
                    case 0: // โปรแกรมหมดอายุใช้งาน demo , โปรแกรมหมดอายุใช้งานจากการต่อชั่วคราว
                        if (!CHECK_PASSWORD_DATE())
                        {
                            return;
                        }
                        break;
                    case 1: // alert ปลดล็อคโปรแกรมทั่วไป
                        if (!CHECK_PASSWORD_UNLOCK())
                        {
                            return;
                        }
                        break;
                    case 2: // โปรแกรมฟังชั่นการใช้งาน  API,CCTV,LPR
                        if (!CHECK_PASSWORD_EXTENSION())
                        {
                            return;
                        }
                        break;
                }

                // กำหนดค่าว่ามีการปลดล็อคแล้ว พร้อมเครีย์ค่า
                chckUnlock = true;
                txtPassUnlock.Clear();
                // ตรวจสอบว่าผู้ใช้เรียกฟอร์ม frmSetupEnvironment จากที่ไหน
                if (callForm == "frmSetting")
                {
                    MessageBox.Show("ปลดล็อคโปรแกรมสำเร็จ โปรแกรมจะปิดตัวกรุณา เปิดโปรแกรมอีกครั้ง", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                }
                else // เปิดฟอร์มนี้โดยการเช็คครั้งแรก
                {
                    this.Close();
                }
            }
        }
    }
}
