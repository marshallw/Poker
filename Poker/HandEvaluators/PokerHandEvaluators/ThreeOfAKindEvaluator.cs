using Poker.Exceptions;
using Poker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker.HandEvaluators
{
    public class ThreeOfAKindEvaluator : BasePokerHandEvaluator
    {
        public override HandDetails GetHandRank(Hand hand)
        {
            if (!IsHandThis(hand))
                throw new HandIsNotThisTypeException("Hand is not a Three of a Kind and cannot be evaluated");

            var highCard = hand.Cards.OrderByDescending(_ => _.CardValue).GroupBy(_ => _.CardValue).Where(_ => _.Count() >= 3).First().First();
            var cards = new List<Card>(new Card[] { highCard });
            cards.AddRange(hand.Cards.Where(_ => _.CardValue != highCard.CardValue).OrderByDescending(_ => _.CardValue).Where((i, j) => i.CardValue != highCard.CardValue && j < 2));

            return new HandDetails(hand, new HandValue(2, cards));
        }

        public override bool IsHandThis(Hand hand) => hand.Cards.GroupBy(_ => _.CardValue).Where(_ => _.Count() >= 3).Any();
    }
}
