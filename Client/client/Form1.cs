using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace client
{
    public partial class Form1 : Form
    {
        bool terminating = false;
        bool connected = false;
        Socket clientSocket;

        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            connected = false;
            terminating = true;
            Environment.Exit(0);
        }

        private void button_send_Click(object sender, EventArgs e)
        {
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            string IP = "127.0.0.1";
            int portNum;

            if (Int32.TryParse(textBox_port.Text, out portNum))
            {
                try
                {
                    clientSocket.Connect(IP, portNum);
                    connected = true;

                    Thread receiveThread = new Thread(Receive);
                    receiveThread.Start();

                    string request = richTextBox_request.Text;

                    if (request != "" && request.Length <= 1000)
                    {
                        //richTextBox_response.AppendText("\n" + request + "\n");
                        Byte[] buffer = new Byte[1000];
                        buffer = Encoding.Default.GetBytes(request);
                        clientSocket.Send(buffer);
                    }

                   
                }
                catch
                {
                    richTextBox_response.AppendText("Could not connect to the server\n");
                }

            }
            else
            {
                richTextBox_response.AppendText("Check the port\n");
            }

            
        }

        private void Receive()
        {
            while (connected)
            {
                try
                {
                    Byte[] buffer = new Byte[1000];
                    clientSocket.Receive(buffer);

                    string response = Encoding.Default.GetString(buffer);
                    response = response.Substring(0, response.IndexOf("\0"));
                    richTextBox_response.AppendText("Server: " + response + "\n");
                }
                catch
                {
                    clientSocket.Close();
                    connected = false;
                }
            }
        }

    }
}
