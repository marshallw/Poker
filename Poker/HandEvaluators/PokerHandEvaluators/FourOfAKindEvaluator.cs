using Poker.Exceptions;
using Poker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker.HandEvaluators
{
    public class FourOfAKindEvaluator : BasePokerHandEvaluator
    {
        public override HandDetails GetHandRank(Hand hand)
        {
            if (!IsHandThis(hand))
                throw new HandIsNotThisTypeException("Hand is not a Four of a Kind and cannot be evaluated");

            var highCard = hand.Cards.OrderByDescending(_ => _.CardValue)
                                     .GroupBy(_ => _.CardValue)
                                     .Where(_ => _.Count() == 4)
                                     .First().First();

            var cards = new List<Card>(new Card[]{ highCard });
            cards.Add(hand.Cards.Where(_ => _.CardValue != highCard.CardValue)
                                .OrderByDescending(_ => _.CardValue)
                                .First());

            return new HandDetails(hand, new HandValue(7, cards));
        }

        public override bool IsHandThis(Hand hand)
        {
            return hand.Cards.GroupBy(_ => _.CardValue)
                             .Where(_ => _.Count() == 4)
                             .Any();
        }
    }
}
