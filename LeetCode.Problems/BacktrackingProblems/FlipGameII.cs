using Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.StringProblems
{
    [Problem(Company = "Google", Level = Level.Median)]
    public class FlipGameII
    {
        public bool CanWin(string s)
        {
            if (string.IsNullOrEmpty(s)) return false;
            if (s.Length < 2 || (s.Length == 2 && (s[0] == '-' || s[1] == '-'))) return false;
            return CanWin(s.ToCharArray());
        }

        public bool CanWin(char[] arr)
        {
            //if (player % 2 != 0)
            //{
            //    return !CanWin(arr, player); // bad stack overflow
            //}

            for (var i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] == '+' && arr[i + 1] == '+')
                {
                    arr[i] = '-'; arr[i + 1] = '-';
                    var canWin = CanWin(arr);
                    arr[i] = '+'; arr[i + 1] = '+';
                    if (!canWin) return true;
                    //if (player % 2 == 0 && !canWin) return true;
                    //else if (player % 2 != 0 && canWin) return true;
                    
                }
            }
            return false;
        }
    }
}
