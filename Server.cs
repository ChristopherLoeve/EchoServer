using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EchoServer
{
    class Server
    {
        public Server()
        {

        }

        public void Start()
        {
            TcpListener listener = new TcpListener(IPAddress.Loopback, 7);
            listener.Start();

            TcpClient socket = listener.AcceptTcpClient();


            using (StreamReader sr = new StreamReader(socket.GetStream()))
            using (StreamWriter sw = new StreamWriter(socket.GetStream()))
            {
                while (true)
                {
                    string line = sr.ReadLine();
                    Console.WriteLine("The server has received message: " + line);

                    sw.WriteLine(line);
                    sw.Flush();
                }
            }

        }
    }
}
