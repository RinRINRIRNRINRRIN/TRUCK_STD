﻿using ClosedXML.Excel;
using Guna.UI2.WinForms;
using System;
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

        void ShowDataOnGrid()
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
    "ON  b.jobOrder = a.jobOrder " +
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
                sql += $" and a.licenseHead LIKE '%{txtLicense.Text}%'";
            }

            // Get data 
            if (jobDetail.SelectSearchQuery(sql))
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
                foreach (DataRow item in jobDetail.tb.Rows)
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

        private void btnSearch_Click(object sender, System.EventArgs e)
        {
            ShowDataOnGrid();
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
                        DialogResult result = msg.Show($"Do you want delete the data \n JobOrder : {jobId}", "Delete data");

                        if (result == DialogResult.Yes)
                        {
                            // ปรับสถานะเป็น ยกเลิก
                            if (!job.updateStataWhenDelete(jobId))
                            {
                                msg.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error;
                                msg.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                                msg.Show($"Error delete order : {jobId}\n{job.ERR}", "Error delete");
                                return;
                            }
                            msg.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                            msg.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                            msg.Show($"Delete order success \nJobOrder : {jobId}", "Error delete");
                            ShowDataOnGrid();
                        }
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

                        switch (registy.system.bussinessType)
                        {
                            case "ทั่วไป":
                                frmReport.reportType = "MN";
                                break;
                            case "หัวมันสด":
                                frmReport.reportType = "Cassava";
                                break;
                            case "ข้าวเปลือก":
                                frmReport.reportType = "Paddy";
                                break;
                            case "ข้าวโพดเลี้ยงสัตว์":
                                frmReport.reportType = "Corn";
                                break;

                        }

                        frmReport.id = jobId;
                        frmReport.ShowDialog();
                        break;
                }
            }
            catch (System.Exception exx)
            {
                Console.WriteLine(exx.Message);
            }
        }

        private void frmHistoryLPR_Load(object sender, System.EventArgs e)
        {
            dtpStart.Value = DateTime.Now;
            dtpEnd.Value = DateTime.Now;

        }

        private void cbLicense_Click(object sender, EventArgs e)
        {
            Guna2CheckBox cbb = sender as Guna2CheckBox;
            switch (cbb.Text)
            {
                case "ค้นหาจากวันที่":
                    if (cbb.Checked)
                    {
                        dtpEnd.Enabled = true;
                        dtpStart.Enabled = true;
                    }
                    else
                    {
                        dtpEnd.Enabled = false;
                        dtpStart.Enabled = false;
                    }
                    break;
                case "ค้นหาจากทะเบียนรถ":
                    if (cbb.Checked)
                    {
                        txtLicense.Enabled = true;
                    }
                    else
                    {
                        txtLicense.Enabled = false;
                    }
                    break;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            // ตรวจสอบก่อนว่าเลือกข้อมูลหรือไม่
            if (dgvdata.Rows.Count == 0)
            {
                msg.Icon = MessageDialogIcon.Warning;
                msg.Buttons = MessageDialogButtons.OK;
                msg.Show("Data is null ,Please search the data for export to excel", "Excel export");
                return;
            }
            // ทำการสูตร Exxcel
            using (SaveFileDialog sa = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
            {
                if (sa.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (XLWorkbook el = new XLWorkbook())
                        {
                            DataTable tb = new DataTable();
                            tb = (DataTable)dgvdata.DataSource;
                            el.Worksheets.Add(tb, "Data export");
                            el.SaveAs(sa.FileName);
                        }
                        msg.Icon = MessageDialogIcon.Information;
                        msg.Buttons = MessageDialogButtons.OK;
                        msg.Show("Export data success", "Excel export");
                    }
                    catch (Exception ex)
                    {
                        msg.Icon = MessageDialogIcon.Error;
                        msg.Buttons = MessageDialogButtons.OK;
                        msg.Show("Export data error\n" + ex.Message, "Excel error");
                    }
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // ตรวจสอบก่อนว่าเลือกข้อมูลหรือไม่
            if (dgvdata.Rows.Count == 0)
            {
                msg.Icon = MessageDialogIcon.Warning;
                msg.Buttons = MessageDialogButtons.OK;
                msg.Show("Data is null ,Please search the data for print", "Print report");
                return;
            }

            frmReport frmReport = new frmReport();
            switch (cbbWeightType.Text)
            {
                case "ดำเนินการสำเร็จ":
                    frmReport.state = "Success";
                    break;
                case "กำลังดำเนินการ":
                    frmReport.state = "Process";
                    break;
            }
            frmReport.reportType = "ReportAll";

            frmReport.ShowDialog();
        }
    }

}
