using Poker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker.HandEvaluators
{
    public class FlushHandEvaluator : IPokerHandEvaluator
    {
        public HandDetails GetHandValue(Hand hand)
        {
            var cards = hand.cards.OrderByDescending(_ => _.CardValue).Where((i,j) => j <= 7).ToList();
            return new HandDetails(hand, new HandValue(5, cards));
        }

        public bool IsHandThis(Hand hand)
        {
            return hand.cards.GroupBy(_ => _.CardSuit).Where(_ => _.Count() >= 5).Any();
        }
    }
}
