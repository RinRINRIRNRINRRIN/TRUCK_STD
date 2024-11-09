using System;
using System.Data;
using System.Data.OleDb;

namespace TRUCK_STD.MSACCESSCommand
{
    class tbPRIVIVRAGE
    {

        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        DataTable tb = new DataTable();

        string sqlstr = "";

        #region SELECT
        public DataTable SELECT_SEACH_PRIVIRAGE(string emp_username)
        {
            try
            {
                sqlstr = "SELECT * FROM PRIVIRAGE WHERE pr_emp_username = '" + emp_username + "'";
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
        #endregion

        #region INSERT
        public bool INSERT_NEW_PRIVIRAGE(string emp_username, string emp_menu_name, string pr_add, string pr_del, string pr_edit)
        {
            try
            {
                sqlstr = "INSERT INTO PRIVIRAGE" +
                    "(pr_emp_username,pr_manu_name,pr_add,pr_del,pr_edit)VALUES" +
                    "('" + emp_username + "','" + emp_menu_name + "','" + pr_add + "','" + pr_del + "','" + pr_edit + "')";

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

        #endregion

        #region DELETE

        /// <summary>
        /// ใช้้สำหรับลบข้อมูล user กอนทำกากรแก้ไขหรือเพ่ิมใหม่
        /// </summary>
        /// <param name="emp_username">user ทีจะทำไปลบใฐานข้อมูล</param>
        /// <returns></returns>
        public bool DELETE_USER(string emp_username)
        {
            try
            {
                sqlstr = "DELETE FROM PRIVIRAGE WHERE pr_emp_username = '" + emp_username + "'";
                da = new OleDbDataAdapter(sqlstr, Variable.conOLEDB);
                tb = new DataTable();
                da.Fill(tb);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        #endregion
    }
}
