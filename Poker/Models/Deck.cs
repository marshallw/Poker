﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Poker.Enums;
using System.Linq;

namespace Poker.Models
{
    public class Deck: IEnumerable<Card>
    {
        private const int MAX_CARDS = 52;
        private int top = 0;
        private Card[] cards;

        public int Count => top;

        public Deck()
        {
            cards = new Card[MAX_CARDS];
        }
        public IEnumerator<Card> GetEnumerator()
        {
            return new DeckEnum<Card>(cards, top);
        }

        public void Randomize()
        {
            
            Random random = new Random();
        
            for(int i = 0; i < cards.Length; i++)
            {
                int swap = random.Next(i + 1);
                Card temp = cards[i];
                cards[i] = cards[swap];
                cards[swap] = temp;
            }
        }

        public static Deck GenerateDeck()
        {
            Deck deck = new Deck();
            var suits = Enum.GetValues(typeof(CardSuit)).Cast<CardSuit>();
            var cardValues = Enum.GetValues(typeof(CardValue)).Cast<CardValue>().ToList();
            cardValues.Remove(CardValue.AceLow);
            foreach (var suit in suits)
            {
                foreach (var cardValue in cardValues)
                {
                    deck.Push(new Card(cardValue, suit));
                }
            }

            return deck;
        }

        public void Push(Card card)
        {
            if (top < MAX_CARDS)
            {
                cards[top++] = card;
            }
            else
            {
                throw new Exception("This is a 52 card deck, not a 53 card deck");
            }
        }

        public Card Pop()
        {
            if (top > 0)
            {
                return cards[--top];
            }
            else
            {
                throw new Exception("Nothing left to pop!");
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
    }

    public class DeckEnum<Card> : IEnumerator<Card>
    {
        private Card[] _cards;
        private int  _position = -1;
        int _top;

        public DeckEnum(Card[] cards, int top)
        {
            _cards = cards;
            _top = top;
        }
        public Card Current
        {
            get
            {
                try
                {
                    return _cards[_position];
                }
                catch
                {
                    throw new Exception("position of cards out of bounds");
                }
            }
        }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            _position++;
            return _position < _top;
        }

        public void Reset()
        {
            _position = -1;
        }
    }
}
