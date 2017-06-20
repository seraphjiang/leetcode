using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LeetCode.Problems.MathProblems
{
    public class ValidNumber
    {
        /// <summary>
        /// "0" => true
        /// " 0.1 " => true
        /// "abc" => false
        /// "1 a" => false
        /// "2e10" => true
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool IsNumber(string s)
        {
            return IsNumberDFA(s);
        }

        public bool IsNumberRegularExpress(string s)
        {
            if (s.Trim().Length == 0)
            {
                return false;
            }
            var pattern = "[-+]?(\\d+\\.?|\\.\\d+)\\d*(e[-+]?\\d+)?";
            var reg = new Regex(pattern);
            if (reg.IsMatch(s.Trim()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsNumberDFA(String s)
        {
            // build state table
            int[,] transState = {
                {-1,  0,  3,  1,  2, -1}, //0初始无输入或者只有space的状态  
                {-1,  8, -1,  1,  4,  5}, //1输入了数字之后的状态  
                {-1, -1, -1,  4, -1, -1}, //2前面无数字，只输入了Dot的状态  
                {-1, -1, -1,  1,  2, -1}, //3输入了符号状态  
                {-1,  8, -1,  4, -1,  5}, //4前面有数字和有dot的状态  
                {-1, -1,  6,  7, -1, -1}, //5'e' or 'E'输入后的状态  
                {-1, -1, -1,  7, -1, -1}, //6输入e之后输入Sign的状态  
                {-1,  8, -1,  7, -1, -1}, //7输入e后输入数字的状态  
                {-1,  8, -1, -1, -1, -1}  //8前面有有效数输入之后，输入space的状态  
            };

            int state = 0;

            // foreach input, determine state , exit if invalid
            for (int i = 0; i < s.Length; i++)
            {
                if (state == -1)
                    return false;

                int type = (int)GetType(s[i]);

                state = transState[state, type];
            }

            return state == 1 || state == 4 || state == 7 || state == 8;
        }

        public enum InputType
        {
            INVALID,        // 0 Include: Alphas, '(', '&' ans so on  
            SPACE,      // 1  
            SIGN,       // 2 '+','-'  
            DIGIT,      // 3 numbers  
            DOT,            // 4 '.'  
            EXPONENT,       // 5 'e' 'E' 
        }
        public InputType GetType(char s)
        {
            var input = InputType.INVALID;
            if (s == ' ') input = InputType.SPACE;
            else if (s == '+' || s == '-') input = InputType.SIGN;
            else if (char.IsDigit(s)) input = InputType.DIGIT;
            else if (s == '.') input = InputType.DOT;
            else if (s == 'e' || s == 'E') input = InputType.EXPONENT;
            return input;
        }
        /*
        public int InputType(char input)
        {
            int ret = 0;
            switch (input)
            {
                case ' ':
                    ret = 1;
                    break;
                case '+':
                case '-':
                    ret = 2;
                    break;
                case '.':
                    ret = 4;
                    break;
                case 'e':
                case 'E':
                    ret = 5;
                    break;
                default:
                    if (input >= '0' && input <= '9')
                        ret = 3;
                    break;

            }

            return ret;
        }
        */
    }
}
