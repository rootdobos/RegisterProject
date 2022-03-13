using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterProject
{
    public class EventuallyPerfectFailureDetector
    {
        public List<string> Suspected
        { get { return _Suspected; } }
        public List<string> Processes
        { get { return _Processes; } }

        public EventuallyPerfectFailureDetector(List<string> processes,double deltaTime)
        {
            _Processes = processes;
            _Alive = Utilities.Clone(_Processes);
            _Suspected = new List<string>();
            _Delay = deltaTime;
            _DeltaTime = deltaTime;
            //starttimer
        }
        public void Timeout()
        {
            if (Utilities.IsIntersection(_Alive, _Suspected))
                _Delay += _DeltaTime;
            foreach(string process in _Processes)
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
        List<string> _Alive;
        List<string> _Suspected;
        List<string> _Processes;
        double _Delay;
        double _DeltaTime;
    }
}
