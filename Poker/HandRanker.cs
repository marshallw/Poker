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
            evaluators = new List<IHandEvaluator>();
            LoadEvaluators();
        }

        private void LoadEvaluators()
        {
            var test = from type in this.GetType().Assembly.GetTypes()
                       where typeof(T).IsAssignableFrom(type) && !type.IsInterface
                       select type;

            foreach (Type pluginType in test)
            {
                var evaluator = Activator.CreateInstance(pluginType) as IPokerHandEvaluator;
                if (evaluator != null)
                    evaluators.Add(evaluator);
            }
        }
        public HandDetails RankHand(Hand hand)
        {
            HandDetails result;
            result = evaluators.Where(_ => _.IsHandThis(hand)).Select(_ => _.GetHandValue(hand)).OrderByDescending(_ => _).FirstOrDefault();

            return result;
        }
    }
}
