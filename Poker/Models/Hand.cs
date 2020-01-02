using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Poker.Models
{
    public class Hand
    {
        private int _maxHandSize;
        public int MaxHandSize
        {
            get => _maxHandSize;
        }
        public List<Card> cards;

        public Hand(params Card[] newCards)
        {
            cards = new List<Card>();
            cards.AddRange(newCards);
        }

        public Hand(int maxHandSize)
        {
            _maxHandSize = maxHandSize;
            cards = new List<Card>();
        }
        public Hand()
        {
            cards = new List<Card>();
            _maxHandSize = 5;
        }

        public bool AddCard(Card card)
        {
            bool result = false;
            if (cards.Count < _maxHandSize)
            {
                cards.Add(card);
                result = true;
            }
            return result;
        }

        public bool RemoveCard(Card card)
        {
            return cards.Remove(card);
        }

        public bool Equals(Hand hand)
        {
            if (Object.ReferenceEquals(hand, null))
                return false;

            bool result = true;
            foreach (var card in cards)
            {
                if (!hand.cards.Any(_ => _ == card))
                {
                    result = false;
                    break;
                }
            }

            if (result)
                result = hand.Equals(this);

            return result;
        }

        public override bool Equals(object obj)
        {
            bool result = false;

            if (obj.GetType() == typeof(Hand))
                result = this == (Hand)obj;

            return result;
        }

        public static bool operator ==(Hand left, Hand right)
        {
            if (Object.ReferenceEquals(left, null))
            {
                return Object.ReferenceEquals(right, null);
            }

            return left.Equals(right);
        }

        public static bool operator !=(Hand left, Hand right) => !(left == right);
    }
}
