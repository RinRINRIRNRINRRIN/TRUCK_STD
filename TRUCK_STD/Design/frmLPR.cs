﻿using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TRUCK_STD.DbBase;
using TRUCK_STD.Functions;
using TRUCK_STD.Models;

namespace TRUCK_STD.Design
{
    public partial class frmLPR : Form
    {
        public frmLPR()
        {
            InitializeComponent();
        }

        LRP LPr = new LRP();
        string old_ip = "";


        void ClearForm()
        {
            // Clear
            foreach (Guna2TextBox txt in gb.Controls.OfType<Guna2TextBox>())
            {
                txt.Clear();
            }

            txtPort.Text = "554";
            txtoption.Text = ":network-caching=0\r\n:file-caching=100";

            old_ip = "";
            LRP.Stop(vlcControl1);
            btnTest.Text = "เริ่มทดสอบ";
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

        private void btnTake_Click(object sender, EventArgs e)
        {
            LRP.TakePicture(vlcControl1);
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

            lprModels lprModels = new lprModels
            {
                new_ip = txtIP.Text,
                old_ip = old_ip,
                port = txtPort.Text,
                user = txtUser.Text,
                pass = txtPass.Text,
                position = txtPosition.Text
            };

            // Check Insert or Update
            if (old_ip == "") // Insert
            {
                // บันทึกข้อมูล
                if (!lpr.Insert(lprModels))
                {
                    sb.Show(this, "เกิดข้อผิดผลาด " + lpr.ERR, Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                    return;
                }
            }
            else // Update
            {
                if (!lpr.Update(lprModels))
                {
                    sb.Show(this, "เกิดข้อผิดผลาด " + lpr.ERR, Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                    return;
                }
            }

            sb.Show(this, "บันทึกข้อมูลสำเร็จ", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
            ClearForm();
            if (lpr.Select())
                dgv.DataSource = lpr.tb;
        }

        private async void btnTest_Click(object sender, EventArgs e)
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

                    LRP.ip = txtIP.Text;
                    LRP.port = txtPort.Text;
                    LRP.user = txtUser.Text;
                    LRP.pass = txtPass.Text;
                    LRP.option = txtoption.Text.Split('\n');


                    await LRP.SetCamera(vlcControl1);
                    await Task.Run(ConnectCam);
                    break;
                case "หยุดทดสอบ":
                    btnTest.Text = "เริ่มทดสอบ";
                    LRP.Stop(vlcControl1);
                    break;
            }
        }

        private void btnCancelConnect_Click(object sender, EventArgs e)
        {
            btnTest.Text = "เริ่มทดสอบ";
            gb.Enabled = true;
            gbConnect.Visible = false;
            tmConnect.Stop();
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
                            lprModels lprModels = new lprModels
                            {
                                old_ip = dgv.Rows[e.RowIndex].Cells["cl_ip"].Value.ToString()
                            };
                            // delete
                            if (lpr.Delete(lprModels))
                            {
                                sb.Show(this, "ลบข้อมูลสำเร็จ", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                                if (lpr.Select())
                                    dgv.DataSource = lpr.tb;
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

        private void frmLPR_Load(object sender, EventArgs e)
        {
            // Show data
            if (lpr.Select())
                dgv.DataSource = lpr.tb;
            dgv.DefaultCellStyle.ForeColor = Color.Black;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void gb_Click(object sender, EventArgs e)
        {

        }

        private void vlcControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
