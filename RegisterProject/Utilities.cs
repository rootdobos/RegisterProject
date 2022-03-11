using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterProject
{
    public static class Utilities
    {
        public static bool IsIntersection(List<string> list1, List<string> list2)
        {
            if (Intersection(list1, list2).Count > 0)
                return true;
            else
                return false;
        }
        public static List<string> Intersection(List<string> list1, List<string> list2)
        {
            List<string> intersection = new List<string>();
            foreach (string element in list1)
                if (list2.Contains(element))
                    intersection.Add(element);
            return intersection;
        }
        public static List<string> Clone(List<string> list)
        {
            List<string> clone = new List<string>();
            foreach (string element in list)
                clone.Add(element);
            return clone;
        }
    }
}
