using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.Contests.Week40
{
    public class ShoppingOffersProblem
    {
        public int ShoppingOffers(IList<int> price, IList<IList<int>> special, IList<int> needs)
        {
            var result = int.MaxValue;

            for (var i = 0; i < special.Count; i++)
            {
                var offer = special[i];
                var valid = true;
                for (var j = 0; j < needs.Count; j++)
                {
                    var remain = needs[j] - offer[j];
                    needs[j] = remain;
                    if (valid && remain < 0)
                    {
                        valid = false;
                    }
                }

                if (valid) result = Math.Min(result, ShoppingOffers(price, special, needs) + offer[needs.Count]);

                for (var j = 0; j < needs.Count; j++)
                {
                    needs[j] += offer[j];
                }

            }
            var nonOfferPrice = 0;
            for (var i = 0; i < needs.Count; i++)
            {
                nonOfferPrice += needs[i] * price[i];
            }
            return Math.Min(result, nonOfferPrice);
        }
    }
}
