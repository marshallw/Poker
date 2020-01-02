﻿using Poker.EqualityComparers;
using Poker.Exceptions;
using Poker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker.HandEvaluators
{
    public class FullHouseEvaluator : IPokerHandEvaluator
    {
        public HandDetails GetHandValue(Hand hand)
        {
            if (!IsHandThis(hand))
                throw new HandIsNotThisTypeException("Hand is not a Full House and cannot be evaluated");

            var cards = hand.cards.GroupBy(_ => _.CardValue).OrderByDescending(_ => _.Count())
                                  .SelectMany(_ => _).Distinct(new CardValueEqualityComparer());

            return new HandDetails(hand, new HandValue(6, cards));
        }

        public bool IsHandThis(Hand hand)
        {
            return hand.cards.GroupBy(_ => _.CardValue).Any(_ => _.Count() == 2) && 
                   hand.cards.GroupBy(_ => _.CardValue).Any(_ => _.Count() == 3);
        }
    }
}
