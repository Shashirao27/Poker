using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Models;

namespace ConsoleApp1.Evaluators
{
    public class TwoPairEvaluator : IEvaluator
    {
        public int Evaluate(Hand hand)
        {
            // Here we evaluate for count > 1 (3 of a kind and 4 of a kind also fall into this)
            var cards = hand.Cards.GroupBy(c => c.Rank)
                .ToDictionary(group => group.Key, group => group.Count());

            var soloCard = cards.FirstOrDefault(k => k.Value == 1).Key;
            var cardPairs = cards.Where(c => c.Value == 2)
                            .Select(c => (int)c.Key)
                            .OrderByDescending(v => v) // Order pairs by highest first
                            .ToList();
            if (cardPairs.Count == 2) 
            { 
                return cardPairs[0] * 100 + cardPairs[1] * 10 + (int)soloCard;
                // example  hand1 - 99 88 7and 99 77 6 will have values 987 and 976 respectively
            }
            return 0;

        }
    }


    //Extra implementation to expand the usage
    public class ThreeOfAKindEvaluator: IEvaluator
    {
        public int Evaluate(Hand hand)
        {
            // Here we evaluate for count > 1 (3 of a kind and 4 of a kind also fall into this)
            var cards = hand.Cards.GroupBy(c => c.Rank).Where(g => g.Count() > 2);
            if (cards.Count() >= 3)
            {
                return cards.Select(c => (int)c.Key).First();
            }
            return 0;

        }
    }

    public class FourOfaKind : IEvaluator
    {
        public int Evaluate(Hand hand)
        {
            // Here we evaluate for count > 1 (3 of a kind and 4 of a kind also fall into this)
            var cards = hand.Cards.GroupBy(c => c.Rank).Where(g => g.Count() > 3);
            if (cards.Count() >= 4)
            {
                return cards.Select(c => (int)c.Key).First();
            }
            return 0;

        }
    }
}
