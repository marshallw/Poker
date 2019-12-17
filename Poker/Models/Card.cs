using System;
using System.Collections.Generic;
using System.Text;
using Poker.Enums;

namespace Poker.Models
{
    public class Card: IComparable<Card>
    {
        private CardSuit _cardSuit;
        private int _cardValue;

        public int CardValue
        {
            get => _cardValue;
        }

        public CardSuit CardSuit
        {
            get => _cardSuit;
        }

        public string CardSuitName
        {
            get => Enum.GetName(typeof(CardSuit), _cardSuit);
        }

        public Card(CardSuit newSuit, int newCardValue)
        {
            _cardSuit = newSuit;
            _cardValue = newCardValue;
        }

        public Card(CardSuit newSuit, string newCardValue)
        {
            _cardSuit = newSuit;
            _cardValue = ConvertValue(newCardValue);

        }

        private int ConvertValue(string cardValue)
        {
            int result = 0;
            switch (cardValue.ToLower())
            {
                case "a":
                case "ace":
                    result = 1;
                    break;
                case "j":
                case "jack":
                    result = 11;
                    break;
                case "q":
                case "queen":
                    result = 12;
                    break;
                case "k":
                case "king":
                    result = 13;
                    break;
                default:
                    throw new Exception($"Card value {cardValue} is invalid");
            }
            
            return result;
        }

        public override string ToString()
        {
            return $"{Enum.GetName(typeof(CardSuit), _cardSuit)} {_cardValue}";
        }
        private bool CardValueIsValid() => _cardValue > 0 && _cardValue < 14;

        public bool IsValid() => CardValueIsValid();

        public int CompareTo(Card other)
        {
            if (other == null)
                return 1;
            return _cardValue.CompareTo(other.CardValue);
        }
    }
}
