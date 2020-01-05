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
        public void FullHouse_FiveCards3High2Low_IsValid()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(2, CardSuit.Club));
            hand.AddCard(new Card(2, CardSuit.Diamond));
            hand.AddCard(new Card(3, CardSuit.Heart));
            hand.AddCard(new Card(3, CardSuit.Spade));
            hand.AddCard(new Card(3, CardSuit.Club));

            IPokerHandEvaluator evaluator = new FullHouseEvaluator();

            Assert.IsTrue(evaluator.IsHandThis(hand));
        }

        [TestCase]
        public void FullHouse_FiveCards3HighKingLow_IsValid()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(13, CardSuit.Diamond));
            hand.AddCard(new Card(3, CardSuit.Diamond));
            hand.AddCard(new Card(3, CardSuit.Heart));
            hand.AddCard(new Card(3, CardSuit.Spade));
            hand.AddCard(new Card(13, CardSuit.Club));

            IPokerHandEvaluator evaluator = new FullHouseEvaluator();

            Assert.IsTrue(evaluator.IsHandThis(hand));
        }

        [TestCase]
        public void FullHouse_FiveCards_IsNotValid()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(4, CardSuit.Club));
            hand.AddCard(new Card(6, CardSuit.Diamond));
            hand.AddCard(new Card(4, CardSuit.Diamond));
            hand.AddCard(new Card(3, CardSuit.Spade));
            hand.AddCard(new Card(3, CardSuit.Club));

            IPokerHandEvaluator evaluator = new FullHouseEvaluator();

            Assert.IsFalse(evaluator.IsHandThis(hand));
        }

        [TestCase]
        public void FullHouse_FiveCards_IsNotValid2()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(4, CardSuit.Club));
            hand.AddCard(new Card(6, CardSuit.Diamond));
            hand.AddCard(new Card(3, CardSuit.Diamond));
            hand.AddCard(new Card(4, CardSuit.Spade));
            hand.AddCard(new Card(4, CardSuit.Heart));

            IPokerHandEvaluator evaluator = new FullHouseEvaluator();

            Assert.IsFalse(evaluator.IsHandThis(hand));
        }

        [TestCase]
        public void FullHouse_FiveCards4High6Low_CreatesProperRank()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(6, CardSuit.Club));
            hand.AddCard(new Card(6, CardSuit.Diamond));
            hand.AddCard(new Card(4, CardSuit.Diamond));
            hand.AddCard(new Card(4, CardSuit.Spade));
            hand.AddCard(new Card(4, CardSuit.Heart));

            IPokerHandEvaluator evaluator = new FullHouseEvaluator();

            Assert.AreEqual(evaluator.GetHandRank(hand).HandValue, new HandValue(6, new Card(4, CardSuit.Spade),
                                                                                     new Card(6, CardSuit.Heart)));
        }

        [TestCase]
        public void FullHouse_FiveCards11High2Low_CreatesProperRank()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(11, CardSuit.Club));
            hand.AddCard(new Card(11, CardSuit.Heart));
            hand.AddCard(new Card(2, CardSuit.Diamond));
            hand.AddCard(new Card(11, CardSuit.Spade));
            hand.AddCard(new Card(2, CardSuit.Club));

            IPokerHandEvaluator evaluator = new FullHouseEvaluator();

            Assert.AreEqual(evaluator.GetHandRank(hand).HandValue, new HandValue(6, new Card(11, CardSuit.Spade),
                                                                                     new Card(2, CardSuit.Diamond)));
        }

        [TestCase]
        public void FullHouse_SevenCardStud_IsValid()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(11, CardSuit.Club));
            hand.AddCard(new Card(11, CardSuit.Heart));
            hand.AddCard(new Card(2, CardSuit.Diamond));
            hand.AddCard(new Card(2, CardSuit.Spade));
            hand.AddCard(new Card(2, CardSuit.Club));
            hand.AddCard(new Card(11, CardSuit.Spade));

            IPokerHandEvaluator evaluator = new FullHouseEvaluator();

            Assert.IsTrue(evaluator.IsHandThis(hand));
        }

        [TestCase]
        public void FullHouse_SevenCardStud_IsNotValid()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(10, CardSuit.Club));
            hand.AddCard(new Card(11, CardSuit.Heart));
            hand.AddCard(new Card(2, CardSuit.Diamond));
            hand.AddCard(new Card(4, CardSuit.Spade));
            hand.AddCard(new Card(2, CardSuit.Club));
            hand.AddCard(new Card(11, CardSuit.Spade));

            IPokerHandEvaluator evaluator = new FullHouseEvaluator();

            Assert.IsFalse(evaluator.IsHandThis(hand));
        }


        [TestCase]
        public void FullHouse_SevenCardStud_CreatesProperRank()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(11, CardSuit.Club));
            hand.AddCard(new Card(11, CardSuit.Heart));
            hand.AddCard(new Card(2, CardSuit.Diamond));
            hand.AddCard(new Card(11, CardSuit.Spade));
            hand.AddCard(new Card(2, CardSuit.Club));
            hand.AddCard(new Card(11, CardSuit.Spade));

            IPokerHandEvaluator evaluator = new FullHouseEvaluator();

            Assert.AreEqual(evaluator.GetHandRank(hand).HandValue, new HandValue(6, new Card(11, CardSuit.Spade),
                                                                                     new Card(2, CardSuit.Diamond)));
        }

        [TestCase]
        public void FullHouse_SevenCardStud_CreatesProperRank2()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(11, CardSuit.Club));
            hand.AddCard(new Card(11, CardSuit.Heart));
            hand.AddCard(new Card(2, CardSuit.Diamond));
            hand.AddCard(new Card(2, CardSuit.Spade));
            hand.AddCard(new Card(2, CardSuit.Club));
            hand.AddCard(new Card(11, CardSuit.Spade));

            IPokerHandEvaluator evaluator = new FullHouseEvaluator();

            Assert.AreEqual(evaluator.GetHandRank(hand).HandValue, new HandValue(6, new Card(11, CardSuit.Spade),
                                                                                     new Card(2, CardSuit.Diamond)));
        }
    }
}
