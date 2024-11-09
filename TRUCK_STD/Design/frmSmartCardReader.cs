using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThaiNationalIDCard;
namespace TRUCK_STD.Design
{
    public partial class frmSmartCardReader : Form
    {
        ThaiIDCard iDCard = new ThaiIDCard();
        public frmSmartCardReader()
        {
            InitializeComponent();
            iDCard.eventCardInsertedWithPhoto += IDCard_eventCardInsertedWithPhoto;
            iDCard.eventPhotoProgress += IDCard_eventPhotoProgress;
            iDCard.eventCardRemoved += IDCard_eventCardRemoved;
        }

        private void IDCard_eventPhotoProgress(int value, int maximum)
        {
            if (txtBoxLog.InvokeRequired)
            {
                if (PhotoProgressBar1.Maximum != maximum)
                    PhotoProgressBar1.BeginInvoke(new MethodInvoker(delegate { PhotoProgressBar1.Maximum = maximum; }));

                // fix progress bar sync.
                if (PhotoProgressBar1.Maximum > value)
                    PhotoProgressBar1.BeginInvoke(new MethodInvoker(delegate { PhotoProgressBar1.Value = value + 1; }));

                PhotoProgressBar1.BeginInvoke(new MethodInvoker(delegate { PhotoProgressBar1.Value = value; }));
            }
            else
            {
                if (PhotoProgressBar1.Maximum != maximum)
                    PhotoProgressBar1.Maximum = maximum;

                // fix progress bar sync.
                if (PhotoProgressBar1.Maximum > value)
                    PhotoProgressBar1.Value = value + 1;

                PhotoProgressBar1.Value = value;
            }
        }

        private void IDCard_eventCardRemoved()
        {

        }

        private void IDCard_eventCardInsertedWithPhoto(Personal personal)
        {
            if (personal == null)
            {
                if (iDCard.ErrorCode() > 0)
                {
                    MessageBox.Show(iDCard.Error());
                }
                return;
            }
        }

        void GetReader()
        {
            while (true)
            {
                try
                {
                    ThaiIDCard idcard = new ThaiIDCard();
                    string[] readers = idcard.GetReaders();

                    if (readers == null)
                    {
                        BeginInvoke(new MethodInvoker(delegate ()
                        {
                            label1.Text = "เชื่อมต่อไม่สำเร็จ";
                        }));
                    }
                    else
                    {
                        BeginInvoke(new MethodInvoker(delegate ()
                        {
                            label1.Text = "เชื่อมต่อสำเร็จ";
                        }));
                    }

                }
                catch (Exception ex)
                {
                    BeginInvoke(new MethodInvoker(delegate ()
                    {
                        label1.Text = "เชื่อมต่อไม่สำเร็จ";
                    }));
                }
            }
        }

        private void frmSmartCardReader_Load(object sender, EventArgs e)
        {

            Task.Run(GetReader);
        }
    }
}
