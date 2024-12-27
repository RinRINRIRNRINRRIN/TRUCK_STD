using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TRUCK_STD.DbBase;
using TRUCK_STD.Models;


namespace TRUCK_STD.Design
{
    public partial class frmCustomer : Form
    {
        public frmCustomer()
        {
            InitializeComponent();
        }

        #region "VARIABLE"


        string COMPCODE = ""; // ใช้สำหรับเก็บค่าของ ID ที่ DGV

        #endregion


        #region "FUCSION"
        /// <summary>
        /// ใช้สำหรับตรวจสอบสิทธิ์กับเมนูนี้
        /// </summary>
        void CHECK_PRIVIRAGE()
        {
            // ตรวจสอบว่าใช้สิทธิ์ sa หรือไม่ เพราะ sa เข้าได้หมดทุกเมนู
            if (accountModels.user != "sa")
            {
                // หากไม่ใช่ sa ให้เช็คสิทธ์ที่มีการ login มาว่ามีสิทธ์อะไรบ้าง
                foreach (var item in menuModels.menuList)
                {
                    string menu = item.Key;
                    if (menu == "ข้อมูลพนักงาน")
                    {
                        string add = item.Value.Item1;
                        string del = item.Value.Item2;
                        string edit = item.Value.Item3;
                        if (add == "FALSE")
                            btnAdd.Visible = false;
                        if (del == "FALSE")
                            dgvCustomer.Columns["cl_del"].Visible = false;
                        if (edit == "FALSE")
                            dgvCustomer.Columns["cl_edit"].Visible = false;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// ใช้สำหรับเครียค่า เมื่อมีการบันทักหรือแก้ไขเสร็จ และกดยกเลิก
        /// </summary>
        void CLEAR_FORM()
        {
            btnAdd.Enabled = true;
            txtSearch.Enabled = true;
            dgvCustomer.Enabled = true;

            gbCustomerDetail.Visible = false;
            txtCOMPCODE.Clear();
            txtCOMPDESC.Clear();

            COMPCODE = "";
        }


        #endregion
        private void frmCustomer_Load(object sender, EventArgs e)
        {
            if (customer.Select())
                dgvCustomer.DataSource = customer.tb;
            dgvCustomer.DefaultCellStyle.ForeColor = Color.Black;

            CHECK_PRIVIRAGE();
        }


        /// <summary>
        /// ปุ่มเพื่มรายการ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            txtSearch.Enabled = false;
            dgvCustomer.Enabled = false;

            bunifuTransition1.ShowSync(gbCustomerDetail);
        }


        /// <summary>
        /// ใช้บันทึกข้อมูล
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            // ทำการเช็คว่าเจอข้อมูลว่างก่อนบันทึกหรือไม่
            bool chk = true;

            foreach (Guna.UI2.WinForms.Guna2TextBox txt in gbCustomerDetail.Controls.OfType<Guna.UI2.WinForms.Guna2TextBox>())
            {
                if (txt.Text == "")
                {
                    bunifuSnackbar1.Show(this,
                        "กรุณากรอกข้อมูลให้ครบ " + txt.PlaceholderText,
                        Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning,
                        3000,
                        "OK",
                        Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                    txt.BorderColor = Color.Red;
                    chk = false;
                }
            }

            // ทำการเช็คว่า ข้อมูลที่คีย์เข้ามาต้องมากกว่า 1 ตัว
            if (txtCOMPCODE.Text.Length < 0)
            {
                chk = false;
                bunifuSnackbar1.Show(this,
                       "กรุณากรอก เลขบัตรให้ครบ 13 ตัว",
                       Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning,
                       3000,
                       "OK",
                       Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
            }

            // ตรวจสอบแล้วไม่พบ ค่าว่าง
            if (chk)
            {
                if (COMPCODE == "") // INSERT INTO
                {
                    // กำหนดค่า
                    customer.new_id = txtCOMPCODE.Text;
                    customer.names = txtCOMPDESC.Text;
                    // Insert
                    if (!customer.Insert())
                    {
                        bunifuSnackbar1.Show(this, "เกิดข้อผิดผลาดกรุณาตรวจสอบว่าถูกต้องหรือไม่ หรือมีข้อมูลซ้ำในระบบ", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 3000, "OK", Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                        return;
                    }
                }
                else // UPDATE
                {
                    // กำหนดค่า

                    customer.new_id = txtCOMPCODE.Text;
                    customer.old_id = COMPCODE;
                    customer.names = txtCOMPDESC.Text;

                    // Update
                    if (customer.Update())
                    {
                        bunifuSnackbar1.Show(this, "เกิดข้อผิดผลาดกรุณาตรวจสอบว่าถูกต้องหรือไม่ หรือมีข้อมูลซ้ำในระบบ", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 3000, "OK", Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                        return;
                    }
                }

                // หากมีการบันทึก หรือ แก้ไขโดยไม่มีปัญหา
                bunifuSnackbar1.Show(this,
                    "บันทึกรายการสำเร็จ",
                    Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success,
                    3000,
                    "OK",
                     Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                // ดึงข้อมูลมาโชว์
                if (customer.Select())
                    dgvCustomer.DataSource = customer.tb;
                // คืนค่าฟอร์ม
                CLEAR_FORM();
            }
        }


        /// <summary>
        /// ใช้สำหรับยกเลิกข้อมูล
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            CLEAR_FORM();
        }

        private void txtSearch_IconRightClick(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                bunifuSnackbar1.Show(this, "กรุณาคีย์ข้อมูลก่อนทำการค้นหา", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 3000, "OK", Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
            }
            else
            {
                customer.names = txtCOMPDESC.Text;
                if (customer.Select())
                    dgvCustomer.DataSource = customer.tb;

            }
        }

        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // ดึงข้อมูล มาแสดงที่ dgv ก่อน
                string customer_id = dgvCustomer.Rows[e.RowIndex].Cells["cl_id"].Value.ToString();
                string customer_name = dgvCustomer.Rows[e.RowIndex].Cells["cl_names"].Value.ToString();
                if (dgvCustomer.Columns[e.ColumnIndex].Name == "cl_del")
                {
                    guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
                    guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;
                    DialogResult dialogResult = guna2MessageDialog1.Show($"Do you want to delete the customer {customer_name}?", "Delete information");

                    if (dialogResult == DialogResult.Yes)
                    {
                        // กำหนดค่า

                        customer.old_id = customer_id;

                        // Delete
                        if (customer.Delete())
                            dgvCustomer.DataSource = customer.tb;
                    }
                }
                else if (dgvCustomer.Columns[e.ColumnIndex].Name == "cl_edit")
                {
                    // กำหนดค่าและโชว์หนาตาให้ผู้ใช้แก้ไข
                    COMPCODE = customer_id;
                    txtCOMPCODE.Text = COMPCODE;
                    txtCOMPDESC.Text = customer_name;
                    bunifuTransition1.ShowSync(gbCustomerDetail);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            if (customer.Select())
                dgvCustomer.DataSource = customer.tb;
        }
    }
}
