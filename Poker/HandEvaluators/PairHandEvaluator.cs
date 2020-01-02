using System;
using System.Collections.Generic;
using System.Text;
using Poker.Models;
using System.Linq;
using System.Diagnostics.CodeAnalysis;

namespace Poker.HandEvaluators
{
    public class PairHandEvaluator : IPokerHandEvaluator
    {
        public HandDetails GetHandValue(Hand hand)
        {
            List<Card> cards = hand.cards.OrderByDescending(_ => _).GroupBy(_ => _.CardValue).Where(_ => _.Count() == 2).SelectMany(_ => _).Distinct<Card>(new CardValueEqualityComparer()).ToList();
            cards.AddRange(hand.cards.OrderByDescending(_ => _).GroupBy(_ => _.CardValue).Where(_ => _.Count() == 1).SelectMany(_ => _).Distinct<Card>(new CardValueEqualityComparer()));
            return new HandDetails(hand, new HandValue(1, cards));
        }

        public bool IsHandThis(Hand hand) => hand.cards.GroupBy(_ => _.CardValue).Where(_ => _.Count() == 2).Any();
    }
}
