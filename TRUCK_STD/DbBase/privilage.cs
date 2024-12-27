using MySql.Data.MySqlClient;
using System.Data;
using TRUCK_STD.Models;

namespace TRUCK_STD.DbBase
{
    internal class privilage
    {
        static MySqlConnection con = DbConnect.con;
        static MySqlDataAdapter da = new MySqlDataAdapter();
        static MySqlCommand cmd = new MySqlCommand();
        public static DataTable tb = new DataTable();
        static string sql = "";


        public static string ERR { get; set; }
        public static string user_id { get; set; }
        public static string menu_id { get; set; }
        public static string pr_add { get; set; }
        public static string pr_edit { get; set; }
        public static string pr_del { get; set; }

        public static bool SelectPrivilage(string _user)
        {
            try
            {
                sql = $"SELECT * FROM privilage WHERE user_id = '{_user}'";
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

        public static bool Select(privilageModels privilage)
        {
            try
            {
                sql = $"SELECT * FROM privilage a " +
                    $"LEFT JOIN menu b " +
                    $"ON a.menu_id = b.id " +
                    $"WHERE a.user_id = {privilage.user_id}";
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


        public static bool Insert()
        {
            try
            {
                sql = "INSERT INTO privilage (user_id,menu_id,pr_add,pr_del,pr_edit) " +
                    "VALUES(@user_id,@menu_id,@pr_add,@pr_del,@pr_edit)";

                cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("@user_id", user_id));
                cmd.Parameters.Add(new MySqlParameter("@menu_id", menu_id));
                cmd.Parameters.Add(new MySqlParameter("@pr_add", pr_add));
                cmd.Parameters.Add(new MySqlParameter("@pr_del", pr_del));
                cmd.Parameters.Add(new MySqlParameter("@pr_edit", pr_edit));
                cmd.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                ERR = ex.Message;
                return false;
            }
            return true;
        }

        public static bool Update()
        {
            try
            {

            }
            catch (System.Exception ex)
            {
                ERR = ex.Message;
                return false;
            }
            return true;
        }


        public static bool Delete(string _user)
        {
            try
            {
                sql = $"DELETE FROM privilage WHERE user_id = '{_user}'";
                cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                ERR = ex.Message;
                return false;
            }
            return true;
        }




    }
}
