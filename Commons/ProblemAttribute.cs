using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons
{
    public enum Level
    {
        Easy,
        Median,
        Hard
    }
    [AttributeUsage(AttributeTargets.All)]
    public class ProblemAttribute : Attribute
    {
        public string Company { get; set; }
        public Level Level { get; set; }
        public string[] Algorithms { get; set; }
        public string[] DataStructure { get; set; }
        public string[] Tags { get; set; }
    }
}
