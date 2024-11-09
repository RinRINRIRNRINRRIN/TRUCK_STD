using MySql.Data.MySqlClient;
using System.Data;
using TRUCK_STD.Models;

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



        public static DataTable SelectChar(string _names)
        {
            try
            {
                sql = $"SELECT * FROM employee WHERE emp_names LIKE '%{_names}%'";
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

        public static bool Insert(employeeModels employeeModels)
        {
            try
            {
                sql = "INSERT INTO employee (emp_username,emp_password,emp_names,emp_state) " +
                    "VALUES (@emp_username,@emp_password,@emp_names,@emp_state)";

                cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("@emp_username", employeeModels.new_username));
                cmd.Parameters.Add(new MySqlParameter("@emp_password", employeeModels.password));
                cmd.Parameters.Add(new MySqlParameter("@emp_names", employeeModels.names));
                cmd.Parameters.Add(new MySqlParameter("@emp_state", employeeModels.state));
                cmd.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                ERR = ex.Message;
                return false;
            }
            return true;
        }


        public static bool Update(employeeModels employeeModels)
        {
            try
            {
                sql = "UPDATE employee " +
                    "SET emp_username = @emp_username, " +
                    "emp_password = @emp_password, " +
                    "emp_names = @emp_names " +
                    "WHERE emp_username = @old_username";
                cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("@emp_username", employeeModels.new_username));
                cmd.Parameters.Add(new MySqlParameter("@emp_password", employeeModels.password));
                cmd.Parameters.Add(new MySqlParameter("@emp_names", employeeModels.names));
                cmd.Parameters.Add(new MySqlParameter("@old_username", employeeModels.old_username));
                cmd.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                ERR = ex.Message;
                return false;
            }
            return true;
        }


        public static bool Delete(employeeModels employeeModels)
        {
            try
            {
                sql = $"DELETE FROM employee WHERE emp_username = '{employeeModels.old_username}'";

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
