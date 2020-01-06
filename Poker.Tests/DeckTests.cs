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
            for(int i = 2; i <= 14; i++)
            {
                deck.Push(new Card(i, CardSuit.Club));
                deck.Push(new Card(i, CardSuit.Diamond));
                deck.Push(new Card(i, CardSuit.Heart));
                deck.Push(new Card(i, CardSuit.Spade));
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

            deck.Push(new Card(2, CardSuit.Club));
            deck.Push(new Card(10, CardSuit.Heart));

            Card card = deck.Pop();

            Assert.IsTrue(card.CardSuitName == "Heart" && card.CardValue == CardValue.Ten);
        }

        [TestCase]
        public void CanInitializeDeck()
        {
            Deck deck = new Deck();

            deck = Deck.GenerateDeck();

            Assert.AreEqual(deck.Count, 52);
        }
    }
}
