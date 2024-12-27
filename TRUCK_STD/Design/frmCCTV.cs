using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TRUCK_STD.DbBase;
using TRUCK_STD.Functions;

namespace TRUCK_STD.Design
{
    public partial class frmCCTV : Form
    {
        public frmCCTV()
        {
            InitializeComponent();
        }

        CCTV cctv = new CCTV();
        string old_ip = "";


        async void ClearForm()
        {
            // Clear
            foreach (Guna2TextBox txt in gb.Controls.OfType<Guna2TextBox>())
            {
                txt.Clear();
            }

            txtPort.Text = "554";
            txtoption.Text = ":network-caching=0\r\n:file-caching=100";

            old_ip = "";
            await cctv.Stop(vlcControl1);
            btnTest.Text = "เริ่มทดสอบ";
        }

        private void frmCCTV_Load(object sender, EventArgs e)
        {
            // Show data
            if (cctvs.Select())
                dgv.DataSource = cctvs.tb;
            dgv.DefaultCellStyle.ForeColor = Color.Black;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // เช็คค่าว่าง
            foreach (Guna2TextBox txt in gb.Controls.OfType<Guna2TextBox>())
            {
                if (txt.Text == "")
                {
                    sb.Show(this, "กรุณากรอกข้อมูลให้ครบก่อนบันทึก", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 3000, "OK", Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                    return;
                }
            }

            // กำหนดค่า

            cctvs.new_ip = txtIP.Text;
            cctvs.old_ip = old_ip;
            cctvs.port = int.Parse(txtPort.Text);
            cctvs.user = txtUser.Text;
            cctvs.pass = txtPass.Text;
            cctvs.position = txtPosition.Text;


            // Check Insert or Update
            if (old_ip == "") // Insert
            {
                // บันทึกข้อมูล
                if (!cctvs.Insert())
                {
                    sb.Show(this, "เกิดข้อผิดผลาด " + cctvs.ERR, Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                    return;
                }
            }
            else // Update
            {
                if (!cctvs.Update())
                {
                    sb.Show(this, "เกิดข้อผิดผลาด " + cctvs.ERR, Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                    return;
                }
            }

            sb.Show(this, "บันทึกข้อมูลสำเร็จ", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
            ClearForm();
            if (cctvs.Select())
                dgv.DataSource = cctvs.tb;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            string _text = btnTest.Text;
            switch (_text)
            {
                case "เริ่มทดสอบ":
                    foreach (Guna2TextBox txt in gb.Controls.OfType<Guna2TextBox>())
                    {
                        if (txt.Text == "")
                        {
                            sb.Show(this, "กรุณากรอกข้อมูลให้ครบก่อนทดสอบ", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 3000, "OK", Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                            return;
                        }
                    }
                    btnTest.Text = "หยุดทดสอบ";
                    gb.Enabled = false;
                    gbConnect.Visible = true;
                    cctv = new CCTV
                    {
                        ip = txtIP.Text,
                        port = txtPort.Text,
                        user = txtUser.Text,
                        pass = txtPass.Text,
                        option = txtoption.Text.Split('\n')
                    };

                    cctv.SetCamera(vlcControl1);
                    Task.Run(ConnectCam);
                    break;
                case "หยุดทดสอบ":
                    btnTest.Text = "เริ่มทดสอบ";
                    cctv.Stop(vlcControl1);
                    break;
            }


        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string cl_name = dgv.Columns[e.ColumnIndex].Name;
                switch (cl_name)
                {
                    case "cl_del":
                        DialogResult dr = MessageBox.Show("คุณต้องการลบข้อมูลหรือไม่", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            // กำหนดค่า

                            cctvs.old_ip = dgv.Rows[e.RowIndex].Cells["cl_ip"].Value.ToString();

                            // delete
                            if (cctvs.Delete())
                            {
                                sb.Show(this, "ลบข้อมูลสำเร็จ", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                                if (cctvs.Select())
                                    dgv.DataSource = cctvs.tb;
                            }
                        }
                        break;
                    case "cl_edit":
                        old_ip = dgv.Rows[e.RowIndex].Cells["cl_ip"].Value.ToString();
                        txtIP.Text = old_ip;
                        txtPort.Text = dgv.Rows[e.RowIndex].Cells["cl_port"].Value.ToString();
                        txtUser.Text = dgv.Rows[e.RowIndex].Cells["cl_user"].Value.ToString();
                        txtPass.Text = dgv.Rows[e.RowIndex].Cells["cl_pass"].Value.ToString();
                        txtPosition.Text = dgv.Rows[e.RowIndex].Cells["cl_position"].Value.ToString();
                        break;
                }
            }
            catch (Exception)
            {
            }
        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        async Task ConnectCam()
        {
            bool isSuccess = false;

            for (int i = 0; i < 10; i++)
            {
                if (vlcControl1.State == Vlc.DotNet.Core.Interops.Signatures.MediaStates.Playing)
                {
                    isSuccess = true;
                    break;
                }
                await Task.Delay(1000);
            }

            if (!isSuccess)
            {
                BeginInvoke(new MethodInvoker(delegate ()
                {
                    sb.Show(this, "ไม่สามารถเชื่อมต่อกล้องได่้", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 3000, "OK", Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                    gbConnect.Visible = false;
                    gb.Enabled = true;
                    btnTest.Text = "เริ่มทดสอบ";
                }));
            }
            else
            {
                BeginInvoke(new MethodInvoker(delegate ()
                {
                    sb.Show(this, "เชื่อมต่อกล้องสำเร็จ", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, "OK", Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                    gbConnect.Visible = false;
                    gb.Enabled = true;

                }));
            }
        }

        private void btnCancelConnect_Click(object sender, EventArgs e)
        {
            btnTest.Text = "เริ่มทดสอบ";
            gb.Enabled = true;
            gbConnect.Visible = false;
        }

        private void btnTake_Click(object sender, EventArgs e)
        {
            cctv.TakePicture(vlcControl1);
        }
    }
}
