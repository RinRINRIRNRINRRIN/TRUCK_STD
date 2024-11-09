using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
namespace TRUCK_STD.Function
{
    class Func_TCP
    {
        public static int Weight = 0; //ตัวแปรสำหรับ Flag น้ำหนักเพื่อให้หน้าโปรแกรมส่งน้ำหนักมาได้เลย

        public static List<TcpClient> clients = new List<TcpClient>();
        static TcpListener tcpListener;

        /// <summary>
        /// 1. ทำการเปิดServer รอ
        /// </summary>
        /// <returns></returns>
        public static async Task StartServer()
        {
            tcpListener = new TcpListener(IPAddress.Any, 1932);
            tcpListener.Start();
            Console.WriteLine("Server started...");

            await AcceptClients();
        }

        /// <summary>
        /// 2.ทำการยอมรับ Client มาเชื่อมต่อที่ Server
        /// </summary>
        /// <returns></returns>
        public static async Task AcceptClients()
        {
            while (true)
            {
                TcpClient tcpClient = await tcpListener.AcceptTcpClientAsync();
                clients.Add(tcpClient);

                Console.WriteLine($"Client connected: {((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address}");

                await HandleClient(tcpClient);
            }
        }

        /// <summary>
        /// 3.ทำการรับข้อมูลจาก Client และส่งน้ำหนักออกไป โดยใช้ตัวแปร Weight
        /// </summary>
        /// <param name="tcpClient"></param>
        /// <returns></returns>
        public static async Task HandleClient(TcpClient tcpClient)
        {
            NetworkStream ns = tcpClient.GetStream();
            byte[] buffer = new byte[1024];

            while (true)
            {
                int bytesRead = await ns.ReadAsync(buffer, 0, buffer.Length);

                if (bytesRead == 0)
                {
                    // Client disconnected
                    clients.Remove(tcpClient);
                    Console.WriteLine($"Client disconnected: {((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address}");
                    break;
                }

                string receivedData = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine($"Received from {((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address}: {receivedData}");

                // ส่งข้อมูลไปทุก client
                foreach (TcpClient client in clients)
                {
                    NetworkStream clientStream = client.GetStream();
                    byte[] sendData = Encoding.UTF8.GetBytes($"Server: {Weight} \r\n");
                    await clientStream.WriteAsync(sendData, 0, sendData.Length);
                }
            }
        }
    }
}
