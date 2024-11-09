using Serilog;
using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
namespace TRUCK_STD.MSACCESSCommand
{
    class tbHireWeight
    {
        OleDbCommand cmd = new OleDbCommand();

        OleDbDataAdapter da = new OleDbDataAdapter();

        DataTable tb = new DataTable();

        string sqlstr = "";

        #region SELECT
        /// <summary>
        /// ทำการเรียกดูข้อมูลทั้งหมด เรียงจากน้อย > มาก
        /// </summary>
        /// <returns></returns>
        public DataTable SELECT_ALL_DATA()
        {
            try
            {
                sqlstr = "SELECT * FROM HIRE_WEIGHT";
                da = new OleDbDataAdapter(sqlstr, Variable.conOLEDB);
                tb = new DataTable();
                da.Fill(tb);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return tb;
            }
            return tb;
        }
        /// <summary>
        /// ทำการเรียกดูข้อมูลทั้งหมด เรียงจาก มาก ไปน้อย
        /// </summary>
        /// <returns></returns>
        public DataTable SELECT_ALL_DATA_DESC()
        {
            try
            {
                sqlstr = "SELECT ORDER_NUMB,DATE_IN,DATE_OUT,TIME_IN,TIME_OUT,GROSS,CARNUM,W_IN,W_OUT,TYPEDESC,COMPDESC,TYPECODE,COMPCODE,PRICE,price_net FROM HIRE_WEIGHT  ORDER BY ORDER_NUMB DESC";
                da = new OleDbDataAdapter(sqlstr, Variable.conOLEDB);
                tb = new DataTable();
                da.Fill(tb);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return tb;
            }
            return tb;
        }

        public DataTable SELECT_SEARCH_DATA(string order_num)
        {
            try
            {
                sqlstr = "SELECT * FROM HIRE_WEIGHT WHERE ORDERNUM = '" + order_num + "'";
                da = new OleDbDataAdapter(sqlstr, Variable.conOLEDB);
                tb = new DataTable();
                da.Fill(tb);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return tb;
            }
            return tb;
        }




        /// <summary>
        /// สำหรับค้นหาฐานข้อมูลเพื่อมา GEN ORDER
        /// </summary>
        /// <param name="yearMounth">รับค่าวันที่ พ.ศ. yy/MM</param>
        /// <returns></returns>
        public int SELECT_GEN_ORDERNUMBER(string yearMounth)
        {
            int ordernumber = 0;
            try
            {
                sqlstr = "SELECT COUNT(ORDERNUM) FROM HIRE_WEIGHT WHERE ORDERNUM LIKE  '%" + yearMounth + "%' ";
                da = new OleDbDataAdapter(sqlstr, Variable.conOLEDB);
                tb = new DataTable();
                da.Fill(tb);

                if (tb.Rows.Count == 0)
                {
                    ordernumber = 1;
                }
                else
                {
                    foreach (DataRow rw in tb.Rows)
                    {
                        ordernumber = Convert.ToInt32(rw[0]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return ordernumber;
            }
            return ordernumber;
        }
        #endregion

        #region INSERT
        /// <summary>
        /// ใช้สำหรับ บันทึกข้อมูลการชั่งรอบ 2 
        /// </summary>
        /// <param name="ORDER_NUMB">เลขที่ ออเดอร์</param>
        /// <param name="DATE_IN">วันที่ชั่งเข้า พ.ศ.dd/MM/yyyy</param>
        /// <param name="DATE_OUT">วันที่ชั่งออก พ.ศ. dd/MM/yyyy</param>
        /// <param name="TIME_IN">เวลาที่ชั่งเข้า HH:mm:ss</param>
        /// <param name="TIME_OUT">เวลาที่ชั่งออก HH:mm:ss</param>
        /// <param name="CARNUM">ทะเบียนรถที่ชั่ว/param>
        /// <param name="W_IN">น้ำหนักชั่งเข้า</param>
        /// <param name="W_OUT">น้ำหนักชั่งออก</param>
        /// <param name="typedesc">ชื่อสินค้า</param>
        /// <param name="compdesc">ชื่อลูกค้า</param>
        /// <param name="typecode">รหัสสินค้า</param>
        /// <param name="compcode">รหัสลูกค้า</param>
        /// <param name="price">ราคา/กก.</param>
        /// <param name="price_net">ราคาสุทธิ์</param>
        /// <returns></returns>
        public bool INSERT_ALL_DATA(string ORDERNUM, string CARNUM_H, string WG, string DATE_IN, string TIME_IN, string comcode, string comdesc, string typecode, string typedesc)
        {
            try
            {
                sqlstr = "INSERT INTO HIRE_WEIGHT" +
                    "(ORDERNUM,CARNUM_H,WG,DATE_IN,TIME_IN,comcode,comdesc,typecode,typedesc)VALUES" +
                    "('" + ORDERNUM + "','" + CARNUM_H + "','" + WG + "','" + DATE_IN + "','" + TIME_IN + "','" + comcode + "','" + comdesc + "','" + typecode + "','" + typedesc + "')";

                cmd = new OleDbCommand(sqlstr, Variable.conOLEDB);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }
        #endregion

        #region UPDATE

        #endregion

        #region DELETE
        public bool DELETE_SEARCH(string ORDER_NUMB)
        {
            try
            {
                sqlstr = "DELETE FROM HIRE_WEIGHT WHERE ORDERNUM = '" + ORDER_NUMB + "'";
                cmd = new OleDbCommand(sqlstr, Variable.conOLEDB);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.Error("TBWGH " + ex.Message);
                return false;
            }
            return true;
        }
        #endregion
    }
}
