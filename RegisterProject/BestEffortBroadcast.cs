using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf;
using Google.Protobuf.Communication;
using System.Threading.Tasks;
namespace RegisterProject
{
    public class BestEffortBroadcast
    {
        public event EventHandler<BEBDeliverEventArgs> Deliver;
        public BestEffortBroadcast(List<ProcessId> processes, PerfectLink perfectLink)
        {
            _Processes = processes;
            _PerfectLink = perfectLink;
            _PerfectLink.Deliver += DeliverFunction;
        }
        public async void Broadcast(Message message)
        {
            foreach (ProcessId process in _Processes)
            {
                //Send process,message
                await _PerfectLink.Send(process, message);
            }
        }
        //Deliver process message
        public void DeliverFunction(object sender, PerfectLinkDeliverEventArgs e)
        {


            EventHandler<BEBDeliverEventArgs> handler = Deliver;
            BEBDeliverEventArgs args = new BEBDeliverEventArgs();
            BebDeliver bebArgs = new BebDeliver()
                {Sender=e.DeliverMessage.Sender,
                Message=e.DeliverMessage.Message};
            args.DeliverMessage = bebArgs;
            handler?.Invoke(this, args);
        }
        List<ProcessId> _Processes;
        PerfectLink _PerfectLink;

    }
    public class BEBDeliverEventArgs : EventArgs
    {
        public BebDeliver DeliverMessage { get; set; }
    }
}
