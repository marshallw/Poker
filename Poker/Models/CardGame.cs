using System;
using System.Collections.Generic;
using System.Text;
using Poker.Enums;

namespace Poker.Models
{
    public class CardGame
    {
        private List<Hand> _players;
        private Stack<Card> _deck;
        private List<Card> _discard;

        public CardGame(int numPlayers)
        {
            
        }

        private void GenerateDeck()
        {
            List<Card> cards = new List<Card>();

            for(int i= 0; i <= 13; i++)
            {
                cards.Add(new Card(CardSuit.Club, i));
                cards.Add(new Card(CardSuit.Diamond, i));
                cards.Add(new Card(CardSuit.Heart, i));
                cards.Add(new Card(CardSuit.Spade, i));
            }

            //cards.
        }
    }
}
