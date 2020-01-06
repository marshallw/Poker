using NUnit.Framework;
using Poker.Enums;
using Poker.HandEvaluators;
using Poker.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.Tests
{
    class HandForecasterTests
    {
        [TestCase]
        public void HandForecaster_RoyalFlush()
        {
            HandForecaster<IPokerHandEvaluator> handForecaster = new HandForecaster<IPokerHandEvaluator>();
            Hand hand = new Hand();

            hand.AddCard(new Card(10, CardSuit.Diamond));
            hand.AddCard(new Card(11, CardSuit.Diamond));
            hand.AddCard(new Card(12, CardSuit.Diamond));
            hand.AddCard(new Card(13, CardSuit.Diamond));

            hand.AddCard(new Card(14, CardSuit.Diamond));
            Assert.AreEqual(handForecaster.FindStrongestHand(hand).Hand, hand);
        }

        [TestCase]
        public void HandForecaster_FourOfAKind()
        {
            HandForecaster<IPokerHandEvaluator> handForecaster = new HandForecaster<IPokerHandEvaluator>();
            Hand hand = new Hand();

            hand.AddCard(new Card(10, CardSuit.Diamond));
            hand.AddCard(new Card(10, CardSuit.Club));
            hand.AddCard(new Card(10, CardSuit.Spade));
            hand.AddCard(new Card(14, CardSuit.Heart));

            hand.AddCard(new Card(10, CardSuit.Heart));
            Assert.AreEqual(handForecaster.FindStrongestHand(hand).Hand, hand);
        }
    }
}
