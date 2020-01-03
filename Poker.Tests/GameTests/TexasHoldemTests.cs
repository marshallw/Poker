using NUnit.Framework;
using Poker.Enums;
using Poker.GameTypes;
using Poker.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.Tests.GameTests
{
    class TexasHoldemTests
    {
        [TestCase]
        public void Poker_Challenge1_TestCase1()
        {
            TexasHoldem game = new TexasHoldem();

            var joe = new Hand(new Card(10, CardSuit.Club),
                               new Card(10, CardSuit.Diamond));

            var jen = new Hand(new Card(5, CardSuit.Club),
                               new Card(CardValue.Queen, CardSuit.Spade));

            var bob = new Hand(new Card(CardValue.Two, CardSuit.Heart),
                                  new Card(CardValue.Two, CardSuit.Club));

            game.AddHand(joe, jen, bob);

            game.AddCardToCommunityHand(new Card(CardValue.Queen, CardSuit.Diamond),
                                        new Card(CardValue.King, CardSuit.Diamond),
                                        new Card(CardValue.Eight, CardSuit.Diamond),
                                        new Card(CardValue.Nine, CardSuit.Diamond),
                                        new Card(CardValue.Two, CardSuit.Diamond));

            Assert.AreEqual(game.FindWinningHand().Hand, joe);
        }
    }
}
