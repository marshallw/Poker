using NUnit.Framework;
using Poker.Enums;
using Poker.GameTypes;
using Poker.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.Tests.GameTests
{
    public class SevenCardStudTests
    {
        [TestCase]
        public void SevenCardStud_Challenge2_TestCase1()
        {
            SevenCardStud game = new SevenCardStud();

            var joe = new Hand(new Card(3, CardSuit.Heart),
                                  new Card(6, CardSuit.Heart),
                                  new Card(8, CardSuit.Heart),
                                  new Card(CardValue.Jack, CardSuit.Heart),
                                  new Card(CardValue.King, CardSuit.Heart),
                                  new Card(2, CardSuit.Club),
                                  new Card(4, CardSuit.Club));

            var jen = new Hand(new Card(3, CardSuit.Club),
                                  new Card(3, CardSuit.Diamond),
                                  new Card(3, CardSuit.Spade),
                                  new Card(8, CardSuit.Club),
                                  new Card(10, CardSuit.Diamond),
                                  new Card(3, CardSuit.Diamond),
                                  new Card(8, CardSuit.Heart));

            var bob = new Hand(new Card(CardValue.Two, CardSuit.Heart),
                                  new Card(CardValue.Five, CardSuit.Club),
                                  new Card(CardValue.Seven, CardSuit.Spade),
                                  new Card(CardValue.Ace, CardSuit.Club),
                                  new Card(CardValue.Ace, CardSuit.Spade),
                                  new Card(CardValue.Ace, CardSuit.Diamond),
                                  new Card(CardValue.Ace, CardSuit.Heart));

            game.AddHand(joe, jen, bob);

            Assert.AreEqual(game.FindWinningHand().Hand, bob);
        }

    }
}
