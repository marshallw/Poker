using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Poker.Enums;
using Poker.HandEvaluators;
using Poker.Models;

namespace Poker.Tests
{
    class HandRankerTests
    {
        private HandRanker<IPokerHandEvaluator> handRanker;
        private Hand highCardHand;
        private Hand pairHand;
        private Hand threeOfAKindHand;
        private Hand fourOfAKindHand;
        private Hand flushHand;
        private Hand straightHand;

        [SetUp]
        public void Setup()
        {
            handRanker = new HandRanker<IPokerHandEvaluator>();

            highCardHand = new Hand();
        }

        [TestCase]
        public void HandRanker_HighCard_FindWinningHand()
        {
            Hand lowHand = new Hand();
            Hand highHand = new Hand();

            lowHand.AddCard(new Card(2, CardSuit.Club));
            lowHand.AddCard(new Card(3, CardSuit.Diamond));
            lowHand.AddCard(new Card(4, CardSuit.Heart));
            lowHand.AddCard(new Card(5, CardSuit.Spade));
            lowHand.AddCard(new Card(7, CardSuit.Club));

            highHand.AddCard(new Card(2, CardSuit.Club));
            highHand.AddCard(new Card(3, CardSuit.Diamond));
            highHand.AddCard(new Card(4, CardSuit.Heart));
            highHand.AddCard(new Card(5, CardSuit.Spade));
            highHand.AddCard(new Card(8, CardSuit.Club));

            var lowValue = handRanker.RankHand(lowHand);
            var highValue = handRanker.RankHand(highHand);

            Assert.IsTrue(handRanker.RankHand(lowHand) < handRanker.RankHand(highHand));
        }

        [TestCase]
        public void HandRanker_Pair_HighPair()
        {
            Hand pair1 = new Hand();
            Hand pair2 = new Hand();

            pair1.AddCard(new Card(7, CardSuit.Club));
            pair1.AddCard(new Card(3, CardSuit.Diamond));
            pair1.AddCard(new Card(4, CardSuit.Heart));
            pair1.AddCard(new Card(5, CardSuit.Spade));
            pair1.AddCard(new Card(7, CardSuit.Club));

            pair2.AddCard(new Card(2, CardSuit.Club));
            pair2.AddCard(new Card(3, CardSuit.Diamond));
            pair2.AddCard(new Card(6, CardSuit.Heart));
            pair2.AddCard(new Card(8, CardSuit.Spade));
            pair2.AddCard(new Card(8, CardSuit.Club));

            Assert.IsTrue(handRanker.RankHand(pair2) > handRanker.RankHand(pair1));
        }

        [TestCase]
        public void HandRanker_ThreeOfaKindPair()
        {
            Hand three = new Hand();
            Hand pair = new Hand();

            pair.AddCard(new Card(7, CardSuit.Club));
            pair.AddCard(new Card(3, CardSuit.Diamond));
            pair.AddCard(new Card(4, CardSuit.Heart));
            pair.AddCard(new Card(5, CardSuit.Spade));
            pair.AddCard(new Card(7, CardSuit.Club));

            three.AddCard(new Card(2, CardSuit.Club));
            three.AddCard(new Card(2, CardSuit.Diamond));
            three.AddCard(new Card(2, CardSuit.Heart));
            three.AddCard(new Card(3, CardSuit.Spade));
            three.AddCard(new Card(8, CardSuit.Club));

            Assert.IsTrue(handRanker.RankHand(pair) < handRanker.RankHand(three));
        }

        [TestCase]
        public void HandRanker_Pairs_EqualPairsHIghCard()
        {
            Hand pair1 = new Hand();
            Hand pair2 = new Hand();

            pair1.AddCard(new Card(7, CardSuit.Club));
            pair1.AddCard(new Card(3, CardSuit.Diamond));
            pair1.AddCard(new Card(4, CardSuit.Heart));
            pair1.AddCard(new Card(5, CardSuit.Spade));
            pair1.AddCard(new Card(7, CardSuit.Club));

            pair2.AddCard(new Card(7, CardSuit.Club));
            pair2.AddCard(new Card(3, CardSuit.Diamond));
            pair2.AddCard(new Card(13, CardSuit.Heart));
            pair2.AddCard(new Card(2, CardSuit.Spade));
            pair2.AddCard(new Card(7, CardSuit.Club));

            Assert.IsTrue(handRanker.RankHand(pair2) > handRanker.RankHand(pair1));
        }
    }
}
