using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Poker.Models;
using Poker.Enums;
using Poker.GameTypes;

namespace Poker.Tests.GameTests
{
    class PokerTests
    {

        [TestCase]
        public void Poker_CHallenge1_TestCase1()
        {
            PokerGame game = new PokerGame();

            var joe = new Hand(new Card(CardSuit.Heart, 3),
                                  new Card(CardSuit.Heart, 6),
                                  new Card(CardSuit.Heart, 8),
                                  new Card(CardSuit.Heart, CardValue.Jack),
                                  new Card(CardSuit.Heart, CardValue.King));

            var jen = new Hand(new Card(CardSuit.Club, 3),
                                  new Card(CardSuit.Diamond, 3),
                                  new Card(CardSuit.Spade, 3),
                                  new Card(CardSuit.Club, 8),
                                  new Card(CardSuit.Diamond, 10));

            var bob = new Hand(new Card(CardSuit.Heart, CardValue.Two),
                                  new Card(CardSuit.Club, CardValue.Five),
                                  new Card(CardSuit.Spade, CardValue.Seven),
                                  new Card(CardSuit.Club, CardValue.Ten),
                                  new Card(CardSuit.Club, CardValue.Ace));

            game.AddHand(joe, jen, bob);

            Assert.AreEqual(game.FindWinningHand().Hand, joe);
        }

        [TestCase]
        public void Poker_CHallenge1_TestCase2()
        {
            PokerGame game = new PokerGame();

            var joe = new Hand(new Card(CardSuit.Heart, 3),
                                  new Card(CardSuit.Diamond, 4),
                                  new Card(CardSuit.Club, 9),
                                  new Card(CardSuit.Diamond, 9),
                                  new Card(CardSuit.Heart, CardValue.Queen));

            var jen = new Hand(new Card(CardSuit.Club, 5),
                                  new Card(CardSuit.Diamond, 7),
                                  new Card(CardSuit.Heart, 9),
                                  new Card(CardSuit.Spade, 9),
                                  new Card(CardSuit.Spade, CardValue.Queen));

            var bob = new Hand(new Card(CardSuit.Heart, CardValue.Two),
                                  new Card(CardSuit.Club, CardValue.Two),
                                  new Card(CardSuit.Spade, CardValue.Five),
                                  new Card(CardSuit.Club, CardValue.Ten),
                                  new Card(CardSuit.Heart, CardValue.Ace));

            game.AddHand(joe, jen, bob);

            Assert.AreEqual(game.FindWinningHand().Hand, jen);
        }
    }
}
