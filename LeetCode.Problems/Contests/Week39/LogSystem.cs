using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.Contests.Week39
{
    public class LogSystem
    {
        Dictionary<int, long> logs = new Dictionary<int, long>();
        const long pre = 100000000000000;
        public LogSystem()
        {
        }

        public void Put(int id, string timestamp)
        {
            var t = timestamp.Replace(":", "");
            logs.Add(id, pre + long.Parse(t));
        }

        public IList<int> Retrieve(string s, string e, string gra)
        {
            long start = pre + long.Parse(s.Replace(":", ""));
            long end = pre + long.Parse(e.Replace(":", ""));
            
            long div = 1;
            switch (gra)
            {
                case "Year":
                    div = 10000000000;
                    break;
                case "Month":
                    div = 100000000;
                    break;
                case "Day":
                    div = 1000000;
                    break;
                case "Hour":
                    div = 10000;
                    break;
                case "Minute":
                    div = 100;
                    break;
                case "Second":
                    div = 1;
                    break;
                default:
                    div = 1;
                    break;
            }

            start /= div;
            end /= div;
            var ret = logs.Where(x => x.Value/div >= start && x.Value/div <= end);
            var res = ret.Select(x => x.Key).ToList();
            return res;
        }
    }
}
