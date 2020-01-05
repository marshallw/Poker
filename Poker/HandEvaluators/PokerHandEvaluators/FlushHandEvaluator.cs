using Poker.Exceptions;
using Poker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker.HandEvaluators
{
    public class FlushHandEvaluator : BasePokerHandEvaluator
    {
        public override HandDetails GetHandRank(Hand hand)
        {
            if (!IsHandThis(hand))
                throw new HandIsNotThisTypeException("Hand is not a Flush and cannot be evaluated");

            var cards = hand.Cards.GroupBy(_ => _.CardSuit).Where(_ => _.Count() >= 5).SelectMany(_ => _)
                                  .OrderByDescending(_ => _.CardValue).Where((i, j) => j <= 4).ToList();

            return new HandDetails(hand, new HandValue(5, cards));
        }

        public override bool IsHandThis(Hand hand)
        {
            return hand.Cards.GroupBy(_ => _.CardSuit).Where(_ => _.Count() >= 5).Any();
        }
    }
}
