using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.StringProblems
{
    public class BasicCalculator
    {
        public int Calculate(string s)
        {
            var res = 0;
            var stack = new Stack<int>();
            var sign = 1;

            for (var i = 0; i < s.Length; ++i)
            {
                if (char.IsDigit(s[i]))
                {
                    var num = (int)(s[i] - '0');

                    while (i + 1 < s.Length && char.IsDigit(s[i + 1]))
                    {
                        num = num * 10 + (int)(s[i + 1] - '0');
                        i++;
                    }
                    res += sign * num;
                }
                else if (s[i] == '+')
                {
                    sign = 1;
                }
                else if (s[i] == '-')
                {
                    sign = -1;
                }
                else if (s[i] == '(')
                {
                    stack.Push(sign);
                    stack.Push(res);
                    res = 0;
                    sign = 1;
                }
                else if (s[i] == ')')
                {
                    res = stack.Pop() + stack.Pop() * res;
                }
            }

            return res;
        }

        public int Calculate2(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;
            var i = 0;

            var ret = new Stack<string>();
            //var ops = new Stack<string>();
            while (i < s.Length)
            {
                var token = GetNext(s, ref i);
                if (string.IsNullOrEmpty(token))
                {
                    continue;
                }
                if (token == "+" || token == "-")
                {
                    ret.Push(token);
                }
                else if (token == "(")
                {
                    ret.Push(token);
                }
                else if (token == ")")
                {
                    //calc
                    var num1 = ret.Pop();

                    if (ret.Count > 0)
                    {
                        ret.Pop();//remove (

                        if (ret.Count == 0)
                        {
                            ret.Push(num1);
                        }
                        else
                        {
                            var op = ret.Pop();
                            var num2 = ret.Pop();

                            if (op == "+")
                            {
                                ret.Push((int.Parse(num2) + int.Parse(num1)).ToString());
                            }
                            else
                            {
                                ret.Push((int.Parse(num2) - int.Parse(num1)).ToString());
                            }
                        }
                    }
                    else
                    {
                        return int.Parse(num1);
                    }
                }
                else
                { // num
                    var num1 = token;
                    if (ret.Count > 0)
                    {
                        if (ret.Peek() == "+" || ret.Peek() == "-")
                        {
                            var pre = ret.Pop();

                            var num2 = ret.Pop();
                            if (pre == "+")
                            {
                                ret.Push((int.Parse(num2) + int.Parse(num1)).ToString());
                            }
                            else
                            {
                                ret.Push((int.Parse(num2) - int.Parse(num1)).ToString());
                            }
                        }
                        else
                        {
                            ret.Push(token);
                        }
                    }
                    else
                    {
                        ret.Push(token);
                    }
                }

            }

            return int.Parse(ret.Peek());
        }

        string GetNext(string s, ref int i)
        {

            var start = i;
            var sb = new StringBuilder();
            while (i < s.Length)
            {
                if ("+-()".Contains(s[i]))
                {
                    if (sb.Length == 0)
                    {
                        var ret = s[i] + "";
                        i++;
                        return ret;
                    }
                    else
                    {
                        return sb.ToString();
                    }
                }
                else if (s[i] != ' ')
                {
                    sb.Append(s[i]);
                }
                i++;
            }
            return sb.ToString();
        }
    }
}
