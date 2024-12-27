using Bunifu.UI.WinForms;
using Serilog;
using System;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TRUCK_STD.DbBase;
using TRUCK_STD.Function;
using TRUCK_STD.Functions;
using TRUCK_STD.Models;

namespace TRUCK_STD.Design
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            Console.WriteLine("===========================  Open frmLogin");
        }


        BunifuSnackbar msg = new BunifuSnackbar();


        #region"FUNCTION LOCAL"
        /// <summary>
        /// ใช้สำหรับติดต่อฐานข้อมูล
        /// </summary>
        async Task ConnnectDatabase()
        {
            // 1. ทำการเชื่อมต่อกับ server
            if (DbConnect.ConnectBase())
            {
                BeginInvoke(new MethodInvoker(delegate ()
                {
                    label2.Text = "เชื่อมต่อสำเร็จ....";
                    Log.Information("ทดสอบการเชื่อมต่อฐานข้อมูล เชื่อมต่อสำเร็จ");
                }));

                Thread.Sleep(2000);

                BeginInvoke(new MethodInvoker(delegate ()
                {
                    guna2CircleProgressBar1.Animated = false;
                    gbConnect.Visible = false;
                    pnTextbox.Enabled = true;
                }));

                // หากทำการเชื่อมต่อสำเร็จ ให้ทำการเช็คว่า มีการสร้างรหัส SA ในระบบหรือยังซึ้ง sa จะไม่สามารถลบได้

                employee.new_username = "sa";
                employee.password = "sa";
                employee.names = "sa";
                employee.state = "SA";


                if (employee.Select())
                {
                    bool isHave = false;
                    foreach (DataRow rw in employee.tb.Rows)
                    {
                        if (rw["emp_username"].ToString() == "sa")
                        {
                            isHave = true;
                        }
                    }

                    if (!isHave)
                    {
                        if (!employee.Insert())
                        {
                            MessageBox.Show("เกิดข้อผิดผลาด " + employee.ERR, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("เกิดข้อผิดผลาดในการเชื่อมต่อฐานข้อมูล", "ERROR 01");
                    Application.Exit();
                    return;
                }

                BeginInvoke(new MethodInvoker(delegate ()
                {
                    lbSystemNumber.Text = registy.system.id;
                }));
            }
            // 2. ถ้าไม่สามารถเชื่อมต่อได้
            else
            {
                BeginInvoke(new MethodInvoker(delegate ()
                {
                    label2.Text = "ไม่สามารถติดตั้งฐานข้อมูลได้";
                    guna2CircleProgressBar1.ProgressColor = Color.Red;
                    guna2CircleProgressBar1.ProgressColor2 = Color.Red;

                }));
            }
            await Task.Delay(200);
        }

        /// <summary>
        /// ใช้สำหรับ login
        /// </summary>
        void LOGIN()
        {
            // 1.ตรวจสอบว่ามีข้อมูลว่างหรือไม่
            if (txtPassword.Text == "" || txtUsername.Text == "")
            {
                Log.Warning("พบค่าว่าง ที่ username or password");
                // MessageBox.Show("กรุณากรอกข้อมูลให้ครบก่อนทำการเข้าสู่ระบบ", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                msg.Show(this, "กรุณากรอกข้อมูลให้ครบก่อนทำการเข้าสู่ระบบ", BunifuSnackbar.MessageTypes.Warning, 2500, "OK", BunifuSnackbar.Positions.TopCenter);
            }
            // 2.ถ้าไม่มีให้ทำการทำการตรวจสอบการเข้าสู่ระบบ
            else
            {
                // ตรวจสอบว่า ผู้ใช้และรหัสผ่าน ถูกต้องหรือไม่
                if (employee.Select())
                {
                    foreach (DataRow rw in employee.tb.Rows)
                    {
                        string _id = rw["id"].ToString();
                        string _user = rw["emp_username"].ToString();
                        string _pass = rw["emp_password"].ToString();
                        string _name = rw["emp_names"].ToString();
                        string _state = rw["emp_state"].ToString();

                        // เช็คข้อมูลครงกันหรือไม่
                        if (_user == txtUsername.Text && _pass == txtPassword.Text)
                        {
                            // เช็คว่ารหัสถูกระงับการใช้งานหรือไม่
                            if (_state == "Inactive")
                            {
                                MessageBox.Show("ข้อมูลผู้ใช้ถูกระงับการใช้งาน");
                                return;
                            }

                            Log.Information("เข้าสู่ระบบสำเร็จ");
                            // กำหนดค่า
                            accountModels.id = _id;
                            accountModels.user = _user;
                            accountModels.pass = _pass;
                            accountModels.names = _name;
                            accountModels.state = _state;

                            // Show log
                            Console.WriteLine($"ID : {accountModels.id}");
                            Console.WriteLine($"User : {accountModels.user}");
                            Console.WriteLine($"Pass : {accountModels.pass}");
                            Console.WriteLine($"Names : {accountModels.names}");
                            Console.WriteLine($"state : {accountModels.state}");

                            // เครียค่า
                            txtPassword.Clear();
                            txtUsername.Clear();
                            frmMain frm = new frmMain();
                            this.Hide();
                            frm.ShowDialog();
                            return;
                        }
                    }
                    // หากหาข้อมูลผู้ใช้ไม่เจอ
                    Log.Warning("เข้าสู่ระบบไม่สำเร็จ");
                    msg.Show(this, "ผู้ใช้ หรือ รหัสผ่านไม่ถุกต้อง", BunifuSnackbar.MessageTypes.Warning, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                    txtPassword.Clear();
                    txtUsername.Clear();
                    txtUsername.Focus();
                }
            }
        }

        #endregion
        private async void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                #region ดึงค่าจาก REGISTRY
                // เช็คสถานะโปรแกมว่าโดนระงับหรือไม่
                string[] j = registy.system.steate.Split(':');
                if (j[0].Trim() == "FALSE")
                {
                    Func_Main.SHOW_FROM_ALERT(1, "โปรแกรมถูกระงับการใช้งาน \n " + j[1].Trim());
                }

                try
                {
                    // เช็ควันที่
                    DateTime dateProgram = DateTime.Parse(registy.system.date);
                    string a = DateTime.Now.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("th-TH"));
                    DateTime dateComputer = DateTime.Parse(a);

                    // เปรียบเทียบวันที่  วันที่คอมพิวเตอร์ ห้ามน้อยกว่าวันที่โปรแกรม 
                    if (dateComputer < dateProgram)
                    {
                        // โปรแกรมมีการเปลี่ยนวันที่ 
                        registy.system.steate = "FALSE : ตรวจพบการเปลี่ยนแปลงวันที่คอมพิวเตอร์";
                        // หากมีการย้อนกลับวันที่คอมพิวเตอร์ กำหนดค่าไปที่ registry เพื่อระงับการใช้งานโปรแกรม
                        registy.Set();
                        // แสดงฟอร์มแจ้งเตือน
                        Func_Main.SHOW_FROM_ALERT(1, "โปรแกรมถูกระงับการใช้งาน \n ตรวจพบการเปลี่ยนแปลงวันที่คอมพิวเตอร์");
                    }
                    else if (dateComputer > dateProgram)
                    {
                        // ถ้าหากวันที่คอมพิวเตอร์มากกว่าวันที่โปรแกรมจะทำการบันทึกวันที่โปรแกรมเป็นวันนั้นเลย
                        registy.system.date = DateTime.Now.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("th-TH"));
                        registy.tickets.state = "FALSE";
                        registy.Set();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("FuncMain CHECK_DATE_PROGRAM_AND_DATE_COMPUTER : " + ex.Message);
                    Log.Error("FuncMain CHECK_DATE_PROGRAM_AND_DATE_COMPUTER : " + ex.Message);
                }

                // เช็คว่าถ้าโปรแกรมไม่ใช่โปรแกรมจริง
                if (registy.system.programType == "FALSE")
                {
                    // แต่ถ้าเป็น demo ให้ตรรวจสอยว่า หมดอายุหรือยัง
                    lbProgramType.Text = "Program Demo";
                    DateTime dateExprie = DateTime.Parse(registy.system.dateExpire);
                    string b = DateTime.Now.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("th-TH"));
                    DateTime date = DateTime.Parse(b);
                    if (dateExprie <= date)
                    {
                        Func_Main.SHOW_FROM_ALERT(0, "โปรแกรมถูกระงับการใช้งาน \n การทดสอบโปรแกรมหมดอายุแล้ว");
                    }
                }
                else
                {
                    if (registy.system.dateExpire != "FOREVER")
                    {
                        // แต่ถ้าเป็น demo ให้ตรรวจสอยว่า หมดอายุหรือยัง
                        DateTime dateExprie = DateTime.Parse(registy.system.dateExpire);
                        string b = DateTime.Now.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("th-TH"));
                        DateTime date = DateTime.Parse(b);
                        if (dateExprie <= date)
                        {
                            Func_Main.SHOW_FROM_ALERT(0, "โปรแกรมถูกระงับการใช้งาน \n ตรวจสอบโปรแกรมหมดอายุ");
                        }
                    }
                }

                // กำหนดค่าการเชื่อม่อ
                DbConnect.HOST = registy.db.host;
                DbConnect.PORT = registy.db.Port;
                DbConnect.USER = registy.db.User;
                DbConnect.PASS = registy.db.Pass;
                DbConnect.BASS = registy.db.Base;
                await Task.Run(ConnnectDatabase);

                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดผลาด", "frmLogin_Load");

                Console.WriteLine("frmLogin frmLogin_Load " + ex.Message);
                Log.Error("frmLogin frmLogin_Load " + ex.Message);
                Application.Exit();
            }

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LOGIN();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LOGIN();
            }
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            LOGIN();
        }

        private void gbConnect_Click(object sender, EventArgs e)
        {

        }
    }
}
