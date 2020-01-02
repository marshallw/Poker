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
            var highCard = hand.cards.OrderByDescending(_ => _.CardValue).Distinct<Card>(new CardValueEqualityComparer()).First();
            return new HandDetails(hand, new HandValue(4, highCard));
        }

        public bool IsHandThis(Hand hand)
        {
            var cardsTransformation = hand.cards.OrderBy(_ => _.CardValue).Select((i, j) => new Card(i.CardValue - j, i.CardSuit));
            return cardsTransformation.Where(_ => _.CardValue == cardsTransformation.First().CardValue).Count() == 5 && cardsTransformation.Distinct<Card>(new CardValueEqualityComparer()).Count() == 1;
        }
    }

    public class CardValueEqualityComparer : IEqualityComparer<Card>
    {
        public bool Equals(Card x, Card y)
        {
            return x.CardValue == y.CardValue;
        }

        public int GetHashCode(Card obj)
        {
            return obj.CardValue.GetHashCode();
        }
    }
}
