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
            Hand hand = new Hand(5);
            hand.AddCard(new Card(CardSuit.Club, 2));
            hand.AddCard(new Card(CardSuit.Diamond, 3));
            hand.AddCard(new Card(CardSuit.Diamond, 4));
            hand.AddCard(new Card(CardSuit.Spade, 10));
            hand.AddCard(new Card(CardSuit.Spade, 3));

            HighCardEvaluator evaluator = new HighCardEvaluator();

            Assert.IsTrue(evaluator.IsHandThis(hand));
           
        }

        [TestCase]
        public void HighCard_CanCreateHandValue()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(CardSuit.Club, 2));
            hand.AddCard(new Card(CardSuit.Diamond, 3));
            hand.AddCard(new Card(CardSuit.Diamond, 4));
            hand.AddCard(new Card(CardSuit.Spade, 10));
            hand.AddCard(new Card(CardSuit.Spade, 7));

            IPokerHandEvaluator evaluator = new HighCardEvaluator();

            Assert.IsTrue(evaluator.GetHandValue(hand).HandValue == new HandValue(0, hand.cards.OrderByDescending(_ => _.CardValue)));

        }
    }
}
