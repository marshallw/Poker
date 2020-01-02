using System;
using System.Collections.Generic;
using System.Text;
using Poker.Enums;

namespace Poker.Models
{
    public class Card: IComparable<Card>
    {
        private CardSuit _cardSuit;
        private CardValue _cardValue;

        public CardValue CardValue => _cardValue;
        public CardSuit CardSuit => _cardSuit;

        public string CardSuitName
        {
            get => Enum.GetName(typeof(CardSuit), _cardSuit);
        }

        public Card(CardValue newCardValue, CardSuit newCardSuit)
        {
            _cardSuit = newCardSuit;
            _cardValue = newCardValue;
        }

        public Card(int newCardValue, CardSuit newCardSuit)
        {
            if (!Enum.IsDefined(typeof(CardValue), newCardValue))
                throw new Exception($"Card value {newCardValue} is invalid.");

            _cardSuit = newCardSuit;
            _cardValue = (CardValue)newCardValue;

        }

        public override string ToString()
        {
            return $"{_cardValue} of {Enum.GetName(typeof(CardSuit), _cardSuit)}s";
        }

        public int CompareTo(Card other)
        {
            if (other == null)
                return 1;
            return _cardValue.CompareTo(other.CardValue);
        }
    }
}
