using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TRUCK_STD.DbBase;
using TRUCK_STD.Models;

namespace TRUCK_STD.Design
{
    public partial class frmEmployee : Form
    {
        public frmEmployee()
        {
            InitializeComponent();

        }


        #region variable local
        string emp_username = "";

        #endregion



        #region FUNCTION LOCAL
        /// <summary>
        /// สำหรับเครีย์ฟอร์มให้พร้อมก่อนทำงาน
        /// </summary>
        void CLEAR_FROM()
        {
            foreach (Guna.UI2.WinForms.Guna2TextBox txt in gbEmployeeDetail.Controls.OfType<Guna.UI2.WinForms.Guna2TextBox>())
            {
                txt.Clear();
                txt.BorderColor = Color.Black;
            }

            emp_username = "";
            gbEmployeeDetail.Visible = false;
            btnAdd.Enabled = true;
            txtSearch.Enabled = true;
            btnRefresh.Enabled = true;
            dgvEmployee.Enabled = true;
        }

        /// <summary>
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
                            dgvEmployee.Columns["cl_del"].Visible = false;
                        if (edit == "FALSE")
                            dgvEmployee.Columns["cl_edit"].Visible = false;
                        break;
                    }
                }
            }
        }
        #endregion




        private void frmEmployee_Load(object sender, EventArgs e)
        {
            // ดึงข้อมูลมาแสดงที่ dgv 
            if (employee.Select())
            {
                dgvEmployee.DataSource = employee.tb;
                dgvEmployee.DefaultCellStyle.ForeColor = Color.Black;
                // เช็คสิทธิ์การใช้งาน
                CHECK_PRIVIRAGE();
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            txtSearch.Enabled = false;
            btnRefresh.Enabled = false;
            dgvEmployee.Enabled = false;
            // โชว์ Animation
            // bunifuTransition1.ShowSync(gbCustomerDetail);

            guna2Transition1.HideSync(gbEmployeeDetail);
            guna2Transition1.ShowSync(gbEmployeeDetail);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CLEAR_FROM();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // เช็คค่าว่างก่อนทำการบันทีก
            bool chk = true;
            foreach (Guna.UI2.WinForms.Guna2TextBox txt in gbEmployeeDetail.Controls.OfType<Guna.UI2.WinForms.Guna2TextBox>())
            {
                if (txt.Text == "")
                {
                    txt.BorderColor = Color.Red;
                    chk = false;
                    bunifuSnackbar1.Show(this,
                        "กรุณากรอกข้อมูล " + txt.PlaceholderText,
                        Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning,
                        3000,
                        "OK",
                        Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                }
            }

            // ตรวจสอบว่าได้กรอดข้อมูลหรือไม่
            if (chk)
            {
                // หากกรอกข้อมูลแล้วให้เช็คว่า เป็นการ inser or update 
                if (emp_username == "")
                {
                    // ตรวจสอบว่ามีชื่อซ้ำกับในระบบหรือไม่
                    foreach (DataGridViewRow rw in dgvEmployee.Rows)
                    {
                        if (Convert.ToString(rw.Cells["cl_emp_username"].Value) == txtUsername.Text.Trim())
                        {
                            // หากพบว่ามีชื่อซ้ำกับในระบบให้ทำการแจ้งเตือนและออกจากการทำงาน
                            bunifuSnackbar1.Show(this,
                       "พบชื่อผู้ใช้งานซ้ำกับในระบบ ",
                       Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning,
                       3000,
                       "OK",
                       Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                            return;
                        }
                    }

                    // กำหนดค่า
                    employee.new_username = txtUsername.Text;
                    employee.password = txtPass.Text;
                    employee.names = txtName.Text;
                    employee.state = "Actice";

                    // เพิ่มข้อมูล
                    if (employee.Insert())
                    {
                        CLEAR_FROM();
                        bunifuSnackbar1.Show(this,
                       "บันทึกรายการสำเร็จ ",
                       Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success,
                       3000,
                       "OK",
                       Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                    }
                    else
                    {
                        MessageBox.Show("เกิดข้อผิดผลาดขณะบันทึก");
                        return;
                    }

                }
                //แต่หากเป็น update
                else
                {
                    // ตรวจสอบว่า username ได้มีการเปลี่ยนรหรือไม่ หากมีการเปลี่ยนจะต้องเช็คว่าซ้ำกับ user คนอื่นในระบบหรือไม่
                    if (emp_username != txtUsername.Text)
                    {
                        // ตรวจสอบว่ามีชื่อซ้ำกับในระบบหรือไม่
                        foreach (DataGridViewRow rw in dgvEmployee.Rows)
                        {
                            if (Convert.ToString(rw.Cells["cl_emp_username"].Value) == txtUsername.Text.Trim())
                            {
                                // หากพบว่ามีชื่อซ้ำกับในระบบให้ทำการแจ้งเตือนและออกจากการทำงาน
                                bunifuSnackbar1.Show(this,
                           "พบชื่อผู้ใช้งานซ้ำกับในระบบ ",
                           Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning,
                           3000,
                           "OK",
                           Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                                return;
                            }

                        }
                    }

                    // กำหนดค่า 
                    employeeModels employeeModels = new employeeModels
                    {
                        new_username = txtUsername.Text,
                        old_username = emp_username,
                        password = txtPass.Text,
                        names = txtName.Text
                    };

                    employee.new_username = txtUsername.Text;
                    employee.old_username = emp_username;
                    employee.password = txtPass.Text;
                    employee.names = txtName.Text;

                    // Update
                    if (employee.Update())
                    {
                        // คืนค่า
                        CLEAR_FROM();
                        dgvEmployee.Visible = true;
                        bunifuSnackbar1.Show(this,
                            "แก้ไขรายการสำเร็จ",
                            Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success,
                            3000,
                            "OK",
                            Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                    }
                    else
                    {
                        MessageBox.Show("เกิดข้อผิดผลาดขณะบันทึก");
                        return;
                    }
                }

                // แสดงข้อมูล
                if (employee.Select())
                    dgvEmployee.DataSource = employee.tb;
            }
            else
            {
                // แต่หากตรรวจสอบแล้วพบข้อมูลว่า
                return;
            }


        }

        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // กำหนด username มาไว้ในตัวแปร
                string user_i = Convert.ToString(dgvEmployee.Rows[e.RowIndex].Cells["cl_id"].Value);
                emp_username = Convert.ToString(dgvEmployee.Rows[e.RowIndex].Cells["cl_emp_username"].Value);
                // DELETE
                if (dgvEmployee.Columns[e.ColumnIndex].Name == "cl_del")
                {
                    // ให้เช็คก่อนว่าได้ลบ sa ออกหรือไม่เพราะจะไม่สามารถลบออกจากระบบได้
                    if (emp_username == "sa")
                    {
                        bunifuSnackbar1.Show(this,
                            "ไม่สามารถลบ User Master ได้",
                            Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning,
                            3000,
                            "OK",
                            Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                    }
                    // แต่หากไม่ได้ลบ sa ให้ทำการถามก่อนว่าว่าต้องการลบหรือไม่
                    else
                    {
                        if (MessageBox.Show("คุณต้องการลบข้อมูลหรือไม่?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            // หากผู้ใช้ยืนยันที่จะลบข้อมูลให้ลบข้อมูลในตาราง PRIVIRAGE ก่อ
                            if (privilage.Delete(emp_username))
                            {

                                employee.old_username = emp_username;

                                // และให้ลบข้อมูลในตาราง EMPLOYEE ต่อ
                                if (employee.Delete())
                                {
                                    CLEAR_FROM();
                                    if (employee.Select())
                                        dgvEmployee.DataSource = employee.tb;

                                    bunifuSnackbar1.Show(this,
                                        "ลบรายการสำเร็จ",
                                        Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success,
                                        3000,
                                        "OK",
                                        Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                                }
                            }
                        }
                    }
                }
                // EDIT
                else if (dgvEmployee.Columns[e.ColumnIndex].Name == "cl_edit")
                {
                    // ให้เช็คก่อนว่าได้แก้ไข sa ออกหรือไม่เพราะจะไม่สามารถลบออกจากระบบได้
                    if (emp_username == "sa")
                    {
                        bunifuSnackbar1.Show(this,
                            "ไม่สามารถ แก้ไข User Master ได้",
                            Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning,
                            3000,
                            "OK",
                            Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                    }
                    else
                    {
                        // กำหนดค่าให้กับ controls ต่าง ๆ 
                        btnAdd.Enabled = false;
                        txtSearch.Enabled = false;
                        btnRefresh.Enabled = false;
                        dgvEmployee.Enabled = false;

                        txtUsername.Text = Convert.ToString(dgvEmployee.Rows[e.RowIndex].Cells["cl_emp_username"].Value);
                        txtPass.Text = Convert.ToString(dgvEmployee.Rows[e.RowIndex].Cells["cl_emp_password"].Value);
                        txtName.Text = Convert.ToString(dgvEmployee.Rows[e.RowIndex].Cells["cl_emp_name"].Value);

                        // แสดงหน้าให้ผู้ใช้แก้ไข
                        guna2Transition1.ShowSync(gbEmployeeDetail);
                    }
                }
                // Privalage
                else if (dgvEmployee.Columns[e.ColumnIndex].Name == "cl_account")
                {
                    // ให้เช็คก่อนว่าได้แก้ไข sa ออกหรือไม่เพราะจะไม่สามารถลบออกจากระบบได้
                    if (emp_username == "sa")
                    {
                        bunifuSnackbar1.Show(this,
                            "ไม่สามารถ แก้ไข User Master ได้",
                            Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning,
                            3000,
                            "OK",
                            Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                    }
                    else
                    {
                        frmAccount frmAccount = new frmAccount();
                        frmAccount.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR CUSTOMER 01" + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            if (employee.Select())
                dgvEmployee.DataSource = employee.tb;
        }

        private void txtSearch_IconRightClick(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                if (employee.Select())
                    dgvEmployee.DataSource = employee.tb;
                bunifuSnackbar1.Show(this,
                    "กรุณาใส่ข้อมูล ก่อนทำการค้นหา",
                    Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning,
                    3000,
                    "OK",
                    Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
            }
            else
            {
                dgvEmployee.DataSource = employee.Select(txtSearch.Text);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
