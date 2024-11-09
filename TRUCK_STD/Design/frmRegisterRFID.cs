
using Guna.UI2.WinForms;
using Serilog;
using System;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using System.Windows.Forms;
using ThaiNationalIDCard;
using TRUCK_STD.DbCenter;
using TRUCK_STD.Functions;
using TRUCK_STD.Models;
using TRUCK_STD.UControls;

namespace TRUCK_STD.Design
{
    public partial class frmRegisterRFID : Form
    {
        public frmRegisterRFID()
        {
            InitializeComponent();
            // จัดหน้าตำแหน่งโปรแกรม
            this.TopMost = false;
            this.WindowState = FormWindowState.Maximized;
        }

        bool isIdCardReady = false;
        bool isRfidReady = false;
        string id = "";
        string oldHex = "BD 03 01 01 BE"; // กำหนดค่าเริ่มต้นให้อ่านบัตรไม่เจอ
        bool RFIDReady = false;
        ThaiIDCard idcard = new ThaiIDCard();



        #region DATABASE
        /// <summary>
        /// สำหรับเชื่อมต่อไปที่ฐานข้อมูล
        /// </summary>
        /// <returns></returns>
        async Task<bool> ConnnectDatabase()
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
                    pgbProcess.Animated = false;
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

        /// <summary>
        /// ดึงข้อมูลมาแสดง ทะเบียนรถวันนั้น ๆ 
        /// </summary>
        void GetaData()
        {
            BeginInvoke(new MethodInvoker(delegate ()
            {
                // เครีย์หน้าจอ
                flpPendding.Controls.Clear();
                flpProcess.Controls.Clear();
                flpSuccess.Controls.Clear();
                // Get data
                if (job.Select_Today())
                {
                    int pendding = 0;
                    int process = 0;
                    int success = 0;
                    pgbPendding.Maximum = job.tb.Rows.Count;
                    pgbProcess.Maximum = job.tb.Rows.Count;
                    pgbSuccess.Maximum = job.tb.Rows.Count;
                    bool isAlready = false;
                    foreach (DataRow rw in job.tb.Rows)
                    {
                        // Define parameter
                        string licenseHead = rw["licenseHead"].ToString();
                        string provniceHead = rw["provniceHead"].ToString();
                        string licenseTail = rw["licenseTail"].ToString();
                        string provniceTail = rw["provniceTail"].ToString();
                        string fullnames = rw["fullname"].ToString();
                        string objects = rw["objective"].ToString();
                        string status = rw["status"].ToString();

                        string license = $"{licenseHead}";
                        //Check license
                        if (licenseTail != "-")
                            license = license + "/" + licenseTail;

                        ucRFID ucRFID = new ucRFID();
                        foreach (Label item in ucRFID.pnData.Controls.OfType<Label>())
                        {
                            item.ForeColor = System.Drawing.Color.White;
                        }

                        ucRFID.lblLicense.Text = license;
                        ucRFID.lblFullname.Text = fullnames;
                        ucRFID.lblObject.Text = objects;


                        // Check status 
                        switch (status)
                        {
                            case "Pendding":
                                ucRFID.pnData.FillColor = pnWait.FillColor2;
                                ucRFID.pnData.FillColor2 = pnWait.FillColor;
                                foreach (ucRFID item in flpPendding.Controls.OfType<ucRFID>())
                                {
                                    if (item.lblLicense.Text == license)
                                    {
                                        isAlready = true;
                                    }
                                }
                                if (!isAlready)
                                {
                                    flpPendding.Controls.Add(ucRFID);
                                    pendding++;
                                }
                                break;
                            case "Process":
                                ucRFID.pnData.FillColor = pnProcess.FillColor2;
                                ucRFID.pnData.FillColor2 = pnProcess.FillColor;
                                foreach (ucRFID item in flpProcess.Controls.OfType<ucRFID>())
                                {
                                    if (item.lblLicense.Text == license)
                                    {
                                        isAlready = true;
                                    }
                                }
                                if (!isAlready)
                                {
                                    flpProcess.Controls.Add(ucRFID);
                                    process++;
                                }
                                break;
                            case "Success":
                                ucRFID.pnData.FillColor = pnSuccess.FillColor2;
                                ucRFID.pnData.FillColor2 = pnSuccess.FillColor;
                                foreach (ucRFID item in flpSuccess.Controls.OfType<ucRFID>())
                                {
                                    if (item.lblLicense.Text == license)
                                    {
                                        isAlready = true;
                                    }
                                }
                                if (!isAlready)
                                {
                                    flpSuccess.Controls.Add(ucRFID);
                                    success++;
                                }
                                break;
                        }
                        ucRFID.Show();
                    }
                    pgbPendding.Value = pendding;
                    pgbProcess.Value = process;
                    pgbSuccess.Value = success;
                    pgbPendding.Animated = true;
                    pgbProcess.Animated = true;
                    pgbSuccess.Animated = true;
                }
            }));
        }
        /// <summary>
        /// สำหรับดึงข้อมูลจากฐานข้อมูลวันต่อวัน
        /// </summary>
        /// <returns></returns>
        async void GetDataToday()
        {
            while (true)
            {
                GetaData();
                await Task.Delay(15000);
            }
        }

        /// <summary>
        /// สำหรับข้อหาข้อมูลจากฐานข้อมูล โดยใช้เลขบัตรประชาชน
        /// </summary>
        /// <param name="idCard">เลขบัตรประชาชน</param>
        void GetDataFromIdCard(string idCard)
        {
            // เมื่อได้เลขบัตรประชาชนแล้ว
            if (job.SelectSearchIdCardToday(idCard))
            {
                // ตรวจสอบว่าพบรายการหรือไม่
                if (job.tb.Rows.Count != 0)  // มีรายการเข้ามาแต่ต้องเช็คว่าเป็นสถานะอะไร
                {
                    // นำข้อมูลล่าสุดที่ได้มาเช็คว่าเป็นสถานะอะไร 
                    foreach (DataRow rw in job.tb.Rows)
                    {
                        string status = rw["status"].ToString();
                        switch (status)
                        {
                            case "Process":
                                msg.Show(this, "พบรายการนี้กำลังชั่งน้ำหนักอยู่", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 3000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);
                                lblLicenHead.Text = "--";
                                lblLicenTail.Text = "--";
                                lblProvniceHead.Text = "--";
                                lblProvniceTail.Text = "--";
                                lblObject.Text = "--";
                                lblFullName.Text = "--";
                                lblIdCard.Text = "--";
                                lblMessageIdCard.Text = "กรณาเสียบบัตรประชาชน";
                                lblMessageIdCard.BackColor = System.Drawing.Color.Red;
                                // กำหนดตัวแปรว่า idCard ไม่พร้อมให้ผูกบัตรกับข้อมูล
                                isIdCardReady = false;
                                break;
                            case "Pendding":
                                string licenseHead = rw["licenseHead"].ToString();
                                string provniceHead = rw["provniceHead"].ToString();
                                string licenseTail = rw["licenseTail"].ToString();
                                string provniceTail = rw["provniceTail"].ToString();
                                string objects = rw["objective"].ToString();
                                string full = rw["fullName"].ToString();

                                lblIdCard.Text = idCard;
                                lblFullName.Text = full;
                                lblLicenHead.Text = licenseHead;
                                lblLicenTail.Text = licenseTail;
                                lblProvniceHead.Text = provniceHead;
                                lblProvniceTail.Text = provniceTail;
                                lblObject.Text = objects;
                                id = rw["id"].ToString();

                                lblMessageIdCard.Text = "บัตรประชาชนพร้อม";
                                lblMessageIdCard.BackColor = System.Drawing.Color.Green;
                                // กำหนดค่าเลขบัตรประชาชนนี้พร้อมให้ใช้งาน
                                isIdCardReady = true;
                                break;
                        }
                        break;
                    }
                }
            }
        }
        #endregion

        #region RFID
        /// <summary>
        /// เชื่อมต่อ RFID
        /// </summary>
        void RFIDConnect()
        {
            saRFID.PortName = registy.function.RFID_COM;
            saRFID.BaudRate = int.Parse(registy.function.RFID_BAUDRATE);
            saRFID.Open();
        }


        /// <summary>
        /// สำหรับตัดการเชื่อมต่อ RFID
        /// </summary>
        void RFIDDisconnect()
        {
            if (saRFID.IsOpen)
            {
                saRFID.Close();
            }
        }

        /// <summary>
        /// อ่าน RFID
        /// </summary>
        /// <returns></returns>
        async Task ReadRFID()
        {
            while (RFIDReady)
            {
                BeginInvoke(new MethodInvoker(async delegate ()
                {
                    await ReadRfid();

                }));
                await Task.Delay(100);
            }
        }
        /// <summary>
        /// อ่าน RFID
        /// </summary>
        /// <returns></returns>
        async Task ReadRfid()
        {
            try
            {
                // เช็คว่าพร้อมหรือยัง
                if (!RFIDReady)
                    return;

                // กำหนด Byte
                byte[] select = new byte[30];

                select[0] = 186;
                select[1] = 2;
                select[2] = 1;
                select[3] = 185;
                // Send command
                saRFID.Write(select, 0, select[1] + 2);

                int intBytes = saRFID.BytesToRead;
                byte[] bytes = new byte[intBytes];
                saRFID.Read(bytes, 0, intBytes);

                string hexString = BitConverter.ToString(bytes).Replace("-", " ");
                // Read response
                if (bytes.Length == 5) // ไม่พบเลขบัตร
                {
                    // เปลี่ยนค่าที่ได้จากการอ่านเป็น HEX
                    lblMessageRFID.Text = "กรุณาวางบัตร RFID ที่เครื่องอ่าน";
                    lblMessageRFID.BackColor = System.Drawing.Color.Red;
                    lblEPC.Text = "--";
                    //isRfidReady = false;
                }
                else if (bytes.Length == 10) // พบเลขบัตร
                {
                    lblMessageRFID.Text = "วางบัตร RFID เรียบร้อย";
                    lblMessageRFID.BackColor = System.Drawing.Color.Green;
                    Console.WriteLine(hexString);
                    // กำหนดสีให้ ค่าที่อ่านจาก RFID 
                    lblEPC.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
                    lblEPC.Text = hexString;
                    //isRfidReady = true;
                }

                if (oldHex == hexString)
                {
                    return;
                }
                else
                {
                    oldHex = hexString;
                }

                // นำข้อมูล RFID ไปค้นหาว่ามีการใช้งานหรือไม่
                if (oldHex != "BD 03 01 01 BE" && oldHex != "" && isIdCardReady)  // ข้อมูล RFID ต้องไม่ว่างและเลขที่บัตรประชาชนต้องพร้อมให้ผู้ข้อมูล
                {
                    if (job.SelectSearchRFIDToday(hexString))
                    {
                        // เช็คว่าพบบัตรกำลังใช้งานหรือไม่
                        if (job.tb.Rows.Count != 0) // หากพบบัตรให้ดีดออก
                        {
                            msg.Show(this, "พบว่าบัตรนี้มีการใช้งานอยู่", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 3000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);
                            return;
                        }

                        // นำเลขบัตรประชาชนไปค้นหาเพื่อเอาเลข ID
                        jobModels jobModels = new jobModels();
                        jobModels = new jobModels
                        {
                            idCard = lblIdCard.Text
                        };

                        if (job.SelectGetId(jobModels))
                        {
                            // loop get ip
                            foreach (DataRow rw in job.tb.Rows)
                            {
                                // ดึงค่า ID มาเก็บไว้ที่ตัวแปร
                                string _id = rw["id"].ToString();

                                // กำหนดค่าเพื่อไปอัพเดทและปรับสถานะ
                                jobModels = new jobModels
                                {
                                    epc = hexString,
                                    status = "Process",
                                    id = id
                                };

                                if (job.UpdateStatusAndEPC(jobModels))
                                {
                                    // แสดงข้อมูล
                                    GetaData();
                                    msg.Show(this, "ผูกข้อมูลสำเร็จ", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);
                                    // เครียข้อมูล
                                    txtSearchId.Clear();
                                }
                            }
                        }
                    }
                }
                else if (oldHex != "BD 03 01 01 BE" && oldHex != "") // แต่ถ้าข้อมูลบัตรไม่ว่าและเลขบัตรประชาชนไม่พร้อมให้ผูกข้อมูล หมายถึงต้องการที่จะออกจากโรงงาน
                {
                    // ตรวจสอบว่า RFID นั้นชั่งครบรายการแล้วหรือยัง
                    if (job.SelectSearchWeight(hexString))
                    {
                        if (job.tb.Rows.Count == 1) // 1 = เจอรายการการชั่งที่ยังไม่สำเร็จ
                        {
                            msg.Show(this, "พบว่าบัตรนี้มีการใช้งานอยู่", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 3000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);
                        }
                        else // หากเป็น 2 หมายความว่า บัตรนี้มีการชั่งเรียบร้อยให้ปรับสถานะ
                        {
                            // ดึงค่า ID มาเพื่อเก็บมาอีพเดท
                            foreach (DataRow rw in job.tb.Rows)
                            {
                                string _id = rw["id"].ToString();
                                // กำหนดค่า
                                jobModels jobModels = new jobModels()
                                {
                                    epc = hexString,
                                    status = "Success",
                                    id = _id
                                };

                                if (job.UpdateStatusAndEPC(jobModels))
                                {
                                    GetaData();
                                    msg.Show(this, "บันทึกการชั่งทั้งหมดสำเร็จ", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);
                                }
                            }
                        }
                    }
                }

                lblRFIDReader.ForeColor = System.Drawing.Color.Green;
                lblRFIDReader.Text = "เชื่อมต่อสำเร็จ";
                await Task.Delay(500);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                lblRFIDReader.ForeColor = System.Drawing.Color.Red;
                lblRFIDReader.Text = "เชื่อมต่อไม่สำเร็จ";
                RFIDReady = false;
            }

        }
        #endregion

        #region SMART_CARD

        /// <summary>
        /// สำหรับเชื่อต่อ smartcard reader
        /// </summary>
        async void GetSmartCardReader()
        {
            while (true)
            {
                try
                {

                    string[] readers = idcard.GetReaders();

                    if (readers == null)
                    {
                        BeginInvoke(new MethodInvoker(delegate ()
                        {
                            lblSmartCard.Text = "เชื่อมต่อไม่สำเร็จ";
                            lblSmartCard.ForeColor = System.Drawing.Color.Red;
                        }));
                    }
                    else
                    {
                        BeginInvoke(new MethodInvoker(delegate ()
                        {
                            lblSmartCard.Text = "เชื่อมต่อสำเร็จ";
                            lblSmartCard.ForeColor = System.Drawing.Color.Green;
                        }));
                    }

                }
                catch (Exception ex)
                {
                    BeginInvoke(new MethodInvoker(delegate ()
                    {
                        lblSmartCard.Text = "เชื่อมต่อไม่สำเร็จ";
                        lblSmartCard.ForeColor = System.Drawing.Color.Red;
                    }));
                }

                await Task.Delay(1000);
            }
        }

        /// <summary>
        /// สำหรับเรียกดูรายชื่อเครื่องอ่าน
        /// </summary>
        /// <returns></returns>
        string[] GetSmartCard()
        {
            return idcard.GetReaders();
        }

        /// <summary>
        /// สำหรับจับตาดูเหตุการณ์
        /// </summary>
        /// <param name="device"></param>
        void MonitorStart(string device)
        {
            idcard.MonitorStart(device);
        }

        private void Idcard_eventCardInsertedWithPhoto1(ThaiNationalIDCard.Personal personal)
        {
            BeginInvoke(new MethodInvoker(delegate ()
            {

                lblFullName.Text = $"{personal.Th_Firstname}  {personal.Th_Lastname}";
                lblIdCard.Text = personal.Citizenid;
                picImage.Image = personal.PhotoBitmap;
                lblMessageIdCard.Text = "บัตรประชาชนพร้อม";
                lblMessageIdCard.BackColor = System.Drawing.Color.Green;
                gbReadSmartCard.Visible = false;
                pnSmart.Visible = true;

                GetDataFromIdCard(personal.Citizenid);
            }));
        }

        private void Idcard_eventCardRemoved()
        {
            BeginInvoke(new MethodInvoker(delegate ()
            {
                lblFullName.Text = "";
                lblIdCard.Text = "";
                picImage.Image = null;
                lblMessageIdCard.Text = "กรุณาเสียบบัตรประชาชน";
                lblMessageIdCard.BackColor = System.Drawing.Color.Red;
            }));
        }

        private void Idcard_eventPhotoProgress(int value, int maximum)
        {
            BeginInvoke(new MethodInvoker(delegate ()
            {
                pnSmart.Visible = false;
                gbReadSmartCard.Visible = true;

            }));
        }
        #endregion

        void ShowObjectCenterScreen(Guna2GroupBox gb)
        {
            // หน้าหน้าสำหรับเชื่อมต่อ
            int x = (this.Width - gb.Width) / 2;
            int y = (this.Height - gb.Height) / 2;
            gb.Location = new Point(x, y);
            gb.Visible = true;
        }
        private void frmRFID_Load(object sender, EventArgs e)
        {
            // ตรวสอบว่า มีการตั้งค่าการเชื่อมต่อ RFID หรือยัง
            if (registy.function.RFID_COM == "" || registy.function.RFID_BAUDRATE == "")
            {
                MessageBox.Show("ระบบยังไม่ได้ตั้งค่าการเชื่อมต่อ RFID กรุณาตั้งค่าก่อนการใช้งาน", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ShowObjectCenterScreen(gbSetting);
                return;
            }

            // จัดหน้าจอการเชื่อมต่อ
            ShowObjectCenterScreen(gbConnect);


            // กำหนดค่าการเชื่อม่อ
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
                        flpMain.Visible = true;
                    }));
                    // จัดหน้าจอให้อยู่ตรงกลาง
                    foreach (Guna2GroupBox item in flpMain.Controls.OfType<Guna2GroupBox>())
                    {
                        BeginInvoke(new MethodInvoker(delegate ()
                        {
                            int width = (flpMain.Width / 4) - 10;
                            int heigth = flpMain.Height - 10;
                            item.Size = new System.Drawing.Size(width, heigth);
                        }));
                    }
                    // แสดงข้อมูล
                    Task.Run(GetDataToday);
                    Task.Run(GetSmartCardReader);
                    RFIDReady = true;
                    Task.Run(ReadRFID);
                }
            });
            // เชื่อมต่อ RFID 
            RFIDConnect();
            // จัดตาเหตุการณ์เครื่องอ่านบัตรประชาช
            MonitorStart(GetSmartCard()[0]);
            // กำหนด เหตุการบัตรเข้าออก
            idcard.eventCardRemoved += Idcard_eventCardRemoved;
            idcard.eventCardInsertedWithPhoto += Idcard_eventCardInsertedWithPhoto1;
            idcard.eventPhotoProgress += Idcard_eventPhotoProgress;
        }



        private async void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            RFIDReady = false;
            await Task.Delay(1000);
            RFIDDisconnect();
            Application.Exit();
        }

        private void txtSearchId_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchId.Text.Length == 13)
            {
                GetDataFromIdCard(txtSearchId.Text);
            }
            else
            {
                lblLicenHead.Text = "--";
                lblLicenTail.Text = "--";
                lblProvniceHead.Text = "--";
                lblProvniceTail.Text = "--";
                lblObject.Text = "--";
                lblFullName.Text = "--";
                lblIdCard.Text = "--";
                lblMessageIdCard.Text = "กรุณาเสียบบัตรประชาชน";
                lblMessageIdCard.BackColor = System.Drawing.Color.Red;
                // กำหนดตัวแปรว่า idCard ไม่พร้อมให้ผูกบัตรกับข้อมูล
                isIdCardReady = false;
            }
        }

        private async void tmReadRfid_Tick(object sender, EventArgs e)
        {
            try
            {
                // เช็คว่าพร้อมหรือยัง
                if (!RFIDReady)
                    return;

                // กำหนด Byte
                byte[] select = new byte[30];

                select[0] = 186;
                select[1] = 2;
                select[2] = 1;
                select[3] = 185;
                // Send command
                saRFID.Write(select, 0, select[1] + 2);

                int intBytes = saRFID.BytesToRead;
                byte[] bytes = new byte[intBytes];
                saRFID.Read(bytes, 0, intBytes);

                string hexString = BitConverter.ToString(bytes).Replace("-", " ");
                // Read response
                if (bytes.Length == 5) // ไม่พบเลขบัตร
                {
                    // เปลี่ยนค่าที่ได้จากการอ่านเป็น HEX
                    lblMessageRFID.Text = "กรุณาวางบัตร RFID ที่เครื่องอ่าน";
                    lblMessageRFID.BackColor = System.Drawing.Color.Red;
                    lblEPC.Text = "--";
                    //isRfidReady = false;
                }
                else if (bytes.Length == 10) // พบเลขบัตร
                {
                    lblMessageRFID.Text = "วางบัตร RFID เรียบร้อย";
                    lblMessageRFID.BackColor = System.Drawing.Color.Green;
                    Console.WriteLine(hexString);
                    // กำหนดสีให้ ค่าที่อ่านจาก RFID 
                    lblEPC.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
                    lblEPC.Text = hexString;
                    //isRfidReady = true;
                }

                if (oldHex == hexString)
                {
                    return;
                }
                else
                {
                    oldHex = hexString;
                }

                // นำข้อมูล RFID ไปค้นหาว่ามีการใช้งานหรือไม่
                if (oldHex != "BD 03 01 01 BE" && oldHex != "" && isIdCardReady)  // ข้อมูล RFID ต้องไม่ว่างและเลขที่บัตรประชาชนต้องพร้อมให้ผู้ข้อมูล
                {
                    if (job.SelectSearchRFIDToday(hexString))
                    {
                        // เช็คว่าพบบัตรกำลังใช้งานหรือไม่
                        if (job.tb.Rows.Count != 0) // หากพบบัตรให้ดีดออก
                        {
                            msg.Show(this, "พบว่าบัตรนี้มีการใช้งานอยู่", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 3000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);
                            return;
                        }

                        // นำเลขบัตรประชาชนไปค้นหาเพื่อเอาเลข ID
                        jobModels jobModels = new jobModels();
                        jobModels = new jobModels
                        {
                            idCard = lblIdCard.Text
                        };

                        if (job.SelectGetId(jobModels))
                        {
                            // loop get ip
                            foreach (DataRow rw in job.tb.Rows)
                            {
                                // ดึงค่า ID มาเก็บไว้ที่ตัวแปร
                                string _id = rw["id"].ToString();

                                // กำหนดค่าเพื่อไปอัพเดทและปรับสถานะ
                                jobModels = new jobModels
                                {
                                    epc = hexString,
                                    status = "Process",
                                    id = id
                                };

                                if (job.UpdateStatusAndEPC(jobModels))
                                {
                                    // แสดงข้อมูล
                                    GetaData();
                                    // แสดงข้อมูลนำบัตร RFID ออก
                                    await Task.Delay(1500);
                                    lblMessageRFID.Text = "กรุณนำบัตร RFID ออก";
                                    lblMessageRFID.BackColor = System.Drawing.Color.Goldenrod;
                                    // เครียข้อมูล
                                    txtSearchId.Clear();
                                    msg.Show(this, "ผูกข้อมูลสำเร็จ", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);
                                }
                            }
                        }
                    }
                }
                else if (oldHex != "BD 03 01 01 BE" && oldHex != "") // แต่ถ้าข้อมูลบัตรไม่ว่าและเลขบัตรประชาชนไม่พร้อมให้ผูกข้อมูล หมายถึงต้องการที่จะออกจากโรงงาน
                {
                    //// ตรวจสอบว่า RFID นั้นชั่งครบรายการแล้วหรือยัง
                    //if (job.SelectSearchRFIDToday(hexString))
                    //{
                    //    if(job.tb.Rows.Count != 0) // ไม่เจอรายการ Pendding or Process = Success
                    //    {
                    //        msg.Show(this, "ไม่พบรายการ");
                    //    }
                    //}
                }

                lblRFIDReader.ForeColor = System.Drawing.Color.Green;
                lblRFIDReader.Text = "เชื่อมต่อสำเร็จ";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                lblRFIDReader.ForeColor = System.Drawing.Color.Red;
                lblRFIDReader.Text = "เชื่อมต่อไม่สำเร็จ";
                tmReadRfid.Stop();
            }
        }

        private void tmcheckData_Tick(object sender, EventArgs e)
        {
            //if (!isIdCardReady)
            //{
            //    lblMessageIdCard.Text = "กรุณาเสียบบัตรประชาชน";
            //    lblMessageIdCard.BackColor = Color.Red;
            //    //if (lblMessageIdCard.Visible == false)
            //    //{
            //    //    lblMessageIdCard.Visible = true;
            //    //}
            //    //else if (lblMessageIdCard.Visible == true)
            //    //{
            //    //    lblMessageIdCard.Visible = false;
            //    //}
            //}
            //else
            //{
            //    //if (lblMessageIdCard.Visible == false)
            //    //    lblMessageIdCard.Visible = true;
            //    lblMessageIdCard.Text = "เสียบบัตรประชาชนเรียบร้อย";
            //    lblMessageIdCard.BackColor = Color.Green;
            //}

            //if (!isRfidReady)
            //{
            //    lblMessageRFID.Text = "กรุณาวางบัตร RFID ที่เครื่องอ่าน";
            //    lblMessageRFID.BackColor = Color.Red;
            //    //if (lblMessageRFID.Visible == false)
            //    //{
            //    //    lblMessageRFID.Visible = true;
            //    //}
            //    //else if (lblMessageRFID.Visible == true)
            //    //{
            //    //    lblMessageRFID.Visible = false;
            //    //}
            //}
            //else
            //{
            //    //if (lblMessageRFID.Visible == false)
            //    //    lblMessageRFID.Visible = true;

            //    lblMessageRFID.Text = "วางบัตร RFID เรียบร้อย";
            //    lblMessageRFID.BackColor = Color.Green;
            //}
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbbComport.Text == "" || cbbBaudrate.Text == "")
            {
                MessageBox.Show("กรุณาใส่ข้อมูลการเชื่อมต่อให้ครบก่อนการบันทึก", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                // กำหนดค่าให้กับ registy
                registy.function.RFID_COM = cbbComport.Text;
                registy.function.RFID_BAUDRATE = cbbBaudrate.Text;
                registy.Set();
                MessageBox.Show("บันทึกการเชื่อมต่อสำเร็จ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
        }

        private void cbbComport_DropDown(object sender, EventArgs e)
        {
            cbbComport.Items.Clear();
            string[] a = SerialPort.GetPortNames();
            foreach (var item in a)
            {
                cbbComport.Items.Add(item.ToString());
            }
        }

        private void cbbBaudrate_DropDown(object sender, EventArgs e)
        {
            cbbBaudrate.Items.Clear();
            cbbBaudrate.Items.Add("9600");
            cbbBaudrate.Items.Add("115200");
        }

        private void BtnReadCard_Click(object sender, EventArgs e)
        {

            Personal personal = idcard.readAllPhoto();
            pnSmart.Visible = false;
            gbReadSmartCard.Visible = true;
            if (personal != null)
            {
                GetDataFromIdCard(personal.Citizenid);
            }
            else
            {
                msg.Show(this, "ไม่พบบัตรประชาชน", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 3000, "OK", Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);
            }
            pnSmart.Visible = true;
            gbReadSmartCard.Visible = false;

        }
    }
}

