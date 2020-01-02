using Poker.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.EqualityComparers
{
    public class CardValueEqualityComparer : IEqualityComparer<Card>
    {
        public bool Equals(Card left, Card right)
        {
            return left.CardValue == right.CardValue;
        }

        public int GetHashCode(Card card)
        {
            return card.CardValue.GetHashCode();
        }
    }
}
