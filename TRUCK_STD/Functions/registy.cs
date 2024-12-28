using Microsoft.Win32;
using Serilog;
using System;
using System.Windows.Forms;

namespace TRUCK_STD.Functions
{
    internal class registy
    {
        static string PatchRegistry = "SOFTWARE\\28e098175bb05703eb34c5adbb23437"; // Patch ที่ได้ต้องจะเก็บคีย์
        // 28e098175bb05703eb34c5adbb23437  เลขที่โปรแกรม เข้ารหัส MD5
        static RegistryKey Patch = Registry.ClassesRoot.OpenSubKey(PatchRegistry);

        public class function
        {
            public static string RFIDState { get; set; }
            public static string RFIDKey { get; set; }
            public static string RFID_COM { get; set; }
            public static string RFID_BAUDRATE { get; set; }


            public static string CAMERAState { get; set; }
            public static string CAMERAKey { get; set; }


            public static string LPRState { get; set; }
            public static string LPRKey { get; set; }


            public static string BARRIERState { get; set; }
            public static string BARRIERKey { get; set; }
            public static string BARRIERCOM { get; set; }
            public static string BARRIERBaudrate { get; set; }

            public static string APIState { get; set; }
            public static string APIKey { get; set; }
            public static string APIEndpoint { get; set; }
        }

        public class db
        {
            public static string host { get; set; }
            public static int Port { get; set; }
            public static string User { get; set; }
            public static string Pass { get; set; }
            public static string Base { get; set; }
        }

        public class dbCenter
        {
            public static string db { get; set; }
            public static string host { get; set; }
            public static int Port { get; set; }
            public static string User { get; set; }
            public static string Pass { get; set; }
            public static string Base { get; set; }
        }

        public class tickets
        {
            public static string company { get; set; }
            public static string address { get; set; }
            public static string phone { get; set; }
            public static string tax { get; set; }
            public static string state { get; set; }
        }

        public class system
        {
            /// <summary>
            /// ประเภทธุรกิจ
            /// </summary>
            public static string bussinessType { get; set; }

            /// <summary>
            /// วันที่ปัจจุบันเมื่อเปิดโปรแกรมจะเอาวันที่มาเก็บไว้กันย้อนหลังโปรแกรม
            /// </summary>
            public static string date { get; set; }

            /// <summary>
            /// วันหมดอายุโปรแกรมหากโปรแกรมเป็นแบบหมดอายุ
            /// </summary>
            public static string dateExpire { get; set; }

            /// <summary>
            /// ประเภทโปรแกรม (ชั่วคราว,ถาวร)
            /// </summary>
            public static string programType { get; set; }


            /// <summary>
            /// สถานะโปรแกรม (lock,unlock)
            /// </summary>
            public static string steate { get; set; }

            /// <summary>
            /// เลขที่โปรแกรม (SM00000000)
            /// </summary>
            public static string id { get; set; }


            /// <summary>
            /// ประเภทสภานีชั่ง (จุดลงทะเบียน,สถานีชั่ง)
            /// </summary>
            public static string stationType { get; set; }

            /// <summary>
            /// ชื่อสถานีชั่งหรือจุดลงทะเบียน 
            /// </summary>
            public static string stationName { get; set; }

            /// <summary>
            /// keyID ที่ได้จาก ชตว
            /// </summary>
            public static string keyID { get; set; }


            /// <summary>
            /// Public Key ที่ได้จาก ชตว
            /// </summary>
            public static string publicKey { get; set; }
        }

        public class scale
        {
            /// <summary>
            /// ชื่อเครื่องชั่ง
            /// </summary>
            public static string scaleName { get; set; }
            public static string scalePort { get; set; }
            public static int scaleBaudrate { get; set; }

            /// <summary>
            /// พิกัดสูงสุดของเครื่อง
            /// </summary>
            public static int scalecapacity { get; set; }
        }


        public static bool CreateKey()
        {
            try
            {
                using (Patch = Registry.ClassesRoot.CreateSubKey(PatchRegistry))
                {
                    // token
                    Patch.SetValue("key_systemtoken", "");

                    // scale
                    Patch.SetValue("key_scaleName", "");
                    Patch.SetValue("key_scalePort", "");
                    Patch.SetValue("key_scaleBaudrate", "9600");


                    // system
                    Patch.SetValue("key_systemBussinessType", "");
                    Patch.SetValue("key_systemDate", "");
                    Patch.SetValue("key_systemDateExpire", "");
                    Patch.SetValue("key_systemState", "");
                    Patch.SetValue("key_systemProgramType", "");
                    Patch.SetValue("key_systemID", "");
                    Patch.SetValue("key_systemStationStype", "");
                    Patch.SetValue("key_systemStationName", "");

                    // db
                    Patch.SetValue("key_LocalHost", "");
                    Patch.SetValue("key_LocalPort", "0");
                    Patch.SetValue("key_LocalUser", "");
                    Patch.SetValue("key_LocalPass", "");
                    Patch.SetValue("key_LocalBase", "");

                    // dbCenter
                    Patch.SetValue("key_CenterUse", "");
                    Patch.SetValue("key_CenterHost", "");
                    Patch.SetValue("key_CenterPort", "0");
                    Patch.SetValue("key_CenterUser", "");
                    Patch.SetValue("key_CenterPass", "");
                    Patch.SetValue("key_CenterBase", "");

                    // function
                    Patch.SetValue("key_functionRFIDState", "");
                    Patch.SetValue("key_functionRFIDKey", "");
                    Patch.SetValue("key_functionRFID_COM", "");
                    Patch.SetValue("key_functionRFID_BAUDRATE", "");
                    Patch.SetValue("key_functionCAMERAState", "");
                    Patch.SetValue("key_functionCAMERAKey", "");
                    Patch.SetValue("key_functionLPRState", "");
                    Patch.SetValue("key_functionLPRKey", "");
                    Patch.SetValue("key_functionBarrierState", "");
                    Patch.SetValue("key_functionBarrierKey", "");
                    Patch.SetValue("key_functionBarrierCOM", "");
                    Patch.SetValue("key_functionBarrierBaudrate", "");
                    Patch.SetValue("key_functionAPIKey", "");
                    Patch.SetValue("key_functionAPIState", "");
                    Patch.SetValue("key_functionAPIEndpoint", "");

                    // tickets
                    Patch.SetValue("key_ticketAddress", "");
                    Patch.SetValue("key_ticketTAX", "");
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
        /// สำหรับสร้าง SET value registry
        /// </summary>
        public static bool Set()
        {
            try
            {
                using (Patch = Registry.ClassesRoot.CreateSubKey(PatchRegistry))
                {

                    // scale
                    Patch.SetValue("key_scaleName", scale.scaleName);
                    Patch.SetValue("key_scalePort", scale.scalePort);
                    Patch.SetValue("key_scaleBaudrate", scale.scaleBaudrate.ToString());
                    Patch.SetValue("key_scaleCapacity", scale.scalecapacity.ToString());


                    // system
                    Patch.SetValue("key_systemBussinessType", system.bussinessType);
                    Patch.SetValue("key_systemDate", system.date);
                    Patch.SetValue("key_systemDateExpire", system.dateExpire);
                    Patch.SetValue("key_systemState", system.steate);
                    Patch.SetValue("key_systemProgramType", system.programType);
                    Patch.SetValue("key_systemID", system.id);
                    Patch.SetValue("key_systemStationStype", system.stationType);
                    Patch.SetValue("key_systemStationName", system.stationName);
                    Patch.SetValue("key_systemKeyID", system.keyID);
                    Patch.SetValue("key_systemPublicKey", system.publicKey);
                    // dbLocal
                    Patch.SetValue("key_LocalHost", db.host);
                    Patch.SetValue("key_LocalPort", db.Port.ToString());
                    Patch.SetValue("key_LocalUser", db.User);
                    Patch.SetValue("key_LocalPass", db.Pass);
                    Patch.SetValue("key_LocalBase", db.Base);
                    // dbCenter
                    Patch.SetValue("key_CenterUse", dbCenter.db);
                    Patch.SetValue("key_CenterHost", dbCenter.host);
                    Patch.SetValue("key_CenterPort", dbCenter.Port.ToString());
                    Patch.SetValue("key_CenterUser", dbCenter.User);
                    Patch.SetValue("key_CenterPass", dbCenter.Pass);
                    Patch.SetValue("key_CenterBase", dbCenter.Base);
                    // function
                    Patch.SetValue("key_functionRFIDState", function.RFIDState);
                    Patch.SetValue("key_functionRFIDKey", function.RFIDKey);
                    Patch.SetValue("key_functionRFID_COM", function.RFID_COM);
                    Patch.SetValue("key_functionRFID_BAUDRATE", function.RFID_BAUDRATE);
                    Patch.SetValue("key_functionCAMERAState", function.CAMERAState);
                    Patch.SetValue("key_functionCAMERAKey", function.CAMERAKey);
                    Patch.SetValue("key_functionLPRState", function.LPRState);
                    Patch.SetValue("key_functionLPRKey", function.LPRKey);
                    Patch.SetValue("key_functionBarrierState", function.BARRIERState);
                    Patch.SetValue("key_functionBarrierKey", function.BARRIERKey);
                    Patch.SetValue("key_functionBarrierCOM", function.BARRIERCOM);
                    Patch.SetValue("key_functionBarrierBaudrate", function.BARRIERBaudrate);
                    Patch.SetValue("key_functionAPIState", function.APIState);
                    Patch.SetValue("key_functionAPIKey", function.APIKey);
                    Patch.SetValue("key_functionAPIEndpoint", function.APIEndpoint);
                    // tickets
                    Patch.SetValue("key_ticketAddress", tickets.address);
                    Patch.SetValue("key_ticketCompany", tickets.company);
                    Patch.SetValue("key_ticketPhone", tickets.phone);
                    Patch.SetValue("key_ticketState", tickets.state);
                    Patch.SetValue("key_ticketTAX", tickets.tax);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("FuncRegister SET_REGISTRY : " + ex.Message);
                Log.Error("FuncRegister SET KEY : " + ex.Message);
                MessageBox.Show("เกิดข้อผิดผลาด", "FuncRegister SET KEY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        public static bool Get()
        {
            try
            {
                using (Patch = Registry.ClassesRoot.OpenSubKey(PatchRegistry))
                {
                    // scale
                    scale.scaleName = Convert.ToString(Patch.GetValue("key_scaleName"));
                    scale.scalePort = Convert.ToString(Patch.GetValue("key_scalePort"));
                    scale.scaleBaudrate = Convert.ToInt16(Patch.GetValue("key_scaleBaudrate"));
                    scale.scalecapacity = Convert.ToInt16(Patch.GetValue("key_scaleCapacity"));

                    // system
                    system.bussinessType = Convert.ToString(Patch.GetValue("key_systemBussinessType"));
                    system.date = Convert.ToString(Patch.GetValue("key_systemDate"));
                    system.dateExpire = Convert.ToString(Patch.GetValue("key_systemDateExpire"));
                    system.steate = Convert.ToString(Patch.GetValue("key_systemState"));
                    system.programType = Convert.ToString(Patch.GetValue("key_systemProgramType"));
                    system.id = Convert.ToString(Patch.GetValue("key_systemID"));
                    system.stationType = Convert.ToString(Patch.GetValue("key_systemStationSType"));
                    system.stationName = Convert.ToString(Patch.GetValue("key_systemStationName"));
                    system.keyID = Convert.ToString(Patch.GetValue("key_systemKeyID"));
                    system.publicKey = Convert.ToString(Patch.GetValue("key_systemPublickKey"));
                    // db
                    db.host = Convert.ToString(Patch.GetValue("key_LocalHost"));
                    db.Port = Convert.ToInt16(Patch.GetValue("key_LocalPort"));
                    db.User = Convert.ToString(Patch.GetValue("key_LocalUser"));
                    db.Pass = Convert.ToString(Patch.GetValue("key_LocalPass"));
                    db.Base = Convert.ToString(Patch.GetValue("key_LocalBase"));
                    // dbCenter
                    dbCenter.db = Convert.ToString(Patch.GetValue("key_CenterUse"));
                    dbCenter.host = Convert.ToString(Patch.GetValue("key_CenterHost"));
                    dbCenter.Port = Convert.ToInt16(Patch.GetValue("key_CenterPort"));
                    dbCenter.User = Convert.ToString(Patch.GetValue("key_CenterUser"));
                    dbCenter.Pass = Convert.ToString(Patch.GetValue("key_CenterPass"));
                    dbCenter.Base = Convert.ToString(Patch.GetValue("key_CenterBase"));
                    // function
                    function.RFIDState = Convert.ToString(Patch.GetValue("key_functionRFIDState"));
                    function.RFIDKey = Convert.ToString(Patch.GetValue("key_functionRFIDKey"));
                    function.RFID_COM = Convert.ToString(Patch.GetValue("key_functionRFID_COM"));
                    function.RFID_BAUDRATE = Convert.ToString(Patch.GetValue("key_functionRFID_BAUDRATE"));
                    //---------------------------------------------------------------------
                    function.CAMERAState = Convert.ToString(Patch.GetValue("key_functionCAMERAState"));
                    function.CAMERAKey = Convert.ToString(Patch.GetValue("key_functionCAMERAKey"));
                    //---------------------------------------------------------------------
                    function.LPRState = Convert.ToString(Patch.GetValue("key_functionLPRState"));
                    function.LPRKey = Convert.ToString(Patch.GetValue("key_functionLPRKey"));
                    //---------------------------------------------------------------------
                    function.BARRIERState = Convert.ToString(Patch.GetValue("key_functionBarrierState"));
                    function.BARRIERKey = Convert.ToString(Patch.GetValue("key_functionBarrierKey"));
                    function.BARRIERCOM = Convert.ToString(Patch.GetValue("key_functionBarrierCOM"));
                    function.BARRIERBaudrate = Convert.ToString(Patch.GetValue("key_functionBarrierBaudrate"));
                    //---------------------------------------------------------------------
                    function.APIKey = Convert.ToString(Patch.GetValue("key_functionAPIKey"));
                    function.APIState = Convert.ToString(Patch.GetValue("key_functionAPIState"));
                    function.APIEndpoint = Convert.ToString(Patch.GetValue("key_functionAPIEndpoint"));
                    // tickets
                    tickets.address = Convert.ToString(Patch.GetValue("key_ticketAddress"));
                    tickets.company = Convert.ToString(Patch.GetValue("key_ticketCompany"));
                    tickets.phone = Convert.ToString(Patch.GetValue("key_ticketPhone"));
                    tickets.state = Convert.ToString(Patch.GetValue("key_ticketState"));
                    tickets.tax = Convert.ToString(Patch.GetValue("key_ticketTAX"));
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
                    if (CreateKey())
                    {
                        if (registy.system.id == null)
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
                    if (Get())
                    {
                        if (system.id == "")
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
    }
}
