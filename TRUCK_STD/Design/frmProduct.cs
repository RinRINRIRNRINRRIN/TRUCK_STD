using Bunifu.UI.WinForms;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TRUCK_STD.DbBase;
using TRUCK_STD.Function;
using TRUCK_STD.Functions;
using TRUCK_STD.Models;

namespace TRUCK_STD.Design
{
    public partial class frmProduct : Form
    {
        public frmProduct()
        {
            InitializeComponent();
            dgvProduct.Columns["cl_price"].Visible = false;
            txtProdcutPrice.Visible = false;
        }

        #region VARIABLE LOCAL
        BunifuSnackbar msg = new BunifuSnackbar();
        string prd_code = "";  // ใช้สำหรับ เก็บค่ารหัสสินค้า
        #endregion

        #region FUNCTION LOCAL
        /// <summary>
        /// สำหรับเครีย์ฟอร์มให้พร้อมก่อนทำงาน
        /// </summary>
        void CLEAR_FROM()
        {
            foreach (Guna.UI2.WinForms.Guna2TextBox txt in gbProductDetail.Controls.OfType<Guna.UI2.WinForms.Guna2TextBox>())
            {
                txt.Clear();
                txt.BorderColor = Color.Black;
            }

            prd_code = "";

            gbProductDetail.Visible = false;
            btnAdd.Enabled = true;
            txtSearch.Enabled = true;
            dgvProduct.Enabled = true;
        }

        /// <summary>
        /// ใช้สำหรับ เช็ค REGISTRY ว่ามีฟังชั่นคำนวนราคาหรือไม่
        /// </summary>
        void CHECK_REGISTRY()
        {

            if (registy.system.bussinessType != "ทั่วไป")
            {
                txtProdcutPrice.Visible = true;
                txtProdcutPrice.Enabled = true;
                dgvProduct.Columns["cl_price"].Visible = true;
            }
        }


        /// <summary>
        /// ใช้สำหรับ เช็คว่ามีสิทธิ์อะไรในโปรแกรมบ้าง
        /// </summary>
        ///  /// <summary>
        /// ใช้สำหรับ เช็คสิทธิ์การใช้งานเมนูนี้
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
                            dgvProduct.Columns["cl_del"].Visible = false;
                        if (edit == "FALSE")
                            dgvProduct.Columns["cl_edit"].Visible = false;
                        break;
                    }
                }
            }
        }
        #endregion


        private void frmEmployee_Load(object sender, EventArgs e)
        {
            // เช็คฟังชั่น คำนวนเงิน
            CHECK_REGISTRY();
            // เช็คสิทธิ์การใช้งานเมนู
            CHECK_PRIVIRAGE();
            // เรียกข้อมูลทดหมดออกมา
            if (product.Select())
                dgvProduct.DataSource = product.tb;
            dgvProduct.DefaultCellStyle.ForeColor = Color.Black;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            txtSearch.Enabled = false;
            dgvProduct.Enabled = false;
            // โชว์ Animation
            bunifuTransition1.ShowSync(gbProductDetail);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            CLEAR_FROM();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool chk = true;
            if (chk)
            {
                // ตรวจสอบว่าเป็นการ INSERT or UPDATE
                if (prd_code == "")  // INSERT
                {
                    // เช็คค่าว่างก่อน
                    if (txtProdcutName.Text == "" || txtProductCode.Text == "")
                    {
                        // ถ้าเจอช่องว่างให้ แสดงข้อความแจ้งเตือนและออกจากการทำงาน
                        msg.Show(this, "กรุณากรอกข้อมูลให้ครบก่อนทำการบันทึก", BunifuSnackbar.MessageTypes.Warning, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                        return;
                    }

                    // กำหนดค่า
                    product.new_ProductId = txtProductCode.Text;
                    product.ProductName = txtProdcutName.Text;
                    product.ProductType = txtProductType.Text;
                    product.ProductPrice = double.Parse(txtProdcutPrice.Text);
                    // INSERT
                    if (!product.Insert())
                    {
                        msg.Show(this, "เกิดข้อผิดผลาดกรุณาตรวจสอบข้อมูล " + product.ERR, BunifuSnackbar.MessageTypes.Warning, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                        return;
                    }
                }
                else   // UPDATE
                {
                    if (txtProdcutName.Text == "" || txtProductCode.Text == "" || txtProdcutPrice.Text == "")
                    {
                        // ถ้าเจอช่องว่างให้ แสดงข้อความแจ้งเตือนและออกจากการทำงาน
                        msg.Show(this, "กรุณากรอกข้อมูลให้ครบก่อนทำการบันทึก", BunifuSnackbar.MessageTypes.Warning, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                        return;
                    }

                    // กำหนดค่า
                    product.new_ProductId = txtProductCode.Text;
                    product.old_ProductId = prd_code;
                    product.ProductType = txtProductType.Text;
                    product.ProductName = txtProdcutName.Text;
                    product.ProductPrice = double.Parse(txtProdcutPrice.Text);

                    // Update
                    if (!product.Update())
                    {
                        msg.Show(this, "เกิดข้อผิดผลาดกรุณาตรวจสอบข้อมูล หรือมีข้อมูลซ้ำ", BunifuSnackbar.MessageTypes.Warning, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                        return;
                    }
                }
            }

            // เมื่อบันหรือหรือแก้ไขสำเร็จ
            CLEAR_FROM();
            if (product.Select())
                dgvProduct.DataSource = product.tb;

            msg.Show(this, "บันทึกรายการสำเร็จ", BunifuSnackbar.MessageTypes.Success, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
        }



        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // กำหนด username มาไว้ในตัวแปร
                prd_code = Convert.ToString(dgvProduct.Rows[e.RowIndex].Cells["cl_id"].Value);

                // DELETE
                if (dgvProduct.Columns[e.ColumnIndex].Name == "cl_del")
                {
                    if (MessageBox.Show("คุณต้องการลบข้อมูลหรือไม่?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        // Delete
                        if (product.Delete(prd_code))
                        {
                            CLEAR_FROM();
                            if (product.Select())
                                dgvProduct.DataSource = product.tb;
                            bunifuSnackbar1.Show(this,
                                "ลบรายการสำเร็จ",
                                Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success,
                                3000,
                                "OK",
                                Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                        }
                    }
                }
                // EDIT
                else if (dgvProduct.Columns[e.ColumnIndex].Name == "cl_edit")
                {
                    txtProductCode.Text = prd_code;
                    txtProductType.Text = Convert.ToString(dgvProduct.Rows[e.RowIndex].Cells["cl_productType"].Value);
                    txtProdcutName.Text = Convert.ToString(dgvProduct.Rows[e.RowIndex].Cells["cl_names"].Value);
                    txtProdcutPrice.Text = Convert.ToString(dgvProduct.Rows[e.RowIndex].Cells["cl_price"].Value);

                    bunifuTransition1.Show(gbProductDetail);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR CUSTOMER 01" + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }
        private void txtProdcutPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            Func_Main.CHECK_CHARATER_KEY_NUMBER_AND_DOT(sender, e, this);
        }

        private void txtSearch_IconRightClick(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                msg.Show(this, "กรุณาคีย์ข้อมูลก่อนทำการค้นหา", BunifuSnackbar.MessageTypes.Warning, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
            }
            else
            {
                if (product.SelectChar(txtSearch.Text))
                    dgvProduct.DataSource = product.tb;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (product.Select())
                dgvProduct.DataSource = product.tb;
        }
    }
}
