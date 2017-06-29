using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tests.MathProblemsTests
{
    public class GaryCode
    {
        public IList<int> GrayCode(int n)
        {
            var res = new List<int>();
            for (var i = 0; i < 1 << n; i++)
            {
                res.Add(i ^ i >> 1);
            }
            return res;
        }

        public IList<int> GrayCode1(int n)
        {
            var res = new List<int>();
            res.Add(0);
            for(var i=0;i< n; i++)
            {
                var inc = 1 << i; // binary:  1, 10, 100 ...
                for(var j = res.Count - 1; j >= 0; j--)
                {
                    res.Add(res[j] + inc);
                }
            }

            return res;
        }
    }
}
