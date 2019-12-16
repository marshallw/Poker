using System;
using System.Collections.Generic;
using System.Text;
using Poker.Models;
using Poker.Enums;

namespace Poker
{
    public class Game
    {
        private List<Hand> _hands;
        private Deck _deck;
        private Deck _discard;

        public Game()
        {
            _deck = new Deck();
            
        }

        public void InitializeDeck()
        {
            _deck = new Deck();
            for (int i = 1; i < 14; i++)
            {
                _deck.Push(new Card(CardSuit.Club, i));
                _deck.Push(new Card(CardSuit.Diamond, i));
                _deck.Push(new Card(CardSuit.Heart, i));
                _deck.Push(new Card(CardSuit.Spade, i));

            }
            _deck.Randomize();
        }

        public void InitializeGame()
        {
            InitializeDeck();
            _discard = new Deck();

            _hands = new List<Hand>();
        }

        public void FindBiggestHand()
        {

        }
    }
}
