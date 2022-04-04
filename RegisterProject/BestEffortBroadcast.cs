using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf;
using Google.Protobuf.Communication;
namespace RegisterProject
{
    public class BestEffortBroadcast
    {
        public BestEffortBroadcast(List<ProcessId> processes)
        {
            _Processes = processes;
        }
        public void Broadcast(string message)
        {
            foreach (ProcessId process in _Processes)
                ;//Send process,message
        }
        //Deliver process message
        List<ProcessId> _Processes;
    }
}
