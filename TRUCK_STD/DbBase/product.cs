using MySql.Data.MySqlClient;
using System.Data;

namespace TRUCK_STD.DbBase
{
    internal class product
    {
        public static string ERR { get; set; }

        static MySqlConnection con = DbConnect.con;
        static MySqlDataAdapter da = new MySqlDataAdapter();
        static MySqlCommand cmd = new MySqlCommand();
        public static DataTable tb = new DataTable();
        static string sql = "";


        public static string new_ProductId { get; set; }
        public static string old_ProductId { get; set; }
        public static string ProductName { get; set; }
        public static string ProductType { get; set; }
        public static double ProductPrice { get; set; }


        static void ClearProp()
        {
            new_ProductId = null;
            old_ProductId = null;
            ProductName = null;
            ProductType = null;
            ProductPrice = 0;
        }

        /// <summary>
        /// สำหรับแสดงข้อมูลรายการสินค้าทั้งหมด
        /// </summary>
        /// <returns></returns>
        public static bool Select()
        {
            try
            {
                sql = "SELECT * FROM product";
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
        /// ค้นหาข้อมูลรายการสินค้าเฉพาะตัวอักษร
        /// </summary>
        /// <param name="_ProductName">ชื่อรายการสินค้าทีต้องการค้นหา</param>
        /// <returns></returns>
        public static bool SelectChar(string _ProductName)
        {
            try
            {
                sql = $"SELECT * FROM product WHERE productName LIKE '%{_ProductName}%'";
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



        public static DataTable SelectId(string _productId)
        {
            try
            {
                sql = $"SELECT * FROM product WHERE productId = '{_productId}'";
                da = new MySqlDataAdapter(sql, con);
                tb = new DataTable();
                da.Fill(tb);
            }
            catch (System.Exception ex)
            {
                ERR = ex.Message;
                return null;
            }

            return tb;
        }
        public static bool Insert()
        {
            try
            {
                sql = "INSERT INTO product (productId,productName,productType,productPrice) " +
                    "VALUES (@productId,@productName,@productType,@productPrice)";

                cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("@productId", new_ProductId));
                cmd.Parameters.Add(new MySqlParameter("@productName", ProductName));
                cmd.Parameters.Add(new MySqlParameter("@productType", ProductType));
                cmd.Parameters.Add(new MySqlParameter("@productPrice", ProductPrice));
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
        public static bool Update()
        {
            try
            {
                sql = "UPDATE product " +
                    "SET productId = @new_productId," +
                    "productName = @productName," +
                    "productType = @productType," +
                    "productPrice = @productPrice " +
                    "WHERE productId = @old_productId";

                cmd = new MySqlCommand(sql, con);
                cmd.Parameters.Add(new MySqlParameter("@new_productId", new_ProductId));
                cmd.Parameters.Add(new MySqlParameter("@productName", ProductName));
                cmd.Parameters.Add(new MySqlParameter("@productType", ProductType));
                cmd.Parameters.Add(new MySqlParameter("@productPrice", ProductPrice));
                cmd.Parameters.Add(new MySqlParameter("@old_productId", old_ProductId));
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
        public static bool Delete(string id)
        {
            try
            {
                sql = $"DELETE FROM product WHERE productId = '{id}'";
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
