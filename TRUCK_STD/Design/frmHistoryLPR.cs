using System.Data;
using System.Windows.Forms;
using TRUCK_STD.DbBase;
using TRUCK_STD.Functions;

namespace TRUCK_STD.Design
{
    public partial class frmHistoryLPR : Form
    {
        public frmHistoryLPR()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, System.EventArgs e)
        {
            string state = "";
            switch (cbbWeightType.Text)
            {
                case "กำลังดำเนินการ":
                    state = "Process";
                    break;
                case "ดำเนินการสำเร็จ":
                    state = "Success";
                    break;
            }

            string sql = "SELECT * FROM truckdata.job a " +
    "LEFT JOIN truckdata.jobdetail b " +
    "ON  b.jobId = a.id " +
    $"WHERE  a.state = '{state}' and a.stationName = '{registy.system.stationName}' ";

            // เช็ค command เพิ่มเติม
            if (cbDate.Checked == true)
            {
                string _start = dtpStart.Value.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.CreateSpecificCulture("EN-en"));
                string _end = dtpEnd.Value.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.CreateSpecificCulture("EN-en"));

                sql += $" and a.dateRegistor BETWEEN '{_start} 00:00:00' and '{_end} 23:59:59' ";
            }

            if (cbLicense.Checked == true)
            {
                sql += $" and b.licenseHead LIKE '%{txtLicense.Text}%'";
            }

            // Get data 
            if (job.SelectSearchQuery(sql))
            {
                DataTable tb = new DataTable();
                tb.Columns.Add("id");
                tb.Columns.Add("dateRegistor");
                tb.Columns.Add("jobId");
                tb.Columns.Add("licenseHead");
                tb.Columns.Add("licenseTail");
                tb.Columns.Add("netWeight");
                tb.Columns.Add("state");

                string jobOld = "";
                foreach (DataRow item in job.tb.Rows)
                {
                    string _id = item["id"].ToString();
                    string _date = item["dateRegistor"].ToString();
                    string _jobId = item["jobOrder"].ToString();
                    string _licenseHead = item["licenseHead"].ToString();
                    string _licenseTail = item["licenseTail"].ToString();
                    string _weight = item["netWeight"].ToString();
                    string _state = item["state"].ToString();

                    if (jobOld != _jobId)
                    {
                        jobOld = _jobId;
                        tb.Rows.Add(_id, _date, _jobId, _licenseHead, _licenseTail, _weight, _state);
                    }
                }

                dgvdata.DataSource = tb;
            }
        }

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string id = dgvdata.Rows[e.RowIndex].Cells["cl_id"].Value.ToString();
                string jobId = dgvdata.Rows[e.RowIndex].Cells["cl_job"].Value.ToString();
                string clName = dgvdata.Columns[e.ColumnIndex].Name;
                switch (clName)
                {
                    case "cl_del":
                        msg.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;
                        msg.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
                        msg.Show($"do you want delete the data \n เลขที่การชั่ง {jobId}", "Delete data");
                        break;
                    case "cl_print":
                        if (cbbWeightType.Text == "กำลังดำเนินการ")
                        {
                            msg.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;
                            msg.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                            msg.Show("Can't print the document in Process type", "Print document");
                            return;
                        }
                        frmReport frmReport = new frmReport();
                        frmReport.reportType = "LPR";
                        frmReport.id = id;
                        frmReport.ShowDialog();
                        break;
                }
            }
            catch (System.Exception exx)
            {


            }
        }

        private void frmHistoryLPR_Load(object sender, System.EventArgs e)
        {
            job.SelectHistory();
            dgvdata.DataSource = job.tb;

        }
    }

}
