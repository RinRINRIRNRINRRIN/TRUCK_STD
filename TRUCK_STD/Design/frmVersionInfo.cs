using System;
using System.Windows.Forms;

namespace TRUCK_STD.Design
{
    public partial class frmVersionInfo : Form
    {
        public frmVersionInfo()
        {
            InitializeComponent();
        }

        private void frmVersionInfo_KeyDown(object sender, KeyEventArgs e)
        {
            // เปิดหมด Version admin เพื่อแสดงรายละเอียดต่าง ๆ ไม่เกียวกับ version ของเครื่องชั่ง
            if (e.Control && e.KeyCode == Keys.F9)
            {
                MessageBox.Show("Version info program\n" +
                    "Version : " + Variable.systemVersion + "\n", "Version program", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void gbMain_Click(object sender, EventArgs e)
        {

        }
    }
}
