using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterProject
{
    public class EventuallyPerfectFailureDetector
    {
        public EventuallyPerfectFailureDetector(List<string> Processes,double delay)
        {
            _Alive = Processes;
            _Suspected = new List<string>();
            _Delay = delay;
        }
        public void Timeout()
        {
          //  if()
        }
        List<string> _Alive;
        List<string> _Suspected;
        double _Delay;
    }
}
