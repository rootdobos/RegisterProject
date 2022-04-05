using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegisterProject;
using Google.Protobuf.Communication;
namespace Application
{
    class Program
    {
        public static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }
        private static async Task MainAsync()
        {
            _PerfectLink = new PerfectLink("127.0.0.1", 5000,5005);
            Message m = new Message();
            m.Type = Message.Types.Type.NetworkMessage;
            m.NetworkMessage = new NetworkMessage();
            m.NetworkMessage.SenderListeningPort = 5005;
            m.NetworkMessage.Message = new Message();
            m.NetworkMessage.Message.Type = Message.Types.Type.ProcRegistration;
            m.NetworkMessage.Message.ProcRegistration = new ProcRegistration();
            await _PerfectLink.TCPSend(m);
            Console.ReadKey();
        }
        private static PerfectLink _PerfectLink;
    }
}
