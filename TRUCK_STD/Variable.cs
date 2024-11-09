using System.Data.Odbc;
using System.Data.OleDb;
namespace TRUCK_STD
{
    class Variable
    {
        // ตัวแปรทั่วไป 

        public static string systemVersion = "6.0.0"; // ใช้สำหรับเก็บค่าเวอร์ชั่น
        public static string systemVersionDev = "6.0.5"; // ใช้สำหรับเก็บค่าเวอร์ชั่น

        #region ตัวแปรฐานข้อมูล
        // ตัวแปรสำหรับ การเชื่อมต่่อฐานข้อมูล
        public static OdbcConnection conODBC = new OdbcConnection();
        public static OleDbConnection conOLEDB = new OleDbConnection();
        #endregion

    }

}
