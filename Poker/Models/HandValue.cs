using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.Models
{
    public class HandValue: IComparable<HandValue>
    {
        private string _handTypeValue;
        private string _highCardValue;

        public string HandTypeValue => _handTypeValue;
        public string HighCardValue => _highCardValue;
        
        public HandValue(string handTypeValue, string highCardValue)
        {
            _handTypeValue = handTypeValue;
            _highCardValue = highCardValue;
        }

        public int CompareTo(HandValue other)
        {
            if (other == null)
                return 1;

            int result = _handTypeValue.CompareTo(other.HandTypeValue);
            if (result == 0)
            {
                result = _highCardValue.CompareTo(other.HighCardValue);
            }

            return result;
        }
    }
}
