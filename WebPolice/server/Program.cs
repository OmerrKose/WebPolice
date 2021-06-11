using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace projetest
{
    class Program
    {
        /** Port for the proxy */
        private static int serverPort;
        /** Socket for client connections */
        private static Socket serverSocket;

        private static List<String> bannedWords = new List<String>();
        static readonly string textFilePath = @".....";

        static bool listening = false;
        private static List<Socket> clientSockets = new List<Socket>();
        public static void init(int p)
        {
            serverPort = p;
            try
            {
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, serverPort);
                serverSocket.Bind(endPoint);
                serverSocket.Listen(3);


                Console.WriteLine("Started listening on port: " + serverPort + "\n");
            }
            catch (IOException e)
            {
                Console.WriteLine("Error creating socket: " + e);
                return;
            }
        }

        public static void handle(Socket client)
        {
            Socket server = null;
            HttpRequest request = null;
            HttpResponse response = null;

            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, serverPort);

            /* Read request */
            try
            {
                Byte[] buffer = new Byte[128];
                client.Receive(buffer);
                request = new HttpRequest(buffer);
                Console.WriteLine("Got request...");
                listening = true;

            }
            catch (Exception e)
            {
                Console.WriteLine("Error reading request from client: " + e);
                return;
            }

            /* Send request to web page */
            try
            {
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                if (!canIUseThisWord(request.toString()))
                {
                    Byte[] errorBuffer = Encoding.Default.GetBytes("Access Denied");
                    Console.WriteLine("Access Denied");
                    client.Send(errorBuffer);
                    server.Close();

                    return;
                }

                server.Connect(request.getHost(), request.getPort());
                Console.WriteLine(request.toString());

                Byte[] bufferToSend = Encoding.Default.GetBytes(request.toString());
                server.Send(bufferToSend);
            }
            catch (IOException e)
            {
                Console.WriteLine("Error writing request to server: " + e);
                return;
            }

            /* Read response and forward it to client */
            try
            {
                Byte[] buffer = new Byte[1000];
                server.Receive(buffer);
                Console.WriteLine(Encoding.Default.GetString(buffer));
                response = new HttpResponse(buffer);

                Byte[] bufferToSend = new Byte[1000];
                bufferToSend = Encoding.Default.GetBytes(response.toString());
                client.Send(bufferToSend);
                server.Close();
            }
            catch (IOException e)
            {
                Console.WriteLine("Error writing response to client: " + e);
            }
        }

        /** Get input from command prompt and start server */
        public static void Main(string[] args)
        {
            int myPort = 0;
            string val;
            Console.Write("Enter port: ");
            val = Console.ReadLine();

            myPort = Int32.Parse(val);

            init(myPort);

            /** Main loop. Listen for incoming connections and spawn a new thread for handling them */
            while (true)
            {
                try
                {
                    Socket client = serverSocket.Accept();
                    clientSockets.Add(client);
                    Console.WriteLine("Got connection " + client);

                    Thread receiveThread = new Thread(() => handle(client));
                    receiveThread.Start();
                }
                catch (IOException e)
                {
                    Console.WriteLine("Error reading request from client: " + e);
                    /* Definitely cannot continue, so skip to next
                        * iteration of while loop. */
                    continue;
                }
            }

        }

        public static bool canIUseThisWord(String word)
        {
            readFromTextFile(textFilePath);

            foreach (string i in bannedWords)
            {

                if (word.Contains(i))
                {
                    return false;
                }
            }
            return true;
        }

        public static void readFromTextFile(String fileName)
        {
            var lines = File.ReadLines(fileName);

            foreach (var line in lines)
            {
                bannedWords.Add(line);
            }
        }

    }
}
