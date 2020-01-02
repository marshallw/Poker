using Poker.EqualityComparers;
using Poker.Exceptions;
using Poker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker.HandEvaluators
{
    public class StraightHandEvaluator : IPokerHandEvaluator
    {
        public HandDetails GetHandValue(Hand hand)
        {
            if (!IsHandThis(hand))
                throw new HandIsNotThisTypeException("Hand is not a Straight and cannot be evaluated");

            var highCard = hand.cards.OrderByDescending(_ => _.CardValue).Distinct<Card>(new CardValueEqualityComparer()).First();

            return new HandDetails(hand, new HandValue(4, highCard));
        }

        public bool IsHandThis(Hand hand)
        {
            var cardsTransformation = hand.cards.OrderBy(_ => _.CardValue).Select((i, j) => new Card(i.CardValue - j, i.CardSuit));
            return cardsTransformation.Where(_ => _.CardValue == cardsTransformation.First().CardValue).Count() == 5 && cardsTransformation.Distinct<Card>(new CardValueEqualityComparer()).Count() == 1;
        }
    }
}
