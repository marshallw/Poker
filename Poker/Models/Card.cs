using System;
using System.Collections.Generic;
using System.Text;
using Poker.Enums;

namespace Poker.Models
{
    public class Card: IComparable<Card>
    {
        private CardSuit cardSuit;
        private CardValue cardValue;

        public CardValue CardValue => cardValue;
        public CardSuit CardSuit => cardSuit;

        public string CardSuitName
        {
            get => Enum.GetName(typeof(CardSuit), cardSuit);
        }

        public Card(CardValue newCardValue, CardSuit newCardSuit)
        {
            cardSuit = newCardSuit;
            cardValue = newCardValue;
        }

        public Card(int newCardValue, CardSuit newCardSuit)
        {
            if (!Enum.IsDefined(typeof(CardValue), newCardValue))
                throw new Exception($"Card value {newCardValue} is invalid.");

            cardSuit = newCardSuit;
            cardValue = (CardValue)newCardValue;

        }

        public override string ToString()
        {
            return $"{Enum.GetName(typeof(CardValue), cardValue)} of {Enum.GetName(typeof(CardSuit), cardSuit)}s";
        }

        public int CompareTo(Card other)
        {
            if (other == null)
                return 1;
            return cardValue.CompareTo(other.CardValue);
        }
    }
}
