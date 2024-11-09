using Microsoft.Win32;
using Serilog;
using System;
using System.Windows.Forms;
namespace TRUCK_STD.Function
{
    class Func_Registry_key
    {
        #region REGISTRY
        static string PatchRegistry = "SOFTWARE\\28e098175bb05703eb34c5adbb23437"; // Patch ที่ได้ต้องจะเก็บคีย์
        static RegistryKey Patch = Registry.ClassesRoot.OpenSubKey(PatchRegistry);

        public static string key_functionAPI { get; set; }
        public static string key_functionLINE { get; set; }
        public static string key_functionPRICE { get; set; }
        public static string key_passwordDatabase { get; set; }
        public static string key_programDate { get; set; }
        public static string key_programExpire { get; set; }
        public static string key_programIndicator { get; set; }
        public static string key_programNumber { get; set; }
        public static string key_programState { get; set; }
        public static string key_programType { get; set; }
        public static string key_TicketAddress { get; set; }
        public static string key_TicketCompany { get; set; }
        public static string key_TicketPhone { get; set; }
        public static string key_ticketState { get; set; }

        public static bool SET_REGISTRY_FIRST_INSTALL()
        {
            try
            {
                using (Patch = Registry.ClassesRoot.CreateSubKey(PatchRegistry))
                {
                    Patch.SetValue("key_functioAPI", "");
                    Patch.SetValue("key_functionLINE", "");
                    Patch.SetValue("key_functionPRICE", "");
                    Patch.SetValue("key_passwordDatebase", "");
                    Patch.SetValue("key_programDate", "");
                    Patch.SetValue("key_programExpire", "");
                    Patch.SetValue("key_programIndicator", "");
                    Patch.SetValue("key_programNumber", "");
                    Patch.SetValue("key_programState", "");
                    Patch.SetValue("key_programType", "");
                    Patch.SetValue("key_ticketAddress", "");
                    Patch.SetValue("key_ticketCompany", "");
                    Patch.SetValue("key_ticketPhone", "");
                    Patch.SetValue("key_ticketState", "");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("FuncMain SET_REGISTRY : " + ex.Message);
                Log.Error("FuncMain SET KEY : " + ex.Message);
                MessageBox.Show("เกิดข้อผิดผลาด", "FuncMain SET KEY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
                return false;
            }
            Console.WriteLine("FuncRegister SET_REGISTRY : SUCCESS");
            Log.Error("FuncRegister SET KEY : SUCCESS");
            return true;

        }

        /// <summary>
        /// สำหรับสร้าง SET value registry  ที่ต้องการ
        /// </summary>
        public static bool SET_REGISTRY()
        {
            try
            {
                using (Patch = Registry.ClassesRoot.CreateSubKey(PatchRegistry))
                {
                    Patch.SetValue("key_functioAPI", key_functionAPI);
                    Patch.SetValue("key_functionLINE", key_functionLINE);
                    Patch.SetValue("key_functionPRICE", key_functionPRICE);
                    Patch.SetValue("key_passwordDatebase", key_passwordDatabase);
                    Patch.SetValue("key_programDate", key_programDate);
                    Patch.SetValue("key_programExpire", key_programExpire);
                    Patch.SetValue("key_programIndicator", key_programIndicator);
                    Patch.SetValue("key_programNumber", key_programNumber);
                    Patch.SetValue("key_programState", key_programState);
                    Patch.SetValue("key_programType", key_programType);
                    Patch.SetValue("key_ticketAddress", key_TicketAddress);
                    Patch.SetValue("key_ticketCompany", key_TicketCompany);
                    Patch.SetValue("key_ticketPhone", key_TicketPhone);
                    Patch.SetValue("key_ticketState", key_ticketState);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("FuncRegister SET_REGISTRY : " + ex.Message);
                Log.Error("FuncRegister SET KEY : " + ex.Message);
                MessageBox.Show("เกิดข้อผิดผลาด", "FuncRegister SET KEY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
                return false;
            }
            Console.WriteLine("FuncRegister SET_REGISTRY : SUCCESS");
            Log.Error("FuncRegister SET KEY : SUCCESS");
            return true;

        }

        /// <summary>
        /// สำหรับดึงค่าใน REGISTRY
        /// </summary>
        /// <returns></returns>
        public static bool GET_REGISTRY()
        {
            try
            {
                using (Patch = Registry.ClassesRoot.OpenSubKey(PatchRegistry))
                {
                    key_TicketCompany = Convert.ToString(Patch.GetValue("key_ticketCompany"));
                    key_TicketAddress = Convert.ToString(Patch.GetValue("key_ticketAddress"));
                    key_TicketPhone = Convert.ToString(Patch.GetValue("key_ticketPhone"));
                    key_ticketState = Convert.ToString(Patch.GetValue("key_ticketState"));
                    key_functionLINE = Convert.ToString(Patch.GetValue("key_functionLINE"));
                    key_functionAPI = Convert.ToString(Patch.GetValue("key_functioAPI"));
                    key_functionPRICE = Convert.ToString(Patch.GetValue("key_functionPRICE"));
                    key_programIndicator = Convert.ToString(Patch.GetValue("key_programIndicator"));
                    key_programNumber = Convert.ToString(Patch.GetValue("key_programNumber"));
                    key_programState = Convert.ToString(Patch.GetValue("key_programState"));
                    key_programType = Convert.ToString(Patch.GetValue("key_programType"));
                    key_programDate = Convert.ToString(Patch.GetValue("key_programDate"));
                    key_programExpire = Convert.ToString(Patch.GetValue("key_programExpire"));
                    key_passwordDatabase = Convert.ToString(Patch.GetValue("key_passwordDatebase"));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("FuncRegister GET_REGISTRY : " + ex.Message);
                Log.Error("FuncRegister GET KEY : " + ex.Message);
                MessageBox.Show("เกิดข้อผิดผลาด", "FuncMain CREATE KEY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
                return false;
            }
            Console.WriteLine("FuncRegister GET_REGISTRY : SUCCESS");
            Log.Error("FuncRegister GET KEY : SUCCESS");
            return true;
        }
        /// <summary>
        /// สำหรับสร้าง registry
        /// </summary>
        /// <returns></returns>
        public static bool CREATE_REGISTRY()
        {
            try
            {

                // ตรวจสอบว่ามีการกำหนดหรือยัง
                if (Patch == null)
                {
                    // หากยังไม่มีการกำหนดให้สร้าง Registry จะทำการสร้างคีย์และค่าว่าง ๆ เพื่อให้ผู้้ใช่คีย์
                    if (SET_REGISTRY_FIRST_INSTALL())
                    {
                        if (Func_Registry_key.key_programNumber == null)
                        {
                            // return ออกให้ผู้ใช้ไปกำหนดการตั้งค่าโปรแกรม
                            return false;
                        }
                    }
                    else
                    {
                        // หากการสร้างคีย์และค่าว่าง  ๆมีปัญหาจะทำการ return อออก
                        return false;
                    }

                }
                // หากตรวจสอบแล้วพบว่า มีการสร้าง Registy Patch แล้ว
                else
                {
                    // แต่่หากเช็คแล้ว patch registry เคยมีการสร้าง คีย์แล้ว ให้ตรวจสอบว่าคีย์ที่สร้างมีค่าว่างหรืือไม่ 
                    // โดยตรวจสอบจากเลขที่โปรแกรม
                    // ดึงค่า registry มาก่อน
                    if (GET_REGISTRY())
                    {
                        if (Func_Registry_key.key_programNumber == "")
                        {
                            // return ออกให้ผู้ใช้ไปกำหนดการตั้งค่าโปรแกรม
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("FuncRegister CREATE_REGISTRY : " + ex.Message);
                Log.Error("FuncRegister CREATE_REGISTRY : " + ex.Message);
                MessageBox.Show("เกิดข้อผิดผลาด", "FuncMain CREATE KEY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
                return false;
            }
            Console.WriteLine("FuncRegister CREATE_REGISTRY : SUCCESS");
            Log.Error("FuncRegister CREATE KEY Create success");
            return true;
        }
        #endregion

    }
}
