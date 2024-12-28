namespace TRUCK_STD.Functions
{
    internal class systems
    {
        public static string KeyId
        {
            get { return registy.system.keyID; }
        }


        public static string PublicKey
        {
            get { return registy.system.publicKey; }
        }

        public static string BussinessType
        {
            get { return registy.system.bussinessType; }
        }

        public static string Date
        {
            get { return registy.system.date; }
        }

        public static string DateExpire
        {
            get { return registy.system.dateExpire; }
        }

        /// <summary>
        /// ประเภทการใช้งานโปรแกรม TRUE = ใช้งานจริง , FALSE = ใช้งานทดสอบ
        /// </summary>
        public static string ProgramType
        {
            get { return registy.system.programType; }
        }

        public static string StationName
        {
            get { return registy.system.stationName; }
        }


        /// <summary>
        /// ประเภทของการใช้โปรแกรม (สถานีชั่ง , จุดลงทะเบียน)
        /// </summary>
        public static string StationType
        {
            get { return registy.system.stationType; }
        }


    }
}
