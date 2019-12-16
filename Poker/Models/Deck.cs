using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Poker.Models
{
    public class Deck: IEnumerable<Card>
    {
        private const int MAX_CARDS = 52;
        private int top = 0;
        private Card[] _cards;

        public int Count => top;

        public Deck()
        {
            _cards = new Card[MAX_CARDS];
        }
        public IEnumerator<Card> GetEnumerator()
        {
            return new DeckEnum<Card>(_cards, top);
        }

        public void Randomize()
        {
            
            Random random = new Random();
        
            for(int i = 0; i < _cards.Length; i++)
            {
                int swap = random.Next(i + 1);
                Card temp = _cards[i];
                _cards[i] = _cards[swap];
                _cards[swap] = temp;
            }
        }

        public void Push(Card card)
        {
            if (top < MAX_CARDS)
            {
                _cards[top++] = card;
            }
            else
            {
                throw new Exception("There ain't more than 52 cares in a deck fool");
            }
        }

        public Card Pop()
        {
            if (top > 0)
            {
                return _cards[--top];
            }
            else
            {
                throw new Exception("Nothing left ta pop!");
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
