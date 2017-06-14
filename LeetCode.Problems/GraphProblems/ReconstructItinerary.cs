using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.GraphProblems
{
    public class ReconstructItinerary
    {
        public IList<string> FindItinerary(string[,] tickets)
        {
            var path = new List<string>();
            var dict = new Dictionary<string, List<string>>();
            for (var i = 0; i < tickets.GetLength(0); i++)
            {
                if (!dict.ContainsKey(tickets[i, 0])) dict[tickets[i, 0]] = new List<string>();
                dict[tickets[i, 0]].Add(tickets[i, 1]);
            }

            foreach(var val in dict.Values)
            {
                val.Sort(); 
            }
            Dfs("JFK", dict, path);
            return path;
        }

        public void Dfs(string from, Dictionary<string, List<string>> tickets, List<string> path)
        {
            if (tickets.ContainsKey(from))
            {
                var arrivals = new List<string>(tickets[from]);
                
                while(tickets[from].Count>0)
                {
                    var p = tickets[from][0];
                    tickets[from].RemoveAt(0);
                    Dfs(p, tickets, path);
                }
            }

            path.Insert(0, from);
        }
    }
}