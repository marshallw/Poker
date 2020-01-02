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
                cards.Add(new Card(i, CardSuit.Club));
                cards.Add(new Card(i, CardSuit.Diamond));
                cards.Add(new Card(i, CardSuit.Heart));
                cards.Add(new Card(i, CardSuit.Spade));
            }

            //cards.
        }
    }
}
