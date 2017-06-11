using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.Contests.Week36
{
    /// <summary>
    /// 604. Design Compressed String Iterator My SubmissionsBack To Contest
    /// </summary>
    public class StringIterator
    {
        string s;
        int current = 0;
        int remain = 0;
        int next = -1;
        public StringIterator(string compressedString)
        {
            s = compressedString;
            if (!string.IsNullOrEmpty(s))
            {
                current = 0;
                var count = 0;
                var i = current + 1;
                while (i < s.Length)
                {
                    if (s[i] >= '0' && s[i] <= '9')
                    {
                        count = count * 10 + (s[i] - '0');
                    }
                    else
                    {
                        next = i;
                        break;
                    }
                    i++;
                }
                remain = count;
            }
        }

        public char Next()
        {
            if (HasNext())
            {
                if (remain > 0)
                {
                    remain--;

                    return s[current];
                }
                else
                {
                    current = next;
                    var i = current + 1;
                    var count = 0;
                    next = -1;
                    while (i < s.Length)
                    {
                        if (s[i] >= '0' && s[i] <= '9')
                        {
                            count = count * 10 + (s[i] - '0');
                        }
                        else
                        {
                            next = i;
                            break;
                        }
                        i++;
                    }
                    remain = count;
                    remain--;

                    return s[current];
                }
            }
            else
            {
                return ' ';
            }
        }

        public bool HasNext()
        {
            return remain > 0 || (next > 0 && next < s.Length - 1);
        }
    }

    /**
     * Your StringIterator object will be instantiated and called as such:
     * StringIterator obj = new StringIterator(compressedString);
     * char param_1 = obj.Next();
     * bool param_2 = obj.HasNext();
     */
}
