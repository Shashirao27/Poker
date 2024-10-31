using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Models;

namespace ConsoleApp1.Evaluators
{
    public class FlushEvaluator : IEvaluator
    {
        public int Evaluate(Hand hand)
        {
            var cards = hand.Cards;
            if (cards.GroupBy(c => c.Suit).Any(g => g.Count() == 5))
            {
                return (int)cards.Last().Rank;
            }
            return 0;
        }
    }
}
