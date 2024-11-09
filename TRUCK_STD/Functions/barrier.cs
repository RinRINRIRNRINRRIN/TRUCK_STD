using System;
using System.IO.Ports;

namespace TRUCK_STD.Functions
{
    internal class barrier
    {
        public static string COM
        {
            get { return registy.plc.plcPort; }
        }

        public static int BAUDRATE
        {
            get { return registy.plc.plcBaudrate; }
        }
        public static string ERR { get; set; }
        /// <summary>
        /// For connect port
        /// </summary>
        /// <param name="sa">SerialPort</param>
        /// <returns></returns>
        public static bool Connect(SerialPort sa)
        {
            try
            {
                sa.PortName = COM;
                sa.BaudRate = BAUDRATE;
                sa.Open();
                if (!sa.IsOpen)
                {
                    return false;
                }
            }
            catch (System.Exception ex)
            {
                ERR = ex.Message;
                return false;
            }
            return true;
        }


        /// <summary>
        /// For open or close the gate
        /// </summary>
        /// <param name="state">OPEN = UP , CLOSE = DOWN</param>
        /// <param name="sa">SerialPort</param>
        /// <returns></returns>
        public static bool Gate1(string state, SerialPort sa)
        {
            try
            {
                // Send command
                switch (state)
                {
                    case "OPEN":
                        sa.WriteLine("GATE1_UP");
                        break;
                    case "CLOSE":
                        sa.WriteLine("GATE1_DOWN");
                        break;
                }

                // Check response
                string res = sa.ReadLine();
                Console.WriteLine(res);
                if (!res.Contains("TRUE"))
                {
                    ERR = "สั่งงานไม้กั้นไม่สำเร็จ";
                    return false;
                }

            }
            catch (System.Exception ex)
            {
                ERR = ex.Message;
                return false;
            }
            return true;
        }


        /// <summary>
        /// For open or close the gate
        /// </summary>
        /// <param name="state">OPEN = UP , CLOSE = DOWN</param>
        /// <param name="sa">SerialPort</param>
        /// <returns></returns>
        public static bool Gate2(string state, SerialPort sa)
        {
            try
            {
                // Send command
                switch (state)
                {
                    case "OPEN":
                        sa.WriteLine("GATE2_UP\n");
                        break;
                    case "CLOSE":
                        sa.WriteLine("GATE2_DOWN\n");
                        break;
                }

                // Check response
                string res = sa.ReadLine();
                Console.WriteLine(res);
                if (!res.Contains("TRUE"))
                {
                    ERR = "สั่งงานไม้กั้นไม่สำเร็จ";
                    return false;
                }
            }
            catch (System.Exception ex)
            {
                ERR = ex.Message;
                return false;
            }
            return true;
        }


        /// <summary>
        /// For on green or red of light
        /// </summary>
        /// <param name="state">GREEN,RED</param>
        /// <param name="sa">SerialPort</param>
        /// <returns></returns>
        public static bool Light1(string state, SerialPort sa)
        {
            // Send command
            switch (state)
            {
                case "GREEN":
                    sa.WriteLine("LIGHT1_GREEN");
                    break;
                case "RED":
                    sa.WriteLine("LIGHT1_RED");
                    break;
            }

            // Check response
            string res = sa.ReadLine();
            Console.WriteLine(res);
            if (!res.Contains("TRUE"))
            {
                ERR = "สั่งงานไม้กั้นไม่สำเร็จ";
                return false;
            }
            return true;
        }


        /// <summary>
        /// For on green or red of light
        /// </summary>
        /// <param name="state">GREEN,RED</param>
        /// <param name="sa">SerialPort</param>
        /// <returns></returns>
        public static bool Light2(string state, SerialPort sa)
        {
            // Send command
            switch (state)
            {
                case "GREEN":
                    sa.WriteLine("LIGHT2_GREEN");
                    break;
                case "RED":
                    sa.WriteLine("LIGHT2_RED");
                    break;
            }

            // Check response
            string res = sa.ReadLine();
            Console.WriteLine(res);
            if (!res.Contains("TRUE"))
            {
                ERR = "สั่งงานไม้กั้นไม่สำเร็จ";
                return false;
            }
            return true;
        }


        public static bool IntitialBoard()
        {
            try
            {

            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }



    }
}
