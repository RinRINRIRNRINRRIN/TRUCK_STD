using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThaiNationalIDCard;

namespace TRUCK_STD.Functions
{
    internal class smartCard
    {
        public smartCard()
        {
            MonitorStart(GetReader()[0]);
            idcard.eventCardInserted += Idcard_eventCardInserted;
            idcard.eventCardRemoved += Idcard_eventCardRemoved;
        }

        ThaiIDCard idcard = new ThaiIDCard();
        private void Idcard_eventCardRemoved()
        {

        }

        private void Idcard_eventCardInserted(Personal personal)
        {

        }

        string[] GetReader()
        {
            return idcard.GetReaders();
        }

        void MonitorStart(string device)
        {
            idcard.MonitorStart(device);
        }

        public async Task GetStatus(Label lbl)
        {
            while (true)
            {
                try
                {
                    string[] readers = GetReader();

                    if (readers == null)
                    {

                        lbl.Text = "เชื่อมต่อไม่สำเร็จ";
                        lbl.ForeColor = Color.Red;
                    }
                    else
                    {

                        lbl.Text = "เชื่อมต่อสำเร็จ";
                        lbl.ForeColor = Color.Green;

                    }
                }
                catch (Exception ex)
                {

                    lbl.Text = "เชื่อมต่อไม่สำเร็จ";
                    lbl.ForeColor = Color.Red;

                }

                await Task.Delay(1000);
            }
        }





    }
}
