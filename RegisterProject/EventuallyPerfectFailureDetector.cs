using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf.Communication;
namespace RegisterProject
{
    public class EventuallyPerfectFailureDetector
    {
        public List<ProcessId> Suspected
        { get { return _Suspected; } }
        public List<ProcessId> Processes
        { get { return _Processes; } }

        public EventuallyPerfectFailureDetector(List<ProcessId> processes,int deltaTime=100)
        {
            _Processes = processes;
            _Alive = Utilities.Clone(_Processes);
            _Suspected = new List<ProcessId>();
            _Delay = deltaTime;
            _DeltaTime = deltaTime;
            //starttimer
        }
        public void Timeout()
        {
            if (Utilities.IsIntersection(_Alive, _Suspected))
                _Delay += _DeltaTime;
            foreach(ProcessId process in _Processes)
            {
                if (!_Alive.Contains(process) && !_Suspected.Contains(process))
                    _Suspected.Add(process);
                else if (_Alive.Contains(process) && _Suspected.Contains(process))
                    _Suspected.Remove(process);
                //trigger send HeartbeatRequest
            }
            _Alive.Clear();
            //starttimer
        }
        //Deliver heartbeatRequest
        //Deliver HeartbeatReply
        List<ProcessId> _Alive;
        List<ProcessId> _Suspected;
        List<ProcessId> _Processes;
        int _Delay;
        int _DeltaTime;
    }
}
