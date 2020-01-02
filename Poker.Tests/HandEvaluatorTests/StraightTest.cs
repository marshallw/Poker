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
            Hand hand = new Hand(5);
            hand.AddCard(new Card(CardSuit.Club, 9));
            hand.AddCard(new Card(CardSuit.Diamond, 10));
            hand.AddCard(new Card(CardSuit.Diamond, 11));
            hand.AddCard(new Card(CardSuit.Spade, 12));
            hand.AddCard(new Card(CardSuit.Club, 13));

            IPokerHandEvaluator evaluator = new StraightHandEvaluator();

            Assert.IsTrue(evaluator.IsHandThis(hand));
        }

        [TestCase]
        public void Straight2_IsValid()
        {
            Hand hand = new Hand(5);
            hand.AddCard(new Card(CardSuit.Club, 2));
            hand.AddCard(new Card(CardSuit.Diamond, 3));
            hand.AddCard(new Card(CardSuit.Diamond, 4));
            hand.AddCard(new Card(CardSuit.Spade, 5));
            hand.AddCard(new Card(CardSuit.Club, 6));

            IPokerHandEvaluator evaluator = new StraightHandEvaluator();

            Assert.IsTrue(evaluator.IsHandThis(hand));
        }

        [TestCase]
        public void Straight_IsNotValid()
        {
            Hand hand = new Hand(5);
            hand.AddCard(new Card(CardSuit.Club, 2));
            hand.AddCard(new Card(CardSuit.Diamond, 4));
            hand.AddCard(new Card(CardSuit.Diamond, 5));
            hand.AddCard(new Card(CardSuit.Spade, 7));
            hand.AddCard(new Card(CardSuit.Club, 9));

            IPokerHandEvaluator evaluator = new StraightHandEvaluator();

            Assert.IsFalse(evaluator.IsHandThis(hand));
        }

        [TestCase]
        public void Straight2_IsNotValid()
        {
            Hand hand = new Hand(5);
            hand.AddCard(new Card(CardSuit.Club, 2));
            hand.AddCard(new Card(CardSuit.Diamond, 3));
            hand.AddCard(new Card(CardSuit.Diamond, 4));
            hand.AddCard(new Card(CardSuit.Spade, 5));
            hand.AddCard(new Card(CardSuit.Heart, 4));

            IPokerHandEvaluator evaluator = new StraightHandEvaluator();

            Assert.IsFalse(evaluator.IsHandThis(hand));
        }

        [TestCase]
        public void Straight_CreatesCorrectHandValue_IsValid()
        {
            Hand hand = new Hand(5);
            hand.AddCard(new Card(CardSuit.Club, 7));
            hand.AddCard(new Card(CardSuit.Diamond, 3));
            hand.AddCard(new Card(CardSuit.Diamond, 5));
            hand.AddCard(new Card(CardSuit.Spade, 6));
            hand.AddCard(new Card(CardSuit.Club, 4));

            IPokerHandEvaluator evaluator = new StraightHandEvaluator();

            Assert.AreEqual(evaluator.GetHandValue(hand).HandValue, new HandValue(4, new Card(CardSuit.Spade, 7)));
        }

        [TestCase]
        public void Straight_CreatesCorrectHandValue2_IsValid()
        {
            Hand hand = new Hand(5);
            hand.AddCard(new Card(CardSuit.Club, 2));
            hand.AddCard(new Card(CardSuit.Diamond, 3));
            hand.AddCard(new Card(CardSuit.Diamond, 4));
            hand.AddCard(new Card(CardSuit.Spade, 5));
            hand.AddCard(new Card(CardSuit.Club, 6));

            IPokerHandEvaluator evaluator = new StraightHandEvaluator();

            Assert.AreEqual(evaluator.GetHandValue(hand).HandValue, new HandValue(4, new Card(CardSuit.Spade, 6)));
        }
    }
}
