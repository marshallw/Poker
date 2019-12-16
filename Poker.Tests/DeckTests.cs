using System;
using System.Collections.Generic;
using NUnit.Framework;
using Poker.Enums;
using Poker.Models;
using System.Text;

namespace Tests
{
    class DeckTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase()]
        public void CreatedDeckIsValid()
        {
            Deck deck = new Deck();
            for(int i = 1; i <= 13; i++)
            {
                deck.Push(new Card(CardSuit.Club, i));
                deck.Push(new Card(CardSuit.Diamond, i));
                deck.Push(new Card(CardSuit.Heart, i));
                deck.Push(new Card(CardSuit.Spade, i));
            }
            deck.Randomize();
            foreach (var card in deck)
            {
                Console.WriteLine(card.ToString());
            }

            Assert.IsTrue(deck.Count == 52);
        }

        [TestCase()]
        public void PoppedCardIsValid()
        {
            Deck deck = new Deck();

            deck.Push(new Card(CardSuit.Club, 1));
            deck.Push(new Card(CardSuit.Heart, 10));

            Card card = deck.Pop();

            Assert.IsTrue(card.CardSuitName == "Heart" && card.CardValue == 10);
        }
    }
}
