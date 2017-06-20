using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.StringProblems
{
    public class TextJustification
    {
        public IList<string> FullJustify(string[] words, int maxWidth)
        {
            var ret = new List<string>();

            var level = new List<string>();
            var len = 0;
            for (var i = 0; i < words.Length; ++i)
            {
                // total word len + num of space + current word
                if (len + level.Count + words[i].Length > maxWidth) // exceed
                {
                    var spaces = maxWidth - len;
                    var sp = level.Count == 1 ? 0 : (spaces) / (level.Count - 1);
                    var addition = spaces - sp * (level.Count - 1);
                    var sb = new StringBuilder();
                    sb.Append(level[0]);
                    for (var j = 1; j < level.Count; j++)
                    {
                        if (addition > 0)
                        {
                            sb.Append(' ', sp + 1);
                            addition--;
                        }
                        else
                        {
                            sb.Append(' ', sp);
                        }
                        sb.Append(level[j]);
                    }
                    if(sb.Length< maxWidth)
                    {
                        sb.Append(new string(' ', maxWidth - sb.Length));
                    }
                    ret.Add(sb.ToString());
                    level = new List<string> { words[i] };
                    len = words[i].Length;
                }
                else
                {
                    len += words[i].Length;
                    level.Add(words[i]);
                }
            }
            var last = string.Join(" ", level);
            if(last.Length < maxWidth)
            {
                ret.Add(last + new string(' ', maxWidth - last.Length));
            }
            else
            {
                ret.Add(last);
            }
            
            return ret;
        }
    }
}
