using System.IO.Ports;

namespace TRUCK_STD.Functions
{
    internal class rfid
    {
        public static string ERR { get; set; }



        /// <summary>
        /// สำหรับเช็คว่ามีการกำหนดค่าของการเชื่อมต่อหรือยัง
        /// </summary>
        /// <returns></returns>
        public static bool CheckPort()
        {
            if (registy.function.RFID_COM == "" || registy.function.RFID_BAUDRATE == "")
                return false;
            else
                return true;
        }





        public static bool Connect(SerialPort sa)
        {
            try
            {
                sa.PortName = registy.function.RFID_COM;
                sa.BaudRate = int.Parse(registy.function.RFID_BAUDRATE);
                sa.Open();
            }
            catch (System.Exception ex)
            {
                ERR = ex.Message;
                return false;
            }

            return true;
        }


        public static void Disconnect(SerialPort sa)
        {
            try
            {
                if (sa.IsOpen)
                {
                    sa.Close();
                }
            }
            catch (System.Exception ex)
            {


            }


        }
    }
}
