using MySql.Data.MySqlClient;
using System.Data;

namespace TRUCK_STD.DbBase
{
    internal class employee
    {
        static MySqlConnection con = DbConnect.con;
        static MySqlDataAdapter da = new MySqlDataAdapter();
        static MySqlCommand cmd = new MySqlCommand();
        public static DataTable tb = new DataTable();
        static string sql = "";

        public static string ERR { get; set; }
        public static string new_username { get; set; }
        public static string old_username { get; set; }
        public static string password { get; set; }
        public static string names { get; set; }
        public static string state { get; set; }

        private static void ClearProp()
        {
            new_username = null;
            old_username = null;
            password = null;
            names = null;
            state = null;
        }

        /// <summary>
        /// ค้นหาข้อมูลทั้งหมดของผู้ใช้
        /// </summary>
        /// <returns></returns>
        public static bool Select()
        {
            try
            {
                sql = "SELECT * FROM employee";
                da = new MySqlDataAdapter(sql, con);
                tb = new DataTable();
                da.Fill(tb);
            }
            catch (System.Exception ex)
            {
                ERR = ex.Message;
                return false;
            }
            return true;
        }


        /// <summary>
        /// ค้นหาข้อมูลผู้ใช้ตามตัวอักษร
        /// </summary>
        /// <param name="_names"></param>
        /// <returns></returns>
        public static DataTable Select(string _names)
        {
            try
            {
                sql = $"SELECT * FROM truckdata.employee WHERE emp_names LIKE '%{_names}%'";
                da = new MySqlDataAdapter(sql, con);
                tb = new DataTable();
                da.Fill(tb);
            }
            catch (System.Exception ex)
            {
                return tb;
            }
            return tb;
        }


        /// <summary>
        /// สำหรับเพิ่มผู้ใช้งานในระบบ
        /// </summary>
        /// <returns></returns>
        public static bool Insert()
        {
            try
            {
                sql = "INSERT INTO employee (emp_username,emp_password,emp_names,emp_state) " +
                    "VALUES (@emp_username,@emp_password,@emp_names,@emp_state)";

                cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("@emp_username", new_username));
                cmd.Parameters.Add(new MySqlParameter("@emp_password", password));
                cmd.Parameters.Add(new MySqlParameter("@emp_names", names));
                cmd.Parameters.Add(new MySqlParameter("@emp_state", state));
                cmd.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                ERR = ex.Message;
                ClearProp();
                return false;
            }
            ClearProp();
            return true;
        }



        /// <summary>
        /// สำหรับ แก้ไข user
        /// </summary>
        /// <returns></returns>
        public static bool Update()
        {
            try
            {
                sql = "UPDATE employee " +
                    "SET emp_username = @emp_username, " +
                    "emp_password = @emp_password, " +
                    "emp_names = @emp_names " +
                    "WHERE emp_username = @old_username";
                cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("@emp_username", new_username));
                cmd.Parameters.Add(new MySqlParameter("@emp_password", password));
                cmd.Parameters.Add(new MySqlParameter("@emp_names", names));
                cmd.Parameters.Add(new MySqlParameter("@old_username", old_username));
                cmd.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                ERR = ex.Message;
                ClearProp();
                return false;
            }
            ClearProp();
            return true;
        }


        /// <summary>
        /// สำหรับลบ user ออกจากระบบ
        /// </summary>
        /// <returns></returns>
        public static bool Delete()
        {
            try
            {
                sql = $"DELETE FROM employee WHERE emp_username = '{old_username}'";

                cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();

            }
            catch (System.Exception ex)
            {
                ERR = ex.Message;
                ClearProp();
                return false;
            }
            ClearProp();
            return true;
        }
    }
}
