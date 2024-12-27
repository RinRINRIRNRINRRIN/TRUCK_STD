using System;
using System.Drawing;
using System.Windows.Forms;
using TRUCK_STD.Function;
using TRUCK_STD.Functions;

namespace TRUCK_STD.Design
{
    public partial class frmInformation : Form
    {
        public frmInformation()
        {
            InitializeComponent();
        }
        void CheckFunction(Label lbl, string _bool)
        {
            switch (_bool)
            {
                case "TRUE":
                    lbl.Text = "Active";
                    lbl.ForeColor = Color.Green;
                    break;
                case "FALSE":
                    lbl.Text = "Inactive";
                    lbl.ForeColor = Color.Red;
                    break;
            }
        }
        private void frmInformation_Load(object sender, EventArgs e)
        {
            // Get data from registry
            lblID.Text = registy.system.id;
            lblBusinessType.Text = registy.system.bussinessType;
            lblSystemType.Text = registy.system.programType;
            string dateEXP = registy.system.dateExpire;
            if (dateEXP == "FOREVER")
            {
                lblDateExpire.Text = "--";
                linkLabel1.Visible = false;
            }
            else
            {
                lblDateExpire.ForeColor = Color.Red;
                lblDateExpire.Text = $"หมดอายุในวันที่ : {dateEXP}";
                linkLabel1.Visible = true;
            }

            CheckFunction(lblRFID, registy.function.RFIDState);
            CheckFunction(lblCAMERA, registy.function.CAMERAState);
            CheckFunction(lblLPR, registy.function.LPRState);
            //CheckFunction(lblPRICE, registy.function.PRICE);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Func_Main.SHOW_FROM_ALERT(0, "รหัสสำหรับต่ออายุโปรแกรม");
            //frmProgramMessageAlert frmProgramMessageAlert = new frmProgramMessageAlert();
            //frmProgramMessageAlert.alertLevel = 0;
            //frmProgramMessageAlert.messageAlert = "รหัสสำหรับต่ออายุโปรแกรม";
            //frmProgramMessageAlert.ShowDialog();
            //if (frmProgramMessageAlert.chckUnlock == true)
            //{
            //    Application.Exit();
            //}
        }
    }
}
