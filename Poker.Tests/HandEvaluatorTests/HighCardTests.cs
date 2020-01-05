using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Poker.Enums;
using Poker.Models;
using Poker.HandEvaluators;
using System.Linq;

namespace Poker.Tests.HandEvaluatorTests
{
    public class HighCardTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [TestCase]
        public void HighCard_FiveCardsTenHigh_IsValid()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(2, CardSuit.Club));
            hand.AddCard(new Card(3, CardSuit.Diamond));
            hand.AddCard(new Card(4, CardSuit.Diamond));
            hand.AddCard(new Card(10, CardSuit.Spade));
            hand.AddCard(new Card(3, CardSuit.Spade));

            HighCardEvaluator evaluator = new HighCardEvaluator();

            Assert.IsTrue(evaluator.IsHandThis(hand));
           
        }

        [TestCase]
        public void HighCard_FiveCards_CreateProperRanking()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(2, CardSuit.Club));
            hand.AddCard(new Card(3, CardSuit.Diamond));
            hand.AddCard(new Card(4, CardSuit.Diamond));
            hand.AddCard(new Card(10, CardSuit.Spade));
            hand.AddCard(new Card(7, CardSuit.Spade));

            IPokerHandEvaluator evaluator = new HighCardEvaluator();

            Assert.AreEqual(evaluator.GetHandRank(hand).HandValue, new HandValue(0, hand.Cards.OrderByDescending(_ => _.CardValue)));

        }

        [TestCase]
        public void HighCard_SevenCardStud_IsValid()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(2, CardSuit.Club));
            hand.AddCard(new Card(10, CardSuit.Diamond));
            hand.AddCard(new Card(10, CardSuit.Club));
            hand.AddCard(new Card(14, CardSuit.Spade));
            hand.AddCard(new Card(14, CardSuit.Diamond));
            hand.AddCard(new Card(5, CardSuit.Heart));
            hand.AddCard(new Card(7, CardSuit.Spade));

            HighCardEvaluator evaluator = new HighCardEvaluator();

            Assert.IsTrue(evaluator.IsHandThis(hand));
        }

        [TestCase]
        public void HighCard_SevenCardStud_CreatesProperRanking()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(2, CardSuit.Club));
            hand.AddCard(new Card(10, CardSuit.Diamond));
            hand.AddCard(new Card(10, CardSuit.Club));
            hand.AddCard(new Card(14, CardSuit.Spade));
            hand.AddCard(new Card(14, CardSuit.Diamond));
            hand.AddCard(new Card(5, CardSuit.Heart));
            hand.AddCard(new Card(7, CardSuit.Spade));

            HighCardEvaluator evaluator = new HighCardEvaluator();

            Assert.AreEqual(evaluator.GetHandRank(hand).HandValue, new HandValue(0, hand.Cards.OrderByDescending(_ => _.CardValue).Where((i,j) => j <= 4)));
        }
    }
}
