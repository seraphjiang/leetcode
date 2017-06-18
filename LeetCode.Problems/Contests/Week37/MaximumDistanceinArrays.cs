using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.Contests.Week37
{
    public class MaximumDistanceinArrays
    {
        public int MaxDistance(IList<IList<int>> arrays)
        {
            var m = arrays.Count;
            var min = arrays[0][0];
            var max = arrays[0].Last();

            var d = 0;
            for(var i = 1; i < arrays.Count; ++i)
            {
                d = Math.Max(d, Math.Abs(arrays[i][0] - max));
                d = Math.Max(d, Math.Abs(arrays[i].Last() - min));
                min = Math.Min(min, arrays[i][0]);
                max = Math.Max(max, arrays[i].Last());
            }

            return d;
        }

        public int MaxDistanceTLE(IList<IList<int>> arrays)
        {
            var m = arrays.Count;

            var max = 0;
            for (var i = 0; i < m - 1; i++)
            {
                //all array;
                for (var j = i + 1; j < m; j++)
                {
                    var d1 = Math.Abs(arrays[j][arrays[j].Count - 1] - arrays[i][0]);
                    var d2 = Math.Abs(arrays[i][arrays[i].Count - 1] - arrays[j][0]);
                    max = Math.Max(max, d1);
                    max = Math.Max(max, d2);
                }
            }

            return max;
        }
    }
}
