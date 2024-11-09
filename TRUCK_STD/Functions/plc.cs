using System;
using System.IO.Ports;

namespace TRUCK_STD.Functions
{
    internal class plc
    {
        private static string PLC_PORT
        {
            get { return registy.plc.plcPort; }
        }

        private static int PLC_BAURATE
        {
            get { return registy.plc.plcBaudrate; }
        }

        public static string ERR { get; set; }



        /// <summary>
        /// สำหรับเชื่อมต่อ Scale
        /// </summary>
        /// <param name="sa"></param>
        /// <returns></returns>
        public static bool Connect(SerialPort sa)
        {
            try
            {
                sa.PortName = PLC_PORT;
                sa.BaudRate = PLC_BAURATE;
                sa.Open();
            }
            catch (Exception ex)
            {
                ERR = ex.Message;
                return false;
            }
            return true;
        }

        /// <summary>
        /// สำหรับตัดการเชื่อมต่อ PLC
        /// </summary>
        /// <param name="sa"></param>
        /// <returns></returns>
        public static bool Disconnect(SerialPort sa)
        {
            try
            {
                if (sa.IsOpen)
                {
                    sa.Close();
                }
            }
            catch (Exception ex)
            {
                ERR = ex.Message;
                return false;
            }
            return true;
        }

    }
}
