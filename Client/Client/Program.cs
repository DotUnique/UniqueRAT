using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace Client
{
    class Program
    {
        private const int _BUFFER_SIZE = 20971520;
        private static int _PORT = 100;
        private static string _IP = "192.168.0.48";
        private static TcpClient _client;
        static void Main(string[] args)
        {
            while (true)
            {
                TcpClient _client = new TcpClient(_IP, _PORT);
                Console.WriteLine("What message?");
                string message = Console.ReadLine();

                int byteCount = Encoding.ASCII.GetByteCount(message + 1);

                byte[] sendData = new byte[byteCount];

                sendData = Encoding.ASCII.GetBytes(message + ';');

                NetworkStream stream = _client.GetStream();

                stream.Write(sendData, 0, sendData.Length);

                stream.Close();
                _client.Close();
            }


        }
    }
}
