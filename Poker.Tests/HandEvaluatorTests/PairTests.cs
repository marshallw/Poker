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

            hand.AddCard(new Card(CardSuit.Club, 2));
            hand.AddCard(new Card(CardSuit.Diamond, 3));
            hand.AddCard(new Card(CardSuit.Heart, 5));
            hand.AddCard(new Card(CardSuit.Heart, 3));
            hand.AddCard(new Card(CardSuit.Club, 5));

            PairHandEvaluator evaluator = new PairHandEvaluator();
            Assert.IsTrue(evaluator.IsHandThis(hand));
        }

        [TestCase]
        public void PairOfCards2_IsNotValid()
        {
            Hand hand = new Hand();

            hand.AddCard(new Card(CardSuit.Club, 2));
            hand.AddCard(new Card(CardSuit.Diamond, 3));
            hand.AddCard(new Card(CardSuit.Club, 6));
            hand.AddCard(new Card(CardSuit.Heart, 4));
            hand.AddCard(new Card(CardSuit.Club, 5));

            PairHandEvaluator evaluator = new PairHandEvaluator();
            Assert.IsFalse(evaluator.IsHandThis(hand));
        }

        [TestCase]
        public void PairOfCards_TwoPairs_IsValid()
        {
            Hand hand = new Hand();

            hand.AddCard(new Card(CardSuit.Club, 6));
            hand.AddCard(new Card(CardSuit.Diamond, 4));
            hand.AddCard(new Card(CardSuit.Club, 3));
            hand.AddCard(new Card(CardSuit.Heart, 4));
            hand.AddCard(new Card(CardSuit.Club, 3));

            PairHandEvaluator evaluator = new PairHandEvaluator();
            //Assert.IsFalse(evaluator.IsHandThis(hand));
            Assert.AreEqual(evaluator.GetHandValue(hand).HandValue, new HandValue(1, new Card(CardSuit.Diamond, 4),
                                                                                     new Card(CardSuit.Diamond, 3),
                                                                                     new Card(CardSuit.Diamond, 6)));
        }

        [TestCase]
        public void PairOfCards_IsNotValid()
        {
            Hand hand = new Hand();

            hand.AddCard(new Card(CardSuit.Club, 2));
            hand.AddCard(new Card(CardSuit.Diamond, 3));
            hand.AddCard(new Card(CardSuit.Club, 3));
            hand.AddCard(new Card(CardSuit.Heart, 3));
            hand.AddCard(new Card(CardSuit.Club, 5));

            PairHandEvaluator evaluator = new PairHandEvaluator();
            Assert.IsFalse(evaluator.IsHandThis(hand));
        }

        [TestCase]
        public void PairOfCards2_IsValid()
        {
            Hand hand = new Hand();

            hand.AddCard(new Card(CardSuit.Club, 2));
            hand.AddCard(new Card(CardSuit.Diamond, 3));
            hand.AddCard(new Card(CardSuit.Club, 6));
            hand.AddCard(new Card(CardSuit.Heart, 4));
            hand.AddCard(new Card(CardSuit.Club, 3));

            PairHandEvaluator evaluator = new PairHandEvaluator();
            Assert.AreEqual(evaluator.GetHandValue(hand).HandValue, new HandValue(1, new Card(CardSuit.Diamond,3), 
                                                                                     new Card(CardSuit.Diamond, 6),
                                                                                     new Card(CardSuit.Diamond, 4),
                                                                                     new Card(CardSuit.Diamond, 2)));
        }
    }
}
