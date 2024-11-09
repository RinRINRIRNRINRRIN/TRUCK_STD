
using Guna.UI2.WinForms;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TRUCK_STD.DbBase;
using TRUCK_STD.Functions;
using TRUCK_STD.UControls;

namespace TRUCK_STD.Design
{
    public partial class frmNewWeight : Form
    {
        public frmNewWeight()
        {
            InitializeComponent();

        }
        string wghOld = "";
        string wghNew = "";
        string optionCam = ":network-caching=0|:file-caching=100";
        private double lastWeight = 0;
        private double newWeight = 0;
        private bool isStable = true;
        private bool isGetCam = false;

        // สำหรับเก็บค่าทะเบียนรถ
        string licenPlate = "";
        Image ConvertToImage(string base64)
        {
            byte[] bytes = Convert.FromBase64String(base64);
            MemoryStream ms = new MemoryStream(bytes);
            Image image = Image.FromStream(ms);
            return image;
        }

        /// <summary>
        /// สำหรับสร้างการเชื่อมต่อกล้อง บน Thread อื่น ๆ 
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        async Task ConnectCCTV(string ip, int port, string user, string password, string position)
        {
            BeginInvoke(new MethodInvoker(async delegate ()
            {
                CCTV cCTV = new CCTV();
                cCTV.ip = ip;
                cCTV.port = port.ToString();
                cCTV.user = user;
                cCTV.pass = password;
                cCTV.option = optionCam.Split('|');

                // สร้างกล้อง
                ucCCTV ucCCTv = new ucCCTV();

                ucCCTv.Show();
                ucCCTv.lblIP.Text = ip;
                ucCCTv.lblPort.Text = port.ToString();
                ucCCTv.lblUser.Text = user;
                ucCCTv.lblPass.Text = password;
                ucCCTv.lblPosition.Text = position;
                flpCamera.Controls.Add(ucCCTv);


                if (await cCTV.SetCamera(ucCCTv.vlcCam))
                {
                    ucCCTv.lblStatus.Text = $"เชื่อมต่อสำเร็จ";
                    ucCCTv.lblStatus.ForeColor = System.Drawing.Color.Green;
                    ucCCTv.btnZoom.Enabled = true;

                    //await Task.Run(async () => await GetParameterCam());
                }
                else
                {
                    ucCCTv.lblStatus.Text = $"เชื่อมต่อไม่สำเร็จ";
                    ucCCTv.lblStatus.ForeColor = System.Drawing.Color.Red;
                }
            }));
        }

        /// <summary>
        /// อ่านข้อมูลจากกล้องเมื่อ อ่านทะเบียนได้
        /// </summary>
        /// <returns></returns>
        async Task GetdataFormApiLPR(string licenseString)
        {
            try
            {
                isGetCam = false;
                bool isSuccess = false;
                // นำเลขทะเบียนรถไปหาในฐานข้อมูล ว่ามีการชั่งอะไรบ้าง
                if (job.selectLicensePlate(licenseString))
                {
                    // หากมีข้อมูล ให้นำ id ไปหาที่ jobdetail
                    switch (job.tb.Rows.Count)
                    {
                        case 1: // มีการลงทะเบียนมาแล้ว

                            foreach (DataRow item in job.tb.Rows)
                            {
                                int id = int.Parse(item["id"].ToString());
                                string customerId = item["customerId"].ToString();
                                //string customerName = item["customerName"].ToString();
                                string productid = item["productId"].ToString();
                                //string productname = item["productName"].ToString();
                                string note = item["objective"].ToString();
                                //string weightIn = item["weightIn"].ToString();


                                if (jobDetail.SelectCountOrderDetail(id))
                                {
                                    if (jobDetail.tb.Rows.Count == 0) // ถ้าเป็น 0 จะต้องบันทึกเป็น weight IN
                                    {
                                        // อัพเดทข้อมูล job 
                                        if (job.updatejobNumber(id))
                                        {
                                            // บันทึกข้อมูลที่ได้ไปที่ jobDetail
                                            // หากเช็คแล้วพบว่าไม่มีการชั่งหมายถึงชั่งใหม่ ให้บันทึกข้อมูลชั่งใหม่
                                            if (jobDetail.InsertNewOrderdetail(id, "ชั่งเข้า", int.Parse(lblWeight.Text)))
                                            {
                                                BeginInvoke(new MethodInvoker(delegate ()
                                                {
                                                    msg.Show(this, "บันทึกรายการชั่งเข้าสำเร็จ", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                                                }));
                                                isSuccess = true;
                                            }
                                            else
                                            {
                                                BeginInvoke(new MethodInvoker(delegate ()
                                                {
                                                    msg.Show(this, "บันทึกรายการชั่งเข้าไม่สำเร็จ " + jobDetail.ERR, Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                                                }));
                                            }
                                        }
                                    }
                                    else if (jobDetail.tb.Rows.Count == 1)
                                    {
                                        BeginInvoke(new MethodInvoker(delegate ()
                                        {
                                            txtCustomerId.Text = customerId;
                                            //txtCustomerName.Text = customerName;
                                            txtProductId.Text = productid;
                                            //txtProductName.Text = productname;
                                            txtNote.Text = note;
                                            //txtWeightIn.Text = weightIn;
                                        }));
                                        // หากเช็คแล้วพบว่าไม่มีการชั่งหมายถึงชั่งใหม่ ให้บันทึกข้อมูลชั่งใหม่
                                        if (jobDetail.InsertNewOrderdetail(id, "ชั่งเข้า", int.Parse(lblWeight.Text)))
                                        {
                                            BeginInvoke(new MethodInvoker(delegate ()
                                            {
                                                msg.Show(this, "บันทึกรายการชั่งออกสำเร็จ", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                                            }));
                                            isSuccess = true;
                                        }
                                        else
                                        {
                                            BeginInvoke(new MethodInvoker(delegate ()
                                            {
                                                msg.Show(this, "บันทึกรายการชั่งออกไม่สำเร็จ " + jobDetail.ERR, Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                                            }));
                                        }
                                    }
                                }
                            }
                            break;
                    }

                    if (isSuccess)
                    {
                        isGetCam = true;

                        btnSave.Enabled = false;
                        btnCancelWeight.Enabled = false;
                        await Task.Delay(1000);
                        await Task.Run(async () =>
                         {
                             await GetCam();
                         });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        /// <summary>
        /// For loop Get api LPR
        /// </summary>
        /// <returns></returns>
        async Task GetCam()
        {
            // GetCam
            string LPRFront = "";
            string LPRBack = "";
            foreach (DataRow rw in DbBase.lpr.tb.Rows)
            {
                string position = rw["position"].ToString();
                switch (position)
                {
                    case "หลัง":
                        LPRBack = rw["ip"].ToString();
                        break;
                    case "หน้า":
                        LPRFront = rw["ip"].ToString();
                        break;
                }
            }

            string picLicensePlate = "";
            string picture = "";
            bool isHaveLicense = false;
            while (isGetCam)
            {
                // Read Cam1
                await Service.lpr.CheckLicenPlate(LPRFront);
                if (await Service.lpr.GetLicensPlate(LPRFront))
                {
                    // เช็คว่ามีรถจากน้ำหนักหรือไม่
                    if (int.Parse(lblWeight.Text) <= 100)
                    {
                        // Show button  
                        isHaveLicense = true;
                        await Task.Delay(1000);
                        picLicensePlate = Service.lpr.licenPlate1;
                        picture = Service.lpr.Picture1;
                        licenPlate = Service.lpr.licens1;
                        BeginInvoke(new MethodInvoker(delegate ()
                        {
                            label4.Text = Service.lpr.licens1;
                        }));
                        break;
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

                // Read Cam2
                await Service.lpr.CheckLicenPlate(LPRBack);
                if (await Service.lpr.GetLicensPlate(LPRBack))
                {
                    // เช็คว่ามีรถจากน้ำหนักหรือไม่
                    if (int.Parse(lblWeight.Text) <= 100)
                    {
                        await Task.Delay(1000);
                        isHaveLicense = true;
                        picLicensePlate = Service.lpr.licenPlate2;
                        picture = Service.lpr.Picture2;
                        licenPlate = Service.lpr.licens2;
                        BeginInvoke(new MethodInvoker(delegate ()
                        {
                            label5.Text = Service.lpr.licens2;
                        }));
                        break;

                    }
                }
                else
                {
                    BeginInvoke(new MethodInvoker(delegate ()
                    {
                        pictureBox2.Image = null;
                        pictureBox4.Image = null;
                        label5.Text = "----";
                    }));
                }
                await Task.Delay(6000);
            }
            if (isHaveLicense)
            {
                isGetCam = false;
                await Task.Delay(200);
                BeginInvoke(new MethodInvoker(delegate ()
                {
                    pnText.Enabled = true;
                    pictureBox1.Image = ConvertToImage(picLicensePlate);
                    pictureBox3.Image = ConvertToImage(picture);
                }));
            }
            // GetdataFormApiLPR(licenPlate);

        }



        private async void frmNewWeight_Load(object sender, System.EventArgs e)
        {

            #region Indicator
            // เช็คการเชื่อมต่อ น้ำหนัก
            if (scales.ChcekPort())
            {
                // กำหนดค่าการเชื่อมต่อ
                if (!scales.Connect(saScale))
                {
                    MessageBox.Show("เกิดข้อผิดผลาดในการเชื่อมต่อเครื่องชั่ง" + scales.ERR, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("โปรแกรมยังไม่ได้ตั้งค่าการเชื่อมต่อ เครื่องชั่ง กรุณาไปที่หน้าตั้งค่าเพื่อกำหนดการเชื่อมต่อ", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
            #endregion

            // ดึงข้อมูลจากฐานข้อมูลว่ามีการเพิ่มกล้องหรือไม่
            DbBase.lpr.SelectCam();
            if (DbBase.lpr.tb.Rows.Count < 2) // แสดงว่าไม่พบข้อมูล
            {
                // return ค่าให้ไปกำหนดค่าก่อน
                MessageBox.Show("ระบบยังไม่ได้กำหนดค่ากล้องกรุณาตั้งค่าก่อน", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
            else
            {
                // กำหนดค่ามาแสดงที่กล้อง
                foreach (DataRow item in DbBase.lpr.tb.Rows)
                {
                    LRP.ip = item["ip"].ToString();
                    LRP.port = item["port"].ToString();
                    LRP.user = item["user"].ToString();
                    LRP.pass = item["password"].ToString();
                    LRP.option = optionCam.Split('|');
                    string status = item["position"].ToString();
                    // Reset parameter at api
                    await Service.lpr.ResetLicensePlate(LRP.ip);
                    switch (status)
                    {
                        case "หลัง":
                            lblLPRBack.Text = $"กล้องด้านหลัง : {LRP.ip} : {LRP.port}";
                            await LRP.SetCamera(vlcBack);
                            break;
                        case "หน้า":
                            lblLPRFront.Text = $"กล้องด้านหน้า : {LRP.ip} : {LRP.port}";
                            await LRP.SetCamera(vlcFront);
                            break;
                    }
                }
            }

            #region CAMERA
            // เช็คว่ามีฟั่งชั่น  Camera หรือไม่
            if (registy.function.CAMERAState == "TRUE")
            {
                if (!cctvs.Select()) { this.Close(); }

                if (cctvs.tb.Rows.Count == 0)
                {
                    // return ค่าให้ไปกำหนดค่าก่อน
                    MessageBox.Show("ระบบยังไม่ได้กำหนดค่ากล้องกรุณาตั้งค่าก่อน", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
                else
                {
                    flpCamera.Controls.Clear();
                    foreach (DataRow item in cctvs.tb.Rows)
                    {
                        // หากมีข้อมูลอยู่แล้วให้ลูปสร้างกล้อง
                        string _ip = item["ip"].ToString();
                        string _port = item["port"].ToString();
                        string _user = item["user"].ToString();
                        string _pass = item["password"].ToString();
                        string _position = item["position"].ToString();
                        Task.Run(async () => await ConnectCCTV(_ip, int.Parse(_port), _user, _pass, _position));
                    }
                }
            }
            #endregion

            #region BARIER
            // เช็คว่ามีฟังชั่ง ไม้กั้นหรอไม่
            if (registy.function.BARRIERState == "TRUE")
            {
                //เช็คต่อว่าได้มีการกำหนดค่าการเชื่อมต่อหรือไม่
                if (registy.plc.plcPort == "" || registy.plc.plcBaudrate == 0)
                {
                    MessageBox.Show("โปรแกรมยังไม่ได้ตั้งค่าการเชื่อมต่อไม้กั้น กรุณาไปที่หน้าตั้งค่าเพื่อกำหนดการเชื่อมต่อ", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                    return;
                }

                // แต่หากมีการเชือมต่อแล้วให้ทำการกำหนดค่าP
                plc.Connect(saPLC);
            }
            #endregion



            // ShowData
            if (job.selectOrderProcess())
            {
                DataTable tb = new DataTable();
                tb.Columns.Add("id");
                tb.Columns.Add("jobOrder");
                tb.Columns.Add("licenseHead");
                tb.Columns.Add("licenseTail");
                tb.Columns.Add("weight");
                foreach (DataRow rw in job.tb.Rows)
                {
                    string id = rw["id"].ToString();
                    string job = rw["jobOrder"].ToString();
                    string licenseHead = rw["licenseHead"].ToString();
                    string licenseTail = rw["licenseTail"].ToString();
                    string weight = rw["weight"].ToString();
                    tb.Rows.Add(id, job, licenseHead, licenseTail, weight);
                }
                dgvdata.DataSource = tb;
            }
            else
            {
                msg.Show(this, $"ไม่สามารถดึงข้อมูลรายการชั่งได้ {job.ERR}", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                return;
            }
            isGetCam = true;
            await Task.Delay(5000);
            await Task.Run(async () =>
            {
                await GetCam();
            });
        }

        private void saScale_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string a = saScale.ReadLine();
            string wgh = a.Substring(1, 8).Trim();
            newWeight = double.Parse(wgh);

            // ถ้าน้ำหนักแตกต่างจากน้ำหนักล่าสุด
            if (newWeight != lastWeight)
            {
                lastWeight = newWeight;
                BeginInvoke(new MethodInvoker(delegate ()
                {
                    tmCheckWeight.Stop();
                    tmCheckWeight.Start();
                    lblWeight.ForeColor = System.Drawing.Color.Red; // เปลี่ยนสี Label เป็นสีแดง
                    pnText.Enabled = false;
                }));
            }

            BeginInvoke(new MethodInvoker(delegate ()
            {
                lblWeight.Text = wgh;
            }));
        }

        private void tmCheckWeight_Tick(object sender, EventArgs e)
        {
            lblWeight.ForeColor = System.Drawing.Color.Green; // เปลี่ยนสี Label เป็นสีดำ
            tmCheckWeight.Stop(); // หยุด Timer
            if (!isGetCam)
            {
                pnText.Enabled = true;
            }
        }


        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {

        }

        private async void frmNewWeight_FormClosing(object sender, FormClosingEventArgs e)
        {
            scales.Disconnect(saScale);

            foreach (ucCCTV item in flpCamera.Controls.OfType<ucCCTV>())
            {
                LRP.Stop(item.vlcCam);
                await Task.Delay(500);
            }
            this.Enabled = false;
            isGetCam = false;
            await Task.Delay(10000);

        }



        private async void btnCancelWeight_Click(object sender, EventArgs e)
        {
            guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;
            guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
            guna2MessageDialog1.Style = Guna.UI2.WinForms.MessageDialogStyle.Light;

            DialogResult reult = guna2MessageDialog1.Show("Do you want to canncel?", "Cancel");
            if (reult == DialogResult.Yes)
            {
                // Deleta data

                // clear text
                foreach (Guna2TextBox text in panel3.Controls.OfType<Guna2TextBox>())
                {
                    text.Clear();
                }


                pnText.Enabled = true;
                // CheckInsert
                await Service.lpr.ResetLicensePlate("192.168.1.205");
                await Service.lpr.ResetLicensePlate("192.168.1.206");
                // Get cam
                isGetCam = true;
                await Task.Run(async () =>
                {
                    await GetCam();
                });




            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // หยุดการอ่าน
                isGetCam = false;
                bool isSuccess = false;
                // นำเลขทะเบียนรถไปหาในฐานข้อมูล ว่ามีการชั่งอะไรบ้าง
                if (job.selectLicensePlate(licenPlate))
                {
                    // หากมีข้อมูล ให้นำ id ไปหาที่ jobdetail
                    switch (job.tb.Rows.Count)
                    {
                        case 1: // มีการลงทะเบียนมาแล้ว

                            foreach (DataRow item in job.tb.Rows)
                            {
                                int id = int.Parse(item["id"].ToString());
                                string customerId = item["customerId"].ToString();
                                //string customerName = item["customerName"].ToString();
                                string productid = item["productId"].ToString();
                                //string productname = item["productName"].ToString();
                                string note = item["objective"].ToString();
                                //string weightIn = item["weightIn"].ToString();


                                if (jobDetail.SelectCountOrderDetail(id))
                                {
                                    if (jobDetail.tb.Rows.Count == 0) // ถ้าเป็น 0 จะต้องบันทึกเป็น weight IN
                                    {
                                        // อัพเดทข้อมูล job 
                                        if (job.updatejobNumber(id))
                                        {
                                            // บันทึกข้อมูลที่ได้ไปที่ jobDetail
                                            // หากเช็คแล้วพบว่าไม่มีการชั่งหมายถึงชั่งใหม่ ให้บันทึกข้อมูลชั่งใหม่
                                            if (jobDetail.InsertNewOrderdetail(id, "ชั่งเข้า", int.Parse(lblWeight.Text)))
                                            {
                                                BeginInvoke(new MethodInvoker(delegate ()
                                                {
                                                    msg.Show(this, "บันทึกรายการชั่งเข้าสำเร็จ", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                                                }));
                                                isSuccess = true;
                                            }
                                            else
                                            {
                                                BeginInvoke(new MethodInvoker(delegate ()
                                                {
                                                    msg.Show(this, "บันทึกรายการชั่งเข้าไม่สำเร็จ " + jobDetail.ERR, Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                                                }));
                                            }
                                        }
                                    }
                                    else if (jobDetail.tb.Rows.Count == 1)
                                    {
                                        // หากเช็คแล้วพบว่าไม่มีการชั่งหมายถึงชั่งใหม่ ให้บันทึกข้อมูลชั่งใหม่
                                        if (jobDetail.InsertNewOrderdetail(id, "ชั่งออก", int.Parse(lblWeight.Text)))
                                        {
                                            BeginInvoke(new MethodInvoker(delegate ()
                                            {
                                                msg.Show(this, "บันทึกรายการชั่งออกสำเร็จ", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                                            }));

                                            // อัพเดทสถานะงานเนื่องจากครบกระบวนการชั่งแล้ว
                                            if (!job.updateStatus(id))
                                            {
                                                BeginInvoke(new MethodInvoker(delegate ()
                                                {
                                                    msg.Show(this, "บันทึกรายการชั่งออกไม่สำเร็จ " + jobDetail.ERR, Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                                                }));
                                            }

                                            isSuccess = true;
                                        }
                                        else
                                        {
                                            BeginInvoke(new MethodInvoker(delegate ()
                                            {
                                                msg.Show(this, "บันทึกรายการชั่งออกไม่สำเร็จ " + jobDetail.ERR, Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                                            }));
                                        }
                                    }
                                }
                            }
                            break;
                    }

                    if (isSuccess)
                    {
                        isGetCam = true;
                        pnText.Enabled = false;
                        // ShowData
                        if (job.selectOrderProcess())
                        {
                            DataTable tb = new DataTable();
                            tb.Columns.Add("id");
                            tb.Columns.Add("jobOrder");
                            tb.Columns.Add("licenseHead");
                            tb.Columns.Add("licenseTail");
                            tb.Columns.Add("weight");
                            foreach (DataRow rw in job.tb.Rows)
                            {
                                string id = rw["id"].ToString();
                                string job = rw["jobOrder"].ToString();
                                string licenseHead = rw["licenseHead"].ToString();
                                string licenseTail = rw["licenseTail"].ToString();
                                string weight = rw["weight"].ToString();
                                tb.Rows.Add(id, job, licenseHead, licenseTail, weight);
                            }
                            dgvdata.DataSource = tb;
                        }
                        else
                        {
                            msg.Show(this, $"ไม่สามารถดึงข้อมูลรายการชั่งได้ {job.ERR}", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                            return;
                        }

                        await Task.Delay(1000);
                        await Task.Run(async () =>
                        {
                            await GetCam();
                        });
                    }
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
