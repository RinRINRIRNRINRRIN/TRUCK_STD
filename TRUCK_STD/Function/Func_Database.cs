namespace TRUCK_STD.Function
{
    class Func_Database
    {
        /// <summary>
        /// ใช้สำหรับเชื่อมต่อ server
        /// </summary>
        /// <returns></returns>
        public static bool CONNECTION_SERVER()
        {
            ////OdbcConnection conodbc = new OdbcConnection();
            //OleDbConnection con = new OleDbConnection();
            //try
            //{
            //    con = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source =" + Application.StartupPath + "\\DATA_600.mdb; Jet OLEDB:Database Password = " + Func_Registry_key.key_passwordDatabase);
            //    con.Open();
            //    con.Close();
            //    Variable.conOLEDB = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source =" + Application.StartupPath + "\\DATA_600.mdb; Jet OLEDB:Database Password = " + Func_Registry_key.key_passwordDatabase);
            //    Variable.conOLEDB.Open();
            //}
            //catch (Exception ex)
            //{
            //    Log.Error("CONNECTION_SERVER " + ex.Message);
            //    Console.WriteLine("ERROR MAIN FUNCTION 14 " + ex.Message);
            //    // หากเกิดการ Exception ให้ไล่ปิดการเชื่อมต่อให้หมด               
            //    if (con.State == ConnectionState.Open)
            //    {
            //        con.Close();
            //    }
            //    return false;
            //}
            return true;
        }
    }
}
