
using ConsoleApp1.Evaluators;
using ConsoleApp1.Models;

namespace ConsoleApp1
{
    public class EvaluatorBuilder
    {
        private readonly Hand _hand;
        private readonly List<EvaluatorCreator> _evaluatorCreators;
        

        public EvaluatorBuilder(Hand hand)
        {
            _hand = hand;
            _evaluatorCreators = new List<EvaluatorCreator>
            {
                new FlushEvaluatorCreator(),
                new StraightEvaluatorCreator(),
                // Can add four of a kind, 3 of a kind, full house etc in the order to extend this implementation
                new TwoPairEvaluatorCreator(),
                new PairEvaluatorCreator()
            }; 
        }

        public HandEvaluator BuildHandEvaluator()
        {
            // Instantiate evaluators using the creators
            var evaluators = _evaluatorCreators.Select(creator => creator.CreateEvaluator()).ToList();

            var handEvaluator = new HandEvaluator(_hand, evaluators);
            handEvaluator.Evaluate();
            return handEvaluator;
        }
    }

    internal class FlushEvaluatorCreator : EvaluatorCreator
    {
        public override IEvaluator CreateEvaluator()
        {
            return new FlushEvaluator();
        }
    }

    internal abstract class EvaluatorCreator
    {
        public abstract IEvaluator CreateEvaluator();
    }
    internal class StraightEvaluatorCreator : EvaluatorCreator
    {
        public override IEvaluator CreateEvaluator()
        {
            return new StraightEvaluator();
        }
    }
    internal class TwoPairEvaluatorCreator : EvaluatorCreator
    {
        public override IEvaluator CreateEvaluator()
        {
            return new TwoPairEvaluator();
        }
    }
    internal class PairEvaluatorCreator : EvaluatorCreator
    {
        public override IEvaluator CreateEvaluator()
        {
            return new PairEvaluator();
        }
    }
}
