using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
namespace TRUCK_STD.MSACCESSCommand
{
    class tbCOMPANY
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
                sqlstr = "SELECT * FROM COMPANY";
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

        public DataTable SELECT_SEARCH(string COMPCODE)
        {
            try
            {
                sqlstr = "SELECT * FROM COMPANY WHERE COMPCODE LIKE '%" + COMPCODE + "%'";
                //sqlstr = "SELECT * FROM COMPANY WHERE COMPCODE LIKE '*s*'";
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
        public bool INSERT_ALL_DATA(string COMPCODE, string COMPDESC)
        {
            try
            {
                sqlstr = "INSERT INTO COMPANY" +
                    "(COMPCODE,COMPDESC)VALUES" +
                    "('" + COMPCODE + "','" + COMPDESC + "')";

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
        public bool UPDATE_ALL_DATA(string COMPCODE, string COMDESC, string COMPCODE_OLD)
        {
            try
            {
                sqlstr = "UPDATE COMPANY" +
                    " SET COMPCODE = '" + COMPCODE + "'," +
                    " COMPDESC = '" + COMDESC + "'" +
                    " WHERE COMPCODE = '" + COMPCODE_OLD + "'";

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

        public bool DELETE_ALL_DATA(string COMPCODE)
        {
            try
            {
                sqlstr = "DELETE FROM COMPANY WHERE COMPCODE = '" + COMPCODE + "'";

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
