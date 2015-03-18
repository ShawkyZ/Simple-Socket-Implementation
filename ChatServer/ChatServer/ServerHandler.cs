using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ChatServer
{
    class ServerHandler
    {
        Socket _socket;
        Socket clientSocket;
        byte[] buffer = new byte[1024];
        public ServerHandler()
        {
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
            Console.WriteLine("Client Connected");
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
            Console.WriteLine(Encoding.ASCII.GetString(packet));
            buffer = new byte[1024];
            clientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, RecieveCallBack, clientSocket);
        }
        public void SendMsg(string msg)
        {
            clientSocket.Send(Encoding.ASCII.GetBytes(msg));
        }
    }
}
