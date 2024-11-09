using System;
using System.Windows.Forms;
using TRUCK_STD.Functions;

namespace TRUCK_STD.Design
{
    public partial class frmCCTV_TEST : Form
    {
        public frmCCTV_TEST()
        {
            InitializeComponent();
        }
        CCTV cCTV = new CCTV();
        private void frmCCTV_TEST_Load(object sender, EventArgs e)
        {
            //DirectoryInfo directoryInfo = new DirectoryInfo("C:\\Program Files (x86)\\VideoLAN\\VLC");
            //vlcControl1.VlcLibDirectory = directoryInfo;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                cCTV = new CCTV
                {
                    ip = txtIP.Text,
                    port = txtPort.Text,
                    user = txtUse.Text,
                    pass = txtPass.Text,
                    option = txtOption.Text.Split('\n')

                };
                cCTV.SetCamera(vlcControl1);

                btnStart.Enabled = false;
                btnStop.Enabled = true;
                btnTake.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                cCTV.Stop(vlcControl1);
                btnStart.Enabled = true;
                btnStop.Enabled = false;
                btnTake.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTake_Click(object sender, EventArgs e)
        {
            cCTV.TakePicture(vlcControl1);
        }
    }
}
