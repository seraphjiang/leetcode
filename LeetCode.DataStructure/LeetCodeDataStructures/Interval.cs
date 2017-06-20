using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.DataStructure.LeetCodeDataStructures
{
    public class Interval
    {
        public int start;
        public int end;
        public Interval() { start = 0; end = 0; }
        public Interval(int s, int e) { start = s; end = e; }
        public override bool Equals(object obj)
        {
            var tar = obj as Interval;
            if (tar == null) return false;
            return this.start == tar.start && this.end == tar.end;
        }
    }
}
