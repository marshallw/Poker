using Poker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Poker.Exceptions;

namespace Poker.HandEvaluators.PokerHandEvaluators
{
    public class RoyalFlushEvaluator : BasePokerHandEvaluator
    {
        public override HandDetails GetHandRank(Hand hand)
        {
            if (!IsHandThis(hand))
                throw new HandIsNotThisTypeException("This hand is not a royal flush and cannot be evaluated.");

            return new HandDetails(hand, new HandValue(10, new Card[] { }));
        }

        public override bool IsHandThis(Hand hand)
        {
            return hand.Cards.GroupBy(_ => _.CardSuit)
                             .Where(_ => _.Count() >= 5)
                             .SelectMany(_ => _)
                             .Where(_ => _.CardValue >= Enums.CardValue.Ten)
                             .Count() == 5;
        }
    }
}
