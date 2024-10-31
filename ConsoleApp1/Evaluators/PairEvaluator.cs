using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Models;

namespace ConsoleApp1.Evaluators
{
    public class PairEvaluator:IEvaluator
    {
        public int Evaluate(Hand hand)
        {
            var cards = hand.Cards.GroupBy(c => c.Rank).Where(g => g.Count() > 1);
            if (cards.Any())
            {
                return (int)cards.Last().Key;
            }
            return 0;

        }
    }
}
