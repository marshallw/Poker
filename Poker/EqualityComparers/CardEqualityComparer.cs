using Poker.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Poker.EqualityComparers
{
    public class CardEqualityComparer : IEqualityComparer<Card>
    {
        public bool Equals([AllowNull] Card left, [AllowNull] Card right)
        {
            return left == right;
        }

        public int GetHashCode([DisallowNull] Card card)
        {
            return card.GetHashCode();
        }
    }
}
