using System;
using System.Collections.Generic;
using System.Text;
using Poker.Models;
using System.Linq;
using System.Diagnostics.CodeAnalysis;
using Poker.Exceptions;
using Poker.EqualityComparers;

namespace Poker.HandEvaluators
{
    public class PairHandEvaluator : IPokerHandEvaluator
    {
        public HandDetails GetHandValue(Hand hand)
        {
            if (!IsHandThis(hand))
                throw new HandIsNotThisTypeException("Hand is not a Flush and cannot be evaluated");

            List<Card> cards = hand.cards.OrderByDescending(_ => _).GroupBy(_ => _.CardValue)
                                         .Where(_ => _.Count() == 2).SelectMany(_ => _).Distinct<Card>(new CardValueEqualityComparer()).ToList();
            cards.AddRange(hand.cards.OrderByDescending(_ => _).GroupBy(_ => _.CardValue)
                                     .Where(_ => _.Count() == 1).SelectMany(_ => _).Distinct<Card>(new CardValueEqualityComparer()));

            return new HandDetails(hand, new HandValue(1, cards));
        }

        public bool IsHandThis(Hand hand) => hand.cards.GroupBy(_ => _.CardValue).Where(_ => _.Count() == 2).Any();
    }
}
