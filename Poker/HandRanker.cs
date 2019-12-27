using Poker.HandEvaluators;
using Poker.Models;
using Poker.PokerHands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker
{
    public class HandRanker<T> where T: IHandEvaluator
    {
        private List<IHandEvaluator> evaluators;
        public HandRanker()
        {

        }

        private void LoadEvaluators()
        {
            var test = from type in this.GetType().Assembly.GetTypes()
                       where typeof(T).IsAssignableFrom(type) && !type.IsInterface
                       select type;

            foreach (Type pluginType in test)
            {
                var evaluator = Activator.CreateInstance(pluginType) as IHandEvaluator;
                if (evaluator != null)
                    evaluators.Add(evaluator);
            }
        }
        public IHand RankHand(Hand hand)
        {
            HandValue result;
            _ = evaluators.Where(_ => _.IsHandThis(hand)).Select(_ => _.GetHandValue(hand)).FirstOrDefault();
            foreach (var evaluator in evaluators)
            {
                if (evaluator.IsHandThis(hand))
                {
                    result = evaluator.GetHandValue(hand);
                }
            }

            return null;
        }
    }
}
