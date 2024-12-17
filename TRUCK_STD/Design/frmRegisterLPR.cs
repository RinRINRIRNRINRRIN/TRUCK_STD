using Guna.UI2.WinForms;
using Serilog;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TRUCK_STD.DbBase;
using TRUCK_STD.Functions;
using Vlc.DotNet.Forms;

namespace TRUCK_STD.Design
{
    public partial class frmRegisterLPR : Form
    {
        public frmRegisterLPR()
        {
            InitializeComponent();
        }

        async Task GateInOpenAndClose(string state)
        {
            // สั่งเปิดไม้กั้น
            if (registy.function.BARRIERState == "TRUE")
            {
                barrier.Gate1(state, sa);
            }
            await Task.Delay(100);
        }

        async Task GateOutOpenAndClose(string state)
        {
            // สั่งเปิดไม้กั้น
            if (registy.function.BARRIERState == "TRUE")
            {
                barrier.Gate2(state, sa);
            }
            await Task.Delay(100);
        }

        Image ConvertToImage(string base64)
        {
            byte[] bytes = Convert.FromBase64String(base64);
            MemoryStream ms = new MemoryStream(bytes);
            Image image = Image.FromStream(ms);
            return image;
        }


        async Task ResetCam(string _ip)
        {
            Console.WriteLine("Resecam " + _ip);
            await Service.lpr.ResetLicensePlate(_ip);
        }


        /// <summary>
        /// สำหรับกำหนดค่าให้กับกล้องและ เชื่อมต่อกล้อง
        /// </summary>
        /// <param name="vlc">control ที่ต้องการเชื่อมต่อ</param>
        /// <param name="InOrOut">ทิศทางที่ต้องการเชื่อมต่อ</param>
        /// <returns></returns>
        async Task<bool> DefineCamAndConnectCam(VlcControl vlc, string InOrOut)
        {
            Console.WriteLine("define cam " + InOrOut);
            #region ดึงข้อมูลกำหนดค่าการเชื่อมต่อกล้อง
            // ดึงข้อมูลจากฐานข้อมูลว่ามีการเพิ่มกล้องหรือไม่
            DbBase.lpr.SelectCamInOut();
            // ตรวจสอบว่ากล้องมีการเพิ่มในระบบหรือยัง
            if (DbBase.lpr.tb.Rows.Count == 0)
            {
                msgD.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                msgD.Style = Guna.UI2.WinForms.MessageDialogStyle.Dark;
                msgD.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;
                BeginInvoke(new MethodInvoker(delegate ()
                {
                    msgD.Show("Could not find the camera please check your camera in system", "Can't find camera");
                }));
                Application.Exit();
            }

            string ip = "";
            int port = 0;
            string user = "";
            string pass = "";
            string optionCam = "";
            foreach (DataRow rw in DbBase.lpr.tb.Rows)
            {
                string position = rw["position"].ToString();
                if (InOrOut == position)
                {
                    ip = rw["ip"].ToString();
                    port = Convert.ToInt16(rw["port"].ToString());
                    user = rw["user"].ToString();
                    pass = rw["password"].ToString();
                    optionCam = ":network-caching=0|:file-caching=100";

                    // กำหนดค่าเชื่อมต่อกล้อง
                    Functions.LRP.ip = ip;
                    Functions.LRP.port = port.ToString();
                    Functions.LRP.user = user;
                    Functions.LRP.pass = pass;
                    Functions.LRP.option = optionCam.Split('|');
                    vlc.Tag = ip;
                    // เชื่อมต่อกล้อง
                    if (!await Functions.LRP.SetCamera(vlc))
                    {
                        BeginInvoke(new MethodInvoker(delegate ()
                        {
                            msgD.Show($"Could not connect the camera ip : {ip}", "Can't find camera");
                        }));
                        return false;
                    }
                }
            }
            return true;
            #endregion
        }


        /// <summary>
        /// อ่านค่าจากล้องผ่าน API ขาออก
        /// </summary>
        /// <returns></returns>
        async Task GetCamOut()
        {
            Console.WriteLine("Get camera out");
            #region ดึงค่าจากกล้อง
            string picLicensePlate = "";
            string picture = "";
            bool isHaveLicense = false;
            while (true)
            {
                // Read Cam1
                await Service.lpr.CheckLicenPlate(vlcBack.Tag.ToString());
                if (await Service.lpr.GetLicensPlate(vlcBack.Tag.ToString()))
                {
                    BeginInvoke(new MethodInvoker(delegate ()
                    {
                        pnText.Enabled = true;
                        pictureBox1.Image = ConvertToImage(picLicensePlate);
                        pictureBox3.Image = ConvertToImage(picture);
                    }));
                    // เอาทะเบียนรถไปหาในฐานข้อมูล
                    if (DbBase.job.selectLicensePlate(Service.lpr.licens1))
                    {
                        if (DbBase.job.tb.Rows.Count != 0) // หากข้อมูลมันไม่เท่ากับ 0 แสดงว่าการลงทะเบียนไว้ล้วงหน้าแล้ว
                        {
                            // สั่งเปิดไม้กั้น
                            await GateInOpenAndClose("OPEN");
                        }
                    }
                }
                else
                {
                    BeginInvoke(new MethodInvoker(delegate ()
                    {
                        label4.Text = "----";
                        pictureBox1.Image = null;
                        pictureBox3.Image = null;
                    }));
                }
                await Task.Delay(6000);
            }
            #endregion
        }


        /// <summary>
        /// อ่านค่าจากล้องผ่าน API ขาเข้า
        /// </summary>
        /// <returns></returns>
        async Task GetCamIn()
        {
            Console.WriteLine("Get camera in");
            #region ดึงค่าจากกล้อง
            bool isHaveLicense = false;
            while (true)
            {
                // Read Cam1
                await Service.lpr.CheckLicenPlate(vlcFront.Tag.ToString());
                if (await Service.lpr.GetLicensPlate(vlcFront.Tag.ToString()))
                {
                    BeginInvoke(new MethodInvoker(delegate ()
                    {
                        pnText.Enabled = true;
                        pictureBox1.Image = ConvertToImage(Service.lpr.licenPlate2);
                        pictureBox3.Image = ConvertToImage(Service.lpr.Picture2);
                        label4.Text = Service.lpr.licens2;
                        txtLicenseHead.Text = Service.lpr.licens2;
                    }));

                    // ตรวจสอบว่าเป็นรถที่ pendding ไว้หรือไม่ หรือมีการลงทะเบียไว้ล้วงหน้าหรือไม่
                    if (DbBase.job.selectLicensePlatePendding(Service.lpr.licens2))
                    {
                        if (DbBase.job.tb.Rows.Count > 0) // หากข้อมูลมันไม่เท่ากับ 0 แสดงว่าการลงทะเบียนไว้ล้วงหน้าแล้ว
                        {
                            // เช็คไม่กั้น
                            if (registy.function.BARRIERState == "TRUE")
                            {
                                foreach (DataRow rw in DbBase.job.tb.Rows)
                                {
                                    int id = Convert.ToInt16(rw["id"].ToString());
                                    // ปรับสถานะรถเป็น Process เนื่องจากมา Checkin แล้ว
                                    job.updateStatusWeightIn(id, "Process", "0");
                                    // สั่งเปิดไม้กั้น
                                    await GateInOpenAndClose("OPEN");
                                    await Task.Delay(5000);
                                    await GateInOpenAndClose("CLOSE");
                                }
                            }
                        }
                        else
                        {
                            // เช็คว่าเป็นทะเบียนเดิมที่กำลัง Process อยู่หรือไม่
                            if (DbBase.job.selectLicensePlateProcess(Service.lpr.licens2))
                            {
                                if (DbBase.job.tb.Rows.Count == 0)
                                {
                                    // หากข้อมูลเป็น 0 หมายถึงรถคันใหม่
                                    BeginInvoke(new MethodInvoker(delegate ()
                                    {
                                        gbInformation.Enabled = true;
                                    }));
                                    break;
                                }
                                else // แต่หากข้อมูลไม่ใช่ 0 แสดงว่า
                                {
                                    BeginInvoke(new MethodInvoker(delegate ()
                                    {
                                        msg.Show(this, "พบเลขทะเบียนซ้ำในระบบ กรุณาตรวจสอบ", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 3000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);
                                    }));
                                }
                            }
                        }
                    }
                }
                else
                {
                    BeginInvoke(new MethodInvoker(delegate ()
                    {
                        label4.Text = "----";
                        pictureBox1.Image = null;
                        pictureBox3.Image = null;
                    }));
                }
                await Task.Delay(6000);
            }
            #endregion
        }

        /// <summary>
        /// เชื่อมต่อฐานอข้อมูล
        /// </summary>
        /// <returns></returns>
        async Task<bool> ConnnectDatabase()
        {
            Console.WriteLine("Conecctdatabase");
            // 1. ทำการเชื่อมต่อกับ server
            if (DbBase.DbConnect.ConnectBase())
            {
                BeginInvoke(new MethodInvoker(delegate ()
                {
                    label19.Text = "เชื่อมต่อสำเร็จ....";
                }));
                Log.Information("ทดสอบการเชื่อมต่อฐานข้อมูล เชื่อมต่อสำเร็จ");

                Thread.Sleep(2000);

                BeginInvoke(new MethodInvoker(delegate ()
                {
                    flpcam.Visible = true;
                    gbData.Visible = true;
                    gbInformation.Visible = true;
                    gbConnect.Visible = false;
                }));
            }
            // 2. ถ้าไม่สามารถเชื่อมต่อได้
            else
            {
                BeginInvoke(new MethodInvoker(delegate ()
                {
                    label2.Text = "ไม่สามารถติดตั้งฐานข้อมูลได้";
                    pgbProcess.ProgressColor = System.Drawing.Color.Red;
                    pgbProcess.ProgressColor2 = System.Drawing.Color.Red;
                }));
                return false;
            }
            await Task.Delay(200);
            return true;
        }


        void ShowData()
        {
            if (DbBase.job.selectOrderToday())
            {
                DataTable tb = new DataTable();
                tb.Columns.Add("status");
                tb.Columns.Add("licenseHead");
                tb.Columns.Add("licenseTail");
                tb.Columns.Add("fullname");

                foreach (DataRow rw in DbBase.job.tb.Rows)
                {
                    string status = rw["status"].ToString();
                    string head = rw["licenseHead"].ToString();
                    string tail = rw["licenseTail"].ToString();
                    string fullname = rw["fullname"].ToString();
                    tb.Rows.Add(status, head, tail, fullname);
                }
                BeginInvoke(new MethodInvoker(delegate ()
                {
                    dgvdata.DataSource = tb;
                }));
                Thread.Sleep(1500);
                foreach (DataGridViewRow rw in dgvdata.Rows)
                {
                    string _status = rw.Cells["cl_status"].Value.ToString();
                    BeginInvoke(new MethodInvoker(delegate ()
                    {
                        switch (_status)
                        {
                            case "Pendding":
                                dgvdata.DefaultCellStyle.ForeColor = Color.Goldenrod;
                                break;
                            case "Process":
                                dgvdata.DefaultCellStyle.ForeColor = Color.Navy;
                                break;
                            case "Success":
                                dgvdata.DefaultCellStyle.ForeColor = Color.Chocolate;
                                break;
                            case "Cancel":
                                dgvdata.DefaultCellStyle.ForeColor = Color.Green;
                                break;
                        }


                    }));
                }
            }
        }

        private void frmRegisterLPR_Load(object sender, EventArgs e)
        {
            flpcam.Visible = false;
            gbData.Visible = false;
            gbInformation.Visible = false;

            int x = (this.Width - gbConnect.Width) / 2;
            int y = (this.Height - gbConnect.Height) / 2;
            gbConnect.Location = new Point(x, y);
            gbConnect.Visible = true;


            // ฐานข้อมูล
            DbConnect.HOST = registy.dbCenter.host;
            DbConnect.PORT = registy.dbCenter.Port;
            DbConnect.USER = registy.dbCenter.User;
            DbConnect.PASS = registy.dbCenter.Pass;
            DbConnect.BASS = registy.dbCenter.Base;
            // เชื่อมต่อฐานข้อมูล
            Task.Run(async () =>
             {
                 if (await ConnnectDatabase())
                 {
                     // กำหนดคร่าให้พร้อมใชอ
                     BeginInvoke(new MethodInvoker(delegate ()
                     {
                         flpcam.Visible = true;
                         gbInformation.Visible = true;
                         gbData.Visible = true;
                     }));

                     // แสดงข้อมูล order ทั้งหมด
                     ShowData();


                     // เช็คว่ามีการใช้ไม่้กั้นหรือไม่
                     if (registy.function.BARRIERState == "TRUE")
                     {
                         // เช็คพอร์ตก่อน
                         if (!barrier.Connect(sa))
                         {
                             msgD.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                             msgD.Style = Guna.UI2.WinForms.MessageDialogStyle.Dark;
                             msgD.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error;

                             int xx = (this.Width - gbSetting.Width) / 2;
                             int yy = (this.Height - gbSetting.Height) / 2;
                             BeginInvoke(new MethodInvoker(delegate ()
                             {
                                 msgD.Show("ไม่สามารถเชื่อมต่อกับอุปกรณืที่ใช้สั่งงานไม้กั้นได้ กรุณาตรวจสอบ PLC หรือ อุปกรณ์ Controller", "Connection fails");
                                 flpcam.Visible = false;
                                 gbInformation.Visible = false;
                                 gbData.Visible = false;
                                 gbSetting.Location = new System.Drawing.Point(xx, yy);
                             }));
                             return;
                         }
                     }

                     // เชื่อมต่อกล้อง
                     if (!await DefineCamAndConnectCam(vlcFront, "ทางเข้า"))
                     {
                         Application.Exit();
                     }

                     // เชื่อมต่อกล้อง
                     if (!await DefineCamAndConnectCam(vlcBack, "ทางออก"))
                     {
                         Application.Exit();
                     }
                     BeginInvoke(new MethodInvoker(delegate ()
                     {
                         this.Enabled = false;
                     }));
                     await ResetCam(vlcBack.Tag.ToString());
                     await ResetCam(vlcFront.Tag.ToString());
                     await Task.Delay(2000);
                     // ทำการอ่านทะเบียนรถขาเข้า
                     Task.Run(async () => await GetCamIn());
                     //Task.Run(async () => await GetCamOut());
                     await Task.Delay(2000);
                     BeginInvoke(new MethodInvoker(delegate ()
                     {
                         this.Enabled = true;
                     }));


                 }
                 else
                 {
                     MessageBox.Show("ไม่สามารถเชื่อมต่อฐานอข้อมูล");
                 }
             });
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            // Check ค่าว่าง
            foreach (Guna2TextBox txt in gbInformation.Controls.OfType<Guna2TextBox>())
            {
                if (txt.Text == "")
                {
                    msg.Show(this, "Please fill data before to save", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 3000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);
                    return;
                }
            }

            // บันทึก
            if (!DbBase.job.AddNewRegistor(txtIdCard.Text, txtFullName.Text, txtLicenseHead.Text, txtLicenseTail.Text, int.Parse(txtCustomerId.Text), int.Parse(txtProductId.Text)))
            {

                msg.Show(this, $"Can't to registor {job.ERR}", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 3000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);
                return;
            }
            msg.Show(this, $"Save the data success", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);

            foreach (Guna2TextBox item in pnText.Controls.OfType<Guna2TextBox>())
            {
                item.Clear();
            }

            label4.Text = "---";
            txtLicenseHead.Text = "---";
            gbInformation.Enabled = false;
            ShowData();
            await ResetCam(vlcFront.Tag.ToString());
            await ResetCam(vlcBack.Tag.ToString());
            Task.Run(async () => await GetCamIn());
            //Task.Run(async () => await GetCamOut());
        }

        private async void btnCancelWeight_Click(object sender, EventArgs e)
        {
            msgD.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;
            msgD.Style = Guna.UI2.WinForms.MessageDialogStyle.Dark;
            msgD.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;

            DialogResult result = msgD.Show("Do you want to cancel the order?", "Cancel order");
            if (result == DialogResult.Yes)
            {
                foreach (Guna2TextBox item in pnText.Controls.OfType<Guna2TextBox>())
                {
                    item.Clear();
                }
            }
            label4.Text = "---";
            txtLicenseHead.Text = "---";
            gbInformation.Enabled = false;
            ShowData();
            await ResetCam(vlcFront.Tag.ToString());
            await ResetCam(vlcBack.Tag.ToString());
            Task.Run(async () => await GetCamIn());
            //Task.Run(async () => await GetCamOut());
        }
    }
}
