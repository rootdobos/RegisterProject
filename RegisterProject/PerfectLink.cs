using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf.Communication;
using System.Threading.Tasks;

namespace RegisterProject
{
     public   class PerfectLink
    {
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
        
    }
    public class PerfectLinkDeliverEventArgs: EventArgs
    {
        public PlDeliver DeliverMessage{ get; set; }
    }
}
