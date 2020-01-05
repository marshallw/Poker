using NUnit.Framework;
using Poker.Enums;
using Poker.HandEvaluators;
using Poker.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.Tests.HandEvaluatorTests
{
    class ThreeOfAKindTests
    {
        [TestCase]
        public void ThreeOfAKind_IsValid()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(2, CardSuit.Club));
            hand.AddCard(new Card(3, CardSuit.Diamond));
            hand.AddCard(new Card(4, CardSuit.Diamond));
            hand.AddCard(new Card(3, CardSuit.Spade));
            hand.AddCard(new Card(3, CardSuit.Club));

            ThreeOfAKindEvaluator evaluator = new ThreeOfAKindEvaluator();

            Assert.IsTrue(evaluator.IsHandThis(hand));
        }

        [TestCase]
        public void ThreeOfAKind2_IsValid()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(4, CardSuit.Club));
            hand.AddCard(new Card(3, CardSuit.Diamond));
            hand.AddCard(new Card(4, CardSuit.Diamond));
            hand.AddCard(new Card(3, CardSuit.Spade));
            hand.AddCard(new Card(3, CardSuit.Club));

            ThreeOfAKindEvaluator evaluator = new ThreeOfAKindEvaluator();

            Assert.IsTrue(evaluator.IsHandThis(hand));
        }

        [TestCase]
        public void ThreeOfAKind_IsNotValid()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(4, CardSuit.Club));
            hand.AddCard(new Card(6, CardSuit.Diamond));
            hand.AddCard(new Card(4, CardSuit.Diamond));
            hand.AddCard(new Card(3, CardSuit.Spade));
            hand.AddCard(new Card(3, CardSuit.Club));

            ThreeOfAKindEvaluator evaluator = new ThreeOfAKindEvaluator();

            Assert.IsFalse(evaluator.IsHandThis(hand));
        }

        [TestCase]
        public void ThreeOfAKind2_IsNotValid()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(4, CardSuit.Club));
            hand.AddCard(new Card(6, CardSuit.Diamond));
            hand.AddCard(new Card(4, CardSuit.Diamond));
            hand.AddCard(new Card(4, CardSuit.Spade));
            hand.AddCard(new Card(4, CardSuit.Heart));

            ThreeOfAKindEvaluator evaluator = new ThreeOfAKindEvaluator();

            Assert.IsFalse(evaluator.IsHandThis(hand));
        }

        [TestCase]
        public void ThreeOfAKind_CreatesCorrectHandValue_IsValid()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(4, CardSuit.Club));
            hand.AddCard(new Card(6, CardSuit.Diamond));
            hand.AddCard(new Card(4, CardSuit.Diamond));
            hand.AddCard(new Card(4, CardSuit.Spade));
            hand.AddCard(new Card(3, CardSuit.Club));

            ThreeOfAKindEvaluator evaluator = new ThreeOfAKindEvaluator();

            Assert.AreEqual(evaluator.GetHandRank(hand).HandValue, new HandValue(2, new Card(4, CardSuit.Spade),
                                                                                     new Card(6, CardSuit.Club),
                                                                                     new Card(3, CardSuit.Club)));
        }

        [TestCase]
        public void ThreeOfAKind_CreatesCorrectHandValue2_IsValid()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(4, CardSuit.Club));
            hand.AddCard(new Card(9, CardSuit.Diamond));
            hand.AddCard(new Card(4, CardSuit.Diamond));
            hand.AddCard(new Card(4, CardSuit.Spade));
            hand.AddCard(new Card(3, CardSuit.Club));

            ThreeOfAKindEvaluator evaluator = new ThreeOfAKindEvaluator();

            Assert.AreEqual(evaluator.GetHandRank(hand).HandValue, new HandValue(2, new Card(4, CardSuit.Club),
                                                                                     new Card(9, CardSuit.Club),
                                                                                     new Card(3, CardSuit.Club)));
        }

        [TestCase]
        public void ThreeOfAKind_SevenCardsTwoSetsOfThree_IsValid()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(4, CardSuit.Club));
            hand.AddCard(new Card(6, CardSuit.Diamond));
            hand.AddCard(new Card(4, CardSuit.Diamond));
            hand.AddCard(new Card(3, CardSuit.Spade));
            hand.AddCard(new Card(3, CardSuit.Club));
            hand.AddCard(new Card(3, CardSuit.Diamond));
            hand.AddCard(new Card(4, CardSuit.Spade));

            ThreeOfAKindEvaluator evaluator = new ThreeOfAKindEvaluator();

            Assert.IsTrue(evaluator.IsHandThis(hand));
        }

        [TestCase]
        public void ThreeOfAKind_SevenCards_IsValid()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(4, CardSuit.Club));
            hand.AddCard(new Card(6, CardSuit.Diamond));
            hand.AddCard(new Card(4, CardSuit.Diamond));
            hand.AddCard(new Card(4, CardSuit.Spade));
            hand.AddCard(new Card(3, CardSuit.Club));
            hand.AddCard(new Card(3, CardSuit.Diamond));
            hand.AddCard(new Card(4, CardSuit.Spade));

            ThreeOfAKindEvaluator evaluator = new ThreeOfAKindEvaluator();

            Assert.IsTrue(evaluator.IsHandThis(hand));
        }

        [TestCase]
        public void ThreeOfAKind_SevenCards_IsNotValid()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(2, CardSuit.Club));
            hand.AddCard(new Card(6, CardSuit.Diamond));
            hand.AddCard(new Card(4, CardSuit.Diamond));
            hand.AddCard(new Card(7, CardSuit.Spade));
            hand.AddCard(new Card(3, CardSuit.Club));
            hand.AddCard(new Card(3, CardSuit.Diamond));
            hand.AddCard(new Card(4, CardSuit.Spade));

            ThreeOfAKindEvaluator evaluator = new ThreeOfAKindEvaluator();

            Assert.IsFalse(evaluator.IsHandThis(hand));
        }

        [TestCase]
        public void ThreeOfAKind_SevenCardsTwoSetsOfThree_CreatesProperRanking()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(4, CardSuit.Club));
            hand.AddCard(new Card(3, CardSuit.Diamond));
            hand.AddCard(new Card(4, CardSuit.Diamond));
            hand.AddCard(new Card(3, CardSuit.Spade));
            hand.AddCard(new Card(3, CardSuit.Club));
            hand.AddCard(new Card(3, CardSuit.Heart));
            hand.AddCard(new Card(4, CardSuit.Spade));

            ThreeOfAKindEvaluator evaluator = new ThreeOfAKindEvaluator();

            Assert.AreEqual(evaluator.GetHandRank(hand).HandValue, new HandValue(2, new Card(4, CardSuit.Club),
                                                                                     new Card(3, CardSuit.Club),
                                                                                     new Card(3, CardSuit.Club)));
        }

        [TestCase]
        public void ThreeOfAKind_SevenCardsTwoSetsOfThree_CreatesProperRanking2()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(4, CardSuit.Club));
            hand.AddCard(new Card(3, CardSuit.Diamond));
            hand.AddCard(new Card(4, CardSuit.Diamond));
            hand.AddCard(new Card(3, CardSuit.Spade));
            hand.AddCard(new Card(3, CardSuit.Club));
            hand.AddCard(new Card(6, CardSuit.Diamond));
            hand.AddCard(new Card(4, CardSuit.Spade));

            ThreeOfAKindEvaluator evaluator = new ThreeOfAKindEvaluator();

            Assert.AreEqual(evaluator.GetHandRank(hand).HandValue, new HandValue(2, new Card(4, CardSuit.Club),
                                                                                     new Card(6, CardSuit.Club),
                                                                                     new Card(3, CardSuit.Club)));
        }

        [TestCase]
        public void ThreeOfAKind_SevenCards_CreatesProperRanking()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(7, CardSuit.Club));
            hand.AddCard(new Card(3, CardSuit.Diamond));
            hand.AddCard(new Card(4, CardSuit.Diamond));
            hand.AddCard(new Card(3, CardSuit.Spade));
            hand.AddCard(new Card(3, CardSuit.Club));
            hand.AddCard(new Card(6, CardSuit.Diamond));
            hand.AddCard(new Card(4, CardSuit.Spade));

            ThreeOfAKindEvaluator evaluator = new ThreeOfAKindEvaluator();

            Assert.AreEqual(evaluator.GetHandRank(hand).HandValue, new HandValue(2, new Card(3, CardSuit.Club),
                                                                                     new Card(7, CardSuit.Club),
                                                                                     new Card(6, CardSuit.Club)));
        }
    }
}
