using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.Contests.Week38
{
    public class Excel
    {
        int h;
        int w;
        int[,] excel;
        string[,][] formula;
        public Excel(int H, char W)
        {
            h = H; // 1-26
            w = W - 'A' + 1; // 1-26
            excel = new int[h, w];
            formula = new string[h, w][];
        }

        public void Set(int r, char c, int v)
        {
            Set(r - 1, c - 'A', v);
        }

        void Set(int r, int c, int v)
        {
            formula[r, c] = null;
            excel[r, c] = v;
        }

        public int Get(int r, char c)
        {
            return Get(r - 1, c - 'A');
        }

        int Get(int r, int c)
        {
            if (formula[r, c] != null)
            {
                return Calc(r, c);
            }
            else
            {
                return excel[r, c];
            }
        }

        int Get(string s)
        {
            var r = int.Parse(s.Substring(1)) - 1;
            var c = s[0] - 'A';
            return Get(r, c);
        }

        public int Sum(int r, char c, string[] strs)
        {
            return Sum(r - 1, c - 'A', strs);
        }

        int Sum(int r, int c, string[] strs)
        {
            formula[r, c] = strs;
            return Get(r, c);
        }

        int Calc(int r, int c)
        {
            var strs = formula[r, c];
            var total = 0;
            foreach (var s in strs)
            {
                total += CalcRange(s);
            }

            return total;
        }
        int CalcRange(string s)
        {
            var index = s.IndexOf(":");
            if (index >= 0)
            {
                var upleft = s.Substring(0, index);
                var bottomright = s.Substring(index + 1);

                if (upleft.Equals(bottomright))
                {
                    return Get(upleft);
                }
                else
                {
                    var ulRow = int.Parse(upleft.Substring(1)) - 1; // be careful about row, col position in string. A..Z is col not row.
                    var ulCol = upleft[0] - 'A';

                    var brRow = int.Parse(bottomright.Substring(1)) - 1;
                    var brCol = bottomright[0] - 'A';
                    var total = 0;
                    for (var i = ulRow; i <= brRow; i++)
                    {
                        for (var j = ulCol; j <= brCol; j++)
                        {
                            if (formula[i, j] != null)
                                total += Calc(i, j);
                            else
                                total += excel[i, j];
                        }
                    }

                    return total;
                }
            }
            else
            {
                return Get(s);
            }
        }
    }

    //public class Excel
    //{
    //    public Excel(int H, char W)
    //    {

    //    }

    //    public void Set(int r, char c, int v)
    //    {

    //    }

    //    public int Get(int r, char c)
    //    {

    //    }

    //    public int Sum(int r, char c, string[] strs)
    //    {

    //    }
    //}

    public class ExcelWrong
    {
        int[,] excel;
        string[,][] formula;
        int h;
        int w;

        public ExcelWrong(int H, char W)
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
                formula[r - 1, c - 'A'] = null;
                excel[r - 1, c - 'A'] = v;
            }
        }

        public int Get(int r, char c)
        {
            if (r < h && (c - 'A') < w)
            {
                if (formula[r - 1, c - 'A'] == null)
                    return excel[r - 1, c - 'A'];
                else
                    return Sum(r - 1, c - 'A');
            }

            return 0;
        }

        public int Sum(int r, char c, string[] strs)
        {
            if (r < h && (c - 'A') < w)
            {
                formula[r - 1, c - 'A'] = strs;
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
                A2 = s.Substring(sp + 1);
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
            r = int.Parse(s.Substring(1)) - 1;
        }
    }
}
