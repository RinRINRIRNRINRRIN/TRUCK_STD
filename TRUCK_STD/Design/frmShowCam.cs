using System.Windows.Forms;

namespace TRUCK_STD.Design
{
    public partial class frmShowCam : Form
    {
        public frmShowCam()
        {
            InitializeComponent();
        }

        public bool isClosing = false;
        private void frmShowCam_FormClosing(object sender, FormClosingEventArgs e)
        {
            isClosing = true;
        }
    }
}
