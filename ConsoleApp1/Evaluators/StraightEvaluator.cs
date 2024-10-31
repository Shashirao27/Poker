using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Models;

namespace ConsoleApp1.Evaluators
{
    public class StraightEvaluator : IEvaluator
    {
        public int Evaluate(Hand hand)
        {
            var cards = hand.Cards;
            var length = cards.Count - 1;
            if (cards.Any(c => c.Rank == Enums.Rank.TWO) && cards.Any(c => c.Rank == Enums.Rank.ACE))
            {
                length--;
            }
            for (int i = 0; i < length; i++)
            {
                if ((int)cards[i].Rank != (int)cards[i + 1].Rank)
                    return 0;
            }
            return (int)cards.Last().Rank;
        }
    }
}
