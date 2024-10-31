using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Models;

namespace ConsoleApp1
{
    public class ResultService
    {
        private Hand _hand1;
        private Hand _hand2;
        private HandComparer _handComparer;

        //private IEvaluator _flushEvaluator;
        //private IEvaluator _flushEvaluator;
        public ResultService(Hand hand1, Hand hand2)
        {
            _hand1 = hand1;
            _hand2 = hand2;
            
            _handComparer = new HandComparer();
        }

        public Hand Evaluate()
        {
            
            var hand1eval = new EvaluatorBuilder(_hand1);
            var hand2eval = new EvaluatorBuilder(_hand2);

            var result = _handComparer.Compare(hand1eval.BuildHandEvaluator(), hand2eval.BuildHandEvaluator());
            if (result == 0)
            {
                // Get logic to get the next highest card
                var cards1 = GetCards(_hand1);
                var cards2 = GetCards(_hand2);
                result = HighCardStrength(cards1, cards2);
            }
            if (result == 1) { return _hand1; }
            else if (result == -1)
            {
                return _hand2;
            }
            else { return null; }
        }

        private List<int> GetCards(Hand hand)
        {
            return hand.Cards.OrderByDescending(c => (int)c.Rank).Select(c => (int)c.Rank).ToList();
        }
        private int HighCardStrength(List<int> list1, List<int> list2)
        {
            if (list1 == null && list2 == null) return 0;
            if (list1 == null) return -1;
            if (list2 == null) return 1;

            for (int i = 0; i < list1.Count; i++)
            {
                int comparison = list1[i].CompareTo(list2[i]);
                if (comparison != 0) return comparison;
            }

            return 0;
        }

    }
}
