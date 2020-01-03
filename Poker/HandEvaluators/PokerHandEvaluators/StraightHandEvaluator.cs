using Poker.EqualityComparers;
using Poker.Exceptions;
using Poker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker.HandEvaluators
{
    public class StraightHandEvaluator : BasePokerHandEvaluator
    {
        public override HandDetails GetHandValue(Hand hand)
        {
            if (!IsHandThis(hand))
                throw new HandIsNotThisTypeException("Hand is not a Straight and cannot be evaluated");

            var highCard = hand.Cards.OrderByDescending(_ => _.CardValue).Distinct<Card>(new CardValueEqualityComparer()).First();

            return new HandDetails(hand, new HandValue(4, highCard));
        }

        public override bool IsHandThis(Hand hand)
        {
            var cardsTransformation = hand.Cards.OrderBy(_ => _.CardValue).Select((i, j) => new Card(i.CardValue - j, i.CardSuit));
            return cardsTransformation.Where(_ => _.CardValue == cardsTransformation.First().CardValue).Count() == 5 && cardsTransformation.Distinct<Card>(new CardValueEqualityComparer()).Count() == 1;
        }
    }
}
