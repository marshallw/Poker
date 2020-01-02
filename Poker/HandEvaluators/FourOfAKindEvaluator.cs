﻿using Poker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker.HandEvaluators
{
    public class FourOfAKindEvaluator : IPokerHandEvaluator
    {
        public HandDetails GetHandValue(Hand hand)
        {
            var highCard = hand.cards.OrderByDescending(_ => _.CardValue).GroupBy(_ => _.CardValue).Where(_ => _.Count() == 4).First().First();
            return new HandDetails(hand, new HandValue(7, highCard));
        }

        public bool IsHandThis(Hand hand)
        {
            return hand.cards.GroupBy(_ => _.CardValue).Where(_ => _.Count() == 4).Any();
        }
    }
}