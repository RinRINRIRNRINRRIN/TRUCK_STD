using System;
using System.Windows.Forms;
using TRUCK_STD.Design;
using TRUCK_STD.Functions;

namespace TRUCK_STD.UControls
{
    public partial class ucLPRCam : UserControl
    {
        public ucLPRCam()
        {
            InitializeComponent();
        }

        private async void btnZoom_Click(object sender, EventArgs e)
        {
            string optionCam = ":network-caching=0|:file-caching=100";
            frmShowCam frmShowCam = new frmShowCam();
            CCTV cCTV = new CCTV();
            await cCTV.Stop(vlcCam);
            string[] _ip = gbCam.Text.Split(':');
            cCTV.ip = _ip[1];
            cCTV.port = lblPort.Text;
            cCTV.user = lblUser.Text;
            cCTV.pass = lblPass.Text;
            cCTV.option = optionCam.Split('|');




            frmShowCam.ShowDialog();

            if (frmShowCam.isClosing)
            {
                await cCTV.Stop(frmShowCam.vlc);
                await cCTV.SetCamera(vlcCam);
            }
        }
    }
}
