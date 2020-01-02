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
            Hand hand = new Hand(5);
            hand.AddCard(new Card(CardSuit.Club, 2));
            hand.AddCard(new Card(CardSuit.Club, 4));
            hand.AddCard(new Card(CardSuit.Club, 3));
            hand.AddCard(new Card(CardSuit.Club, 7));
            hand.AddCard(new Card(CardSuit.Club, 8));

            IPokerHandEvaluator evaluator = new FlushHandEvaluator();

            Assert.IsTrue(evaluator.IsHandThis(hand));
        }

        [TestCase]
        public void Flush2_IsValid()
        {
            Hand hand = new Hand(5);
            hand.AddCard(new Card(CardSuit.Diamond, 14));
            hand.AddCard(new Card(CardSuit.Diamond, 6));
            hand.AddCard(new Card(CardSuit.Diamond, 10));
            hand.AddCard(new Card(CardSuit.Diamond, 11));
            hand.AddCard(new Card(CardSuit.Diamond, 13));

            IPokerHandEvaluator evaluator = new FlushHandEvaluator();

            Assert.IsTrue(evaluator.IsHandThis(hand));
        }

        [TestCase]
        public void Flush_IsNotValid()
        {
            Hand hand = new Hand(5);
            hand.AddCard(new Card(CardSuit.Club, 4));
            hand.AddCard(new Card(CardSuit.Diamond, 6));
            hand.AddCard(new Card(CardSuit.Diamond, 4));
            hand.AddCard(new Card(CardSuit.Spade, 3));
            hand.AddCard(new Card(CardSuit.Club, 3));

            IPokerHandEvaluator evaluator = new FlushHandEvaluator();

            Assert.IsFalse(evaluator.IsHandThis(hand));
        }

        [TestCase]
        public void Flush2_IsNotValid()
        {
            Hand hand = new Hand(5);
            hand.AddCard(new Card(CardSuit.Diamond, 4));
            hand.AddCard(new Card(CardSuit.Diamond, 6));
            hand.AddCard(new Card(CardSuit.Diamond, 3));
            hand.AddCard(new Card(CardSuit.Diamond, 9));
            hand.AddCard(new Card(CardSuit.Heart, 4));

            IPokerHandEvaluator evaluator = new FlushHandEvaluator();

            Assert.IsFalse(evaluator.IsHandThis(hand));
        }

        [TestCase]
        public void Flush_CreatesCorrectHandValue_IsValid()
        {
            Hand hand = new Hand(5);
            hand.AddCard(new Card(CardSuit.Diamond, 6));
            hand.AddCard(new Card(CardSuit.Diamond, 9));
            hand.AddCard(new Card(CardSuit.Diamond, 4));
            hand.AddCard(new Card(CardSuit.Diamond, 8));
            hand.AddCard(new Card(CardSuit.Diamond, 5));

            IPokerHandEvaluator evaluator = new FlushHandEvaluator();

            Assert.AreEqual(evaluator.GetHandValue(hand).HandValue, new HandValue(5, new Card(CardSuit.Diamond,9),
                                                                                     new Card(CardSuit.Diamond, 8),
                                                                                     new Card(CardSuit.Diamond, 6),
                                                                                     new Card(CardSuit.Diamond, 5),
                                                                                     new Card(CardSuit.Diamond, 4)));
        }

        [TestCase]
        public void Flush_CreatesCorrectHandValue2_IsValid()
        {
            Hand hand = new Hand(5);
            hand.AddCard(new Card(CardSuit.Club, CardValue.Jack));
            hand.AddCard(new Card(CardSuit.Club, CardValue.Ten));
            hand.AddCard(new Card(CardSuit.Club, CardValue.Queen));
            hand.AddCard(new Card(CardSuit.Club, CardValue.King));
            hand.AddCard(new Card(CardSuit.Club, CardValue.Ace));

            IPokerHandEvaluator evaluator = new FlushHandEvaluator();

            Assert.AreEqual(evaluator.GetHandValue(hand).HandValue, new HandValue(5, new Card(CardSuit.Club, CardValue.Ace),
                                                                                     new Card(CardSuit.Club, CardValue.King),
                                                                                     new Card(CardSuit.Club, CardValue.Queen),
                                                                                     new Card(CardSuit.Club, CardValue.Jack),
                                                                                     new Card(CardSuit.Club, CardValue.Ten)));
        }
    }
}
