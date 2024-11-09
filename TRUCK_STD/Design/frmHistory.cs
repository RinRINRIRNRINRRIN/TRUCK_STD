using Bunifu.UI.WinForms;
using ClosedXML.Excel;
using Serilog;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TRUCK_STD.Function;
using TRUCK_STD.Functions;
using TRUCK_STD.MSACCESSCommand;
namespace TRUCK_STD.Design
{
    public partial class frmHistory : Form
    {

        public frmHistory()
        {
            InitializeComponent();
        }

        #region "VARIABEL LOCAL"
        tbWGH tbWGH = new tbWGH();
        tbID_FI tbID_FI = new tbID_FI();
        tbCOMPANY tbCOMPANY = new tbCOMPANY();
        tbTYPE tbTYPE = new tbTYPE();
        tbHireWeight tbHireWeight = new tbHireWeight();
        BunifuSnackbar msg = new BunifuSnackbar();

        #endregion


        #region "FUCSION LOCAL"

        /// <summary>
        /// สำหรับโชว์ข้อมูล และจัดเรียงข้อมูลใหม่
        /// </summary>
        void SHOW_DATA_DGV_WGH_OUT()
        {
            DataTable tb = tbWGH.SELECT_ALL_DATA();
            DataTable tb1 = new DataTable();

            foreach (DataColumn cl in tb.Columns)
            {
                tb1.Columns.Add(cl.ColumnName);
            }

            foreach (DataRow rw in tb.Rows)
            {
                string ORDER_NUMB = Convert.ToString(rw[0]);
                string dayIn = rw["DATE_IN"].ToString();
                string timeIn = rw["TIME_IN"].ToString();
                string dayOut = rw["DATE_OUT"].ToString();
                string timeOut = rw["TIME_OUT"].ToString();
                string gross = Convert.ToString(rw[5]);
                string carnum = Convert.ToString(rw[6]);
                string w_in = Convert.ToString(rw[7]);
                string w_out = Convert.ToString(rw[8]);
                string typedesc = Convert.ToString(rw[9]);
                string compdesc = Convert.ToString(rw[10]);
                string typecode = Convert.ToString(rw[11]);
                string compcode = Convert.ToString(rw[12]);
                string price = Convert.ToString(rw[13]);
                string priceNet = $"{rw[14]:#,###,###.##}";

                tb1.Rows.Add(ORDER_NUMB, dayIn, dayOut, timeIn, timeOut, gross, carnum, w_in, w_out, typedesc, compdesc, typecode, compcode, price, priceNet);
            }
            dgvWGH_OUT.DefaultCellStyle.ForeColor = Color.Black;

            // ทำการเช็คก่อนว่า มีใช้งานฟังชั่นคำนวนราคาหรือไม่
            if (registy.function.PRICE == "TRUE")
            {
                dgvWGH_OUT.Columns["cl_price"].Visible = true;
                dgvWGH_OUT.Columns["cl_priceNet"].Visible = true;

                foreach (DataGridViewRow rw in dgvWGH_OUT.Rows)
                {
                    if (rw.Cells["cl_priceNet"].Value.ToString() == "")
                    {
                        rw.Cells["cl_priceNet"].Value = "0";
                    }
                }
            }
            else
            {
                dgvWGH_OUT.Columns["cl_priceNet"].Visible = false;
                dgvWGH_OUT.Columns["cl_price"].Visible = false;
            }

            dgvWGH_OUT.DataSource = tb1;

        }


        /// <summary>
        /// สำหรับโชว์ข้อมูล และจัดเรียงข้อมูลใหม่
        /// </summary>
        void SHOW_DATA_DGV_WGH_INT()
        {
            DataTable tb = tbID_FI.SELECT_ALL_DATA();
            DataTable tb1 = new DataTable();

            foreach (DataColumn cl in tb.Columns)
            {
                tb1.Columns.Add(cl.ColumnName);
            }

            foreach (DataRow rw in tb.Rows)
            {
                string strDayIn = Convert.ToString(rw["DATE_IN"]);
                string strTimeIn = Convert.ToString(rw["TIME_IN"]);

                string[] dateDayIn = strDayIn.Split(' ');
                string[] dateTimeIn = strTimeIn.Split(' ');


                string dayIn = dateDayIn[0];
                string timeIn = dateTimeIn[1];
                string carnum = Convert.ToString(rw[0]);
                string w_in = Convert.ToString(rw[1]);
                string typedesc = Convert.ToString(rw[6]);
                string compdesc = Convert.ToString(rw[8]);

                tb1.Rows.Add(carnum, w_in, dayIn, timeIn, "", "", typedesc, "", compdesc);
            }
            dgvWGH_IN.DataSource = tb1;
        }

        void SHOW_DATA_DGV_HIIRE()
        {
            DataTable tb = tbHireWeight.SELECT_ALL_DATA();
            DataTable tb1 = new DataTable();

            foreach (DataColumn cl in tb.Columns)
            {
                tb1.Columns.Add(cl.ColumnName);
            }

            foreach (DataRow rw in tb.Rows)
            {
                string order = Convert.ToString(rw["ORDERNUM"]);
                string carnum = Convert.ToString(rw["CARNUM_H"]);
                string w_in = Convert.ToString(rw["WG"]);
                string strDayIn = Convert.ToString(rw["DATE_IN"]);
                string strTimeIn = Convert.ToString(rw["TIME_IN"]);

                string typedesc = Convert.ToString(rw["typedesc"]);
                string compdesc = Convert.ToString(rw["comdesc"]);

                tb1.Rows.Add(order, carnum, w_in, strDayIn, strTimeIn, "", typedesc, "", compdesc);
            }
            dgvHireWeight.DataSource = tb1;
        }

        /// <summary>
        /// สำหรับโชว์ข้อมูลการค้นหาที่ไม่แน่นอน
        /// </summary>
        /// <param name="query">query string ของตารางนั้น ๆ </param>
        /// <param name="tableType">ข้อมูลตารางที่ต้องการค้นหา IN,OUT</param>s
        void SHOW_DATA_WHEN_SEAERCH(string query, string tableType)
        {
            switch (tableType)
            {
                case "OUT":
                    #region WGH_OUT
                    DataTable tb = tbWGH.SELECT_SEARCH_DATA_MANY(query);
                    DataTable tb1 = new DataTable();

                    foreach (DataColumn cl in tb.Columns)
                    {
                        tb1.Columns.Add(cl.ColumnName);
                    }

                    // ตรวจสอบว่าพบข้อมูลหรือไม่ 
                    if (tb.Rows.Count > 0)
                    {
                        foreach (DataRow rw in tb.Rows)
                        {
                            string ORDER_NUMB = Convert.ToString(rw[0]);
                            string dayIn = rw["DATE_IN"].ToString();
                            string timeIn = rw["TIME_IN"].ToString();
                            string dayOut = rw["DATE_OUT"].ToString();
                            string timeOut = rw["TIME_OUT"].ToString();
                            string gross = Convert.ToString(rw[5]);
                            string carnum = Convert.ToString(rw[6]);
                            string w_in = Convert.ToString(rw[7]);
                            string w_out = Convert.ToString(rw[8]);
                            string typedesc = Convert.ToString(rw[9]);
                            string compdesc = Convert.ToString(rw[10]);
                            string typecode = Convert.ToString(rw[11]);
                            string compcode = Convert.ToString(rw[12]);
                            string price = Convert.ToString(rw[13]);
                            string priceNet = $"{rw[14]:#,###,###.##}";

                            tb1.Rows.Add(ORDER_NUMB, dayIn, dayOut, timeIn, timeOut, gross, carnum, w_in, w_out, typedesc, compdesc, typecode, compcode, price, priceNet);
                            dgvWGH_OUT.DataSource = tb1;
                        }
                    }
                    else
                    {
                        dgvWGH_OUT.DataSource = tb1;
                    }
                    #endregion
                    break;
                case "IN":
                    #region WGH_IN
                    DataTable tb_in = tbID_FI.SELECT_SEARCH_DATA_MANY(query);
                    DataTable tb1_in = new DataTable();

                    foreach (DataColumn cl in tb_in.Columns)
                    {
                        tb1_in.Columns.Add(cl.ColumnName);
                    }

                    // ตรวจสอบว่ามีข้อมูลหรือไม่ 
                    if (tb_in.Rows.Count > 0)
                    {
                        foreach (DataRow rw in tb_in.Rows)
                        {
                            string strDayIn = Convert.ToString(rw["DATE_IN"]);
                            string strTimeIn = Convert.ToString(rw["TIME_IN"]);

                            string[] dateDayIn = strDayIn.Split(' ');
                            string[] dateTimeIn = strTimeIn.Split(' ');


                            string dayIn = dateDayIn[0];
                            string timeIn = dateTimeIn[1];
                            string carnum = Convert.ToString(rw[0]);
                            string w_in = Convert.ToString(rw[1]);
                            string typedesc = Convert.ToString(rw[6]);
                            string compdesc = Convert.ToString(rw[8]);

                            tb1_in.Rows.Add(carnum, w_in, dayIn, timeIn, "", "", typedesc, "", compdesc);
                            dgvWGH_IN.DataSource = tb1_in;
                        }
                    }
                    else
                    {
                        dgvWGH_IN.DataSource = tb_in;
                    }
                    #endregion
                    break;

            }
        }

        /// <summary>
        /// ใช้สำหรับเรียงคิวรีใหม่ หากต้องการค้นหาหลาย  ๆเงือนไข
        /// </summary>
        void SETUP_QUERY()
        {
            string query_out = "SELECT ORDER_NUMB,DATE_IN,DATE_OUT,TIME_IN,TIME_OUT,GROSS,CARNUM,W_IN,W_OUT,TYPEDESC,COMPDESC,TYPECODE,COMPCODE,PRICE,price_net  FROM WGH  ";
            string query_in = "SELECT CARNUM_H,WG,DATE_IN,TIME_IN,price,comcode,comdesc,typecode,typedesc FROM ID_FI  ";
            switch (cbbTable.Text)
            {
                case "ข้อมูลรถชั่งออก":
                    #region ค้นหาข้อมูลชั่งสำเร็จ
                    // ตรวจสอบว่ามีค่าว่างหรือไม่

                    if (cbSearchDate.Checked == true)
                    {
                        DateTime startDay = dtpStart.Value;
                        DateTime endDay = dtpEnd.Value;

                        string sD = startDay.Day.ToString();
                        string sM = startDay.Month.ToString();
                        string sY = startDay.Year.ToString();

                        string eD = endDay.Day.ToString();
                        string eM = endDay.Month.ToString();
                        string eY = endDay.Year.ToString();

                        string dayStart = sD + "/" + sM + "/" + sY;
                        string dayEnd = eD + "/" + eM + "/" + eY;

                        query_out += "WHERE DATE_OUT BETWEEN ('" + startDay.ToShortDateString() + "') AND ('" + endDay.ToShortDateString() + "')";
                    }

                    if (cbSearchProduct.Checked)
                    {
                        if (query_out.Contains("WHERE"))
                        {
                            query_out += "AND TYPEDESC ='" + cbbSearchProduct.Text + "'";
                        }
                        else
                        {
                            query_out += "WHERE TYPEDESC = '" + cbbSearchProduct.Text + "'";
                        }
                    }

                    if (cbSearchCar.Checked)
                    {
                        if (query_out.Contains("WHERE"))
                        {
                            query_out += "AND CARNUM = '" + cbbSearchCar.Text + "'";
                        }
                        else
                        {
                            query_out += "WHERE CARNUM = '" + cbbSearchCar.Text + "'";
                        }
                    }

                    if (cbSearchCustomer.Checked)
                    {
                        if (query_out.Contains("WHERE"))
                        {
                            query_out += "AND COMPDESC ='" + cbbSearchCustomer.Text + "'";
                        }
                        else
                        {
                            query_out += "WHERE COMPDESC ='" + cbbSearchCustomer.Text + "'";
                        }
                    }

                    SHOW_DATA_WHEN_SEAERCH(query_out, "OUT");
                    #endregion
                    break;
                case "ข้อมูลรถชั่งเข้า":
                    #region ค้นหาข้อมูลค้างชั่ง

                    if (cbSearchProduct.Checked)
                    {
                        if (query_in.Contains("WHERE"))
                        {
                            query_in += "AND TYPEDESC ='" + cbbSearchProduct.Text + "'";
                        }
                        else
                        {
                            query_in += "WHERE TYPEDESC = '" + cbbSearchProduct.Text + "'";
                        }
                    }

                    if (cbSearchCar.Checked)
                    {
                        if (query_in.Contains("WHERE"))
                        {
                            query_in += "AND CARNUM = '" + cbbSearchCar.Text + "'";
                        }
                        else
                        {
                            query_in += "WHERE CARNUM = '" + cbbSearchCar.Text + "'";
                        }
                    }

                    if (cbSearchCustomer.Checked)
                    {
                        if (query_in.Contains("WHERE"))
                        {
                            query_in += "AND COMPDESC ='" + cbbSearchCustomer.Text + "'";
                        }
                        else
                        {
                            query_in += "WHERE COMPDESC ='" + cbbSearchCustomer.Text + "'";
                        }
                    }
                    SHOW_DATA_WHEN_SEAERCH(query_in, "IN");

                    #endregion
                    break;
            }
        }

        /// <summary>
        /// ใช้สำหรับกำหนดสิทธิ์ให้กับเมนู
        /// </summary>
        void CHECK_PRIVIRAGE()
        {
            // ทำการเช็คก่อนว่า มีใช้งานฟังชั่นคำนวนราคาหรือไม่
            if (registy.function.PRICE == "TRUE")
            {
                dgvWGH_OUT.Columns["cl_price"].Visible = true;
                dgvWGH_OUT.Columns["cl_priceNet"].Visible = true;

                foreach (DataGridViewRow rw in dgvWGH_OUT.Rows)
                {
                    if (rw.Cells["cl_priceNet"].Value.ToString() == "")
                    {
                        rw.Cells["cl_priceNet"].Value = "0";
                    }
                }
            }
            else
            {
                dgvWGH_OUT.Columns["cl_priceNet"].Visible = false;
                dgvWGH_OUT.Columns["cl_price"].Visible = false;
            }


            // ตรวจสอบว่าใช้สิทธิ์ sa หรือไม่ เพราะ sa เข้าได้หมดทุกเมนู
            if (Func_Privilage.emp_usernmae != "sa")
            {
                // ตรวจสอบว่า มีสิทธิ์อะไรบ้าง ค่าเริ่มค้นคือ TRUE
                if (Func_Privilage.pr_history.pr_systemDel == "FALSE")
                {
                    dgvWGH_OUT.Columns["cl_del_out"].Visible = false;
                }
            }

        }
        #endregion


        private void frmHistory_Load(object sender, EventArgs e)
        {
            // กำหนดค่าให้กับ combobox
            cbbTable.Items.Clear();
            cbbTable.Items.Add("--เลือกการชั่ง--");
            cbbTable.SelectedIndex = 0;

            cbbSearchCar.Items.Clear();
            cbbSearchCar.Items.Add("--ทะเบียนรถ--");
            cbbSearchCar.SelectedIndex = 0;

            cbbSearchCustomer.Items.Clear();
            cbbSearchCustomer.Items.Add("--ชื่อลูกค้า--");
            cbbSearchCustomer.SelectedIndex = 0;

            cbbSearchProduct.Items.Clear();
            cbbSearchProduct.Items.Add("--ชื่อสินค้า--");
            cbbSearchProduct.SelectedIndex = 0;

            dgvWGH_OUT.DefaultCellStyle.ForeColor = Color.Black;
            dgvWGH_IN.DefaultCellStyle.ForeColor = Color.Black;
            dgvHireWeight.DefaultCellStyle.ForeColor = Color.Black;


            // กำหนดค่าให้กลับ dtp
            DateTime dateTime = DateTime.Now;
            // แปลงวันที่เป็นรูปแบบ ค.ศ.
            string formattedDate = dateTime.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"));

            // กำหนดค่าให้กับ DateTimePicker ในรูปแบบค.ศ.
            dtpStart.Value = DateTime.ParseExact(formattedDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            dtpEnd.Value = dateTime;
            // เช็คสิทธิ์การใช้งาน เมนู
            CHECK_PRIVIRAGE();
        }



        private void btnSearch_Click(object sender, EventArgs e)
        {
            #region ตรวจสอบค่าว่าง
            // ตรวจสอบก่อนว่าได้เลือกตารางก่อนค้นหาหรือไม่
            if (cbbTable.Text == "--เลือกการชั่ง--")
            {
                msg.Show(this, "กรุณา เลือกการชั่ง ที่ต้องการจะค้นหาก่อน", BunifuSnackbar.MessageTypes.Warning, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                return;
            }
            // ตรวจสอบว่าเลือกข้อมูลถูกต้องหรือไม่
            DateTime a = dtpStart.Value;
            DateTime b = dtpEnd.Value;
            // ตรวจสอบว่าถ้าวันที่สิ้นสุดมากกว่าวันที่เริ่มค้นจะ error 
            if (a > b)
            {
                msg.Show(this, "รูปแบบวันที่ที่ต้องการหาไม่ถูกต้อง", BunifuSnackbar.MessageTypes.Warning, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                return;
            }
            // ตรวจสอบว่า มีการ checkbox แล้วได้เลือกข้อมูลหรือไม่
            if (cbSearchCar.Checked == true)
            {
                if (cbbSearchCar.Text == "--ทะเบียนรถ--")
                {
                    msg.Show(this, "กรุณาเลือก " + cbbSearchCar.Text + " ที่ต้องการจะหาข้อมูล", BunifuSnackbar.MessageTypes.Warning, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                    return;
                }
            }
            if (cbSearchCustomer.Checked == true)
            {
                if (cbbSearchCustomer.Text == "--ชื่อลูกค้า--")
                {
                    msg.Show(this, "กรุณาเลือก " + cbbSearchCustomer.Text + " ที่ต้องการจะหาข้อมูล", BunifuSnackbar.MessageTypes.Warning, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                    return;
                }
            }
            if (cbSearchProduct.Checked == true)
            {
                if (cbbSearchProduct.Text == "--ชื่อสินค้า--")
                {
                    msg.Show(this, "กรุณาเลือก " + cbbSearchProduct.Text + " ที่ต้องการจะหาข้อมูล", BunifuSnackbar.MessageTypes.Warning, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                    return;
                }
            }


            #endregion
            // ทำการเรียง query เพื่อแสดงผล
            SETUP_QUERY();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            // ตรวจสอบก่อนว่าได้เลือกตารางก่อนค้นหาหรือไม่
            if (cbbTable.Text == "--เลือกการชั่ง--")
            {
                msg.Show(this, "กรุณา เลือกการชั่ง ที่ต้องการจะแสดงข้อมูล", BunifuSnackbar.MessageTypes.Warning, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                return;
            }

            switch (cbbTable.Text)
            {
                case "ข้อมูลค้างชั่ง":
                    SHOW_DATA_DGV_WGH_INT();
                    break;
                case "ข้อมูลชั่งสำเร็จ":
                    SHOW_DATA_DGV_WGH_OUT();
                    break;
            }
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            // ตรวจสอบก่อนว่าได้เลือกตารางก่อนค้นหาหรือไม่
            if (cbbTable.Text == "--เลือกการชั่ง--")
            {
                msg.Show(this, "กรุณา เลือกการชั่ง ที่ต้องการจะค้นหาก่อน", BunifuSnackbar.MessageTypes.Warning, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
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
                            tb = (DataTable)dgvWGH_OUT.DataSource;
                            el.Worksheets.Add(tb, "Data export");
                            el.SaveAs(sa.FileName);
                        }
                        msg.Show(this, "Export รายการสำเร็จ", BunifuSnackbar.MessageTypes.Success, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                    }
                    catch (Exception ex)
                    {
                        msg.Show(this, "เกิดข้อผิดผลาก " + ex.Message, BunifuSnackbar.MessageTypes.Error, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                    }
                }
            }
        }

        #region DATAGRIDVIEW
        private void dgvWGH_IN_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string carnum = dgvWGH_IN.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn15"].Value.ToString();
                switch (dgvWGH_IN.Columns[e.ColumnIndex].Name)
                {

                    case "cl_del_in":
                        DialogResult dialogResult2 = MessageBox.Show("คุณต้องการลบข้อมูลหรือไม่\n", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            if (tbID_FI.DELETE_ALL_DATA(carnum))
                            {
                                msg.Show(this, "ลบรายการ " + carnum + " สำเร็จ", BunifuSnackbar.MessageTypes.Error, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                                SHOW_DATA_DGV_WGH_INT();
                            }
                            else
                            {
                                msg.Show(this, "เกิดข้อผิดผลาด ในการลบข้อมูล ", BunifuSnackbar.MessageTypes.Error, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                            }
                        }

                        break;
                }
            }
            catch (Exception ex)
            {
                Log.Error("เกิดข้อผิดผลาด frmHistory" + ex.Message);
            }
        }
        private void dgvWGH_OUT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string order_num = dgvWGH_OUT.Rows[e.RowIndex].Cells["cl_order_numb"].Value.ToString();
                switch (dgvWGH_OUT.Columns[e.ColumnIndex].Name)
                {

                    case "cl_del_out":
                        DialogResult dialogResult2 = MessageBox.Show("คุณต้องการลบข้อมูลหรือไม่\n", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            if (tbWGH.DELETE_SEARCH(order_num))
                            {
                                msg.Show(this, "ลบรายการ " + order_num + " สำเร็จ", BunifuSnackbar.MessageTypes.Success, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                                SHOW_DATA_DGV_WGH_OUT();
                            }
                            else
                            {
                                msg.Show(this, "เกิดข้อผิดผลาด ในการลบข้อมูล ", BunifuSnackbar.MessageTypes.Error, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                            }
                        }

                        break;
                    case "cl_print_out":
                        DataTable tb = tbWGH.SELECT_SEARCH_DATA(order_num);

                        if (registy.function.PRICE == "TRUE")
                        {
                            // ดึงข้อมูลมาแสดงที่ Report
                            foreach (DataRow rw in tb.Rows)
                            {
                                Func_Report.rtp_carnumber = Convert.ToString(rw["CARNUM"]);
                                Func_Report.rtp_dateIn = Convert.ToString(rw["DATE_IN"]);
                                Func_Report.rtp_timeIn = Convert.ToString(rw["TIME_IN"]);
                                Func_Report.rtp_dateOut = Convert.ToString(rw["DATE_OUT"]);
                                Func_Report.rtp_timeOut = Convert.ToString(rw["TIME_OUT"]);
                                Func_Report.rtp_company = Convert.ToString(rw["COMPDESC"]);
                                Func_Report.rtp_wghIn = Convert.ToString(rw["W_IN"]);
                                Func_Report.rtp_wghOut = Convert.ToString(rw["W_OUT"]);
                                Func_Report.rtp_ordernumber = Convert.ToString(rw["ORDER_NUMB"]);
                                Func_Report.rtp_gross = Convert.ToString(rw["GROSS"]);
                                Func_Report.rtp_product = Convert.ToString(rw["TYPEDESC"]);

                                Func_Report.rtp_price = Convert.ToString(rw["PRICE"]); ;
                                Func_Report.rtp_priceNet = $"{rw["price_net"]:#,###,###.##}";
                            }

                            frmReport frmReport = new frmReport();
                            frmReport.reportType = "HAVE_PRICE";
                            frmReport.ShowDialog();
                        }
                        else if (registy.function.PRICE == "FALSE")
                        {
                            // ดึงข้อมูลมาแสดงที่ Report
                            foreach (DataRow rw in tb.Rows)
                            {
                                Func_Report.rtp_carnumber = Convert.ToString(rw["CARNUM"]);
                                Func_Report.rtp_dateIn = Convert.ToString(rw["DATE_IN"]);
                                Func_Report.rtp_timeIn = Convert.ToString(rw["TIME_IN"]);
                                Func_Report.rtp_dateOut = Convert.ToString(rw["DATE_OUT"]);
                                Func_Report.rtp_timeOut = Convert.ToString(rw["TIME_OUT"]);

                                Func_Report.rtp_wghIn = Convert.ToString(rw["W_IN"]);
                                Func_Report.rtp_wghOut = Convert.ToString(rw["W_OUT"]);
                                Func_Report.rtp_ordernumber = Convert.ToString(rw["ORDER_NUMB"]);
                                Func_Report.rtp_gross = Convert.ToString(rw["GROSS"]);
                                Func_Report.rtp_product = Convert.ToString(rw["TYPEDESC"]);

                            }
                            frmReport frmReport = new frmReport();
                            frmReport.reportType = "NO_PRICE";
                            frmReport.ShowDialog();
                        }
                        // สั่งเปิดฟอร์ม

                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("frmHistory dgvWGH_OUT_CellContentClick " + ex.Message);
                Log.Error("frmHistory dgvWGH_OUT_CellContentClick " + ex.Message);
            }
        }

        #endregion

        #region COMBOBOX PROCESS
        private void cbSearchDate_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSearchDate.Checked == true)
            {
                dtpEnd.Enabled = true;
                dtpStart.Enabled = true;
            }
            else if (cbSearchDate.Checked == false)
            {
                dtpEnd.Enabled = false;
                dtpStart.Enabled = false;
            }
        }

        private void cbSearchProduct_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSearchProduct.Checked == true)
            {
                cbbSearchProduct.Enabled = true;
            }
            else if (cbSearchProduct.Checked == false)
            {
                cbbSearchProduct.Enabled = false;
            }
        }

        private void cbSearchCustomer_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSearchCustomer.Checked == true)
            {
                cbbSearchCustomer.Enabled = true;
            }
            else if (cbSearchCustomer.Checked == false)
            {
                cbbSearchCustomer.Enabled = false;
            }
        }

        private void cbSearchCar_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSearchCar.Checked == true)
            {
                cbbSearchCar.Enabled = true;
            }
            else if (cbSearchCar.Checked == false)
            {
                cbbSearchCar.Enabled = false;
            }
        }

        private void cbbSearchProduct_DropDown(object sender, EventArgs e)
        {
            DataTable tb = tbTYPE.SELECT_ALL_DATA();
            cbbSearchProduct.Items.Clear();
            foreach (DataRow rw in tb.Rows)
            {
                cbbSearchProduct.Items.Add(rw["TYPEDESC"].ToString());
            }
        }

        private void cbbSearchProduct_DropDownClosed(object sender, EventArgs e)
        {
            if (cbbSearchProduct.Text == "")
            {
                cbbSearchProduct.Items.Clear();
                cbbSearchProduct.Items.Add("--ชื่อสินค้า--");
                cbbSearchProduct.SelectedIndex = 0;
            }
        }

        private void cbbSearchCustomer_DropDown(object sender, EventArgs e)
        {
            DataTable tb = tbCOMPANY.SELECT_ALL_DATA();
            cbbSearchCustomer.Items.Clear();
            foreach (DataRow rw in tb.Rows)
            {
                cbbSearchCustomer.Items.Add(rw["COMPDESC"].ToString());
            }
        }

        private void cbbSearchCustomer_DropDownClosed(object sender, EventArgs e)
        {
            if (cbbSearchCustomer.Text == "")
            {
                cbbSearchCustomer.Items.Clear();
                cbbSearchCustomer.Items.Add("--ชื่อลูกค้า--");
                cbbSearchCustomer.SelectedIndex = 0;
            }
        }

        private void cbbSearchCar_DropDown(object sender, EventArgs e)
        {
            DataTable tb = tbWGH.SELECT_ALL_DATA();
            DataTable tb1 = new DataTable();
            tb1.Columns.Add("CARNUM");

            foreach (DataRow row in tb.Rows)
            {
                string t1 = row["CARNUM"].ToString();

                // ใช้เงื่อนไข Contains เพื่อตรวจสอบว่าข้อมูลซ้ำหรือไม่
                if (!tb1.AsEnumerable().Any(row1 => t1.Equals(row1["CARNUM"].ToString())))
                {
                    tb1.Rows.Add(t1);
                }
            }

            cbbSearchCar.Items.Clear();
            foreach (DataRow row in tb1.Rows)
            {
                cbbSearchCar.Items.Add(row["CARNUM"].ToString());
            }


        }

        private void cbbSearchCar_DropDownClosed(object sender, EventArgs e)
        {
            if (cbbSearchCar.Text == "")
            {
                cbbSearchCar.Items.Clear();
                cbbSearchCar.Items.Add("--ทะเบียนรถ--");
                cbbSearchCar.SelectedIndex = 0;
            }
        }

        private void cbbTable_DropDown(object sender, EventArgs e)
        {
            cbbTable.Items.Clear();
            cbbTable.Items.Add("ข้อมูลรถชั่งเข้า");
            cbbTable.Items.Add("ข้อมูลรถชั่งออก");
            cbbTable.Items.Add("ข้อมูลรถจ้างชั่ง");
        }

        private void cbbTable_DropDownClosed(object sender, EventArgs e)
        {
            if (cbbTable.Text == "")
            {
                cbbTable.Items.Clear();
                cbbTable.Items.Add("--เลือกการชั่ง--");
                cbbTable.SelectedIndex = 0;

                dgvWGH_IN.Visible = false;
                dgvWGH_OUT.Visible = false;
                dgvHireWeight.Visible = false;
            }
        }
        private void cbbTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbbTable.Text)
            {
                case "ข้อมูลชั่งเข้า":
                    // กำหนดค่าให้กับ Controls
                    dgvWGH_OUT.Visible = false;
                    dgvHireWeight.Visible = false;
                    dgvWGH_IN.Visible = true;
                    dgvWGH_IN.Location = new Point(251, 58);

                    cbSearchDate.Enabled = false;
                    dtpEnd.Enabled = false;
                    dtpStart.Enabled = false;
                    // โชว์ข้อมูล 
                    SHOW_DATA_DGV_WGH_INT();
                    break;
                case "ข้อมูลรถชั่งออก":
                    // กำหนดค่าให้กับ controls
                    dgvWGH_IN.Visible = false;
                    dgvHireWeight.Visible = false;
                    dgvWGH_OUT.Visible = true;
                    dgvWGH_OUT.Location = new Point(251, 58);

                    cbSearchDate.Enabled = true;
                    dtpEnd.Enabled = false;
                    dtpStart.Enabled = false;
                    // โชว์ข้อมูล 
                    SHOW_DATA_DGV_WGH_OUT();
                    break;
                case "ข้อมูลรถจ้างชั่ง":
                    // กำหนดค่าให้กับ controls
                    dgvWGH_IN.Visible = false;
                    dgvHireWeight.Visible = true;
                    dgvWGH_OUT.Visible = false;
                    dgvHireWeight.Location = new Point(251, 58);

                    cbSearchDate.Enabled = true;
                    dtpEnd.Enabled = false;
                    dtpStart.Enabled = false;
                    // โชว์ข้อมูล 
                    SHOW_DATA_DGV_HIIRE();
                    break;
            }
        }


        #endregion

        private void btnPrintAllReport_Click(object sender, EventArgs e)
        {
            // ตรวจสอบก่อนว่าได้เลือกตารางก่อนค้นหาหรือไม่
            if (cbbTable.Text == "--เลือกการชั่ง--")
            {
                msg.Show(this, "กรุณา เลือกการชั่ง ที่ต้องการจะพิมพ์รายงาน", BunifuSnackbar.MessageTypes.Warning, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                return;
            }
            // ทำการเรียงคำสั่ง query  เพื่อแสดงรายงาน
            SETUP_QUERY();

            // ดึงตารางในฐานข้อมูลมาแสดง
            DataSet1 dataSet1 = new DataSet1();

            frmReportAllDataSuccess frmReportAllData = new frmReportAllDataSuccess();
            // ตรวจสอบว่าปริ้นรายงานของตารางไหน
            switch (cbbTable.Text)
            {
                case "ข้อมูลรถชั่งเข้า":
                    int i = 0; // ตัวแปรสำหรับ นับ่ค่า
                    int wgh = 0; // สำหรับเก็บค่าตัวแปรน้ำหนัก
                                 // ลูปข้อมูลเพื่อกำหนดค่าที่ dataset1

                    foreach (DataGridViewRow rw in dgvWGH_IN.Rows)
                    {
                        string datein = rw.Cells["dataGridViewTextBoxColumn2"].Value.ToString();
                        string timein = rw.Cells["dataGridViewTextBoxColumn3"].Value.ToString();
                        string wghIN = rw.Cells["dataGridViewTextBoxColumn7"].Value.ToString();
                        string product = rw.Cells["dataGridViewTextBoxColumn9"].Value.ToString();
                        string customer = rw.Cells["dataGridViewTextBoxColumn10"].Value.ToString();
                        string carnumber = rw.Cells["dataGridViewTextBoxColumn15"].Value.ToString();

                        dataSet1.tbReportCarWait.Rows.Add(carnumber, datein, timein, wghIN, customer, product);
                        i += 1;
                        wgh += Convert.ToInt32(wghIN);
                    }

                    // โยนค่า dataset ไปที่ datatable 
                    frmReportAllData.tb = dataSet1.tbReportCarWait;
                    // โยนค่า รายการทั้งหมดไปที่ตัวแปร
                    frmReportAllData.count = i;
                    // โยนค่า น้ำหนักสุทธิไปที่ตัวแปร
                    string b = wgh.ToString("#,###,###,###");
                    frmReportAllData.wghNet = b;
                    frmReportAllData.reportType = "ข้อมูลรถชั่งเข้า";
                    frmReportAllData.ShowDialog();
                    break;
                case "ข้อมูลรถชั่งออก":

                    int ii = 0; // ตัวแปรสำหรับ นับ่ค่า
                    int wghh = 0; // สำหรับเก็บค่าตัวแปรน้ำหนัก
                                  // ลูปข้อมูลเพื่อกำหนดค่าที่ dataset1

                    foreach (DataGridViewRow rw in dgvWGH_OUT.Rows)
                    {
                        string ordernumber = rw.Cells["cl_order_numb"].Value.ToString();
                        string datein = rw.Cells["cl_date_in"].Value.ToString();
                        string timein = rw.Cells["cl_time_in"].Value.ToString();
                        string wghNet = rw.Cells["cl_gross"].Value.ToString();
                        string wghIN = rw.Cells["cl_w_in"].Value.ToString();
                        string wghOut = rw.Cells["cl_w_out"].Value.ToString();
                        string product = rw.Cells["cl_typedesc"].Value.ToString();
                        string customer = rw.Cells["cl_compdesc"].Value.ToString();
                        string carnumber = rw.Cells["cl_carnum"].Value.ToString();


                        int carWeight = 0;  // เก็บน้ำหนักรถ
                        int gross = 0;      // เก็บน้ำหนักรวม  
                        int netWeight = 0;  // เก็บน้ำหนักสุทธิ

                        // wghOut = น้ำหนักรวม
                        // wghInt = น้ำหนักรถ 
                        // wghNet = (น้ำหนักสุทธิ  = น้ำหนักรวม - น้ำหนักรถ)

                        // ทำการเทียบค่าเพื่อหาว่า ชั่งเข้าชั่งออก อันไหนคือน้ำหนักรถ 
                        if (int.Parse(wghIN) > int.Parse(wghOut))
                        {
                            gross = int.Parse(wghIN);
                            // หาน้ำหนักรถ = น้ำหนักที่เบาสุด
                            carWeight = int.Parse(wghOut);
                            // หาน้ำหนักสุทธิ (น้ำหนักรวม - น้ำหนักรถ = น้ำหนักสุทธิ)
                            netWeight = gross - carWeight;

                        }
                        else if (int.Parse(wghOut) > int.Parse(wghIN))
                        {
                            gross = int.Parse(wghOut);
                            // หาน้ำหนักรถ = น้ำหนักที่เบาสุด
                            carWeight = int.Parse(wghIN);
                            // หาน้ำหนักสุทธิ (น้ำหนักรวม - น้ำหนักรถ = น้ำหนักสุทธิ)
                            netWeight = gross - carWeight;
                        }


                        dataSet1.tbReportAllData.Rows.Add(ordernumber, carnumber, datein, timein, gross, carWeight, netWeight, customer, product);
                        ii += 1;
                        wghh += Convert.ToInt32(wghNet);
                    }
                    // โยนค่า dataset ไปที่ datatable 
                    frmReportAllData.tb = dataSet1.tbReportAllData;
                    // โยนค่า รายการทั้งหมดไปที่ตัวแปร
                    frmReportAllData.count = ii;
                    // โยนค่า น้ำหนักสุทธิไปที่ตัวแปร
                    string bb = wghh.ToString("#,###,###,###");
                    frmReportAllData.wghNet = bb;
                    frmReportAllData.reportType = "ข้อมูลรถชั่งออก";
                    frmReportAllData.ShowDialog();
                    break;
                case "ข้อมูลรถจ้างชั่ง":

                    int iii = 0; // ตัวแปรสำหรับ นับ่ค่า
                    int wghhh = 0; // สำหรับเก็บค่าตัวแปรน้ำหนัก
                                   // ลูปข้อมูลเพื่อกำหนดค่าที่ dataset1


                    Console.WriteLine(dgvHireWeight.Rows.Count);
                    foreach (DataGridViewRow rw in dgvHireWeight.Rows)
                    {
                        string ordernumber = rw.Cells["cl_hire_order"].Value.ToString();
                        string datein = rw.Cells["cl_hire_dateIn"].Value.ToString();
                        string timein = rw.Cells["cl_hire_timeIn"].Value.ToString();
                        string wghNet = rw.Cells["cl_hire_wgh"].Value.ToString();
                        string product = rw.Cells["cl_hire_product"].Value.ToString();
                        string customer = rw.Cells["cl_hire_customer"].Value.ToString();
                        string carnumber = rw.Cells["cl_hire_carnumber"].Value.ToString();


                        dataSet1.tbReportHireWGH.Rows.Add(ordernumber, carnumber, wghNet, datein, timein, customer, product);
                        iii += 1;
                        wghhh += Convert.ToInt32(wghNet);
                    }
                    // โยนค่า dataset ไปที่ datatable 
                    frmReportAllData.tb = dataSet1.tbReportHireWGH;
                    // โยนค่า รายการทั้งหมดไปที่ตัวแปร
                    frmReportAllData.count = iii;
                    // โยนค่า น้ำหนักสุทธิไปที่ตัวแปร
                    string bbb = wghhh.ToString("#,###,###,###");
                    frmReportAllData.wghNet = bbb;
                    frmReportAllData.reportType = "ข้อมูลรถจ้างชั่ง";
                    frmReportAllData.ShowDialog();
                    break;
            }


        }

        private void dgvHireWeight_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string order = dgvHireWeight.Rows[e.RowIndex].Cells["cl_hire_order"].Value.ToString();
                switch (dgvHireWeight.Columns[e.ColumnIndex].Name)
                {
                    case "cl_hire_del":
                        DialogResult dialogResult = MessageBox.Show("คุณต้องการลบรายการที่ชั่งไปหรือไม่", "Quesetion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            if (tbHireWeight.DELETE_SEARCH(order))
                            {
                                msg.Show(this, "ลบรายการสำเร็จ", BunifuSnackbar.MessageTypes.Success, 3000, "OK", BunifuSnackbar.Positions.TopCenter);
                                SHOW_DATA_DGV_HIIRE();
                            }
                        }
                        break;
                    case "cl_hire_print":

                        DataTable tb = tbHireWeight.SELECT_SEARCH_DATA(order);
                        // ดึงข้อมูลมาแสดงที่ Report
                        foreach (DataRow rw in tb.Rows)
                        {
                            Func_Report.rtp_carnumber = Convert.ToString(rw["CARNUM_H"]);
                            Func_Report.rtp_dateIn = Convert.ToString(rw["DATE_IN"]);
                            Func_Report.rtp_timeIn = Convert.ToString(rw["TIME_IN"]);
                            Func_Report.rtp_company = Convert.ToString(rw["comdesc"]);
                            Func_Report.rtp_product = Convert.ToString(rw["typedesc"]);
                            Func_Report.rtp_ordernumber = Convert.ToString(rw["ORDERNUM"]);
                            Func_Report.rtp_gross = Convert.ToString(rw["WG"]);
                            Func_Report.rtp_product = Convert.ToString(rw["TYPEDESC"]);
                        }

                        frmReport frmReport = new frmReport();
                        frmReport.reportType = "HIRE";
                        frmReport.ShowDialog();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("frmHistory dgvHireWeight_CellContentClick " + ex.Message);
                Log.Error("frmHistory dgvHireWeight_CellContentClick " + ex.Message);
            }
        }
    }
}
