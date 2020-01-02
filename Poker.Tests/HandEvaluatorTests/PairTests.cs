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
        public void PairOfCards2_IsNotValid()
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
            Assert.AreEqual(evaluator.GetHandValue(hand).HandValue, new HandValue(1, new Card(4, CardSuit.Diamond),
                                                                                     new Card(3, CardSuit.Diamond),
                                                                                     new Card(6, CardSuit.Diamond)));
        }

        [TestCase]
        public void PairOfCards_IsNotValid()
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
        public void PairOfCards2_IsValid()
        {
            Hand hand = new Hand();

            hand.AddCard(new Card(2, CardSuit.Club));
            hand.AddCard(new Card(3, CardSuit.Diamond));
            hand.AddCard(new Card(6, CardSuit.Club));
            hand.AddCard(new Card(4, CardSuit.Heart));
            hand.AddCard(new Card(3, CardSuit.Club));

            PairHandEvaluator evaluator = new PairHandEvaluator();
            Assert.AreEqual(evaluator.GetHandValue(hand).HandValue, new HandValue(1, new Card(3, CardSuit.Diamond), 
                                                                                     new Card(6, CardSuit.Diamond),
                                                                                     new Card(4, CardSuit.Diamond),
                                                                                     new Card(2, CardSuit.Diamond)));
        }
    }
}
