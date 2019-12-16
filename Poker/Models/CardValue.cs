using System;
using System.Collections.Generic;
using System.Text;
using Poker.Enums;

namespace Poker.Models
{
    public class CardValue
    {
        private int cardValue;
        public int Value {
            get { return this.cardValue; }
            set { cardValue = value; } }

        public CardValue(int newCardValue)
        {
            this.cardValue = newCardValue;
        }
        public bool IsValid()
        {
            return cardValue < 14 && cardValue > 0;
        }
    }
}
