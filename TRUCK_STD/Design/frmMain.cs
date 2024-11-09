using Bunifu.UI.WinForms;
using Microsoft.Win32;
using Serilog;
using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TRUCK_STD.DbBase;
using TRUCK_STD.Function;
using TRUCK_STD.Functions;
using TRUCK_STD.Models;
namespace TRUCK_STD.Design
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        #region variable local
        BunifuSnackbar msg = new BunifuSnackbar();
        #endregion

        #region function local
        /// <summary>
        /// สำหรับตรวจสอบสิทธิ์การใช้งานโปรแกรม
        /// </summary>
        void CHECK_PRIVIRAGE()
        {
            BeginInvoke(new MethodInvoker(async delegate ()
            {

                // หากมีการใช้งานฟังชั่่ง login ให้ตรวจสอบว่า รหัสที่คีย์เข้ามาใช่ sa หรือไม่
                if (accountModels.user == "sa")
                {
                    ////// หากเป็น sa สามารถใช้งานได้หมดทุกเมนู                                           
                    foreach (Bunifu.UI.WinForms.BunifuButton.BunifuButton btn in panel1.Controls.OfType<Bunifu.UI.WinForms.BunifuButton.BunifuButton>())
                    {
                        // สั่งเปิดทุกเมนู
                        btn.Enabled = true;
                        btn.Visible = true;
                    }

                    // ปิดปุ่มที่เป็นฟังชั่นก่อน
                    //btnRFID.Enabled = false;
                    //btnLPR.Enabled = false;
                    //btnCCTV.Enabled = false;
                }
                else
                {
                    // สิ่งปิด btn ทั้งหมดก่อนน
                    foreach (Bunifu.UI.WinForms.BunifuButton.BunifuButton btn in panel1.Controls.OfType<Bunifu.UI.WinForms.BunifuButton.BunifuButton>())
                    {
                        btn.Visible = false;
                    }

                    // นำ username ไปเช็คสิทธิ์
                    privilageModels privilageModels = new privilageModels
                    {
                        user_id = accountModels.id
                    };
                    if (privilage.Select(privilageModels))
                    {
                        foreach (DataRow rw in privilage.tb.Rows)
                        {
                            foreach (Bunifu.UI.WinForms.BunifuButton.BunifuButton btn in panel1.Controls.OfType<Bunifu.UI.WinForms.BunifuButton.BunifuButton>())
                            {
                                if (btn.Text == rw["menus"].ToString())
                                {
                                    btn.Enabled = true;
                                    guna2Transition1.ShowSync(btn);
                                }
                            }
                            await Task.Delay(100);
                        }
                        // สั่งแสดงปุ่มที่ disable ที่เหลือ
                        foreach (Bunifu.UI.WinForms.BunifuButton.BunifuButton btn in panel1.Controls.OfType<Bunifu.UI.WinForms.BunifuButton.BunifuButton>())
                        {
                            if (btn.Enabled == false)
                            {
                                btn.Enabled = false;
                                guna2Transition1.ShowSync(btn);
                            }
                        }
                    }
                }

                // เช็ค Funstion
                //CHECK_FUNCTION();

                // สั่งเปิดเป็น Suport info
                btnSupport.Enabled = true;
                guna2Transition1.ShowSync(btnSupport);
                // สั่งเปิด เปลี่ยข้อมูลผู้ใช้
                btnChangeUsername.Enabled = true;
                guna2Transition1.ShowSync(btnChangeUsername);

                btnAbout.Enabled = true;
                guna2Transition1.ShowSync(btnAbout);

                label4.Text = registy.system.id;
            }));
        }

        //void CHECK_FUNCTION()
        //{
        //    // เช็คว่าระบบมีฟังชั่นกล้องหรือไม่
        //    if (registy.function.CAMERA == "TRUE")
        //        foreach (var item in menuModels.menuList)
        //        {
        //            if (btnCCTV.Text == item.Key)
        //            {
        //                btnCCTV.Enabled = true;
        //                break;
        //            }
        //        }

        //    // เช็คว่าระบบมีฟังชั่นLPR
        //    if (registy.function.LPR == "TRUE")
        //        foreach (var item in menuModels.menuList)
        //        {
        //            if (btnLPR.Text == item.Key)
        //            {
        //                btnLPR.Enabled = true;
        //                break;
        //            }
        //        }

        //    // เช็คว่าระบบมีฟังชั่นRFID
        //    if (registy.function.RFID == "TRUE")
        //        foreach (var item in menuModels.menuList)
        //        {
        //            if (btnRFID.Text == item.Key)
        //            {
        //                btnRFID.Enabled = true;
        //                break;
        //            }
        //        }
        //}
        #endregion

        private void frmMain_Load(object sender, EventArgs e)
        {
            lbUsername.Text = accountModels.names;
            // ตรวจสอบสิทธิ์การใช้งานฟังชั่น Login ของโปรแกรม
            Thread td2 = new Thread(CHECK_PRIVIRAGE);
            td2.Start();


            // เรียกใช้ TIMER เช็ควันหมดอายุ
            tmDateEXP.Start();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Log.Information("EXIT PROGRAM");
            Application.ExitThread();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {

            Log.Information("CLICK EMPLOYEE PAGE");
            frmEmployee frm = new frmEmployee();
            frm.ShowDialog();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            Log.Information("CLICK CUSTOMER PAGE");
            frmCustomer frm = new frmCustomer();
            frm.ShowDialog();
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            Log.Information("CLICK SETTING PAGE");
            frmSetting frm = new frmSetting();
            frm.ShowDialog();
        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            // ตรวจสอบฟังชั่นโปรแกรม
            if (registy.function.RFIDState == "TRUE")
            {

                return;
            }
            else if (registy.function.LPRState == "TRUE")
            {
                frmNewWeight frmNewWeight = new frmNewWeight();
                frmNewWeight.ShowDialog();
                return;
            }
            else
            {
                frmWeightingNoPrice frmWeightingNoPrice = new frmWeightingNoPrice();
                frmWeightingNoPrice.ShowDialog();
            }
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            Log.Information("CLICK HISTORY PAGE");
            // ตรวจสอบว่าผู้ใช้ login เข้าด้วยสิทธิ sa หรือไม่

            frmHistory frm = new frmHistory();
            frm.ShowDialog();

        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            Log.Information("CLICK ACCOUNT PAGE");
            frmAccount frmAccount = new frmAccount();
            frmAccount.ShowDialog();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            Log.Information("CLICK PRODUCT PAGE");
            frmProduct frmProduct = new frmProduct();
            frmProduct.ShowDialog();
        }

        private void btnVersion_Click(object sender, EventArgs e)
        {
            Log.Information("CLICK VERSIONINFO PAGE");
            frmVersionInfo frmVersionInfo = new frmVersionInfo();
            frmVersionInfo.ShowDialog();
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F9)
            {
                frmProgramMessageAlert exp = new frmProgramMessageAlert();
                exp.ShowDialog();
            }
        }

        private void btnSupport_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Application.StartupPath + "\\AnyDesk.exe");
                Thread.Sleep(1000);
                frmSupport frmSupport = new frmSupport();
                frmSupport.ShowDialog();
            }
            catch (Exception ex)
            {
                Console.WriteLine("frmMain btnsupport_Click " + ex.Message);
            }
        }

        private void tmDateEXP_Tick(object sender, EventArgs e)
        {
            string PatchRegistry = "SOFTWARE\\28e098175bb05703eb34c5adbb23437"; // Patch ที่ได้ต้องจะเก็บคีย์
            RegistryKey Patch = Registry.ClassesRoot.OpenSubKey(PatchRegistry);

            string cc = Convert.ToString(Patch.GetValue("key_programExpire"));

            // ตรวจสอบวันหมดอายุโปรแกรมเฉพาะ DEMO เท่านั้น 
            if (registy.system.programType == "FALSE")
            {
                // ดึงข้อมูลวันที่
                DateTime dateExp = DateTime.Parse(cc);
                string d = DateTime.Now.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("th-TH"));
                DateTime dateCurrent = DateTime.Parse(d);

                TimeSpan timeSpan = dateExp - dateCurrent;
                lbProgramType.Text = "โปรแกรมทดสอบ จะสามารถใช้ได้อีก " + timeSpan.Days + " วัน";
                Log.Warning($"ระยะเวลาระหว่าง {dateExp.ToString("dd/MM/yyyy")} ถึง {dateCurrent.ToString("dd/MM/yyyy")} คือ {timeSpan.Days} วัน");


                if (lbProgramType.Visible == true)
                {
                    lbProgramType.Visible = false;
                }
                else if (lbProgramType.Visible == false)
                {
                    lbProgramType.Visible = true;
                }

                if (!Func_Main.CHECK_DATE_PROGRAM_AND_DATE_COMPUTER())
                {
                    tmDateEXP.Stop();
                    registy.system.programType = "FALSE : ตรวจพบการย้อนกลับของวันที่คอมพิวเตอร์";
                    registy.Set();
                    Log.Error("ตรวจพบการย้อนกลับของวันที่คอมพิวเตอร์");
                    MessageBox.Show("ตรวจพบการย้อนกลับของวันที่คอมพิวเตอร์", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }

                if (timeSpan.Days == 0 || timeSpan.Days < -0)
                {
                    tmDateEXP.Stop();
                    MessageBox.Show("โปรแกรมหมดอายุการใช้งาน กรุณาติดต่อ บ.ไทยเครื่องชั่ง จำกัด");
                    Log.Information("โปรแกรม หมดอายุการใช้งาน ประเภทโปรแกรม " + registy.system.programType);
                    Application.Exit();
                }
            }
            else
            {

                // หากเป็น การใช้งานจริงไม่ใช้ DEMO ให้หยุด Timeer
                tmDateEXP.Stop();
            }
        }

        private void btnChangeUsername_Click(object sender, EventArgs e)
        {
            if (Func_Privilage.emp_usernmae == "sa")
            {
                msg.Show(this, "ไม่สามารถเปลี่นแปลงสิทธิ์ sa ได้", BunifuSnackbar.MessageTypes.Warning, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
            }
            else
            {
                frmChangeUser frmChangeUser = new frmChangeUser();
                frmChangeUser.ShowDialog();
            }
        }

        private void btnHireWeitgh_Click(object sender, EventArgs e)
        {
            frmWeightHire frmHireWeight = new frmWeightHire();
            frmHireWeight.ShowDialog();
        }

        private void btnCCTV_Click(object sender, EventArgs e)
        {
            // Check functions
            if (registy.function.CAMERAKey == "")
            {
                // แต่หากไม่ได้มีการเปิดฟังชั่น line แต่แรกให้ถามผู้ใช้ก่อนว่าต้องการเปิดฟังชั่นหรือไม่
                DialogResult dialogResult = MessageBox.Show("แพ็คเกจคุณไม่ได้เปิดใช้งานฟังชั่น CAMERA (กล้อง) คุณต้องการเปิดการใช้งานฟังชั่นไลน์ CAMERA (กล้อง) หรือไม่", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dialogResult == DialogResult.Yes)
                {
                    frmProgramMessageAlert frmProgramMessageAlert = new frmProgramMessageAlert();
                    frmProgramMessageAlert.alertLevel = 2;
                    frmProgramMessageAlert.extension = "CAMERA";
                    frmProgramMessageAlert.messageAlert = "รหัสสำหรับเปิดฟังชั่น กล้อง";
                    frmProgramMessageAlert.ShowDialog();
                    if (frmProgramMessageAlert.chckUnlock == true)
                    {
                        Application.Exit();
                    }
                }
            }
            else
            {
                frmCCTV frmCCTV = new frmCCTV();
                frmCCTV.ShowDialog();
            }

        }

        private void btnLPR_Click(object sender, EventArgs e)
        {
            // Check functions
            if (registy.function.LPRKey == "")
            {
                // แต่หากไม่ได้มีการเปิดฟังชั่น line แต่แรกให้ถามผู้ใช้ก่อนว่าต้องการเปิดฟังชั่นหรือไม่
                DialogResult dialogResult = MessageBox.Show("แพ็คเกจคุณไม่ได้เปิดใช้งานฟังชั่น LPR (กล้องอ่านทะเบียน) คุณต้องการเปิดการใช้งานฟังชั่นไลน์ LPR (กล้องอ่านทะเบียน) หรือไม่", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dialogResult == DialogResult.Yes)
                {
                    frmProgramMessageAlert frmProgramMessageAlert = new frmProgramMessageAlert();
                    frmProgramMessageAlert.alertLevel = 2;
                    frmProgramMessageAlert.extension = "LPR";
                    frmProgramMessageAlert.messageAlert = "รหัสสำหรับเปิดฟังชั่น กล้องอ่านทะเบียน";
                    frmProgramMessageAlert.ShowDialog();
                    if (frmProgramMessageAlert.chckUnlock == true)
                    {
                        Application.Exit();
                    }
                }
            }
            else
            {
                frmLPR frmLPR = new frmLPR();
                frmLPR.ShowDialog();
            }
        }

        private void btnRFID_Click(object sender, EventArgs e)
        {
            if (registy.function.RFIDKey == "")
            {
                // แต่หากไม่ได้มีการเปิดฟังชั่น line แต่แรกให้ถามผู้ใช้ก่อนว่าต้องการเปิดฟังชั่นหรือไม่
                DialogResult dialogResult = MessageBox.Show("แพ็คเกจคุณไม่ได้เปิดใช้งานฟังชั่น RFID คุณต้องการเปิดการใช้งานฟังชั่นไลน์ RFID หรือไม่", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dialogResult == DialogResult.Yes)
                {
                    frmProgramMessageAlert frmProgramMessageAlert = new frmProgramMessageAlert();
                    frmProgramMessageAlert.alertLevel = 2;
                    frmProgramMessageAlert.extension = "RFID";
                    frmProgramMessageAlert.messageAlert = "รหัสสำหรับเปิดฟังชั่น RFID";
                    frmProgramMessageAlert.ShowDialog();
                    if (frmProgramMessageAlert.chckUnlock == true)
                    {
                        Application.Exit();
                    }
                }
            }
            else
            {
                frmRegisterRFID frmRFID = new frmRegisterRFID();
                frmRFID.ShowDialog();
            }
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            frmInformation frmInformation = new frmInformation();
            frmInformation.ShowDialog();
        }
    }
}
