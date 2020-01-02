using Poker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker.HandEvaluators
{
    public class ThreeOfAKindEvaluator : IPokerHandEvaluator
    {
        public HandDetails GetHandValue(Hand hand)
        {
            var card = hand.cards.OrderByDescending(_ => _.CardValue).GroupBy(_ => _.CardValue).Where(_ => _.Count() == 3).First().First();
            return new HandDetails(hand, new HandValue(2, card));
        }

        public bool IsHandThis(Hand hand) => hand.cards.GroupBy(_ => _.CardValue).Where(_ => _.Count() == 3).Any();
    }
}
