using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Poker.Models;
using Poker.Enums;
using Poker.HandEvaluators;

namespace Poker.Tests.HandEvaluatorTests
{
    class PairTests
    {
        [TestCase]
        public void PairOfCards_IsValid()
        {
            Hand hand = new Hand();

            hand.AddCard(new Card(2, CardSuit.Club));
            hand.AddCard(new Card(3, CardSuit.Diamond));
            hand.AddCard(new Card(5, CardSuit.Heart));
            hand.AddCard(new Card(3, CardSuit.Heart));
            hand.AddCard(new Card(5, CardSuit.Club));

            PairHandEvaluator evaluator = new PairHandEvaluator();
            Assert.IsTrue(evaluator.IsHandThis(hand));
        }

        [TestCase]
        public void PairOfCards_IsNotValid()
        {
            Hand hand = new Hand();

            hand.AddCard(new Card(2, CardSuit.Club));
            hand.AddCard(new Card(3, CardSuit.Diamond));
            hand.AddCard(new Card(6, CardSuit.Club));
            hand.AddCard(new Card(4, CardSuit.Heart));
            hand.AddCard(new Card(5, CardSuit.Club));

            PairHandEvaluator evaluator = new PairHandEvaluator();
            Assert.IsFalse(evaluator.IsHandThis(hand));
        }

        [TestCase]
        public void PairOfCards_TwoPairs_IsValid()
        {
            Hand hand = new Hand();

            hand.AddCard(new Card(6, CardSuit.Club));
            hand.AddCard(new Card(4, CardSuit.Diamond));
            hand.AddCard(new Card(3, CardSuit.Club));
            hand.AddCard(new Card(4, CardSuit.Heart));
            hand.AddCard(new Card(3, CardSuit.Club));

            PairHandEvaluator evaluator = new PairHandEvaluator();
            //Assert.IsFalse(evaluator.IsHandThis(hand));
            Assert.AreEqual(evaluator.GetHandRank(hand).HandValue, new HandValue(1, new Card(4, CardSuit.Diamond),
                                                                                     new Card(6, CardSuit.Diamond),
                                                                                     new Card(3, CardSuit.Diamond),
                                                                                     new Card(3, CardSuit.Club)));
        }

        [TestCase]
        public void PairOfCards_IsNotValid2()
        {
            Hand hand = new Hand();

            hand.AddCard(new Card(2, CardSuit.Club));
            hand.AddCard(new Card(3, CardSuit.Diamond));
            hand.AddCard(new Card(3, CardSuit.Club));
            hand.AddCard(new Card(3, CardSuit.Heart));
            hand.AddCard(new Card(5, CardSuit.Club));

            PairHandEvaluator evaluator = new PairHandEvaluator();
            Assert.IsFalse(evaluator.IsHandThis(hand));
        }

        [TestCase]
        public void PairOfCards_IsValid2()
        {
            Hand hand = new Hand();

            hand.AddCard(new Card(2, CardSuit.Club));
            hand.AddCard(new Card(3, CardSuit.Diamond));
            hand.AddCard(new Card(6, CardSuit.Club));
            hand.AddCard(new Card(4, CardSuit.Heart));
            hand.AddCard(new Card(3, CardSuit.Club));

            PairHandEvaluator evaluator = new PairHandEvaluator();
            Assert.AreEqual(evaluator.GetHandRank(hand).HandValue, new HandValue(1, new Card(3, CardSuit.Diamond), 
                                                                                     new Card(6, CardSuit.Diamond),
                                                                                     new Card(4, CardSuit.Diamond),
                                                                                     new Card(2, CardSuit.Diamond)));
        }

        [TestCase]
        public void PairOfCards_HandOfSeven_CanGetValue()
        {
            Hand hand = new Hand();

            hand.AddCard(new Card(2, CardSuit.Club));
            hand.AddCard(new Card(3, CardSuit.Diamond));
            hand.AddCard(new Card(6, CardSuit.Club));
            hand.AddCard(new Card(7, CardSuit.Heart));
            hand.AddCard(new Card(3, CardSuit.Club));
            hand.AddCard(new Card(7, CardSuit.Club));
            hand.AddCard(new Card(CardValue.Ace, CardSuit.Spade));

            PairHandEvaluator evaluator = new PairHandEvaluator();
            Assert.AreEqual(evaluator.GetHandRank(hand).HandValue, new HandValue(1, new Card(7, CardSuit.Diamond),
                                                                                     new Card(CardValue.Ace, CardSuit.Diamond),
                                                                                     new Card(6, CardSuit.Diamond),
                                                                                     new Card(3, CardSuit.Diamond)));
        }

        [TestCase]
        public void PairOfCards_HandOfSeven_IsValid()
        {
            Hand hand = new Hand();

            hand.AddCard(new Card(2, CardSuit.Club));
            hand.AddCard(new Card(3, CardSuit.Diamond));
            hand.AddCard(new Card(6, CardSuit.Club));
            hand.AddCard(new Card(7, CardSuit.Heart));
            hand.AddCard(new Card(3, CardSuit.Club));
            hand.AddCard(new Card(7, CardSuit.Club));
            hand.AddCard(new Card(CardValue.Ace, CardSuit.Spade));

            PairHandEvaluator evaluator = new PairHandEvaluator();
            Assert.IsTrue(evaluator.IsHandThis(hand));
        }

        [TestCase]
        public void PairOfCards_HandOfSeven_IsNotValid()
        {
            Hand hand = new Hand();

            hand.AddCard(new Card(2, CardSuit.Club));
            hand.AddCard(new Card(3, CardSuit.Diamond));
            hand.AddCard(new Card(4, CardSuit.Club));
            hand.AddCard(new Card(5, CardSuit.Heart));
            hand.AddCard(new Card(6, CardSuit.Club));
            hand.AddCard(new Card(7, CardSuit.Club));
            hand.AddCard(new Card(CardValue.Ace, CardSuit.Spade));

            PairHandEvaluator evaluator = new PairHandEvaluator();
            Assert.IsFalse(evaluator.IsHandThis(hand));
        }
    }
}
