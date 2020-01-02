using NUnit.Framework;
using Poker.Enums;
using Poker.HandEvaluators;
using Poker.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.Tests.HandEvaluatorTests
{
    class FlushTests
    {
        [TestCase]
        public void Flush_IsValid()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(2, CardSuit.Club));
            hand.AddCard(new Card(4, CardSuit.Club));
            hand.AddCard(new Card(3, CardSuit.Club));
            hand.AddCard(new Card(7, CardSuit.Club));
            hand.AddCard(new Card(8, CardSuit.Club));

            IPokerHandEvaluator evaluator = new FlushHandEvaluator();

            Assert.IsTrue(evaluator.IsHandThis(hand));
        }

        [TestCase]
        public void Flush2_IsValid()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(14, CardSuit.Diamond));
            hand.AddCard(new Card(6, CardSuit.Diamond));
            hand.AddCard(new Card(10, CardSuit.Diamond));
            hand.AddCard(new Card(11, CardSuit.Diamond));
            hand.AddCard(new Card(13, CardSuit.Diamond));

            IPokerHandEvaluator evaluator = new FlushHandEvaluator();

            Assert.IsTrue(evaluator.IsHandThis(hand));
        }

        [TestCase]
        public void Flush_IsNotValid()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(4, CardSuit.Club));
            hand.AddCard(new Card(6, CardSuit.Diamond));
            hand.AddCard(new Card(4, CardSuit.Diamond));
            hand.AddCard(new Card(3, CardSuit.Spade));
            hand.AddCard(new Card(3, CardSuit.Club));

            IPokerHandEvaluator evaluator = new FlushHandEvaluator();

            Assert.IsFalse(evaluator.IsHandThis(hand));
        }

        [TestCase]
        public void Flush2_IsNotValid()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(4, CardSuit.Diamond));
            hand.AddCard(new Card(6, CardSuit.Diamond));
            hand.AddCard(new Card(3, CardSuit.Diamond));
            hand.AddCard(new Card(9, CardSuit.Diamond));
            hand.AddCard(new Card(4, CardSuit.Heart));

            IPokerHandEvaluator evaluator = new FlushHandEvaluator();

            Assert.IsFalse(evaluator.IsHandThis(hand));
        }

        [TestCase]
        public void Flush_CreatesCorrectHandValue_IsValid()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(6, CardSuit.Diamond));
            hand.AddCard(new Card(9, CardSuit.Diamond));
            hand.AddCard(new Card(4, CardSuit.Diamond));
            hand.AddCard(new Card(8, CardSuit.Diamond));
            hand.AddCard(new Card(5, CardSuit.Diamond));

            IPokerHandEvaluator evaluator = new FlushHandEvaluator();

            Assert.AreEqual(evaluator.GetHandValue(hand).HandValue, new HandValue(5, new Card(9, CardSuit.Diamond),
                                                                                     new Card(8, CardSuit.Diamond),
                                                                                     new Card(6, CardSuit.Diamond),
                                                                                     new Card(5, CardSuit.Diamond),
                                                                                     new Card(4, CardSuit.Diamond)));
        }

        [TestCase]
        public void Flush_CreatesCorrectHandValue2_IsValid()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(CardValue.Jack, CardSuit.Club));
            hand.AddCard(new Card(CardValue.Ten, CardSuit.Club));
            hand.AddCard(new Card(CardValue.Queen, CardSuit.Club));
            hand.AddCard(new Card(CardValue.King, CardSuit.Club));
            hand.AddCard(new Card(CardValue.Ace, CardSuit.Club));

            IPokerHandEvaluator evaluator = new FlushHandEvaluator();

            Assert.AreEqual(evaluator.GetHandValue(hand).HandValue, new HandValue(5, new Card(CardValue.Ace, CardSuit.Club),
                                                                                     new Card(CardValue.King, CardSuit.Club),
                                                                                     new Card(CardValue.Queen, CardSuit.Club),
                                                                                     new Card(CardValue.Jack, CardSuit.Club),
                                                                                     new Card(CardValue.Ten, CardSuit.Club)));
        }
    }
}
