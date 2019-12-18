using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Poker.Models
{
    public class HandValue: IComparable<HandValue>
    {
        private byte _handRank;
        public byte HandRank => _handRank;
        public HandValue(string handTypeValue, string highCardValue)
        {
            _handRank = (byte)(Byte.Parse(handTypeValue, NumberStyles.HexNumber) << 4);
            _handRank = (byte)(_handRank | Byte.Parse(highCardValue, NumberStyles.HexNumber));
        }

        public int CompareTo(HandValue other)
        {
            if (other == null)
                return 1;

            int result = _handRank.CompareTo(other.HandRank);
            if (result == 0)
            {
                result = _handRank.CompareTo(other.HandRank);
            }

            return result;
        }
    }
}
