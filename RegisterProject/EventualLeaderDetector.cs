using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf.Communication;

namespace RegisterProject
{
    public class EventualLeaderDetector
    {
        public EventuallyPerfectFailureDetector EventuallyPerfectFailureDetector
        { set { _EPFD = value; } }

        public EventualLeaderDetector()
        {
            _Leader = null;
        }

        public void ChangeLeader()
        {
            _Leader = Utilities.Sustraction(_EPFD.Processes, _EPFD.Suspected)[0];
            //trigger trust leader
        }

        private EventuallyPerfectFailureDetector _EPFD;
        ProcessId _Leader;
    }
}
