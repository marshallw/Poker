using NUnit.Framework;
using Poker.Enums;
using Poker.HandEvaluators;
using Poker.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.Tests.HandEvaluatorTests
{
    class FourOfAKindTests
    {
        [TestCase]
        public void FourOfAKind_IsValid()
        {
            Hand hand = new Hand(5);
            hand.AddCard(new Card(CardSuit.Club, 2));
            hand.AddCard(new Card(CardSuit.Diamond, 3));
            hand.AddCard(new Card(CardSuit.Heart, 3));
            hand.AddCard(new Card(CardSuit.Spade, 3));
            hand.AddCard(new Card(CardSuit.Club, 3));

            FourOfAKindEvaluator evaluator = new FourOfAKindEvaluator();

            Assert.IsTrue(evaluator.IsHandThis(hand));
        }

        [TestCase]
        public void FourOfAKind2_IsValid()
        {
            Hand hand = new Hand(5);
            hand.AddCard(new Card(CardSuit.Club, 9));
            hand.AddCard(new Card(CardSuit.Diamond, 3));
            hand.AddCard(new Card(CardSuit.Heart, 3));
            hand.AddCard(new Card(CardSuit.Spade, 3));
            hand.AddCard(new Card(CardSuit.Club, 3));

            FourOfAKindEvaluator evaluator = new FourOfAKindEvaluator();

            Assert.IsTrue(evaluator.IsHandThis(hand));
        }

        [TestCase]
        public void FourOfAKind_IsNotValid()
        {
            Hand hand = new Hand(5);
            hand.AddCard(new Card(CardSuit.Club, 4));
            hand.AddCard(new Card(CardSuit.Diamond, 6));
            hand.AddCard(new Card(CardSuit.Diamond, 4));
            hand.AddCard(new Card(CardSuit.Spade, 3));
            hand.AddCard(new Card(CardSuit.Club, 3));

            FourOfAKindEvaluator evaluator = new FourOfAKindEvaluator();

            Assert.IsFalse(evaluator.IsHandThis(hand));
        }

        [TestCase]
        public void FourOfAKind2_IsNotValid()
        {
            Hand hand = new Hand(5);
            hand.AddCard(new Card(CardSuit.Club, 4));
            hand.AddCard(new Card(CardSuit.Diamond, 6));
            hand.AddCard(new Card(CardSuit.Diamond, 3));
            hand.AddCard(new Card(CardSuit.Spade, 4));
            hand.AddCard(new Card(CardSuit.Heart, 4));

            FourOfAKindEvaluator evaluator = new FourOfAKindEvaluator();

            Assert.IsFalse(evaluator.IsHandThis(hand));
        }

        [TestCase]
        public void FourOfAKind_CreatesCorrectHandValue_IsValid()
        {
            Hand hand = new Hand(5);
            hand.AddCard(new Card(CardSuit.Club, 4));
            hand.AddCard(new Card(CardSuit.Diamond, 6));
            hand.AddCard(new Card(CardSuit.Diamond, 4));
            hand.AddCard(new Card(CardSuit.Spade, 4));
            hand.AddCard(new Card(CardSuit.Heart, 4));

            FourOfAKindEvaluator evaluator = new FourOfAKindEvaluator();

            Assert.AreEqual(evaluator.GetHandValue(hand).HandValue, new HandValue(7, new Card(CardSuit.Spade, 4)));
        }

        [TestCase]
        public void FourOfAKind_CreatesCorrectHandValue2_IsValid()
        {
            Hand hand = new Hand(5);
            hand.AddCard(new Card(CardSuit.Club, 8));
            hand.AddCard(new Card(CardSuit.Heart, 8));
            hand.AddCard(new Card(CardSuit.Diamond, 8));
            hand.AddCard(new Card(CardSuit.Spade, 8));
            hand.AddCard(new Card(CardSuit.Club, 3));

            FourOfAKindEvaluator evaluator = new FourOfAKindEvaluator();

            Assert.AreEqual(evaluator.GetHandValue(hand).HandValue, new HandValue(7, new Card(CardSuit.Spade, 8)));
        }
    }
}
