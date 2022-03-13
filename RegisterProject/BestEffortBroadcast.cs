using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterProject
{
    public class BestEffortBroadcast
    {
        public BestEffortBroadcast(List<string> processes)
        {
            _Processes = processes;
        }
        public void Broadcast(string message)
        {
            foreach (string process in _Processes)
                ;//Send process,message
        }
        //Deliver process message
        List<string> _Processes;
    }
}
