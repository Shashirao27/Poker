using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Evaluators;
using ConsoleApp1.Models;

namespace ConsoleApp1
{
    public class HandEvaluator
    {
        private Hand _hand;
        private readonly List<IEvaluator> _evaluators;

        public List<int> HandStrength { get; set; } // Contains numerical weightage of each category
        public HandEvaluator(Hand hand, List<IEvaluator> evaluators) 
        {
            _hand = hand;
            _evaluators = evaluators;
            HandStrength = [];
        }

        public void Evaluate() 
        {

            foreach (var evaluator in _evaluators)
            {
                HandStrength.Add(evaluator.Evaluate(_hand));
            }
        }

        
    }
}
