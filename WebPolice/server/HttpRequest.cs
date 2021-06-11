using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace projetest
{
    public class HttpRequest
    {
        String CRLF = "\r\n";
        int HTTP_PORT = 80;

        /** Store the request parameters */
        String method;
        String URI;
        String version;
        String headers = "";

        /** Server and port */
        private String host;
        private int port;

        Socket clientSocket;

        /** Create HttpRequest by reading it from the client socket */
        public HttpRequest(Byte[] from)
        {
            String incomingMessage = Encoding.Default.GetString(from);
            incomingMessage = incomingMessage.Substring(0, incomingMessage.IndexOf("\0"));

            String firstLine = "";
            try
            {
                firstLine = incomingMessage.Split(new[] { '\r', '\n' }).FirstOrDefault();
            }
            catch (IOException e)
            {
                Console.WriteLine("Error reading request line: " + e);
            }

            string[] values = firstLine.Split(' ');

            method = values[0];
            URI = values[1];
            version = values[2];


            Console.WriteLine("URI is: " + URI);
            if (method != "GET")
            {
                Console.WriteLine("Error: Method not GET");
            }

            try
            {
                String[] lines = incomingMessage.Split('\n'); 
                port = HTTP_PORT;
 
                foreach (string line in lines)
                {
                    headers += line + CRLF;
                    /* We need to find host header to know which server to
                    * contact in case the request URI is not complete. */
                    if (line.Contains("Host:"))
                    {
                        string[] hostLine = line.Split(' ');
                        host = hostLine[1];
                    }
                    else if (line.Contains("Port:"))
                    {
                        int spaceLine = line.IndexOf(" ");

                        port = Int32.Parse(line.Substring(spaceLine, line.IndexOf("\0")));

                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Error reading from socket: " + e);
                return;
            }
        }

        /** Return host for which this request is intended */
        public String getHost()
        {
            return host;
        }

        /** Return port for server */
        public int getPort()
        {
            return port;
        }
        /**
         * Convert request into a string for easy re-sending.
         */
        public String toString()
        {
            String req = "";

            req += headers;
            /* This proxy does not support persistent connections */
            req += "Connection: close" + CRLF;
            req += CRLF;

            return req;
        }
    }
}
