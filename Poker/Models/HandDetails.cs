using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.Models
{
    public class HandDetails: IComparable<HandDetails>
    {
        private Hand hand;
        private HandValue handValue;

        public Hand Hand => hand;
        public HandValue HandValue => handValue;

        public HandDetails()
        {
            hand = null;
            handValue = new HandValue();
        }
        public HandDetails(Hand hand, HandValue handValue)
        {
            this.hand = hand;
            this.handValue = handValue;
        }
        public static HandDetails Create(Hand hand, HandValue handValue)
        {
            return new HandDetails(hand, handValue);
        }

        public int CompareTo(HandDetails other)
        {
            return handValue.CompareTo(other.handValue);
        }

        public static bool operator >(HandDetails hand1, HandDetails hand2)
        {
            return hand1.handValue > hand2.handValue;
        }

        public static bool operator <(HandDetails hand1, HandDetails hand2) => hand1.handValue < hand2.handValue;
    }
}
