using NUnit.Framework;
using Poker.Enums;
using Poker.HandEvaluators;
using Poker.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.Tests.HandEvaluatorTests
{
    public class FullHouseTests
    {
        [TestCase]
        public void FullHouse_IsValid()
        {
            Hand hand = new Hand(5);
            hand.AddCard(new Card(CardSuit.Club, 2));
            hand.AddCard(new Card(CardSuit.Diamond, 2));
            hand.AddCard(new Card(CardSuit.Heart, 3));
            hand.AddCard(new Card(CardSuit.Spade, 3));
            hand.AddCard(new Card(CardSuit.Club, 3));

            IPokerHandEvaluator evaluator = new FullHouseEvaluator();

            Assert.IsTrue(evaluator.IsHandThis(hand));
        }

        [TestCase]
        public void FullHouse2_IsValid()
        {
            Hand hand = new Hand(5);
            hand.AddCard(new Card(CardSuit.Diamond, 13));
            hand.AddCard(new Card(CardSuit.Diamond, 3));
            hand.AddCard(new Card(CardSuit.Heart, 3));
            hand.AddCard(new Card(CardSuit.Spade, 3));
            hand.AddCard(new Card(CardSuit.Club, 13));

            IPokerHandEvaluator evaluator = new FullHouseEvaluator();

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

            IPokerHandEvaluator evaluator = new FullHouseEvaluator();

            Assert.IsFalse(evaluator.IsHandThis(hand));
        }

        [TestCase]
        public void FullHouse2_IsNotValid()
        {
            Hand hand = new Hand(5);
            hand.AddCard(new Card(CardSuit.Club, 4));
            hand.AddCard(new Card(CardSuit.Diamond, 6));
            hand.AddCard(new Card(CardSuit.Diamond, 3));
            hand.AddCard(new Card(CardSuit.Spade, 4));
            hand.AddCard(new Card(CardSuit.Heart, 4));

            IPokerHandEvaluator evaluator = new FullHouseEvaluator();

            Assert.IsFalse(evaluator.IsHandThis(hand));
        }

        [TestCase]
        public void FullHouse_CreatesCorrectHandValue_IsValid()
        {
            Hand hand = new Hand(5);
            hand.AddCard(new Card(CardSuit.Club, 6));
            hand.AddCard(new Card(CardSuit.Diamond, 6));
            hand.AddCard(new Card(CardSuit.Diamond, 4));
            hand.AddCard(new Card(CardSuit.Spade, 4));
            hand.AddCard(new Card(CardSuit.Heart, 4));

            IPokerHandEvaluator evaluator = new FullHouseEvaluator();

            Assert.AreEqual(evaluator.GetHandValue(hand).HandValue, new HandValue(6, new Card(CardSuit.Spade, 4),
                                                                                     new Card(CardSuit.Heart, 6)));
        }

        [TestCase]
        public void FullHouse_CreatesCorrectHandValue2_IsValid()
        {
            Hand hand = new Hand(5);
            hand.AddCard(new Card(CardSuit.Club, 11));
            hand.AddCard(new Card(CardSuit.Heart, 11));
            hand.AddCard(new Card(CardSuit.Diamond, 11));
            hand.AddCard(new Card(CardSuit.Spade, 2));
            hand.AddCard(new Card(CardSuit.Club, 2));

            IPokerHandEvaluator evaluator = new FullHouseEvaluator();

            Assert.AreEqual(evaluator.GetHandValue(hand).HandValue, new HandValue(6, new Card(CardSuit.Spade, 11),
                                                                                     new Card(CardSuit.Diamond, 2)));
        }
    }
}
