using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.Models
{
    public class HandDetails: IComparable<HandDetails>
    {
        public Hand Hand { get; }
        public HandValue HandValue { get; }

        public HandDetails()
        {
            Hand = null;
            HandValue = new HandValue();
        }
        public HandDetails(Hand hand, HandValue handValue)
        {
            Hand = hand;
            HandValue = handValue;
        }
        public static HandDetails Create(Hand hand, HandValue handValue)
        {
            return new HandDetails(hand, handValue);
        }

        public int CompareTo(HandDetails other)
        {
            return HandValue.CompareTo(other.HandValue);
        }

        public static bool operator >(HandDetails hand1, HandDetails hand2)
        {
            return hand1.HandValue > hand2.HandValue;
        }

        public static bool operator <(HandDetails hand1, HandDetails hand2) => hand1.HandValue < hand2.HandValue;
    }
}
