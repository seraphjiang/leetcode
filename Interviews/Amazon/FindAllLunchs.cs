using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interviews.Amazon
{
    public class FindAllLunchs
    {
        public static string[,] matchLunches(string[,] lunchMenuPairs,
                                                string[,] teamCuisinePreference)
        {
            // WRITE YOUR CODE HERE
            var list = new List<string[]>();
            var m = lunchMenuPairs.GetLength(0);
            var dict = new Dictionary<string, List<string>>();
            for (var i = 0; i < m; ++i)
            {
                if (!dict.ContainsKey(lunchMenuPairs[i, 1])) dict[lunchMenuPairs[i, 1]] = new List<string>();

                dict[lunchMenuPairs[i, 1]].Add(lunchMenuPairs[i, 0]);
            }
            var n = teamCuisinePreference.GetLength(0);
            for (var i = 0; i < n; ++i)
            {
                var user = teamCuisinePreference[i, 0];
                var cuisine = teamCuisinePreference[i, 1];
                if (cuisine == "*")
                {
                    for (var j = 0; j < m; ++j)
                    {
                        list.Add(new string[] { user, lunchMenuPairs[j, 0] });
                    }
                }
                else
                {
                    if (dict.ContainsKey(cuisine))
                    {
                        var menus = dict[cuisine];
                        foreach (var menu in menus)
                        {
                            list.Add(new string[] { user, menu });
                        }
                    }
                }
            }

            var ret = new string[list.Count, 2];
            for (var i = 0; i < list.Count; ++i)
            {
                ret[i, 0] = list[i][0];
                ret[i, 1] = list[i][1];
            }

            return ret;
        }
    }
}
