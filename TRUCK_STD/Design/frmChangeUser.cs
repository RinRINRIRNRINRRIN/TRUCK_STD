using Bunifu.UI.WinForms;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TRUCK_STD.Function;
using TRUCK_STD.MSACCESSCommand;
namespace TRUCK_STD.Design
{
    public partial class frmChangeUser : Form
    {
        public frmChangeUser()
        {
            InitializeComponent();
        }


        BunifuSnackbar msg = new BunifuSnackbar();
        tbEMPLOYEE tbEMPLOYEE = new tbEMPLOYEE();
        private void frmChangeUser_Load(object sender, EventArgs e)
        {
            gbMain.Text = "ยินดีต้อนรับ : " + Func_Privilage.emp_name;

            txtUsername.Text = Func_Privilage.emp_usernmae;


        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                msg.Show(this, "กรุณากรอกข้อมูลให้ครบ", BunifuSnackbar.MessageTypes.Warning, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
            }
            else
            {

                if (tbEMPLOYEE.SELECT_USERNAME_PASSWORD(txtUsername.Text, txtPassword.Text))
                {
                    txtNewName.Text = Func_Privilage.emp_name;
                    txtNewUser.Text = Func_Privilage.emp_usernmae;

                    bunifuTransition1.ShowSync(panel1);
                }
                else
                {
                    msg.Show(this, "ชื่อผู้ใช้หรือรหัสไม่ถูกต้อง", BunifuSnackbar.MessageTypes.Warning, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                }
            }
        }

        private void cbbShowpass_CheckedChanged(object sender, EventArgs e)
        {
            if (cbbShowpass.Checked == true)
            {
                txtNewpass.UseSystemPasswordChar = false;
                txtNewpassconfirm.UseSystemPasswordChar = false;

                txtNewpass.PasswordChar = '\0';
                txtNewpassconfirm.PasswordChar = '\0';
            }
            else
            {
                txtNewpass.UseSystemPasswordChar = true;
                txtNewpassconfirm.UseSystemPasswordChar = true;

                txtNewpass.PasswordChar = '*';
                txtNewpassconfirm.PasswordChar = '*';
            }
        }

        private void txtNewpass_TextChanged(object sender, EventArgs e)
        {
            if (txtNewpass.Text != txtNewpassconfirm.Text)
            {
                label1.ForeColor = Color.Red;
                label1.Text = "รหัสไม่ตรงกัน";
            }
            else if (txtNewpass.Text == "" && txtNewpassconfirm.Text == "")
            {
                label1.ForeColor = Color.White;
                label1.Text = "";
            }
            else if (txtNewpass.Text == txtNewpassconfirm.Text)
            {
                label1.ForeColor = Color.Green;
                label1.Text = "รหัสตรงกัน";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (Guna.UI2.WinForms.Guna2TextBox textBox in panel1.Controls.OfType<Guna.UI2.WinForms.Guna2TextBox>())
            {
                if (textBox.Text == "")
                {
                    msg.Show(this, "กรุณากรอกข้อมูลให้ครบก่อนทำการเปลี่ยนรหัสผ่าน");
                    return;
                }
            }


            if (label1.ForeColor == Color.Red)
            {
                msg.Show(this, "พบรหัสไม่ตรงกัน", BunifuSnackbar.MessageTypes.Warning, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
            }
            else
            {
                DataTable tb = tbEMPLOYEE.SELECT_ALL_DATA();
                // ตรวจสอบ username ห้ามซ้ำ
                foreach (DataRow row in tb.Rows)
                {
                    string a = row["emp_username"].ToString();

                    if (a == txtNewUser.Text.Trim())
                    {
                        msg.Show(this, "พบ username มีซ้ำในระบบ", BunifuSnackbar.MessageTypes.Warning, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                        return;
                    }
                }

                if (tbEMPLOYEE.UPDATE_ALL_DATA(txtNewName.Text, txtNewUser.Text, txtNewpassconfirm.Text, Func_Privilage.emp_usernmae))
                {
                    MessageBox.Show("แก้ไขรายการสำเร็จ ระบบจะปิดกรุณาเข้าสู่ระบบอีกครั้ง", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                }
            }
        }
    }
}
