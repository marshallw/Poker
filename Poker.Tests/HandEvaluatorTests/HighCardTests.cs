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
        public void HighCard_IsThisHighCard()
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
        public void HighCard_CanCreateHandValue()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(2, CardSuit.Club));
            hand.AddCard(new Card(3, CardSuit.Diamond));
            hand.AddCard(new Card(4, CardSuit.Diamond));
            hand.AddCard(new Card(10, CardSuit.Spade));
            hand.AddCard(new Card(7, CardSuit.Spade));

            IPokerHandEvaluator evaluator = new HighCardEvaluator();

            Assert.IsTrue(evaluator.GetHandValue(hand).HandValue == new HandValue(0, hand.Cards.OrderByDescending(_ => _.CardValue)));

        }
    }
}
