using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.Contests.Week38
{
    public class Excel
    {
        int[,] excel;
        string[,][] formula;
        int h;
        int w;
        public Excel(int H, string W)
        {
            h = H;
            w = (W[0] - 'A') + 1;
            excel = new int[h, w];
            formula = new string[h, w][];
        }
        public Excel(int H, char W)
        {
            h = H;
            w = (W - 'A') + 1;
            excel = new int[h, w];
            formula = new string[h, w][];
        }

        public void Set(int r, char c, int v)
        {
            if (r < h && (c - 'A') < w)
            {
                formula[r, c - 'A'] = null;
                excel[r, c - 'A'] = v;
            }
        }

        public int Get(int r, char c)
        {
            if (r < h && (c - 'A') < w)
            {
                if (formula[r, c - 'A'] == null)
                    return excel[r, c - 'A'];
                else
                    return Sum(r, c - 'A');
            }

            return 0;
        }

        public int Sum(int r, char c, string[] strs)
        {
            if (r < h && (c - 'A') < w)
            {
                formula[r, c - 'A'] = strs;
                var sum = 0;
                foreach (var s in strs)
                {
                    sum += ParseAndCalc(s);
                }
                return sum;
            }

            return 0;
        }

        private int Sum(int r, int c)
        {
            if (r < h && c < w)
            {
                var sum = 0;
                var strs = formula[r, c];
                foreach (var s in strs)
                {
                    sum += ParseAndCalc(s);
                }
                return sum;
            }

            return 0;
        }

        private int ParseAndCalc(string s)
        {
            string A1 = "";
            string A2 = "";
            var sp = s.IndexOf(":");
            if (sp > 0)
            {
                A1 = s.Substring(0, sp);
                A2 = s.Substring(sp);
            }
            else
            {
                A1 = s;
                A2 = s;
            }

            var A1_C = 0;
            var A1_R = 0;
            var A2_C = 0;
            var A2_R = 0;

            Parse(A1, out A1_C, out A1_R);
            Parse(A2, out A2_C, out A2_R);
            var sum = 0;
            for (var i = A1_R; i <= A2_R; i++)
            {
                for (var j = A1_C; j <= A2_C; j++)
                {
                    if (formula[i, j] == null)
                        sum += excel[i, j];
                    else
                        sum += Sum(i, j);
                }
            }

            return sum;
        }

        private void Parse(string s, out int c, out int r)
        {
            c = s[0] - 'A';
            r = int.Parse(s.Substring(1));
        }
    }
}
