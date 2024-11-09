using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
namespace TRUCK_STD.MSACCESSCommand
{
    class tbTYPE
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
                sqlstr = "SELECT * FROM TYPE";
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

        public DataTable SELECT_PRODUCT_CODE_LIKE(string prd_code)
        {
            try
            {
                sqlstr = "SELECT * FROM TYPE WHERE TYPECODE LIKE '%" + prd_code + "%'";
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
        #endregion

        #region INSERT
        public bool INSERT_ALL_DATA(string TYPECODE, string TYPEDESC, string TYPEPRICE)
        {
            try
            {
                sqlstr = "INSERT INTO TYPE" +
                    "(TYPECODE,TYPEDESC,TYPEPRICE)VALUES" +
                    "('" + TYPECODE + "','" + TYPEDESC + "','" + TYPEPRICE + "')";

                cmd = new OleDbCommand(sqlstr, Variable.conOLEDB);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        #endregion

        #region UPDATE
        public bool UPDATE_ALL_DATA(string TYPECODE, string TYPEDESC, string TYPEPRICE, string TYPECODE_OLD)
        {
            try
            {
                sqlstr = "UPDATE TYPE" +
                    " SET TYPECODE = '" + TYPECODE + "'," +
                    " TYPEDESC = '" + TYPEDESC + "'," +
                    " TYPEPRICE = " + TYPEPRICE + "" +
                    " WHERE TYPECODE = '" + TYPECODE_OLD + "'";

                cmd = new OleDbCommand(sqlstr, Variable.conOLEDB);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        #endregion

        #region DELETE
        public bool DELETE_ALL_DATA(string TYPECODE)
        {
            try
            {
                sqlstr = "DELETE FROM TYPE WHERE TYPECODE = '" + TYPECODE + "'";

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
