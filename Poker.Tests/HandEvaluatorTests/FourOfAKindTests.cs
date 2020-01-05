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
        public void FourOfAKind_3High2Low_IsValid()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(2, CardSuit.Club));
            hand.AddCard(new Card(3, CardSuit.Diamond));
            hand.AddCard(new Card(3, CardSuit.Heart));
            hand.AddCard(new Card(3, CardSuit.Spade));
            hand.AddCard(new Card(3, CardSuit.Club));

            FourOfAKindEvaluator evaluator = new FourOfAKindEvaluator();

            Assert.IsTrue(evaluator.IsHandThis(hand));
        }

        [TestCase]
        public void FourOfAKind_3High9Low_IsValid()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(9, CardSuit.Club));
            hand.AddCard(new Card(3, CardSuit.Diamond));
            hand.AddCard(new Card(3, CardSuit.Heart));
            hand.AddCard(new Card(3, CardSuit.Spade));
            hand.AddCard(new Card(3, CardSuit.Club));

            FourOfAKindEvaluator evaluator = new FourOfAKindEvaluator();

            Assert.IsTrue(evaluator.IsHandThis(hand));
        }

        [TestCase]
        public void FourOfAKind_FiveCards_IsNotValid()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(4, CardSuit.Club));
            hand.AddCard(new Card(6, CardSuit.Diamond));
            hand.AddCard(new Card(4, CardSuit.Diamond));
            hand.AddCard(new Card(3, CardSuit.Spade));
            hand.AddCard(new Card(3, CardSuit.Club));

            FourOfAKindEvaluator evaluator = new FourOfAKindEvaluator();

            Assert.IsFalse(evaluator.IsHandThis(hand));
        }

        [TestCase]
        public void FourOfAKind_FiveCards_IsNotValid2()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(4, CardSuit.Club));
            hand.AddCard(new Card(6, CardSuit.Diamond));
            hand.AddCard(new Card(3, CardSuit.Diamond));
            hand.AddCard(new Card(4, CardSuit.Spade));
            hand.AddCard(new Card(4, CardSuit.Heart));

            FourOfAKindEvaluator evaluator = new FourOfAKindEvaluator();

            Assert.IsFalse(evaluator.IsHandThis(hand));
        }

        [TestCase]
        public void FourOfAKind_FiveCards4High6Low_CreatesProperRank()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(4, CardSuit.Club));
            hand.AddCard(new Card(6, CardSuit.Diamond));
            hand.AddCard(new Card(4, CardSuit.Diamond));
            hand.AddCard(new Card(4, CardSuit.Spade));
            hand.AddCard(new Card(4, CardSuit.Heart));

            FourOfAKindEvaluator evaluator = new FourOfAKindEvaluator();

            Assert.AreEqual(evaluator.GetHandRank(hand).HandValue, new HandValue(7, new Card(4, CardSuit.Spade),
                                                                                     new Card(6, CardSuit.Club)));
        }

        [TestCase]
        public void FourOfAKind_FiveCards8High3Low_CreatesProperRank()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(8, CardSuit.Club));
            hand.AddCard(new Card(8, CardSuit.Heart));
            hand.AddCard(new Card(8, CardSuit.Diamond));
            hand.AddCard(new Card(8, CardSuit.Spade));
            hand.AddCard(new Card(3, CardSuit.Club));

            FourOfAKindEvaluator evaluator = new FourOfAKindEvaluator();

            Assert.AreEqual(evaluator.GetHandRank(hand).HandValue, new HandValue(7, new Card(8, CardSuit.Spade),
                                                                                     new Card(3, CardSuit.Club)));
        }

        [TestCase]
        public void FourOfAKind_SevenCardStud_IsValid()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(8, CardSuit.Club));
            hand.AddCard(new Card(8, CardSuit.Heart));
            hand.AddCard(new Card(4, CardSuit.Diamond));
            hand.AddCard(new Card(8, CardSuit.Spade));
            hand.AddCard(new Card(3, CardSuit.Club));
            hand.AddCard(new Card(8, CardSuit.Diamond));
            hand.AddCard(new Card(3, CardSuit.Club));

            FourOfAKindEvaluator evaluator = new FourOfAKindEvaluator();

            Assert.IsTrue(evaluator.IsHandThis(hand));
        }

        [TestCase]
        public void FourOfAKind_SevenCardStud_CreatesProperRank()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(8, CardSuit.Club));
            hand.AddCard(new Card(8, CardSuit.Heart));
            hand.AddCard(new Card(4, CardSuit.Diamond));
            hand.AddCard(new Card(8, CardSuit.Spade));
            hand.AddCard(new Card(3, CardSuit.Club));
            hand.AddCard(new Card(8, CardSuit.Diamond));
            hand.AddCard(new Card(3, CardSuit.Club));

            FourOfAKindEvaluator evaluator = new FourOfAKindEvaluator();

            Assert.AreEqual(evaluator.GetHandRank(hand).HandValue, new HandValue(7, new Card(8, CardSuit.Spade),
                                                                                     new Card(4, CardSuit.Club)));
        }

        [TestCase]
        public void FourOfAKind_SevenCardStud_IsNotValid()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(8, CardSuit.Club));
            hand.AddCard(new Card(10, CardSuit.Heart));
            hand.AddCard(new Card(4, CardSuit.Diamond));
            hand.AddCard(new Card(8, CardSuit.Spade));
            hand.AddCard(new Card(3, CardSuit.Club));
            hand.AddCard(new Card(8, CardSuit.Diamond));
            hand.AddCard(new Card(3, CardSuit.Club));

            FourOfAKindEvaluator evaluator = new FourOfAKindEvaluator();

            Assert.IsFalse(evaluator.IsHandThis(hand));
        }
    }
}
