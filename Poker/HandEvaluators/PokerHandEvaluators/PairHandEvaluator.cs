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
                throw new HandIsNotThisTypeException("Hand is not a Pair and cannot be evaluated");

            Card highCard = hand.cards.OrderByDescending(_ => _).GroupBy(_ => _.CardValue)
                                         .Where(_ => _.Count() == 2).First().Distinct<Card>(new CardValueEqualityComparer()).First();
            List<Card> cards = new List<Card>(new Card[] { highCard });
            cards.AddRange(hand.cards.Where(_ => _.CardValue != highCard.CardValue).OrderByDescending(_ => _).Where((i,j) => i.CardValue != highCard.CardValue && j < 3));

            return new HandDetails(hand, new HandValue(1, cards));
        }

        public bool IsHandThis(Hand hand) => hand.cards.GroupBy(_ => _.CardValue).Where(_ => _.Count() == 2).Any();
    }
}
