using System;
using System.Collections.Generic;

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

        public Hand(Card card)
        {
            cards = new List<Card>();
            cards.Add(card);
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
    }
}
