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
            DoClient(socket);
        }



        public void DoClient(TcpClient socket)
        {

            using (StreamReader sr = new StreamReader(socket.GetStream()))
            using (StreamWriter sw = new StreamWriter(socket.GetStream()))
            {
                while (true)
                {
                    string line = sr.ReadLine();
                    Console.WriteLine("The server has received message: " + line);
                    char[] characters = line.ToCharArray();
                    int spaces = 0;
                    foreach (var character in characters)
                    {
                        if (character == ' ') spaces += 1;
                    }
                    string returnMessage = $"Received message. The message contained {spaces+1} words";
                    sw.WriteLine(returnMessage);
                    sw.Flush();
                }
            }
        }


        
    }
}
