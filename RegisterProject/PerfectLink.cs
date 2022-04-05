using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf;
using Google.Protobuf.Communication;
namespace RegisterProject
{
    public class PerfectLink
    {
        public PerfectLink(string hostIP, int hubPort, int myPort)
        {
            IPAddress ip = System.Net.IPAddress.Parse(hostIP);
            IPEndPoint myEndPoint = new IPEndPoint(ip, myPort);
            _Client = new TcpClient(myEndPoint);
            _Client.NoDelay = true;
            _Client.ConnectAsync(hostIP, hubPort);
            TCPDeliver();
        }
        public event EventHandler<PerfectLinkDeliverEventArgs> Deliver;
        public async Task Send(ProcessId destination, Message message)
        {

        }
        public void DeliverFunction()
        {

            EventHandler<PerfectLinkDeliverEventArgs> handler = Deliver;
            PerfectLinkDeliverEventArgs args = new PerfectLinkDeliverEventArgs();
            args.DeliverMessage = null;
            handler?.Invoke(this, args);
        }
        public async Task TCPDeliver()
        {
            NetworkStream stream = _Client.GetStream();
            byte[] buffer = new byte[8192];
            int byteCount = await stream.ReadAsync(buffer, 0, buffer.Length);
            Message message = Message.Parser.ParseFrom(buffer);
            Console.WriteLine("I got something");
        }
        public async Task TCPSend(Message message)
        {
            NetworkStream stream = _Client.GetStream();
            //byte[] messageArray = message.ToByteArray();
            //stream.Write(messageArray, 0, messageArray.Length);

            message.WriteTo(stream);
            Console.WriteLine("Dummy message sent");
        }
        private TcpClient _Client;
    }
    public class PerfectLinkDeliverEventArgs: EventArgs
    {
        public PlDeliver DeliverMessage{ get; set; }
    }
}
