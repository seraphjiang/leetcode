using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.BacktrackingProblems
{
    public class ExpressionAddOperators
    {
        public IList<string> AddOperators(string num, int target)
        {
            var res = new List<string>();
            if (string.IsNullOrEmpty(num)) return res;

            help(num, 0, 0, 0, target, "", res);

            return res;
        }

        public void help(string num, int index, long eval, long pre, int target, string path, List<string> res)
        {
            if (index == num.Length)
            {
                if (eval == target) res.Add(path);
                return;
            }

            for (var i = index; i < num.Length; i++)
            {
                //if (i != index && num[i] == '0') break;
                if (i != index && num[index] == '0') break;

                long cur = long.Parse(num.Substring(index, i - index + 1));
                if (index == 0)
                {
                    help(num, i + 1, cur, cur, target, cur.ToString(), res);
                }
                else
                {
                    help(num, i + 1, eval + cur, cur, target, path + "+" + cur.ToString(), res);
                    help(num, i + 1, eval - cur, -cur, target, path + "-" + cur.ToString(), res);
                    help(num, i + 1, eval - pre + pre * cur, pre * cur, target, path + "*" + cur.ToString(), res);
                }
            }

        }
    }
}
