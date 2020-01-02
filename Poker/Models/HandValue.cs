using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Linq;

namespace Poker.Models
{
    public class HandValue: IComparable<HandValue>
    {
        private uint _handRank;
        private int _rankPosition;
        private int _rankPositionStart = 28;
        public uint HandRank => _handRank;

        public HandValue(int handValueType, params Card[] cards)
        {
            _rankPosition = _rankPositionStart;
            _handRank = (uint)handValueType << _rankPosition;
            _rankPosition -= 4;

            foreach (var card in cards)
            {
                AddCardToComparison(card);
            }
            
        }

        public HandValue(int handValueType, IEnumerable<Card> cards) : this(handValueType, cards.ToArray())
        {

        }

        public HandValue()
        {
            _rankPosition = _rankPositionStart - 4;
            _handRank = 0;
        }

        private void AddCardToComparison(Card card)
        {
            if (_rankPosition < 0)
                throw new Exception("Can't hold more than 7 cards to rank.");
            uint cardValue = (uint)card.CardValue;
            cardValue = cardValue << _rankPosition;
            _handRank = _handRank | cardValue;
            _rankPosition -= 4;
        }
        public int CompareTo(HandValue other)
        {
            if (other == null)
                return -1;

            int result = _handRank.CompareTo(other.HandRank);

            return result;
        }

        public override bool Equals(object obj)
        {
            bool result = false;
            if (obj.GetType() == typeof(HandValue))
            {
                result = this.HandRank == ((HandValue)obj).HandRank;
            }

            return result;
        }

        public bool Equals(HandValue toCompare)
        {
            if (object.ReferenceEquals(toCompare, null))
            {
                return false;
            }

            return this.HandRank == toCompare.HandRank;
        }

        public static bool operator !=(HandValue left, HandValue right) => !(left == right);
        public static bool operator ==(HandValue left, HandValue right)
        {
            if (Object.ReferenceEquals(left, null))
            {
                return object.ReferenceEquals(right, null);
            }
                
            return left.Equals(right);
        }
        public static bool operator >(HandValue left, HandValue right) => left.HandRank > right.HandRank;
        public static bool operator <(HandValue left, HandValue right) => left.HandRank < right.HandRank;
    }
}
