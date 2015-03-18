using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
namespace ChatServer
{
    public partial class Form1 : Form
    {
        Socket _socket;
        Socket clientSocket;
        byte[] buffer = new byte[1024];
        public Form1()
        {
            InitializeComponent();
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
        public void Bind(int port)
        {
            _socket.Bind(new IPEndPoint(IPAddress.Any, port));
        }
        public void Listen(int backlog)
        {
            _socket.Listen(backlog);
        }
        public void Accept()
        {
            _socket.BeginAccept(AcceptCallBack, null);
        }
        private void AcceptCallBack(IAsyncResult result)
        {
            this.Invoke(new Action(() => State.Text = "Client Connected!"));
            clientSocket = _socket.EndAccept(result);
            buffer = new byte[1024];
            Accept();
            clientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, RecieveCallBack, clientSocket);
        }
        private void RecieveCallBack(IAsyncResult result)
        {
            clientSocket = result.AsyncState as Socket;
            int bufferSize = clientSocket.EndReceive(result);
            byte[] packet = new byte[bufferSize];
            Array.Copy(buffer, packet, packet.Length);
            string msg=Encoding.ASCII.GetString(packet);
            if(msg.Contains("cmdoutput"))
            {
                this.Invoke(new Action(() => richTextBox1.Text = msg.Replace("cmdoutput","")));
            }
            else if(msg.Contains("msg"))
            {
                this.Invoke(new Action(() => tbMessaging.Text += "\nClient Says: " + msg.Replace("msg","")));               
            }
            
            buffer = new byte[1024];
            clientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, RecieveCallBack, clientSocket);
        }
        public void SendMsg(byte[] msg)
        {
            clientSocket.Send(msg);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Bind(6556);
            Listen(500);
            Accept();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SendMsg(Encoding.ASCII.GetBytes("cmd" + tbCMD.Text));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SendMsg(Encoding.ASCII.GetBytes(tbMsg.Text));
            tbMessaging.Text += "\nServer Says: " + tbMsg.Text;
        }
    }
}
