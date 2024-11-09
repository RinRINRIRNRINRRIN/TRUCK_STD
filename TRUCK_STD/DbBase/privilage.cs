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


        public static bool Insert(privilageModels privilage)
        {
            try
            {
                sql = "INSERT INTO privilage (user_id,menu_id,pr_add,pr_del,pr_edit) " +
                    "VALUES(@user_id,@menu_id,@pr_add,@pr_del,@pr_edit)";

                cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("@user_id", privilage.user_id));
                cmd.Parameters.Add(new MySqlParameter("@menu_id", privilage.menu_id));
                cmd.Parameters.Add(new MySqlParameter("@pr_add", privilage.add));
                cmd.Parameters.Add(new MySqlParameter("@pr_del", privilage.del));
                cmd.Parameters.Add(new MySqlParameter("@pr_edit", privilage.edit));
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


        public static bool Delete(privilageModels privilageModels)
        {
            try
            {
                sql = $"DELETE FROM privilage WHERE user_id = '{privilageModels.user_id}'";
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
