using Poker.HandEvaluators;
using Poker.Models;
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
            var evaluatorTypes = from type in this.GetType().Assembly.GetTypes()
                       where typeof(T).IsAssignableFrom(type) && !type.IsInterface
                       select type;

            foreach (Type evaluatorType in evaluatorTypes)
            {
                var evaluator = Activator.CreateInstance(evaluatorType) as IHandEvaluator;
                if (evaluator != null)
                    evaluators.Add(evaluator);
            }
        }
        public HandDetails RankHand(params Hand[] hands)
        {
            var collectiveCards = new Hand(hands.ToList().Select(_ => _.cards).SelectMany(_ => _).ToArray());
            return  evaluators.Where(_ => _.IsHandThis(collectiveCards)).Select(_ => _.GetHandValue(collectiveCards)).OrderByDescending(_ => _).FirstOrDefault();
        }
    }
}
