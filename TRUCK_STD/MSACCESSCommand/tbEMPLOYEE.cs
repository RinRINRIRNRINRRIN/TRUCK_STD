using Serilog;
using System;
using System.Data;
using System.Data.OleDb;
using TRUCK_STD.Function;
namespace TRUCK_STD.MSACCESSCommand
{
    class tbEMPLOYEE
    {
        tbPRIVIVRAGE tbPRIVIVRAGE = new tbPRIVIVRAGE();

        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        DataTable tb = new DataTable();

        string sqlstr = "";

        #region SELECT
        /// <summary>
        /// สำหรับเรียกดูข้อมูลทั้งหมดออกมา
        /// </summary>
        /// <returns></returns>
        public DataTable SELECT_ALL_DATA()
        {
            try
            {
                sqlstr = "SELECT * FROM EMPLOYEE";
                da = new OleDbDataAdapter(sqlstr, Variable.conOLEDB);
                tb = new DataTable();
                da.Fill(tb);
            }
            catch (Exception ex)
            {
                Log.Error("EMPLOYEE SELECT_ALL_DATA " + ex.Message);
                Console.WriteLine(ex.Message);
                return tb;
            }
            return tb;
        }

        /// <summary>
        /// สำหรับ login 
        /// </summary>
        /// <param name="username">ชื่อผู้ใช้</param>
        /// <param name="password">รหัสผ่าน</param>
        /// <returns></returns>
        public bool SELECT_USERNAME_PASSWORD(string username, string password)
        {
            try
            {
                sqlstr = "SELECT * FROM EMPLOYEE WHERE StrComp(emp_username, '" + username + "', 0) = 0 AND StrComp(emp_password, '" + password + "', 0) = 0;";
                da = new OleDbDataAdapter(sqlstr, Variable.conOLEDB);
                tb = new DataTable();
                da.Fill(tb);

                // 1.ตรวจสอบว่าถูกต้องหรือไม่ ถ้าเท่ากับ 0 แต่ถ้ามากกว่า 0 หมายถึงพบข้อมูล 
                if (tb.Rows.Count == 0)
                {
                    return false;
                }
                // 2.หากตรวจสอบแล้วพบว่า มีข้อมูลให้เก็บไปที่ตัวแปร static
                else
                {
                    foreach (DataRow row in tb.Rows)
                    {
                        Func_Privilage.emp_name = Convert.ToString(row["emp_name"]);
                        Func_Privilage.emp_usernmae = Convert.ToString(row["emp_username"]);
                        Func_Privilage.emp_password = Convert.ToString(row["emp_password"]);
                    }

                    #region กำหนดสิทธิ์เมนูโปรแกรม
                    // ทำการเอาชื่อ emp_username ไปหาว่า มีสิทธิ์อะไรในโปรแกรมบ้าง
                    DataTable tb1 = tbPRIVIVRAGE.SELECT_SEACH_PRIVIRAGE(Func_Privilage.emp_usernmae);

                    foreach (DataRow rw in tb1.Rows)
                    {
                        // กำหนดค่าให้กลับ static string 
                        string pr_menu_name = rw["pr_manu_name"].ToString();
                        string pr_add = rw["pr_add"].ToString();
                        string pr_del = rw["pr_del"].ToString();
                        string pr_edit = rw["pr_edit"].ToString();

                        #region กำหนดสิทธิ์เมนู
                        // กำหนดสิทธิ์เมนู ข้อมูลลูกค้า
                        if (pr_menu_name == "ข้อมูลลูกค้า")
                        {
                            if (pr_add == "TRUE")
                            {
                                Func_Privilage.pr_customer.pr_systemAdd = pr_add;
                            }
                            if (pr_del == "TRUE")
                            {
                                Func_Privilage.pr_customer.pr_systemDel = pr_del;
                            }
                            if (pr_edit == "TRUE")
                            {
                                Func_Privilage.pr_customer.pr_systemEdit = pr_edit;
                            }
                        }


                        // กำหนดสิทธิ์เมนู ข้อมูลพนักงาน
                        if (pr_menu_name == "ข้อมูลพนักงาน")
                        {
                            if (pr_add == "TRUE")
                            {
                                Func_Privilage.pr_employee.pr_systemAdd = pr_add;
                            }
                            if (pr_del == "TRUE")
                            {
                                Func_Privilage.pr_employee.pr_systemDel = pr_del;
                            }
                            if (pr_edit == "TRUE")
                            {
                                Func_Privilage.pr_employee.pr_systemEdit = pr_edit;
                            }
                        }


                        // กำหนดสิทธิ์เมนู ข้อมูลสินค้า
                        if (pr_menu_name == "ข้อมูลสินค้า")
                        {
                            if (pr_add == "TRUE")
                            {
                                Func_Privilage.pr_product.pr_systemAdd = pr_add;
                            }
                            if (pr_del == "TRUE")
                            {
                                Func_Privilage.pr_product.pr_systemDel = pr_del;
                            }
                            if (pr_edit == "TRUE")
                            {
                                Func_Privilage.pr_product.pr_systemEdit = pr_edit;
                            }
                        }

                        // กำหนดสิทธิ์เมนู ชั่งรถเข้าออก
                        if (pr_menu_name == "ชั่งรถเข้าออก")
                        {
                            if (pr_del == "TRUE")
                            {
                                Func_Privilage.pr_weight.pr_systemDel = pr_del;
                            }
                        }


                        // กำหนดสิทธิ์เมนู ประวัติการชั่ง
                        if (pr_menu_name == "ประวัติการชั่ง")
                        {
                            if (pr_del == "TRUE")
                            {
                                Func_Privilage.pr_history.pr_systemDel = pr_del;
                            }
                        }
                        #endregion                     
                    }
                    #endregion

                }
            }
            catch (Exception ex)
            {
                Log.Error("EMPLOYEE SELECT_LOGIN " + ex.Message);
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        /// <summary>
        /// สำหรับหาคำ
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public DataTable SELECT_SEARCH_LIKE_EMP_NAME(string username)
        {
            try
            {
                sqlstr = "SELECT * FROM EMPLOYEE WHERE emp_name LIKE '%" + username + "%'";
                da = new OleDbDataAdapter(sqlstr, Variable.conOLEDB);
                tb = new DataTable();
                da.Fill(tb);
            }
            catch (Exception ex)
            {
                Console.WriteLine("TBEMPLOYEE " + ex.Message);
                Log.Error("TBEMPLOYEE " + ex.Message);
                return tb;
            }
            return tb;
        }

        /// <summary>
        /// สำหรับเรียกดู username ในระบบ
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public DataTable SELECT_SEARCH_USERNAME(string username)
        {
            try
            {
                sqlstr = "SELECT * FROM EMPLOYEE WHERE emp_username = '" + username + "'";
                da = new OleDbDataAdapter(sqlstr, Variable.conOLEDB);
                tb = new DataTable();
                da.Fill(tb);
            }
            catch (Exception ex)
            {
                Console.WriteLine("tbEsMPLOYEE SELECT_SEARCH_USERNAME " + ex.Message);
                Log.Error("tbEMPLOYEE SELECT_SEARCH_USERNAME " + ex.Message);
                return tb;
            }
            return tb;
        }
        #endregion

        #region INSERT
        /// <summary>
        /// สำหรับบันทึกข้อมูลใหม่ทั้งหมด
        /// </summary>
        /// <param name="emp_name">ชื่อผู้ใช้</param>
        /// <param name="emp_username">ชื่อผู้ใช้สำหรับ login ห้ามซ้ำกัน</param>
        /// <param name="emp_password">รหัสผ่านผู้ใช้</param>
        /// <returns></returns>
        public bool INSERT_ALL_DATA(string emp_name, string emp_username, string emp_password)
        {
            try
            {
                sqlstr = "INSERT INTO EMPLOYEE" +
                    "(emp_name,emp_username,emp_password)VALUES" +
                    "('" + emp_name + "','" + emp_username + "','" + emp_password + "')";

                cmd = new OleDbCommand(sqlstr, Variable.conOLEDB);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Log.Error("EMPLOYEE INSERT_ALL_DATA " + ex.Message);
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

        #endregion

        #region UPDATE
        /// <summary>
        /// สำหรับอัพเดทข้อมูล user ทั้งหมด
        /// </summary>
        /// <param name="emp_name">ชื่อผู้ใช้</param>
        /// <param name="emp_username">ชื่อผู้ใช้สำหรับ login</param>
        /// <param name="emp_password">รหัสผ่านผู้ใช้</param>
        /// <param name="emp_username_old">ชื่อผู้ใช้ที่เป็นคีย์ตัวเก่า</param>
        /// <returns></returns>
        public bool UPDATE_ALL_DATA(string emp_name, string emp_username, string emp_password, string emp_username_old)
        {
            try
            {
                sqlstr = "UPDATE EMPLOYEE" +
                    " SET emp_username = '" + emp_username + "'," +
                    " emp_name = '" + emp_name + "'," +
                    " emp_password = '" + emp_password + "'" +
                    " WHERE emp_username = '" + emp_username_old + "'";

                cmd = new OleDbCommand(sqlstr, Variable.conOLEDB);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Log.Error("EMPLOYEE UPDATE_ALL_DATA " + ex.Message);
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        #endregion

        #region DELETE
        /// <summary>
        /// สำหรับลบชื่อผู้ใช้ออกจาการะบบ
        /// </summary>
        /// <param name="emp_id"></param>
        /// <returns></returns>
        public bool DELETE_ALL_DATA(string emp_username)
        {
            try
            {
                sqlstr = "DELETE FROM EMPLOYEE WHERE emp_username ='" + emp_username + "'";
                cmd = new OleDbCommand(sqlstr, Variable.conOLEDB);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Log.Information("EMPLOYEE DELETE_ALL_DATA " + ex.Message);
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        #endregion
    }
}
