using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    public class HandComparer : IComparer<HandEvaluator>
    {
        public int Compare(HandEvaluator x, HandEvaluator y)
        {
            if (x == null || y == null)
                throw new ArgumentNullException("Cannot compare null HandEvaluator objects.");

            var length = x.HandStrength.Count;

            for (int i = 0;i < length; i ++)
            {
                int Comparison = x.HandStrength[i].CompareTo(y.HandStrength[i]);
                if (Comparison != 0) return Comparison;
            }
            return 0;
        }
    }
}
