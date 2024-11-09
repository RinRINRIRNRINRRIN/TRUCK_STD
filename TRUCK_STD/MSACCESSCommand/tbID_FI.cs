using Serilog;
using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
namespace TRUCK_STD.MSACCESSCommand
{
    class tbID_FI
    {
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        DataTable tb = new DataTable();

        string sqlstr = "";

        #region SELECT
        public DataTable SELECT_ALL_DATA()
        {
            try
            {
                sqlstr = "SELECT CARNUM_H,WG,DATE_IN,TIME_IN,price,comcode,comdesc,typecode,typedesc FROM ID_FI";
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
        /// ใช้สำหรับค้นหาข้อมูล ที่ไม่แน่นอน
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public DataTable SELECT_SEARCH_DATA_MANY(string query)
        {
            try
            {
                da = new OleDbDataAdapter(query, Variable.conOLEDB);
                tb = new DataTable();
                da.Fill(tb);
            }
            catch (Exception ex)
            {
                Console.WriteLine("TB ID_FI ", ex.Message);
                Log.Error("TB ID_FI " + ex.Message);
                return tb;
            }
            return tb;
        }
        #endregion


        #region INSERT
        /// <summary>
        /// สำหหรับ INSERT
        /// </summary>
        /// <param name="carnum_h">ทะเบียนรถ</param>
        /// <param name="wg">น้ำหนัก</param>
        /// <param name="DATE_IN">วันที่</param>
        /// <param name="TIME_IN">เวลา</param>
        /// <param name="price">ราคาต่อ/กก</param>
        /// <param name="comcode">รหัสลูกค้า</param>
        /// <param name="comdesc">ชื่อลูกค้า</param>
        /// <param name="typecode">รหัสสนค้า</param>
        /// <param name="typedesc">ชื่อสินค้า</param>
        /// <returns></returns>
        public bool INSERT_ALL_DATA(string carnum_h, string wg, string DATE_IN, string TIME_IN, string price, string comcode, string comdesc, string typecode, string typedesc)
        {
            try
            {
                sqlstr = "INSERT INTO ID_FI" +
                    "(CARNUM_H,WG,DATE_IN,TIME_IN,price,comcode,comdesc,typecode,typedesc)VALUES" +
                    "('" + carnum_h + "','" + wg + "','" + DATE_IN + "','" + TIME_IN + "'," + price + ",'" + comcode + "','" + comdesc + "','" + typecode + "','" + typedesc + "')";

                cmd = new OleDbCommand(sqlstr, Variable.conOLEDB);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Log.Error("TBID_FI " + ex.Message);
                Console.WriteLine("TBID_FI " + ex.Message);
                return false;
            }
            return true;
        }
        #endregion

        #region UPDATE
        public bool UPDATE_ALL_DATA(string new_carnum_h, string price, string comcode, string comdesc, string typecode, string typedesc, string old_carnum_h)
        {
            try
            {
                sqlstr = "UPDATE  ID_FI " +
                    " SET CARNUM_H = '" + new_carnum_h + "'," +
                    " price = '" + price + "'," +
                    " comcode = '" + comcode + "'," +
                    " comdesc = '" + comdesc + "'," +
                    " typecode = '" + typecode + "'," +
                    " typedesc = '" + typedesc + "' " +
                    " WHERE CARNUM_H = '" + old_carnum_h + "'";
                cmd = new OleDbCommand(sqlstr, Variable.conOLEDB);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Log.Error("TBID_FI " + ex.Message);
                Console.WriteLine("TBID_FI " + ex.Message);
                return false;
            }
            return true;
        }
        #endregion

        #region DELETE
        public bool DELETE_ALL_DATA(string carnum_h)
        {
            try
            {
                sqlstr = "DELETE FROM ID_FI WHERE CARNUM_H = '" + carnum_h + "'";

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
    }
}
