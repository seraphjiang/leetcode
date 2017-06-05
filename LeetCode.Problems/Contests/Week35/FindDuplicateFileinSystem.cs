using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.Contests.Week35
{
    public class FindDuplicateFileinSystem
    {
        public IList<IList<string>> FindDuplicate(string[] paths)
        {
            var dict = new Dictionary<string, IList<string>>();

            foreach (var dfs in paths)
            {
                var df = dfs.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (df.Length <= 1) continue;

                var dir = df[0];
                for (var i = 1; i < df.Length; ++i)
                {
                    var f = df[i];
                    var index = f.IndexOf('('); //e.g.  "a(1)"; index = 1;
                    var filename = f.Substring(0, index);
                    var content = f.Substring(index + 1, f.Length - 1 - index - 1);
                    if (!dict.ContainsKey(content)) dict[content] = new List<string>();
                    var fullname = dir + "/" + filename;
                    dict[content].Add(fullname);
                }
            }

            IList<IList<string>> res = new List<IList<string>>();
            foreach (var kv in dict)
            {
                if (kv.Value.Count > 1)
                {
                    res.Add(kv.Value);
                }
            }

            return res;
        }
    }
}
