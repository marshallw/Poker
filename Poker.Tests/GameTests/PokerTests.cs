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

            var joe = new Hand(new Card(3, CardSuit.Heart),
                                  new Card(6, CardSuit.Heart),
                                  new Card(8, CardSuit.Heart),
                                  new Card(CardValue.Jack, CardSuit.Heart),
                                  new Card(CardValue.King, CardSuit.Heart));

            var jen = new Hand(new Card(3, CardSuit.Club),
                                  new Card(3, CardSuit.Diamond),
                                  new Card(3, CardSuit.Spade),
                                  new Card(8, CardSuit.Club),
                                  new Card(10, CardSuit.Diamond));

            var bob = new Hand(new Card(CardValue.Two, CardSuit.Heart),
                                  new Card(CardValue.Five, CardSuit.Club),
                                  new Card(CardValue.Seven, CardSuit.Spade),
                                  new Card(CardValue.Ten, CardSuit.Club),
                                  new Card(CardValue.Ace, CardSuit.Club));

            game.AddHand(joe, jen, bob);

            Assert.AreEqual(game.FindWinningHand().Hand, joe);
        }

        [TestCase]
        public void Poker_CHallenge1_TestCase2()
        {
            PokerGame game = new PokerGame();

            var joe = new Hand(new Card(3, CardSuit.Heart),
                                  new Card(4, CardSuit.Diamond),
                                  new Card(9, CardSuit.Club),
                                  new Card(9, CardSuit.Diamond),
                                  new Card(CardValue.Queen, CardSuit.Heart));

            var jen = new Hand(new Card(5, CardSuit.Club),
                                  new Card(7, CardSuit.Diamond),
                                  new Card(9, CardSuit.Heart),
                                  new Card(9, CardSuit.Spade),
                                  new Card(CardValue.Queen, CardSuit.Spade));

            var bob = new Hand(new Card(CardValue.Two, CardSuit.Heart),
                                  new Card(CardValue.Two, CardSuit.Club),
                                  new Card(CardValue.Five, CardSuit.Spade),
                                  new Card(CardValue.Ten, CardSuit.Club),
                                  new Card(CardValue.Ace, CardSuit.Heart));

            game.AddHand(joe, jen, bob);

            Assert.AreEqual(game.FindWinningHand().Hand, jen);
        }
    }
}
