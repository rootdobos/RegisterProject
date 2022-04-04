using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf.Communication;
namespace RegisterProject
{
    public static class Utilities
    {
        public static bool IsIntersection(List<ProcessId> list1, List<ProcessId> list2)
        {
            if (Intersection(list1, list2).Count > 0)
                return true;
            else
                return false;
        }
        public static List<ProcessId> Intersection(List<ProcessId> list1, List<ProcessId> list2)
        {
            List<ProcessId> intersection = new List<ProcessId>();
            foreach (ProcessId element in list1)
                if (list2.Contains(element))
                    intersection.Add(element);
            return intersection;
        }
        public static List<ProcessId> Clone(List<ProcessId> list)
        {
            List<ProcessId> clone = new List<ProcessId>();
            foreach (ProcessId element in list)
                clone.Add(element);
            return clone;
        }
        public static List<ProcessId> Sustraction(List<ProcessId> list1, List<ProcessId> list2)
        {
            List<ProcessId> result = new List<ProcessId>();
            foreach(ProcessId element in list1)
            {
                if (!list2.Contains(element))
                    result.Add(element);
            }
            return result;
        }
    }
}
