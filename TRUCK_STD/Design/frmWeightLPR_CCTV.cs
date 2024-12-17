
using Guna.UI2.WinForms;
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
    public partial class frmWeightLPR_CCTV : Form
    {
        public frmWeightLPR_CCTV()
        {
            InitializeComponent();

        }
        string wghOld = "";
        string wghNew = "";
        string optionCam = ":network-caching=0|:file-caching=100";
        private double lastWeight = 0;
        private double newWeight = 0;
        private bool isStable = true;
        private bool isGetCam = true;
        private string id = "";
        // สำหรับเก็บค่าทะเบียนรถ
        string licenPlate = "";
        private string picture = "";  // รูปภาพแนวกว้าง
        private string picturePlate = "";  // รูปภาพทะเบียนรรถุ

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
        //async Task ConnectCCTV(string ip, int port, string user, string password, string position)
        //{
        //    BeginInvoke(new MethodInvoker(async delegate ()
        //    {
        //        CCTV cCTV = new CCTV();
        //        cCTV.ip = ip;
        //        cCTV.port = port.ToString();
        //        cCTV.user = user;
        //        cCTV.pass = password;
        //        cCTV.option = optionCam.Split('|');

        //        // สร้างกล้อง
        //        ucCCTV ucCCTv = new ucCCTV();

        //        ucCCTv.Show();
        //        ucCCTv.lblIP.Text = ip;
        //        ucCCTv.lblPort.Text = port.ToString();
        //        ucCCTv.lblUser.Text = user;
        //        ucCCTv.lblPass.Text = password;
        //        ucCCTv.lblPosition.Text = position;
        //        flpCamera.Controls.Add(ucCCTv);


        //        if (await cCTV.SetCamera(ucCCTv.vlcCam))
        //        {
        //            ucCCTv.lblStatus.Text = $"เชื่อมต่อสำเร็จ";
        //            ucCCTv.lblStatus.ForeColor = System.Drawing.Color.Green;
        //            ucCCTv.btnZoom.Enabled = true;

        //            //await Task.Run(async () => await GetParameterCam());
        //        }
        //        else
        //        {
        //            ucCCTv.lblStatus.Text = $"เชื่อมต่อไม่สำเร็จ";
        //            ucCCTv.lblStatus.ForeColor = System.Drawing.Color.Red;
        //        }
        //    }));
        //}

        /// <summary>
        /// เปิดการประตู
        /// </summary>
        /// <param name="gate"></param>
        async void OpenGate(string gate)
        {
            switch (gate)
            {
                case "IN":
                    barrier.Gate1("OPEN", saPLC);
                    await Task.Delay(5000);
                    barrier.Gate1("CLOSE", saPLC);
                    break;
                case "OUT":
                    barrier.Gate2("OPEN", saPLC);
                    await Task.Delay(5000);
                    barrier.Gate2("CLOSE", saPLC);
                    break;
            }
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
        /// ใชสำหรับอ่านค่าจากกล้องเมื่อ
        /// </summary>
        /// <param name="_picture">รูปภาพมุมกว้าง</param>
        /// <param name="_picturePlate">รูปภาพทะเบียนรถ</param>
        /// <param name="_licensePlate">อักษรทะเบียนรถ</param 
        async void CheckDataWhenReadLPR(string _picture, string _picturePlate, string _licensePlate)
        {
            // แสดงรูปภาพ
            BeginInvoke(new MethodInvoker(delegate ()
            {
                pnText.Enabled = true;
                pictureBox1.Image = ConvertToImage(_picturePlate);
                pictureBox3.Image = ConvertToImage(_picture);
                label4.Text = _licensePlate;
                lblLicense.Text = _licensePlate;
            }));

            // กำหนดค่าตัวแปร
            picture = _picture;
            picturePlate = _picturePlate;

            bool isWeighthave = false;
            string license = "";
            foreach (DataGridViewRow rw in dgvdata.Rows)
            {
                license = rw.Cells["cl_licenseHead"].Value.ToString();

                if (lblLicense.Text == license) // หากเช็คแล้วเหมือนกันหมายถึงต้องบันทึกขาออก
                {
                    isWeighthave = true;

                    string weightIn = rw.Cells["cl_weightIn"].Value.ToString();
                    string licenseTail = rw.Cells["cl_licenseTail"].Value.ToString();
                    string note = rw.Cells["cl_objective"].Value.ToString();
                    string cus = $"{rw.Cells["cl_customerId"].Value} | {rw.Cells["cl_customerName"].Value}";
                    string pro = $"{rw.Cells["cl_productId"].Value} | {rw.Cells["cl_productName"].Value}";
                    id = rw.Cells["cl_id"].Value.ToString();

                    await Task.Delay(200);
                    BeginInvoke(new MethodInvoker(delegate ()
                    {
                        txtWeightIn.Text = weightIn;
                        txtLicenseTail.Text = licenseTail;
                        txtNote.Text = note;
                        cbbCustomer.Items.Clear();
                        cbbProduct.Items.Clear();
                        cbbCustomer.Items.Add(cus);
                        cbbProduct.Items.Add(pro);
                        cbbCustomer.SelectedIndex = 0;
                        cbbProduct.SelectedIndex = 0;
                    }));
                    break;
                }
            }

            if (isWeighthave)
            {
                // WeightOut
                BeginInvoke(new MethodInvoker(delegate ()
                {
                    foreach (Guna2TextBox txt in pnText.Controls.OfType<Guna2TextBox>())
                    {
                        txt.ReadOnly = true;
                    }
                    pnText.Enabled = true;
                    txtOther.Enabled = true;
                    txtOther.ReadOnly = false;
                }));
            }
            else // WeightIn
            {
                Console.WriteLine(lblLicense.Text);
                BeginInvoke(new MethodInvoker(delegate ()
                {
                    foreach (Guna2TextBox txt in pnText.Controls.OfType<Guna2TextBox>())
                    {
                        txt.ReadOnly = false;
                    }
                    pnText.Enabled = true;
                    txtWeightIn.Enabled = false;
                    txtOther.Enabled = false;
                }));
            }
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
            while (isGetCam)
            {
                // Read Cam1
                await Service.lpr.CheckLicenPlate(vlcFront.Tag.ToString());
                if (await Service.lpr.GetLicensPlate(vlcFront.Tag.ToString()))
                {
                    if (int.Parse(lblWeight.Text) <= 100)
                    {
                        if (registy.function.BARRIERState == "TRUE")
                        {
                            Task.Run(async () => { OpenGate("IN"); });
                        }

                        CheckDataWhenReadLPR(Service.lpr.Picture1, Service.lpr.licenPlate1, Service.lpr.licens1);
                        isGetCam = false;
                        return;
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


                // Read Cam1
                await Service.lpr.CheckLicenPlate(vlcBack.Tag.ToString());
                if (await Service.lpr.GetLicensPlate(vlcBack.Tag.ToString()))
                {
                    if (int.Parse(lblWeight.Text) <= 100)
                    {
                        if (registy.function.BARRIERState == "TRUE")
                        {
                            Task.Run(async () => { OpenGate("OUT"); });
                        }

                        CheckDataWhenReadLPR(Service.lpr.Picture2, Service.lpr.licenPlate2, Service.lpr.licens2);
                        isGetCam = false;
                        return;
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

        async Task ResetCam(string _ip)
        {
            Console.WriteLine("Resecam " + _ip);
            await Service.lpr.ResetLicensePlate(_ip);
        }

        void ShowData()
        {
            // แสดงข้อมูลค้างชั่ง
            if (job.selectOrderProcess())
            {
                DataTable tb = new DataTable();
                tb.Columns.Add("id");
                tb.Columns.Add("jobOrder");
                tb.Columns.Add("licenseHead");
                tb.Columns.Add("licenseTail");
                tb.Columns.Add("weight");
                tb.Columns.Add("note");
                tb.Columns.Add("customerId");
                tb.Columns.Add("customerName");
                tb.Columns.Add("productId");
                tb.Columns.Add("productName");
                foreach (DataRow rw in job.tb.Rows)
                {
                    string id = rw["id"].ToString();
                    string job = rw["jobOrder"].ToString();
                    string licenseHead = rw["licenseHead"].ToString();
                    string licenseTail = rw["licenseTail"].ToString();
                    string weight = rw["weight"].ToString();
                    string note = rw["note"].ToString();
                    string customerId = rw["customerId1"].ToString();
                    string customerName = rw["customerName"].ToString();
                    string productId = rw["productId1"].ToString();
                    string productName = rw["productName"].ToString();
                    tb.Rows.Add(id, job, licenseHead, licenseTail, weight, note, customerId, customerName, productId, customerName);
                }
                dgvdata.DataSource = tb;
            }
            else
            {
                msg.Show(this, $"ไม่สามารถดึงข้อมูลรายการชั่งได้ {job.ERR}", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                return;
            }
        }

        async void AddWeightIn()
        {
            string[] cusSplit = cbbCustomer.Text.Split('|');
            string[] proSplit = cbbProduct.Text.Split('|');
            string customerId = customer.SelectChar(cusSplit[1].Trim());
            string productId = product.SelectChar(proSplit[1].Trim());
            if (job.AddNewOrder(lblLicense.Text, txtLicenseTail.Text, customerId, productId, txtPriceProduct.Text, lblWeight.Text, picturePlate, picture, "-"))
            {
                // แสดงข้อมูลว่าบันทึกสำเร็จ
                msg.Show(this, "Save to data success", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);
                // เครีย์
                ClearFormToReady();
                isGetCam = true;
                await Task.Delay(1000);
            }
        }

        async Task<bool> AddWeightOut()
        {
            // เช็คค่าว่าง
            foreach (Guna2TextBox txt in pnText.Controls.OfType<Guna2TextBox>())
            {
                if (txt.Text == "" && cbbCustomer.Text != "" && cbbProduct.Text != "")
                {
                    msg.Show(this, "กรุณากรอกข้อมูลให้ครบก่อนการบันทึก", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 3000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);
                    return false;
                }
            }

            if (jobDetail.InsertNewOrderdetail(int.Parse(id), "ชั่งออก", int.Parse(lblWeight.Text), picturePlate, picture, "-"))
            {
                // เครีย์
                ClearFormToReady();
                isGetCam = true;
                await Task.Delay(1000);
                // Print()
            }
            return true;
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
                    return;
                }
            }
            else
            {
                MessageBox.Show("โปรแกรมยังไม่ได้ตั้งค่าการเชื่อมต่อ เครื่องชั่ง กรุณาไปที่หน้าตั้งค่าเพื่อกำหนดการเชื่อมต่อ", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
            #endregion

            #region PLC barrier
            if (registy.function.BARRIERState == "TRUE")
            {
                // เช็คการเชื่อมต่อ น้ำหนัก
                if (barrier.ChcekPort())
                {
                    // กำหนดค่าการเชื่อมต่อ
                    if (!barrier.Connect(saPLC))
                    {
                        MessageBox.Show("เกิดข้อผิดผลาดในการเชื่อมต่อไม่กั้น" + barrier.ERR, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("โปรแกรมยังไม่ได้ตั้งค่าการเชื่อมต่อ เครื่องชั่ง กรุณาไปที่หน้าตั้งค่าเพื่อกำหนดการเชื่อมต่อ", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
            }
            #endregion

            // แสดงข้อมูลค้างชั่ง
            ShowData();
            // เชื่อมต่อกล้อง
            if (!await DefineCamAndConnectCam(vlcFront, "หน้า"))
            {
                Application.Exit();
            }

            // เชื่อมต่อกล้อง
            if (!await DefineCamAndConnectCam(vlcBack, "หลัง"))
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
            //ask.Run(async () => await GetCamOut());
            await Task.Delay(2000);
            BeginInvoke(new MethodInvoker(delegate ()
            {
                this.Enabled = true;
            }));

            //#region CAMERA
            //// เช็คว่ามีฟั่งชั่น  Camera หรือไม่
            //if (registy.function.CAMERAState == "TRUE")
            //{
            //    if (!cctvs.Select()) { this.Close(); }

            //    if (cctvs.tb.Rows.Count == 0)
            //    {
            //        // return ค่าให้ไปกำหนดค่าก่อน
            //        MessageBox.Show("ระบบยังไม่ได้กำหนดค่ากล้องกรุณาตั้งค่าก่อน", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        this.Close();
            //    }
            //    else
            //    {
            //        flpCamera.Controls.Clear();
            //        foreach (DataRow item in cctvs.tb.Rows)
            //        {
            //            // หากมีข้อมูลอยู่แล้วให้ลูปสร้างกล้อง
            //            string _ip = item["ip"].ToString();
            //            string _port = item["port"].ToString();
            //            string _user = item["user"].ToString();
            //            string _pass = item["password"].ToString();
            //            string _position = item["position"].ToString();
            //            Task.Run(async () => await ConnectCCTV(_ip, int.Parse(_port), _user, _pass, _position));
            //        }  
            //    }  
            //} 
            //#endregion

            #region BARIER
            // เช็คว่ามีฟังชั่ง ไม้กั้นหรอไม่
            if (registy.function.BARRIERState == "TRUE")
            {

            }
            #endregion
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

        private void frmNewWeight_FormClosing(object sender, FormClosingEventArgs e)
        {
            scales.Disconnect(saScale);
            this.Enabled = false;
            isGetCam = false;
            Thread.Sleep(5000);
        }

        private async void btnCancelWeight_Click(object sender, EventArgs e)
        {
            msgD.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;
            msgD.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
            msgD.Style = Guna.UI2.WinForms.MessageDialogStyle.Light;

            DialogResult reult = msgD.Show("Do you want to canncel?", "Cancel");
            if (reult == DialogResult.Yes)
            {
                ClearFormToReady();
                // Get cam

                await Task.Delay(2000);
                // ทำการอ่านทะเบียนรถขาเข้า
                Task.Run(async () => await GetCamIn());
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // เช็คน้ำหนักต้องมากกว่า 1000 kg
                if (int.Parse(lblWeight.Text) <= 1000)
                {
                    msg.Show(this, "น้ำหนักน้อยเกินกว่าจะบันทึกได้", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 3000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);
                }

                // เช็คว่าจะต้องชั่งเข้าหรือช้่งออกโดยเช็คจาก datagridview
                bool isWeightOut = false;
                if (dgvdata.Rows.Count == 0)
                {
                    isWeightOut = false;
                }

                foreach (DataGridViewRow rw in dgvdata.Rows)
                {
                    string license = rw.Cells["cl_licenseHead"].Value.ToString();

                    if (lblLicense.Text == license) // หากเช็คแล้วเหมือนกันหมายถึงต้องบันทึกขาออก
                    {
                        isWeightOut = true;
                        break;
                    }
                }


                switch (isWeightOut)
                {
                    case false: // Save to weightIn
                        AddWeightIn();
                        break;
                    case true: // Save to weightOut

                        if (!await AddWeightOut())
                        {
                            return;
                        }
                        break;
                }


                ShowData();
                await ResetCam(vlcBack.Tag.ToString());
                await ResetCam(vlcFront.Tag.ToString());
                await Task.Delay(2000);
                // ทำการอ่านทะเบียนรถขาเข้า
                Task.Run(async () => await GetCamIn());
                // Task.Run(async () => await GetCamOut());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        async void ClearFormToReady()
        {
            // Clear text
            foreach (Guna2TextBox txt in pnText.Controls.OfType<Guna2TextBox>())
            {
                txt.Clear();
            }

            pnText.Enabled = false;
            lblLicense.Text = "----";
            await Task.Delay(150);
            cbbCustomer.Items.Clear();
            cbbProduct.Items.Clear();

            // แสดงข้อมูลค้างชั่ง
            ShowData();

            await ResetCam(vlcBack.Tag.ToString());
            await ResetCam(vlcFront.Tag.ToString());
            isGetCam = true;
        }

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = dgvdata.Rows[e.RowIndex].Cells["cl_id"].Value.ToString();

                string names = dgvdata.Columns[e.ColumnIndex].Name.ToString();
                switch (names)
                {
                    case "cl_del":
                        msgD.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;
                        msgD.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
                        msgD.Style = Guna.UI2.WinForms.MessageDialogStyle.Light;

                        DialogResult reult = msgD.Show("Do you want to canncel?", "Cancel");
                        if (reult == DialogResult.Yes)
                        {
                            if (job.deleteOrdet(int.Parse(id)))
                            {
                                id = "";
                                ShowData();
                            }
                        }
                        break;
                    case "cl_print":
                        break;
                }
            }
            catch (Exception)
            {

            }
        }

        private void SelectItems(object sender, EventArgs e)
        {
            Guna2ComboBox cbb = sender as Guna2ComboBox;

            string cbbType = cbb.Tag.ToString();

            switch (cbbType)
            {
                case "product":

                    if (product.Select())
                    {
                        cbb.Items.Clear();
                        foreach (DataRow rw in product.tb.Rows)
                        {
                            string id = rw["productId"].ToString();
                            string productName = rw["productName"].ToString();

                            string value = $"{id} | {productName}";
                            cbb.Items.Add(value);
                        }
                    }

                    break;
                case "customer":
                    if (customer.Select())
                    {
                        cbb.Items.Clear();
                        foreach (DataRow rw in customer.tb.Rows)
                        {
                            string id = rw["customerId"].ToString();
                            string customerName = rw["customerName"].ToString();

                            string value = $"{id} | {customerName}";
                            cbb.Items.Add(value);
                        }
                    }
                    break;
            }
        }

        private void pnText_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvdata_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
