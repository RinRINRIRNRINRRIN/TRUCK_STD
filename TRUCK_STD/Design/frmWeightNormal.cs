using Guna.UI2.WinForms;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TRUCK_STD.DbBase;
using TRUCK_STD.Functions;

namespace TRUCK_STD.Design
{
    public partial class frmWeightNormal : Form
    {
        public frmWeightNormal()
        {
            InitializeComponent();

            dgvdata.DefaultCellStyle.ForeColor = Color.Black;
        }
        private double lastWeight = 0;
        private double newWeight = 0;
        private string id = "";

        async Task OpenBarrier()
        {
            // OpenGate
            barrier.Gate1("OPEN", saPLC);
            await Task.Delay(5000);
            // CloseGate
            barrier.Gate1("CLOSE", saPLC);
        }
        /// <summary>
        /// เช็คค่าว่างก่อนทำการบันทึก
        /// </summary>
        /// <param name="weightType">ประเภทการชั่ง ชั่งเข้า , ชั่งออก</param>
        /// <returns></returns>
        bool CheckinformationBeforeSave(string weightType)
        {
            switch (weightType)
            {
                case "IN":
                    foreach (Guna2TextBox item in pnMainInformation.Controls.OfType<Guna2TextBox>())
                    {
                        if (item.Text == "")
                        {
                            msgD.Icon = MessageDialogIcon.Warning;
                            msgD.Buttons = MessageDialogButtons.OK;
                            msgD.Show("Please fill in informaion about weight", "Fill in information before saving");
                            return false;
                        }
                    }
                    break;
                case "OUT":
                    switch (registy.system.bussinessType)
                    {
                        case "ทั่วไป":
                            break;
                        case "หัวมันสด":
                            if (txtPowder.Text == "0" || txtOther.Text == "")
                            {
                                msgD.Icon = MessageDialogIcon.Warning;
                                msgD.Buttons = MessageDialogButtons.OK;
                                msgD.Show("Please fill in the percent flour and others price information before saving", "Fill in information before saving");
                                return false;
                            }
                            break;
                        case "ข้าวเปลือก":
                            if (txtContaminants.Text == "0" || txtOther.Text == "" || txtHumidity.Text == "0")
                            {
                                msgD.Icon = MessageDialogIcon.Warning;
                                msgD.Buttons = MessageDialogButtons.OK;
                                msgD.Show("Please fill in the percent contaminants or percent huminity or others price information before saving", "Fill in information before saving");
                                return false;
                            }
                            break;
                        case "ข้าวโพดเลี้ยงสัตว์":
                            break;
                    }
                    break;
            }

            return true;
        }
        /// <summary>
        /// แสดงข้อมูลการชั่งที่ datagridview
        /// </summary>
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
                tb.Columns.Add("productPrice");

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
                    string productPrice = rw["productPrice"].ToString();
                    tb.Rows.Add(id, job, licenseHead, licenseTail, weight, note, customerId, customerName, productId, productName, productPrice);
                }

                dgvdata.DataSource = tb;
            }
            else
            {
                msg.Show(this, $"ไม่สามารถดึงข้อมูลรายการชั่งได้ {job.ERR}", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                return;
            }
        }
        /// <summary>
        /// เครีย์ฟอร์มให้พร้อมก่อนการชั่ง หรือจากการยกเลิก
        /// /// </summary>
        async void ClearFormToReady()
        {
            string bussiness = registy.system.bussinessType;
            switch (bussiness)
            {
                case "ทั่วไป":
                    pnContaminants.Visible = false;
                    pnHumidity.Visible = false;
                    pnPowder.Visible = false;
                    break;
                case "หัวมันสด":
                    pnContaminants.Visible = false;
                    pnHumidity.Visible = false;
                    pnPowder.Visible = true;
                    pnPowder.Enabled = false;
                    break;
                case "ข้าวเปลือก":
                    pnContaminants.Visible = true;
                    pnContaminants.Enabled = false;
                    pnHumidity.Visible = true;
                    pnHumidity.Enabled = false;
                    pnPowder.Visible = false;
                    break;
                case "ข้าวโพดเลี้ยงสัตว์":
                    pnContaminants.Visible = false;
                    pnHumidity.Visible = true;
                    pnHumidity.Enabled = false;
                    pnPowder.Visible = false;
                    break;
            }

            // Clear text
            foreach (Guna2TextBox txt in pnMainInformation.Controls.OfType<Guna2TextBox>())
            {
                txt.Clear();
            }
            lblScaleName.Text = "";
            txtOther.Clear();
            cbbCustomer.Items.Clear();
            cbbProduct.Items.Clear();
            id = "";
            lblWeightIn.Text = "--";
            lblWeightIn.Visible = false;

            // Clear percent text
            txtPowder.Text = "0";
            txtHumidity.Text = "0";
            txtContaminants.Text = "0";
            txtOther.Enabled = false;

            if (lblWeight.Text == "00")
            {
                btnCancelWeight.Enabled = false;
                btnSave.Enabled = false;
            }

            await Task.Delay(150);

            // แสดงข้อมูลค้างชั่ง
            ShowData();
        }
        /// <summary>
        /// ชั่งเข้า
        /// </summary>
        async void AddWeightIn()
        {
            string[] cusSplit = cbbCustomer.Text.Split('|');
            string[] proSplit = cbbProduct.Text.Split('|');
            string customerId = customer.SelectChar(cusSplit[1].Trim());
            string productId = product.SelectChar(proSplit[1].Trim());
            if (job.AddNewOrder(txtLicenseHead.Text, txtLicenseTail.Text, customerId, productId, lblWeight.Text, txtPriceProduct.Text))
            {
                // แสดงข้อมูลว่าบันทึกสำเร็จ 
                msg.Show(this, "Save to data success", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);
                // เครีย์ 
                ClearFormToReady();
                ShowData();
                await Task.Delay(1000);
            }
        }
        /// <summary>
        /// ชั่งออก
        /// </summary>
        /// <returns></returns>
        async Task<bool> AddWeightOut()
        {
            if (job.SelectId(int.Parse(id)))
            {
                // คำนวนราคารวม
                double productPrice = double.Parse(txtPriceProduct.Text);
                int weightIn = 0;
                int weightOut = int.Parse(lblWeight.Text);
                double weightNet = 0;
                double priceNet = 0;
                double powder = double.Parse(txtPowder.Text);   // แป้งมัน
                double impurity = double.Parse(txtContaminants.Text); // สิ่งเจือปน
                double huminity = double.Parse(txtHumidity.Text); // ความชื่น
                double calculatePowder = 0;
                // กำหนดค่าน้ำหนักชั่งออก
                foreach (DataRow rw in job.tb.Rows)
                {
                    weightIn = int.Parse(rw["weight"].ToString());
                    break;
                }

                if (weightIn > weightOut)
                {
                    weightNet = weightIn - weightOut;
                }

                if (weightOut > weightIn)
                {
                    weightNet = weightOut - weightIn;
                }

                jobDetail.InsertNewOrderdetail(int.Parse(id), "ชั่งออก", weightOut);


                // Print()
                frmReport frmReport = new frmReport();
                switch (registy.system.bussinessType)
                {
                    case "ทั่วไป":
                        frmReport.reportType = "MN";
                        break;
                    case "ข้าวเปลือก":
                        frmReport.reportType = "Paddy";
                        break;
                    case "ข้าวโพดเลี้ยงสัตว์":
                        frmReport.reportType = "Corn";
                        break;
                    case "หัวมันสด":
                        frmReport.reportType = "Cassava";

                        break;
                }

                job.updateStatusWeightOut(int.Parse(id), "Success", weightNet, impurity, huminity, powder, txtOther.Text, priceNet);
                frmReport.id = id;
                frmReport.ShowDialog();
            }

            // เครีย์
            ClearFormToReady();
            ShowData();
            await Task.Delay(1000);

            msgD.Icon = MessageDialogIcon.Information;
            msgD.Show("Save to data success", "Save data success");
            return true;
        }
        private async void frmWeightNormal_Load(object sender, EventArgs e)
        {
            ClearFormToReady();
            await Task.Delay(1000);
            #region Indicator
            // define indigator name
            lblScaleName.Text = "เครื่องชั่ง " + scales.GetScaleName();
            // เช็คการเชื่อมต่อ น้ำหนัก
            if (scales.ChcekPort())
            {
                // กำหนดค่าการเชื่อมต่อ
                if (!scales.Connect(saScale))
                {
                    msgD.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                    msgD.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;
                    msgD.Show("An error occurred connect to scale", "Scale is not config");
                    this.Close();
                    return;
                }
            }
            else
            {
                msgD.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                msgD.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;
                msgD.Show("The program has not configured the connection scale", "Scale is not config");
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
                        msgD.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                        msgD.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;
                        msgD.Show("An error occurred connect to barrier device", "Barrier is not config");
                        this.Close();
                        return;
                    }
                }
                else
                {
                    msgD.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                    msgD.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;
                    msgD.Show("The program has not configured the connection barrier", "Barrier is not config");
                    this.Close();
                }
            }
            #endregion

        }
        private void saScale_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string a = saScale.ReadLine();
            string wgh = a.Substring(1, 8).Trim();
            newWeight = double.Parse(wgh);

            if (newWeight == 0)
            {
                BeginInvoke(new MethodInvoker(delegate ()
                {
                    btnCancelWeight.Enabled = false;
                    btnSave.Enabled = false;
                }));
            }

            // ถ้าน้ำหนักแตกต่างจากน้ำหนักล่าสุด
            if (newWeight != lastWeight)
            {
                lastWeight = newWeight;
                BeginInvoke(new MethodInvoker(delegate ()
                {
                    tmCheckWeight.Stop();
                    tmCheckWeight.Start();
                    lblWeight.ForeColor = System.Drawing.Color.Red; // เปลี่ยนสี Label เป็นสีแดง
                    btnSave.Enabled = false;
                    btnCancelWeight.Enabled = false;
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

            btnSave.Enabled = true;
            btnCancelWeight.Enabled = true;
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
        private async void btnSave_Click(object sender, EventArgs e)
        {
            // เช็คน้ำหนักต้องมากกว่า 1000 kg
            if (int.Parse(lblWeight.Text) <= 1000)
            {
                msg.Show(this, "น้ำหนักน้อยเกินกว่าจะบันทึกได้", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 3000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);
            }


            if (id == "") // Weight IN
            {
                if (!CheckinformationBeforeSave("IN"))
                    return;

                // เช็คว่าจะต้องชั่งเข้าหรือช้่งออกโดยเช็คจาก datagridview
                if (dgvdata.Rows.Count == 0)
                {
                    AddWeightIn();
                    return;
                }

                foreach (DataGridViewRow rw in dgvdata.Rows)
                {
                    string license = rw.Cells["cl_licenseHead"].Value.ToString();

                    if (txtLicenseHead.Text == license) // หากเช็คแล้วเหมือนกันหมายถึงต้องบันทึกขาออก
                    {
                        msg.Show(this, "ไม่สามารถบันทึกได้เนื่องจากพบทะเบียนรถที่กำลังชั่งอยู่", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 3000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                        return;
                    }
                }

                AddWeightIn();
            }
            else // Weight out
            {
                if (!CheckinformationBeforeSave("OUT"))
                    return;

                await AddWeightOut();
            }
        }
        private void btnCancelWeight_Click(object sender, EventArgs e)
        {
            msgD.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;
            msgD.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
            msgD.Style = Guna.UI2.WinForms.MessageDialogStyle.Light;

            DialogResult reult = msgD.Show("Do you want to canncel?", "Cancel");
            if (reult == DialogResult.Yes)
            {
                ClearFormToReady();
                ShowData();
            }
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
                        DialogResult reult = msgD.Show("Do you want to canncel?", "Cancel");
                        if (reult == DialogResult.Yes)
                        {
                            if (job.deleteOrdet(int.Parse(id)))
                            {
                                id = "";
                                ClearFormToReady();
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
        private void dgvdata_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string licenseHead = dgvdata.Rows[e.RowIndex].Cells["cl_licenseHead"].Value.ToString();
                string licenseTail = dgvdata.Rows[e.RowIndex].Cells["cl_licenseTail"].Value.ToString();
                string customerId = dgvdata.Rows[e.RowIndex].Cells["cl_customerId"].Value.ToString();
                string customerName = dgvdata.Rows[e.RowIndex].Cells["cl_customerName"].Value.ToString();
                string productId = dgvdata.Rows[e.RowIndex].Cells["cl_productId"].Value.ToString();
                string productName = dgvdata.Rows[e.RowIndex].Cells["cl_productName"].Value.ToString();
                string productPrice = dgvdata.Rows[e.RowIndex].Cells["cl_productPrice"].Value.ToString();
                string weightIn = dgvdata.Rows[e.RowIndex].Cells["cl_weightIn"].Value.ToString();

                lblWeightIn.Text = $"น้ำหนักชั่งเข้า {weightIn}";
                lblWeightIn.Visible = true;
                id = dgvdata.Rows[e.RowIndex].Cells["cl_id"].Value.ToString();
                txtLicenseHead.Text = licenseHead;
                txtLicenseTail.Text = licenseTail;

                cbbCustomer.Items.Clear();
                cbbCustomer.Items.Add($"{customerId} | {customerName}");
                cbbCustomer.SelectedIndex = 0;

                cbbProduct.Items.Clear();
                cbbProduct.Items.Add($"{productId} | {productName}");
                cbbProduct.SelectedIndex = 0;

                txtPriceProduct.Text = productPrice;

                txtOther.Enabled = true;
                switch (registy.system.bussinessType)
                {
                    case "หัวมันสด":
                        pnPowder.Enabled = true;
                        break;
                    case "ข้าวเปลือก":
                        pnContaminants.Enabled = true;
                        pnHumidity.Enabled = true;
                        break;
                    case "ข้าวโพดเลี้ยงสัตว์":
                        pnHumidity.Enabled = true;
                        break;
                }
            }
            catch (Exception)
            {

            }
        }
        private void frmWeightNormal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Task.Delay(200);
            scales.Disconnect(saScale);
        }
        private void cbbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] proSplit = cbbProduct.Text.Split('|');
            string productId = product.SelectChar(proSplit[1].Trim());
            DataTable dataTable = product.SelectId(int.Parse(productId));
            foreach (DataRow rw in dataTable.Rows)
            {
                txtPriceProduct.Text = rw["price"].ToString();
            }
        }
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            frmReport frmReport = new frmReport();

            frmReport.id = "103";
            frmReport.reportType = "Cassava";
            frmReport.ShowDialog();
        }
    }
}
