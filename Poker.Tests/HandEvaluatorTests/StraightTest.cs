using NUnit.Framework;
using Poker.Enums;
using Poker.HandEvaluators;
using Poker.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.Tests.HandEvaluatorTests
{
    class StraightTest
    {
        [TestCase]
        public void Straight_IsValid()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(10, CardSuit.Club));
            hand.AddCard(new Card(11, CardSuit.Diamond));
            hand.AddCard(new Card(12, CardSuit.Diamond));
            hand.AddCard(new Card(13, CardSuit.Spade));
            hand.AddCard(new Card(14, CardSuit.Club));

            IPokerHandEvaluator evaluator = new StraightHandEvaluator();

            Assert.IsTrue(evaluator.IsHandThis(hand));
        }

        [TestCase]
        public void Straight2_IsValid()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(2, CardSuit.Club));
            hand.AddCard(new Card(3, CardSuit.Diamond));
            hand.AddCard(new Card(4, CardSuit.Diamond));
            hand.AddCard(new Card(5, CardSuit.Spade));
            hand.AddCard(new Card(6, CardSuit.Club));

            IPokerHandEvaluator evaluator = new StraightHandEvaluator();

            Assert.IsTrue(evaluator.IsHandThis(hand));
        }

        [TestCase]
        public void Straight_IsNotValid()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(2, CardSuit.Club));
            hand.AddCard(new Card(4, CardSuit.Diamond));
            hand.AddCard(new Card(5, CardSuit.Diamond));
            hand.AddCard(new Card(7, CardSuit.Spade));
            hand.AddCard(new Card(9, CardSuit.Club));

            IPokerHandEvaluator evaluator = new StraightHandEvaluator();

            Assert.IsFalse(evaluator.IsHandThis(hand));
        }

        [TestCase]
        public void Straight2_IsNotValid()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(2, CardSuit.Club));
            hand.AddCard(new Card(3, CardSuit.Diamond));
            hand.AddCard(new Card(4, CardSuit.Diamond));
            hand.AddCard(new Card(5, CardSuit.Spade));
            hand.AddCard(new Card(4, CardSuit.Heart));

            IPokerHandEvaluator evaluator = new StraightHandEvaluator();

            Assert.IsFalse(evaluator.IsHandThis(hand));
        }

        [TestCase]
        public void Straight_CreatesCorrectHandValue_IsValid()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(7, CardSuit.Club));
            hand.AddCard(new Card(3, CardSuit.Diamond));
            hand.AddCard(new Card(5, CardSuit.Diamond));
            hand.AddCard(new Card(6, CardSuit.Spade));
            hand.AddCard(new Card(4, CardSuit.Club));

            IPokerHandEvaluator evaluator = new StraightHandEvaluator();

            Assert.AreEqual(evaluator.GetHandValue(hand).HandValue, new HandValue(4, new Card(7, CardSuit.Spade)));
        }

        [TestCase]
        public void Straight_CreatesCorrectHandValue2_IsValid()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(2, CardSuit.Club));
            hand.AddCard(new Card(3, CardSuit.Diamond));
            hand.AddCard(new Card(4, CardSuit.Diamond));
            hand.AddCard(new Card(5, CardSuit.Spade));
            hand.AddCard(new Card(6, CardSuit.Club));

            IPokerHandEvaluator evaluator = new StraightHandEvaluator();

            Assert.AreEqual(evaluator.GetHandValue(hand).HandValue, new HandValue(4, new Card(6, CardSuit.Spade)));
        }

        [TestCase]
        public void Straight_AcesLow_IsValid()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(2, CardSuit.Club));
            hand.AddCard(new Card(3, CardSuit.Diamond));
            hand.AddCard(new Card(4, CardSuit.Diamond));
            hand.AddCard(new Card(5, CardSuit.Spade));
            hand.AddCard(new Card(1, CardSuit.Club));

            IPokerHandEvaluator evaluator = new StraightHandEvaluator();

            Assert.IsTrue(evaluator.IsHandThis(hand));
        }

        [TestCase]
        public void Straight_AcesLow()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(2, CardSuit.Club));
            hand.AddCard(new Card(3, CardSuit.Diamond));
            hand.AddCard(new Card(4, CardSuit.Diamond));
            hand.AddCard(new Card(5, CardSuit.Spade));
            hand.AddCard(new Card(1, CardSuit.Club));

            IPokerHandEvaluator evaluator = new StraightHandEvaluator();

            Assert.AreEqual(evaluator.GetHandValue(hand).HandValue, new HandValue(4, new Card(CardValue.Five, CardSuit.Club)));
        }
    }
}
